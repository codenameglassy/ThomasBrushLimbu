using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    PlayerMovement playerMovement;
    CharacterController2D controller;
    //Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        controller = FindObjectOfType<CharacterController2D>();
       // Invoke("FindPlayer", 1f);
       
    }

 
    void FindPlayer()
    {
      //  playerPosition = GameObject.Find("Avatar").transform;
    }
    // Update is called once per frame
    void Update()
    {


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        playerMovement.effectorTarget.transform.position = mousePos;
        
    }
}
