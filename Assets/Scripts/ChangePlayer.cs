using UnityEngine;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    public AnimatorOverrideController player2;
    public AnimatorOverrideController player1;
    public GameObject player;
    public Image playerImage;
    public Sprite newPlayerSprite;
    private Sprite tempSprite;

    private void Start()
    {
        // Store the original sprite
        tempSprite = playerImage.sprite;

        // Aplicar skin ao iniciar o jogo
        if (SkinManager.Instance != null)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = SkinManager.Instance.selectedSkin;
            playerImage.sprite = SkinManager.Instance.selectedSprite;
        }
    }

    public void Skin1()
    {
        playerImage.sprite = tempSprite;
        player.GetComponent<Animator>().runtimeAnimatorController = player1;

        if (SkinManager.Instance != null)
        {
            SkinManager.Instance.selectedSkin = player1;
            SkinManager.Instance.selectedSprite = tempSprite;
        }
    }

    public void Skin2()
    {
        playerImage.sprite = newPlayerSprite;
        player.GetComponent<Animator>().runtimeAnimatorController = player2;

        if (SkinManager.Instance != null)
        {
            SkinManager.Instance.selectedSkin = player2;
            SkinManager.Instance.selectedSprite = newPlayerSprite;
        }
    }
}
