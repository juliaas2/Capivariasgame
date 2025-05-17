using UnityEngine;

public class ChoiceBau : MonoBehaviour
{
    // reference other monobehaviour to change public value 

    public Player_Attack playerAttack;
    public GameObject choiceCanvas;
    public Player player;

    public void AddStrength()
    {
        // desativa canvas estando o script dentro do canvas
        playerAttack.attack += 1;
        choiceCanvas.SetActive(false);
        // volta o tempo normal
        Time.timeScale = 1f;
    }

    public void AddLife()
    {
        // desativa canvas estando o script dentro do canvas
        player.life += 1;

        choiceCanvas.SetActive(false);
        // volta o tempo normal
        Time.timeScale = 1f;

    }
}

