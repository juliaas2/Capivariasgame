using UnityEngine;
using System.Collections;

public class Boss_Controller : MonoBehaviour
{
    private CapsuleCollider2D colliderboss;
    private Animator animator;
    private string side;
    public float speed;
    public int life;
    public Transform player;

    public GameObject range;

    void Start()
    {
        colliderboss = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

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
            colliderboss.enabled = false;

            if (range != null)
                range.SetActive(false);
    
            animator.Play("boss_die");
            StartCoroutine(RemoveNinja());
            return;
        }

        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
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
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
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

    private IEnumerator RemoveNinja()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
