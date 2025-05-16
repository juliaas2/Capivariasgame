using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance { get; private set; }
    public AnimatorOverrideController selectedSkin;
    public Sprite selectedSprite;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Não destruir ao mudar de cena
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
