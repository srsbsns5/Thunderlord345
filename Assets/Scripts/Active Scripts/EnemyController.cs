using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public GameObject enemyPrefab;
    public GameObject target {get; private set;}
    NavMeshAgent navAgent;
    [Header ("Stats")]
    float health;
    float attackRate;
    int attackDamage;
    int moveSpeed;
    public int expAmt; 
    public int spawnCost;
    private float currentHealth;

    [Header("Drops")]
    public WeightedRandomList<Transform> dropTable;

    
    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        health = enemy.health;
        currentHealth = health;
        attackRate = enemy.attackRate;
        attackDamage = enemy.damage;
        expAmt = enemy.expDropped;
        spawnCost = enemy.spawnCost;
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

    public delegate void OnDisableCallBack(EnemyController Instance);
    public OnDisableCallBack Disable;

    private void Die()
    {
        Disable?.Invoke(this);
        Transform item = dropTable.GetRandom();
        Instantiate(item, transform);
        
        //Have to change this functionality to make it applicable for 2 players, this is just for testing
        FindObjectOfType<LevelSystem>().GainEXP(expAmt);
        //gameObject.SetActive(false);

    }
}