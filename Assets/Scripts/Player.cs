using UnityEngine;


public class Player : MonoBehaviour
{   
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
        CheckFalling(); 
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
                animator.SetBool("falling", false);
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

    void CheckFalling()
    {
        // Detecta queda (está no ar e descendo)
        if (rb.linearVelocity.y < -0.1f && isJumping)
        {
            animator.SetBool("falling", true);
            animator.SetBool("jump", false);
        }
        else if (rb.linearVelocity.y >= -0.1f && isJumping)
        {
            animator.SetBool("falling", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // Layer do chão
        {
            isJumping = false;
            doubleJump = false;
            animator.SetBool("jump", false);
            animator.SetBool("falling", false);
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
        life -= damage;
        if (life <= 0)
        {
            // Lógica para o jogador morrer
            Destroy(gameObject);
        }
    }
}
