using UnityEngine;
using System.Collections;

public class Bau : MonoBehaviour
{
    public GameObject choiceCanvas;
    public float audioCutTime = 3f; // Tempo em segundos que o áudio deve tocar
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>().key > 0)
            {
                collision.GetComponent<Player>().key -= 1;
                animator.SetTrigger("Open");
                StartCoroutine(WaitForAnimationAndAudio());
            }
        }
    }

    private IEnumerator WaitForAnimationAndAudio()
    {
        // Espera a animação terminar (qualquer animação que seja trigger "Open")
        yield return new WaitUntil(() => 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f 
            && !animator.IsInTransition(0));

        // Toca o áudio e espera ele terminar ou ser cortado
        audioSource.Play();
        yield return new WaitForSecondsRealtime(audioCutTime);
        audioSource.Stop();

        // Agora, ativa o canvas de escolha e pausa o jogo
        choiceCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
