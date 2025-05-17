using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public int attack;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ninja"))
        {
            other.GetComponent<Ninja_Controller>().life -= attack;
        }
        
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<Boss_Controller>().life -= 2;
        }
    }
}
