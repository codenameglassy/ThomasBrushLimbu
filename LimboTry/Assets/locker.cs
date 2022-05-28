using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locker : MonoBehaviour
{
    GameObject E;



    // Start is called before the first frame update
    void Start()
    {
        E = transform.Find("E").gameObject;

        E.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.SetActive(false);
        }

    }
}
