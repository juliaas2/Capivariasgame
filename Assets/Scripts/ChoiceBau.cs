using UnityEngine;

public class ChoiceBau : MonoBehaviour
{
    // reference other monobehaviour to change public value 

    private Player_Attack player;
    public GameObject choiceCanvas;

    public void AddStrength()
    {
        // desativa canvas estando o script dentro do canvas
        choiceCanvas.SetActive(false);
    }
}
