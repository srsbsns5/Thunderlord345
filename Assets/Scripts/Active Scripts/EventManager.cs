using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public static event Action StartEnded;
    public static event Action TakeItem;
    public static event Action SubtractEnemyCount;

    public static void PlayLoop()
    {
        StartEnded?.Invoke();
    }
    public static void NewItemEquip()
    {
        TakeItem?.Invoke();
    }
    public static void EnemyKilledInWave()
    {
        SubtractEnemyCount?.Invoke();
    }
}
