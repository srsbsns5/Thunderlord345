using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public int waveValue;
    public int enemiesInWave;
    public GameObject HUD;

    public List<EnemyObjectPool> enemyPools = new List<EnemyObjectPool>(); //enemy pools
    public List<EnemyObjectPool> enemiesToSpawn = new List<EnemyObjectPool>();

    public Text waveText;
    public Text enemiesLeft;

    public AudioSource waveStartAudio;
    public AudioSource waveEndAudio;
    public AudioSource gameBGM;
    
    void Start()
    {
        StartCoroutine(GameStartSequence());
        EventManager.SubtractEnemyCount += WaveProgressor;
    }

    IEnumerator GameStartSequence()
    {
        yield return new WaitForSeconds(3);
        HUD.SetActive(true);
        yield return new WaitForSeconds(1);
        gameBGM.Play();
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

    private void GenerateWave()
    {
        waveText.text = "Wave " + currentWave;
        waveValue = currentWave * 10;
        GenerateEnemies();
    }
    
    private void GenerateEnemies()
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

        enemiesInWave = generatedEnemies.Count;
        enemiesLeft.text = "Enemies left: " + enemiesInWave;

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    public void WaveProgressor()
    {
        Debug.Log("Wave Progressing");

        enemiesInWave--;
        enemiesLeft.text = "Enemies left: " + enemiesInWave;

        if (enemiesInWave == 0)
        {
            currentWave++;
            StartCoroutine(BetweenWaves());
        }
        EventManager.SubtractEnemyCount -= WaveProgressor;

    }

    public IEnumerator BetweenWaves()
    {
        print("betweenwave start");

        EventManager.WaveEnded();
        waveEndAudio.Play();
        yield return new WaitForSeconds(5);
        print("betweenwave end");
        EventManager.WaveStarted();
        waveStartAudio.Play();
        GenerateWave();
    }
}
