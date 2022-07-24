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
    public bool collectionChecks = true;
    public int maxPoolSize = 50;

    public IObjectPool<GameObject> pool;

    public IObjectPool<GameObject> enemyPool
    {
        get
        {
            if (enemyPool == null)
            {
                if (poolType == PoolType.Goblin)
                {
                    enemyPool = new ObjectPool<GameObject>
                    (
                        Instantiate()
                    )
                }
            }
        }
    }
}