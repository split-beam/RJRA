using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers>1)
        {
            Destroy(gameObject); //Destroy Instance
        }
        else
        {
            DontDestroyOnLoad(gameObject); //gameObject == Self
        }
    }
}
