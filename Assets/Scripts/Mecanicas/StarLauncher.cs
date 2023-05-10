using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject starPrefab;
    public float spawnRadiusBoxes = 0.1f;
    public float spawnRadiusPlayers = 1f;
    void Start()
    {
        
    }

    public void LaunchStar(){
        Vector2 random;
        while (true){
            bool isColliding = false;
            random = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            Collider2D[] players = Physics2D.OverlapCircleAll(random, spawnRadiusPlayers);
            Collider2D[] boxes = Physics2D.OverlapCircleAll(random, spawnRadiusBoxes);
            foreach(Collider2D player in players){
                if(player.CompareTag("Nave1")||player.CompareTag("Nave2")){
                    isColliding = true;
                    break;
                }
            }
            if(isColliding) continue;
            foreach(Collider2D box in boxes){
                if(box.CompareTag("Square")){
                    isColliding = true;
                    break;
                }
            }
            if (!isColliding) 
                break;
        }
        Instantiate(starPrefab, random, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
