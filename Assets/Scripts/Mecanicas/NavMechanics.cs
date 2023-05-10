using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMechanics : MonoBehaviour
{

    GameObject manager;
    ControllerMechanics mechanics;

    public void restar(){
        mechanics.decrementaPunto(gameObject);
    }
    public void sumar(){
        mechanics.incrementaPunto(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    manager = GameObject.FindGameObjectWithTag("GameManager");
    mechanics = manager.GetComponent<ControllerMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
