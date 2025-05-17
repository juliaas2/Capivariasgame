using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ninja"))
        {
            other.GetComponent<Ninja_Controller>().life -= 2;
        }
        
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<Boss_Controller>().life -= 2;
        }
    }
}
