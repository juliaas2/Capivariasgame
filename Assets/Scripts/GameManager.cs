// GameManager ou outro objeto que persiste entre cenas
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerData playerData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Inicializa com dados padrão
            playerData = new PlayerData(3, 0, 2);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
