using UnityEngine;

public class Boss_Range : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           GetComponentInParent<Animator>().Play("boss_attack", -1);
        }
    }
}
