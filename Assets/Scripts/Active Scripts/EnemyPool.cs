using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private PoolObjectEnemy goblinPrefab;
    [SerializeField] private int spawnAmount; 
    [SerializeField] private bool usePool; 
    private ObjectPool<PoolObjectEnemy> goblinPool;

    private void Start() 
    {
        goblinPool = new ObjectPool<PoolObjectEnemy>(() => 
        {   return Instantiate(goblinPrefab);   }, 
            goblin => {goblin.gameObject.SetActive(true);},
            goblin => {goblin.gameObject.SetActive(false);},
            goblin => {Destroy(goblin.gameObject);},
            true,
            3,
            100);
            InvokeRepeating(nameof(Spawn), 0.2f, 0.2f);
    }

    private void Spawn()
    {
        for(var i = 0; i < spawnAmount; i++)
        {
            var goblin = usePool ? goblinPool.Get() : Instantiate(goblinPrefab);
            goblin.transform.position = transform.position + Random.insideUnitSphere * 10;

        }
    }

    private void KillGoblin(PoolObjectEnemy goblin)
    {
        if(usePool) goblinPool.Release(goblin);
        else Destroy(goblin.gameObject);
    }
}