using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicDestroy : MonoBehaviour
{
    static MusicDestroy musicDestroy = null;
    
    private void Awake()
    {
        if (musicDestroy == null)
        {
            musicDestroy = this;
            DontDestroyOnLoad(this);
        }
        else if (this != musicDestroy)
        {
            Destroy(gameObject);
        }
    }


}
