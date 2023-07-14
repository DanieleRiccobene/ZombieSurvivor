using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public bool menuOpen = false;
    private ThirdPersonController player;
    //private bool controlsChanged = false;
    [SerializeField] public Canvas canvas;

    private void Update()
    {
        // Apri il menu quando viene premuto il tasto Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpen)
            {
                // Chiudi il menu
                Time.timeScale = 1f; // Ripristina la velocità del gioco
                Cursor.lockState = CursorLockMode.Locked; // Blocca il cursore al centro dello schermo
                Cursor.visible = false; // Nascondi il cursore
                menuOpen = false;
            }
            else
            {
                // Apri il menu
                Time.timeScale = 0f; // Metti in pausa il gioco
                Cursor.lockState = CursorLockMode.None; // Sblocca il cursore
                Cursor.visible = true; // Mostra il cursore
                menuOpen = true;
            }
        }
    }

    private void OnGUI()
    {
        if (menuOpen)
        {
            // Mostra il menu e le opzioni
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public void OnExit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
