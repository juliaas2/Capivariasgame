using UnityEngine;

public class Bau : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>().key > 0)
            {
                collision.GetComponent<Player>().key -= 1;
                GetComponent<Animator>().SetTrigger("Open");
            }
        }
    }
}
