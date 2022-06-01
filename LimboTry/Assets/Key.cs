using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


        if(PlayerPrefs.GetInt("PlayerHasKey") == 1)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            rb.isKinematic = false;

        }

        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManagerCS>().Play("getSfx");
            PlayerPrefs.SetInt("PlayerHasKey", 1);
            FindObjectOfType<Canvasitem>().orangeKey.SetActive(true);
            Destroy(gameObject);
        }
    }

}
