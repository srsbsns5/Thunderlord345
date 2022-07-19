using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    float health;
    float attackRate;
    int attackDamage;
    int moveSpeed; 
    private float currentHealth;
    public GameObject target {get; private set;}
    NavMeshAgent navAgent;
    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        health = enemy.health;
        currentHealth = health;
        attackRate = enemy.attackRate;
        attackDamage = enemy.damage;
        navAgent.speed = enemy.moveSpeed;

        print(health);
    }

    private void Update()
    {
        target = FindClosestTarget();
        navAgent.SetDestination(target.transform.position);

        if (navAgent.remainingDistance < 2.5f)
        {
            navAgent.isStopped = true;
        }
        else
        {
            navAgent.isStopped = false;
        }
    }

    private GameObject FindClosestTarget()
    {
        GameObject[] targets;
        targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject active in targets)
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
            Destroy(gameObject);
        }
    }
}