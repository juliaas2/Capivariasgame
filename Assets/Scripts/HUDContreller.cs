using UnityEngine;
using TMPro;

public class HUDContreller : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI keysText;
    public Player player;

    void Update()
    {
        lifeText.text = "X"+ player.life.ToString();
        keysText.text = "X" + player.key.ToString();
    }
}
