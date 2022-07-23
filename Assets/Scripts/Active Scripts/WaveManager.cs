using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public int waveValue;
    public List<EnemyController> enemies = new List<EnemyController>();
    public List<UnityEngine.GameObject> enemiesToSpawn = new List<UnityEngine.GameObject>(); //prefabs
    
    void Start()
    {
        GenerateWave();
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        //object pooling;
    }
    public void GenerateEnemies()
    {
        List<UnityEngine.GameObject> generatedEnemies = new List<UnityEngine.GameObject>();
        while (waveValue > 0)
        {
            int randEnemyID = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyID].spawnCost;

            if (waveValue-randEnemyCost>=0)
            {
                generatedEnemies.Add(enemies[randEnemyID].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

}
