using UnityEngine;

public class Ninja_Range : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Debug.Break();
            GetComponent<Animator>().Play("Ninja_attack", -1);
        }
    }
}
