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
    public static event Action UpdatePlayerHealth;
    public static event Action UpdateEXP;
    public static event Action GameEnded;
    public static event Action CoinCollect;

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

    public static void ChangeHealth()
    {
        UpdatePlayerHealth?.Invoke();
    }

    public static void IncreaseEXP()
    {
        UpdateEXP?.Invoke();
    }
    public static void EndGame()
    {
        GameEnded?.Invoke();
    }
    public static void CoinCountUp()
    {
        CoinCollect?.Invoke();
    }
}
