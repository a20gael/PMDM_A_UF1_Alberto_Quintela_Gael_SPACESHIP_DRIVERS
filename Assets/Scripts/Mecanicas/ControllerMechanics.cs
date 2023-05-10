using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControllerMechanics : MonoBehaviour
{
    public int scoreNav1;
    public int scoreNav2;
    void Start()
    {
     scoreNav2 = 0;
     scoreNav1 = 0;
    }


    public void incrementaPunto(GameObject nav){
        string tagNave = nav.tag;
        switch(tagNave){
            case("Nave1"):
                scoreNav1++;
                if (scoreNav1 >= 10){
                    SceneManager.LoadScene("RedShipWINS");
                }
                break;
            case("Nave2"):
                scoreNav2++;
                if (scoreNav2 >= 10){
                    SceneManager.LoadScene("GreenShipWINS");
                }
                break;
        }
    }

    public void decrementaPunto(GameObject nav){
        string tagNave = nav.tag;
        switch(tagNave){
            case("Nave1"):
                if(scoreNav1 <= 0){

                }
                else{
                    scoreNav1--;
                }
                break;
            case("Nave2"):
                if(scoreNav2 <= 0){

                }
                else{
                    scoreNav2--;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
