using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locker : MonoBehaviour
{
    GameObject E;
    bool canPress = false;
    GameObject lockerLocked;
    GameObject lockerUnlocked;


    // Start is called before the first frame update

    private void Awake()
    {
        E = transform.Find("E").gameObject;
        lockerLocked = GameObject.Find("GunLocker - locked");
        lockerUnlocked = GameObject.Find("GunLocker - Unlocked");

    }
    void Start()
    {
        canPress = false;
        lockerLocked.SetActive(false);
        lockerUnlocked.SetActive(false);
        E.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!canPress)
        {
            return;
        }

        if (PlayerPrefs.GetInt("PlayerHasGun") == 1)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(PlayerPrefs.GetInt("LightRoomOne") == 1 && (PlayerPrefs.GetInt("LightRoomTwo") == 1))
            {
                PlayerPrefs.SetInt("PlayerHasGun", 1);
                lockerUnlocked.SetActive(true);
                FindObjectOfType<PlayerMovement>().gun.SetActive(true);
                FindObjectOfType<PlayerMovement>().gunCanvas.SetActive(true);
                FindObjectOfType<AudioManagerCS>().Play("getSfx");

                return;
            }
            FindObjectOfType<AudioManagerCS>().Play("locked");
            lockerLocked.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("PlayerHasGun") == 1)
            {
                return;
            }

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
            lockerUnlocked.SetActive(false);
        }

    }

    public void ExitLocker()
    {
        E.SetActive(false);
        canPress = false;
        lockerLocked.SetActive(false);
        lockerUnlocked.SetActive(false);
    }
}
