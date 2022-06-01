using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public void NewGame_()
    {
        PlayerPrefs.DeleteAll();
    }

   
}
