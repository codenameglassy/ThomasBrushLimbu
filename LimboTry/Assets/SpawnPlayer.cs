using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    Transform spawnPoint1, spawnPoint2;

    private void Awake()
    {
        spawnPoint1 = GameObject.Find("spawnPoint1").transform;
        spawnPoint2 = GameObject.Find("spawnPoint2").transform;
    }

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("SpawnPosition") == 2)
        {
            Instantiate(playerPrefab, spawnPoint2.position, Quaternion.identity);
            return;
        }


        Instantiate(playerPrefab, spawnPoint1.position, Quaternion.identity);
    }
}
