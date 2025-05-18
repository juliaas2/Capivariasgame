
// PlayerSkinHandler.cs
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinHandler : MonoBehaviour
{
    public Animator playerAnimator;
    public Image playerImage; // Para UI, se necessário
    
    private void Start()
    {
        // Quando o jogador é instanciado, aplica a skin atual
        UpdatePlayerSkin();
    }
    
    public void UpdatePlayerSkin()
    {
        if (SkinManager.Instance != null)
        {
            // Aplica o controlador de animação
            if (playerAnimator != null && SkinManager.Instance.selectedSkinController != null)
            {
                playerAnimator.runtimeAnimatorController = SkinManager.Instance.selectedSkinController;
            }
            
            // Aplica o sprite, se necessário
            if (playerImage != null && SkinManager.Instance.selectedSkinSprite != null)
            {
                playerImage.sprite = SkinManager.Instance.selectedSkinSprite;
            }
        }
    }
}