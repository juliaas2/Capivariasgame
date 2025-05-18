using UnityEngine;
using UnityEngine.SceneManagement;

public class jogar_redirecionar : MonoBehaviour
{
    public string level1;
    public void IniciaJogo()
    {
        // Carrega a cena "Jogo"
        SceneManager.LoadScene(level1);
    }
}
