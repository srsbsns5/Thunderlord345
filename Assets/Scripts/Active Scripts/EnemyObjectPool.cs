using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyObjectPool : MonoBehaviour
{
    public EnemyController enemy;
    public int spawnCost;
    [SerializeField] int initialSpawnAmount;
    public bool collectionChecks = true;
    public ObjectPool<EnemyController> enemyPool;

    void Awake()
    {
        //createFunc, actionOnGet, actionOnRelease, actionOnDestroy
        enemyPool = new ObjectPool<EnemyController>(() =>
        {   return Instantiate(enemy, transform);}, enemyInstance =>
        {   enemyInstance.gameObject.SetActive(true);}, enemyInstance =>
        {   enemyInstance.gameObject.SetActive(false);}, enemyInstance =>
        {   Destroy(enemyInstance.gameObject);},
            collectionChecks);
        
        for (int i = 0; i < initialSpawnAmount; i++)    InitialEnemySpawn();    
    }

    private void InitialEnemySpawn()
    {
        var enemyInstance = enemyPool.Get();
        enemyInstance.Init(KillEnemy);
        enemyInstance.StartCoroutine("ReturnToPool", 0);
    }

    private void KillEnemy(EnemyController enemyInstance)
    {
        enemyInstance.StopAllCoroutines();
        enemyPool.Release(enemyInstance);
    }
}
