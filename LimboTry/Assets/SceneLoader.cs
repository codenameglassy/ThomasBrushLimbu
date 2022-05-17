using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    SceneManager_ sceneManager;
    [SerializeField] string sceneToLoad;
    [SerializeField] int nextSpawnPosition;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager_>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sceneManager.LoadScene(sceneToLoad);

            PlayerPrefs.SetInt("SpawnPosition", nextSpawnPosition);
        }
    }
}
