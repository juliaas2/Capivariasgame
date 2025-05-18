using UnityEngine;
using TMPro;

public class HUDContreller : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI keysText;
    public Player player;

    void OnEnable()
    {
        UpdateHUD();
    }

    void Update()
    {
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        lifeText.text = "X" + Mathf.Max(player.life, 0).ToString();
        keysText.text = "X" + player.key.ToString();
    }
}
