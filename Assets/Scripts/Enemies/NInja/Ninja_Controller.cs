using UnityEngine;

public class Ninja_Controller : MonoBehaviour
{   
    private CapsuleCollider2D colliderNinja;
    private Animator anim;
    private bool goRight;

    public int life;
    public float speed;

    public Transform a;
    public Transform b;
    public GameObject range;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    colliderNinja = GetComponent<CapsuleCollider2D>();
    anim = GetComponent<Animator>();
    
    if (range == null)
        range = transform.Find("Range")?.gameObject;

    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    if (rb != null)
        rb.gravityScale = 0;
}


    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            this.enabled = false;
            colliderNinja.enabled = false;
            range.SetActive(false);
            anim.Play("NInja_Dying", -1);
            return;
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Ninja_attack"))
        {
            return;
        }
        
        if(goRight == true)
        {
            if(Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;
            }

            transform.eulerAngles = new Vector3(0f, 0f , 0f);
            transform.position = Vector2.MoveTowards(transform.position, b.position, speed * Time.deltaTime);
        }

        else
        {
            if(Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;
            }

            transform.eulerAngles = new Vector3(0f, 180f , 0f);
            transform.position = Vector2.MoveTowards(transform.position, a.position, speed * Time.deltaTime);
        }
    }
}
