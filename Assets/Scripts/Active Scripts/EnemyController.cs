using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public GameObject enemyPrefab;
    public GameObject target {get; private set;}
    public Action<EnemyController> killAction;
    NavMeshAgent navAgent;
    [Header ("Stats")]
    float health;
    int moveSpeed;
    public int expAmt; 
    private float currentHealth;

    [Header("Events")]
    public GameObject coin;
    public GameObject deathParticle;
    public GameObject hitParticle;
    public AudioSource enemyHitAudio;
    WaveManager waveM;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        waveM = FindObjectOfType<WaveManager>();
        enemyHitAudio = GameObject.FindGameObjectWithTag("Enemy 1").GetComponent<AudioSource>();
        
        NavMeshHit closestHit;

        if (NavMesh.SamplePosition(gameObject.transform.position, out closestHit, 500f, NavMesh.AllAreas))
            gameObject.transform.position = closestHit.position;
        else
            Debug.LogError("Could not find position on NavMesh!");
    }
    
    private void OnEnable()
    {
        health = enemy.health;
        currentHealth = health;
        expAmt = enemy.expDropped;
        navAgent.speed = enemy.moveSpeed;
    }

    private void Update()
    {
        target = FindClosestTarget();
        navAgent.SetDestination(target.transform.position);
    }

    private UnityEngine.GameObject FindClosestTarget()
    {
        UnityEngine.GameObject[] targets;
        targets = UnityEngine.GameObject.FindGameObjectsWithTag("Player");

        UnityEngine.GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (UnityEngine.GameObject active in targets)
        {
            Vector3 diff = active.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = active;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void TakeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;

        Instantiate(hitParticle, transform.position, transform.rotation);

        print("Enemy has" + currentHealth + "hp");
        
        enemyHitAudio.Play();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SpawnCoin();
        SpawnDeathParticles();

        EventManager.EnemyKilledInWave();
        EventManager.SubtractEnemyCount += waveM.WaveProgressor;

        target.transform.Find("LevelSystemHolder").GetComponent<LevelSystem>().GainEXP(expAmt);

        this.StopAllCoroutines();
        killAction(this); //Returns item to pool
    }

    void SpawnDeathParticles()
    {
        Instantiate(deathParticle, transform.position, transform.rotation);
        deathParticle.transform.SetParent(null);
    }

    void SpawnCoin()
    {
        Vector3 spawnLocation = transform.position;
        Instantiate(coin, spawnLocation, transform.rotation);
        coin.transform.SetParent(null);
    }

    public IEnumerator ReturnToPool(int i)
    {
        yield return new WaitForSeconds(i);
        yield return null;
        killAction(this);
    }

        public void Init(Action<EnemyController> _killAction)
    {
        killAction = _killAction;
    }
}