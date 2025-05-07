using UnityEngine;

public class NInja_Attack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            other.GetComponent<Player>().life -= 1;

        }
    }
}
