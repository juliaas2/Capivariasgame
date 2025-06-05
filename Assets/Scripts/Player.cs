using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameOverCanvas;
    public GameObject mobileControls;

    [Header("Áudio")]
    private AudioSource audioSource;
    public AudioClip keySound;
    public AudioClip attackSound;

    [Header("Movimentação")]
    public float Speed;
    private Rigidbody2D rb;
    public float JumpForce;
    private Animator animator;
    private BoxCollider2D colliderPlayer;

    [Header("Estado do pulo")]
    public bool isJumping;
    public bool doubleJump;

    [Header("Ataque")]
    public CircleCollider2D attackCollider;

    [Header("Coleta e Vida")]
    public int key = 0;
    public int life = 8;

    [Header("Controle Mobile")]
    public bool moveLeft;
    public bool moveRight;
    public bool jumpPressed;
    public bool attackPressed;

    public MusicPlayer musicPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colliderPlayer = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        var data = GameManager.instance.playerData;
        life = data.life;
        key = data.keys;
    }

    private void OnDisable()
    {
        var data = GameManager.instance.playerData;
        data.life = life;
        data.keys = key;
    }

    void Update()
    {
        Move();
        Jump();
        Hit();
    }

    void Move()
    {
        float horizontal = 0f;

        if (moveLeft) horizontal = -1f;
        if (moveRight) horizontal = 1f;

        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (horizontal > 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (horizontal < 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (jumpPressed)
        {
            jumpPressed = false;

            if (!isJumping)
            {
                rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                isJumping = true;
                animator.SetBool("jump", true);
            }
            else if (!doubleJump)
            {
                rb.AddForce(new Vector2(0f, JumpForce / 2f), ForceMode2D.Impulse);
                doubleJump = true;
            }
        }
    }

    void Hit()
    {
        if (attackPressed)
        {
            attackPressed = false;
            animator.SetTrigger("hit");
            audioSource.PlayOneShot(attackSound);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            doubleJump = false;
            animator.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            key++;
            Destroy(other.gameObject, 0.25f);
            other.GetComponent<AudioSource>().Play();
        }
    }

    public void DisableAttackCollider()
    {
        attackCollider.enabled = false;
    }

    public void AbleAttackCollider()
    {
        Debug.Log("Ativando o collider de ataque");
        attackCollider.enabled = true;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player took damage: " + damage);
        life -= damage;
        if (life <= 0)
        {
            this.enabled = false;
            colliderPlayer.enabled = false;
            rb.gravityScale = 0f;
            animator.Play("Player_die", -1);
            musicPlayer.StopMusic();
            if (mobileControls != null)
                mobileControls.SetActive(false);
            if (gameOverCanvas != null)
                gameOverCanvas.SetActive(true);

            // ❗ Importante: NÃO destruir o jogador
            gameObject.SetActive(false);
        }
    }

    // ==== REVIVER ====

    // Método para botão de reviver
    public void ReviveFromButton()
    {
        Vector3 defaultSpawnPosition = new Vector3(0f, 0f, 0f); // Altere para a posição desejada
        gameObject.SetActive(true); // Reativa o jogador
        Revive(defaultSpawnPosition);
    }

    // Lógica de ressuscitar
    public void Revive(Vector3 spawnPosition)
    {
        Debug.Log("Reviving player...");

        transform.position = spawnPosition;
        life = 2;

        this.enabled = true;
        colliderPlayer.enabled = true;
        rb.gravityScale = 5f;

        animator.Play("Player_idle", -1);
        animator.SetBool("jump", false);
        animator.SetBool("walk", false);

        if (mobileControls != null)
            mobileControls.SetActive(true);
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);

    }

    // ==== CONTROLES MOBILE ====
    public void OnLeftDown() => moveLeft = true;
    public void OnLeftUp() => moveLeft = false;

    public void OnRightDown() => moveRight = true;
    public void OnRightUp() => moveRight = false;

    public void OnJumpButton() => jumpPressed = true;
    public void OnAttackButton() => attackPressed = true;
}
