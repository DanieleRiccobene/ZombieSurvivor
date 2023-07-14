using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //passa alla scena del gioco
    }

    public void CreditGame()
    {
        SceneManager.LoadScene("Menu/Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
