using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    [SerializeField] GameObject brokenPrefab;
   
    bool broken = false;
    public void Break()
    {
        if (broken)
        {
            return;
        }
        broken = true;
        Instantiate(brokenPrefab, transform.position, transform.rotation);
        FindObjectOfType<AudioManagerCS>().Play("VaseBreaking");
        
        Destroy(gameObject);
    }
}
