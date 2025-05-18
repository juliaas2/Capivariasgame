using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
     public int damage = 2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            other.GetComponent<Player>().TakeDamage(damage);

        }
    }
}
