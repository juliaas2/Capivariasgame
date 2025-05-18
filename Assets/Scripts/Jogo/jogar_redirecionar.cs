using UnityEngine;
using UnityEngine.SceneManagement;

public class jogar_redirecionar : MonoBehaviour
{
    public void IniciaJogo()
    {
        var data = GameManager.instance.playerData;
        data.attack = 2; // Define o ataque inicial
        data.life = 3; // Define a vida inicial
        data.keys = 0; // Define as moedas iniciais
        // Carrega a cena "Jogo"
        SceneManager.LoadScene(1);
    }
}
