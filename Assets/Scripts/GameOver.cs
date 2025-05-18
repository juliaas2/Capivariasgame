using UnityEngine;
using System.Collections.Generic;
public class GameOver : MonoBehaviour
{
   public void Menu()
   {
       // Carrega a cena do menu
       Debug.Log("Menu");
       UnityEngine.SceneManagement.SceneManager.LoadScene(1);
   }


}
