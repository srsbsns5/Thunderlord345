using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public int waveValue;
    public List<EnemyObjectPool> enemyPools = new List<EnemyObjectPool>(); //enemy pools
    public List<EnemyObjectPool> enemiesToSpawn = new List<EnemyObjectPool>();

    public Text waveText;
    
    void Start()
    {
        GenerateWave();
    }

    private void Update() 
    {
        if (enemiesToSpawn.Count > 0)
        {
            enemiesToSpawn[0].enemyPool.Get();
            enemiesToSpawn.RemoveAt(0);
        }
    }

    public void GenerateWave()
    {
        waveText.text = "Wave " + currentWave;
        waveValue = currentWave * 10;        
        GenerateEnemies();
    }
    
    public void GenerateEnemies()
    {
        List<EnemyObjectPool> generatedEnemies = new List<EnemyObjectPool>();
        while (waveValue > 0)
        {
            int randEnemyID = Random.Range(0, enemyPools.Count);
            int randEnemyCost = enemyPools[randEnemyID].spawnCost;

            if (waveValue-randEnemyCost>=0)
            {
                generatedEnemies.Add(enemyPools[randEnemyID]);
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
