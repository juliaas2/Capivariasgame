using UnityEngine;
using System.Collections; // Necessário para usar IEnumerator

public class Boss_Controller : MonoBehaviour
{
    private CapsuleCollider2D colliderBoss;
    private Animator animator;
    private string side;
    public float speed;
    public int life;
    public Transform player;

    void Start()
    {
        colliderBoss = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

        // Se não foi atribuído manualmente, tenta encontrar o jogador pela tag
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Jogador não encontrado! Atribua o Transform do jogador ao campo 'player' no Inspector ou defina a tag 'Player'.");
            }
        }
    }

    void Update()
    {
        if (life <= 0)
        {
            this.enabled = false;
            colliderBoss.enabled = false;
            animator.Play("boss_die", -1); // Certifique-se de que essa animação existe
            StartCoroutine(RemoveBoss());
            return;
        }

        if (player == null) return;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("boss_attack"))
        {
            return;
        }

        float sideSign = Mathf.Sign(player.position.x - transform.position.x);

        if (Mathf.Abs(sideSign) > 0.1f)
        {
            side = sideSign == 1.0f ? "right" : "left";
        }

        switch (side)
        {
            case "right":
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                break;
            case "left":
                transform.eulerAngles = new Vector3(0f, 0f , 0f);
                break;
        }

        if (Vector2.Distance(transform.position, player.position) > 0.5f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(player.position.x, transform.position.y),
                speed * Time.deltaTime
            );
        }
    }

    private IEnumerator RemoveBoss()
    {
        yield return new WaitForSeconds(1f); // tempo para a animação de morte acontecer
        Destroy(gameObject);
    }
}
