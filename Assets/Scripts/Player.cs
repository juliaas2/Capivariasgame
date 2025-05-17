using UnityEngine;


public class Player : MonoBehaviour
{   
    public GameObject gameOverCanvas;
    private AudioSource audioSource;
    public AudioClip keySound;
    public float Speed;
    private Rigidbody2D rb;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    public int key = 0;

    public int life = 8;

    private Animator animator;

    private BoxCollider2D colliderPlayer;


    public CircleCollider2D attackCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colliderPlayer = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        Jump();
        Hit();
        if(life <= 0)
        {
            this.enabled = false;
            colliderPlayer.enabled = false;
            rb.gravityScale = 0f;
            animator.Play("Player_die", -1);
        }
        
    }

    void Move()
    {  
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f , 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0f)
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                isJumping = true;
                animator.SetBool("jump", true);
            }
            else
            {
                if (!doubleJump) 
                {
                    rb.AddForce(new Vector2(0f, JumpForce / 2f), ForceMode2D.Impulse);
                    doubleJump = true;
                }
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // Layer do chão
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

    void Hit()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("hit");
        }
    
    }

    public void DisableAttackCollider()
    {
        attackCollider.enabled = false;
    }

    public void AbleAttackCollider()
    {
        attackCollider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("Key"))
        {
            key++;
            Destroy(other.gameObject, 0.5f); // Adicione um pequeno atraso para o som tocar antes de destruir
            other.GetComponent<AudioSource>().Play();
        }
    }


    public void TakeDamage(int damage)
    {
        Debug.Log("Player tomou dano: " + damage);
        life -= damage;
        if (life <= 0)
        {
            Debug.Log("Player morreu");
            gameOverCanvas.SetActive(true);
            Destroy(gameObject);
            // Lógica para o jogador morrer
        }
    }
}
