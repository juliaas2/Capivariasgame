using UnityEngine;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    public Image playerImage; // Reference to the Image component
    public Sprite newPlayerSprite; // New sprite to change to
    private Sprite tempSprite; // Temporary sprite to store the original sprite

    public void ChangeImage()
    {
        tempSprite = playerImage.sprite; // Store the original sprite
        playerImage.sprite = newPlayerSprite; // Change the sprite of the Image component
        newPlayerSprite = tempSprite; // Set the new sprite to the original sprite
    }
}
