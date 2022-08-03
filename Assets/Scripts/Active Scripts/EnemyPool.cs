using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    public enum PoolType
    {
       Enemy1,
       Enemy2
    } 

    public PoolType poolType;

    public bool collectionChecks = false;
    public int maxPoolSize = 50;

    [SerializeField] public EnemyController enemyPrefab;
    private ObjectPool<EnemyController> enemyPool;

    private void Awake() 
    {
        enemyPool = new 
        ObjectPool<EnemyController>(CreatePooledObject, OnTakeFromPool, OnReturnToPool, OnDestroyObject, collectionChecks, 10, maxPoolSize);
    }

    private void OnGUI() 
    {   
        GUI.Label(new Rect(10,10,200,30), $"Total Pool Size: {enemyPool.CountAll}");
        GUI.Label(new Rect(10,30,200,30), $"Active Object PoolSize: {enemyPool.CountActive}");
        
    }

    private void Update() 
    {

    }

    private EnemyController CreatePooledObject()
    {
        EnemyController instance = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        instance.gameObject.SetActive(false);
        return instance;
    }
    private void OnTakeFromPool(EnemyController Instance)
    {
        Instance.gameObject.SetActive(true);
        //SpawnEnemy(Instance);
        Instance.transform.SetParent(transform, true);
    }
    public void ReturnObjectToPool(EnemyController Instance)
    {
        enemyPool.Release(Instance);
    }

    private void OnReturnToPool(EnemyController Instance)
    {
        Instance.gameObject.SetActive(false);
    }

    private void OnDestroyObject(EnemyController Instance)
    {
        Destroy(Instance.gameObject);
    }

    private void SpawnEnemy(EnemyController Instance)
    {
        Vector3 spawnLocation = transform.position + Random.insideUnitSphere * 10;

        Instance.transform.position = spawnLocation;
    }
}
