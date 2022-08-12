using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource[] bgm;
    bool startHasPlayed;
    private void Awake() 
    {
        bgm[0].Play();
        startHasPlayed = false;
    }
    
    private void Update() 
    {
        while (bgm[0].isPlaying)
        {
            startHasPlayed = false;
            if(!bgm[0].isPlaying)
            {
                startHasPlayed = true;
                break;
            }
        }
    }
}
