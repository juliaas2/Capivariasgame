using UnityEngine;

public class NInja_Attack : MonoBehaviour
{
    public int damage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
