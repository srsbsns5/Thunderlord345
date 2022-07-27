using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    public enum PoolType
    {
       Goblin,
       Orc
    } 

    public PoolType poolType;

    [SerializeField] public EnemyController goblinPrefab;
    public bool collectionChecks = false;
    public int maxPoolSize = 50;

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
        EnemyController instance = Instantiate(goblinPrefab, Vector3.zero, Quaternion.identity);
        instance.Disable += ReturnObjectToPool;
        instance.gameObject.SetActive(false);

        return instance;
    }
    private void ReturnObjectToPool(EnemyController Instance)
    {
        enemyPool.Release(Instance);
    }
    private void OnTakeFromPool(EnemyController Instance)
    {
        Instance.gameObject.SetActive(true);
        SpawnEnemy(Instance);
        Instance.transform.SetParent(transform, true);
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

        //i want to quit peer support
    }
}
