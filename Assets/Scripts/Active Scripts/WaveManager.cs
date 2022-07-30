using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public int waveValue;
    public GameObject target;
    public List<EnemyController> enemies = new List<EnemyController>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>(); //prefabs

    public Text waveText;
    
    void Start()
    {
        GenerateWave();

        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() 
    {
        waveText.text = "Wave " + currentWave;
       
        /*if (enemiesToSpawn.Count >= 0)
        {
            Instantiate(enemiesToSpawn[0], target.transform.position, Quaternion.identity);
            enemiesToSpawn.RemoveAt(0);
        }*/
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;        
        //GenerateEnemies();
        //object pooling;
    }
    /*
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
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

    }*/
}
