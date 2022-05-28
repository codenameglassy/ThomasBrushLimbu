using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRoomOne : MonoBehaviour
{
    bool canPress;
    bool pressed;
    GameObject offLight;
    GameObject onLight;
    GameObject E;

    private void Start()
    {
        offLight = transform.Find("OffLight").gameObject;
        onLight = transform.Find("GreenLight").gameObject;
        E = transform.Find("E").gameObject;
        
        E.SetActive(false);
        if(PlayerPrefs.GetInt("LightRoomOne") == 0)
        {
            onLight.SetActive(false);
            offLight.SetActive(true);
            pressed = false;
        }
        else if(PlayerPrefs.GetInt("LightRoomOne") == 1)
        {
            onLight.SetActive(true);
            offLight.SetActive(false);
            pressed = true;
        }
       
    }
    private void Update()
    {
        if(canPress == false)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            pressed = true;
            PlayerPrefs.SetInt("LightRoomOne", 1);
            onLight.SetActive(true);
            offLight.SetActive(false);
            E.SetActive(false);
            Debug.Log("Player Pressed Button");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pressed)
        {
            return;
        }
        canPress = true;

        E.SetActive(true);
    }

  

    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
        E.SetActive(false);
    }
}
