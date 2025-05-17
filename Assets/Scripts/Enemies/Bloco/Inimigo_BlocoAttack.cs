using UnityEngine;

public class Inimigo_BlocoAttack : MonoBehaviour
{
    public int damage = 1000;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
