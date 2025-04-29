using UnityEngine;
using UnityEngine.SceneManagement;

public class jogar_redirecionar : MonoBehaviour
{
    public void IniciaJogo()
    {
        // Carrega a cena "Jogo"
        SceneManager.LoadScene(0);
    }
}
