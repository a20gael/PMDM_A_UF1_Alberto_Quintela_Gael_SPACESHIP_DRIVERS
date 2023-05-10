using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class Player1Score : MonoBehaviour    // Start is called before the first frame update
{
    GameObject manager;
    ControllerMechanics mechanics;
    private Text scoreText;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager");
        mechanics = manager.GetComponent<ControllerMechanics>();
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = mechanics.scoreNav1.ToString();
    }
}