using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public static event Action StartEnded;

    public static void PlayLoop()
    {
        StartEnded?.Invoke();
    }
}
