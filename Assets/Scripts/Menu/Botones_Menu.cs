using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botones_Menu : MonoBehaviour
{
    public void Jugar(string Juego)
    {
        SceneManager.LoadScene(Juego);
    }

   public void Salir()
    {
        Application.Quit();
    }
}
