using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject pressStartText;
    public float blinkInterval = 0.5f;

    private bool isBlinking = false;

    private void Start()
    {
        // Iniciamos la rutina para hacer que el texto parpadee
        StartCoroutine(BlinkText());
    }

    private void Update()
    {
        // Si se pulsa la tecla Space, cargamos la siguiente escena
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            // Activamos y desactivamos el objeto del texto cada cierto tiempo
            pressStartText.SetActive(!pressStartText.activeSelf);

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}