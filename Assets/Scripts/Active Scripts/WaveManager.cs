using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    public int waveValue;
    public List<EnemyController> enemies = new List<EnemyController>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        //object pooling;
    }

}
