using UnityEngine;

public class GerenciadorAnuncio : MonoBehaviour
{
    public GameObject telaAnuncio;

    // Método chamado ao clicar no botão
    public void MostrarAnuncio()
    {
        telaAnuncio.SetActive(true);
    }

    public void FecharAnuncio()
    {
        telaAnuncio.SetActive(false);
    }
}
