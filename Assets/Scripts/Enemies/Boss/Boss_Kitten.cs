using UnityEngine;

public class Boss_Kitten : MonoBehaviour
{
    public Transform boss;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && boss != null)
        {
            var bossController = boss.GetComponent<Boss_Controller>();
            if (bossController != null)
            {
                bossController.enabled = true;
                boss.GetComponent<Animator>().SetBool("is_run", true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && boss != null)
        {
            var bossController = boss.GetComponent<Boss_Controller>();
            if (bossController != null)
            {
                bossController.enabled = false;
                boss.GetComponent<Animator>().SetBool("is_run", true);
            }
        }
    }
}
