using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioSource backgroundMusic;
    private bool isPlaying = true;
    public Image musicButtonImage;

    void Awake()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (backgroundMusic != null)
            backgroundMusic.Play();
        else
            Debug.LogWarning("No AudioSource found on AudioManager GameObject.");
    }

    public void ToggleMusic()
    {
        //  change the color of the button
        if (musicButtonImage != null)
        {
            Color newColor = isPlaying ? Color.red : Color.white;
            musicButtonImage.color = newColor;
        }
        else
        {
            Debug.LogWarning("No Image component found on the music button.");
        }
        if (backgroundMusic == null) return;

        if (isPlaying)
        {
            backgroundMusic.Pause();
        }
        else
        {
            backgroundMusic.Play();
        }

        isPlaying = !isPlaying;
    }
}
