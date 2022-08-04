using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyObjectPool : MonoBehaviour
{
    [SerializeField] EnemyController enemyPrefab;
    [SerializeField] int spawnAmount;
    public bool collectionChecks = true;
    ObjectPool<EnemyController> enemyPool;

    void Awake()
    {
        //createFunc, actionOnGet, actionOnRelease, actionOnDestroy
        enemyPool = new ObjectPool<EnemyController>(() =>
        {   return Instantiate(enemyPrefab, transform);}, enemyInstance =>
        {   enemyInstance.gameObject.SetActive(true);}, enemyInstance =>
        {   enemyInstance.gameObject.SetActive(false);}, enemyInstance =>
        {   Destroy(enemyInstance.gameObject);},
            collectionChecks);
        
        CreateEnemy();
    }
    private void OnGUI() 
    {   
        GUI.Label(new Rect(10,10,200,30), $"Total Pool Size: {enemyPool.CountAll}");       
        GUI.Label(new Rect(10,10,200,40), $"Total Pool Size: {enemyPool.CountActive}");       
    }

    private void CreateEnemy()
    {
        for (var i = 0; i < spawnAmount; i++)
        {
            var enemyInstance = enemyPool.Get();
            enemyInstance.gameObject.SetActive(false);
            enemyInstance.Init(KillEnemy);
        }
    }

    private void KillEnemy(EnemyController enemyInstance)
    {
        enemyPool.Release(enemyInstance);
    }
}
