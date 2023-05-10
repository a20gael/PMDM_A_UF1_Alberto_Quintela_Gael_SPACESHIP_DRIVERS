using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSound : MonoBehaviour
{
    private AudioSource starSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        starSound = GetComponent<AudioSource>();
    }

private void OnTriggerEnter2D(Collider2D other){
        //starSound.enabled = true;
        Debug.Log("Colision");
        starSound.Play();
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
