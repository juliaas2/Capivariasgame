using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioClip gameOverSound;
    private AudioSource audioSource;
    private bool gameOverTriggered = false;

    void Start()
    {
        if (gameOverTriggered) return;
        gameOverTriggered = true;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        StopAllOtherSounds();

        if (gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }

    void StopAllOtherSounds()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in sources)
        {
            if (source != audioSource)
            {
                source.loop = false;          
                source.Stop();                
            }
        }
    }

    public void Menu()
    {
        StartCoroutine(GoToMenuAfterSound());
    }

    private System.Collections.IEnumerator GoToMenuAfterSound()
    {
        if (gameOverSound != null)
        {
            yield return new WaitForSeconds(gameOverSound.length);
        }

        SceneManager.LoadScene(1);
    }
}