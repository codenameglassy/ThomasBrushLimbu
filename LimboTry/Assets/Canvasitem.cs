using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasitem : MonoBehaviour
{
    [HideInInspector] public GameObject orangeKey;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        orangeKey = transform.Find("orangeKey").gameObject;

    }


    private void Start()
    {
        if(PlayerPrefs.GetInt("PlayerHasKey") == 1)
        {
            orangeKey.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("PlayerHasKey") == 0)
        {
            orangeKey.SetActive(false);

        }
    }
}
