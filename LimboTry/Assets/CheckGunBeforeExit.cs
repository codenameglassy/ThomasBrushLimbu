using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGunBeforeExit : MonoBehaviour
{

    private void Awake()
    {
        if(PlayerPrefs.GetInt("PlayerHasGun") == 1)
        {
            Debug.Log("Player Has Gun " + gameObject.name + " destroyed");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }
}
