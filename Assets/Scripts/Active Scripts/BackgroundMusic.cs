using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource[] bgm;
    private void Awake() 
    {
        bgm[0].Play();
        EventManager.StartEnded += RunLoopBGM;
    }
    
    private void Update() 
    {
        if (!bgm[0].isPlaying) EventManager.PlayLoop();
    }

    void RunLoopBGM()
    {
        bgm[1].Play();
        EventManager.StartEnded -= RunLoopBGM;
    }
}
