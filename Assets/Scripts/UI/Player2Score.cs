using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour
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
        scoreText.text = mechanics.scoreNav2.ToString();
    }
}
