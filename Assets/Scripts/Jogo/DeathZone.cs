using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public int damage = 100;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
