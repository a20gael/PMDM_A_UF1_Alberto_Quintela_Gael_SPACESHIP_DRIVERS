using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] public GameObject menuPausa;
    private bool juegoEnPausa = false;

    void Start()
    {
        menuPausa.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !juegoEnPausa)
        {
            juegoEnPausa = true;
            menuPausa.SetActive(true);
            Time.timeScale = 0f; // pausa el juego
            // oscurecer elementos que no sean el menú de pausa
        }
        else if (Input.GetKeyDown(KeyCode.P) && juegoEnPausa)
        {
            juegoEnPausa = false;
            menuPausa.SetActive(false);
            Time.timeScale = 1f; // reanudar el juego
            // restaurar la opacidad de los elementos
        }

        if (juegoEnPausa)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f; // reanudar el juego
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }
}
