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
    public static event Action AllowPreWaveActions;
    public static event Action EndPreWaveActions;

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

    public static void WaveEnded()
    {
        AllowPreWaveActions?.Invoke();
    }
    public static void WaveStarted()
    {
        EndPreWaveActions?.Invoke();
    }
}
