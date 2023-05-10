using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyListener : MonoBehaviour
{
    // Nombre de la escena que se cargará al pulsar Espacio
    public string sceneName = "SampleScene";

    void Update()
    {
        // Si se pulsa la tecla Espacio, cargar la escena de nuevo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }

        // Si se pulsa la tecla q, salir del juego
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}