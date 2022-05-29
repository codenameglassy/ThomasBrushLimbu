using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locker : MonoBehaviour
{
    GameObject E;
    bool canPress = false;
    GameObject lockerLocked;

    // Start is called before the first frame update

    private void Awake()
    {
        E = transform.Find("E").gameObject;
        lockerLocked = GameObject.Find("GunLocker - locked");

    }
    void Start()
    {

        lockerLocked.SetActive(false);
        E.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canPress)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            lockerLocked.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.SetActive(true);
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.SetActive(false);
            canPress = false;
            lockerLocked.SetActive(false);
        }

    }

    public void ExitLocker()
    {
        E.SetActive(false);
        canPress = false;
        lockerLocked.SetActive(false);
    }
}
