using UnityEngine;

public class Boss_Kitten : MonoBehaviour
{
    public Transform boss;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && boss != null)
        {
            var controller = boss.GetComponent<Boss_Controller>();
            var animator = boss.GetComponent<Animator>();

            if (controller != null) controller.enabled = true;
            if (animator != null) animator.SetBool("is_run", true); // começa a correr
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && boss != null)
        {
            var controller = boss.GetComponent<Boss_Controller>();
            var animator = boss.GetComponent<Animator>();

            if (controller != null) controller.enabled = false;
            if (animator != null) animator.SetBool("is_run", false); // para de correr
        }
    }
}
