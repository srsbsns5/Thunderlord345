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
    float attackRate;
    int attackDamage;
    int moveSpeed;
    public int expAmt; 
    private float currentHealth;

    [Header("Drops")]
    public WeightedRandomList<Transform> dropTable;

    
    private void OnEnable()
    {
        navAgent = GetComponent<NavMeshAgent>();

        health = enemy.health;
        currentHealth = health;
        attackRate = enemy.attackRate;
        attackDamage = enemy.damage;
        expAmt = enemy.expDropped;
        navAgent.speed = enemy.moveSpeed;

        print(health);
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

        print("Enemy has" + currentHealth + "hp");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Drops
        //Transform item = dropTable.GetRandom();
        //Instantiate(item, transform);
        //item.SetParent(null);
        
        //Have to change this functionality to make it applicable for 2 players, this is just for testing
        //FindObjectOfType<LevelSystem>().GainEXP(expAmt); //Gain exp for both players supposedly        
        killAction(this); //Returns item to pool
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