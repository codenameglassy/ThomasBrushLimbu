using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(PlayerPrefs.GetInt("ThemePlaying") == 1)
            {
                return;
            }

            PlayerPrefs.SetInt("ThemePlaying", 1);
            PlayMusic();
            //Invoke("PlayMusic", 2f);
        }
    }

    void PlayMusic()
    {
        FindObjectOfType<AudioManagerCS>().Play("Theme");
    }
}
