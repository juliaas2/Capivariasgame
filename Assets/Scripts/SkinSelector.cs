// SkinSelector.cs - Simplificado apenas para imagens no menu
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    // Referência apenas para a imagem de visualização no menu
    public Image previewImage;
    
    private void Start()
    {
        // Verifica se estamos no menu e aplica a skin padrão na visualização
        if (previewImage != null && SkinManager.Instance != null)
        {
            previewImage.sprite = SkinManager.Instance.defaultSkinSprite;
        }
    }
    
    // Método para selecionar a skin padrão
    public void SelectDefaultSkin()
    {
        if (SkinManager.Instance != null)
        {
            // Atualiza o gerenciador de skins
            SkinManager.Instance.ChangeSkin(0);
            
            // Atualiza a imagem de visualização no menu
            if (previewImage != null)
            {
                previewImage.sprite = SkinManager.Instance.defaultSkinSprite;
            }
        }
    }
    
    // Método para selecionar a skin alternativa
    public void SelectAlternativeSkin()
    {
        if (SkinManager.Instance != null)
        {
            // Atualiza o gerenciador de skins
            SkinManager.Instance.ChangeSkin(1);
            
            // Atualiza a imagem de visualização no menu
            if (previewImage != null)
            {
                previewImage.sprite = SkinManager.Instance.alternativeSkinSprite;
            }
        }
    }
}