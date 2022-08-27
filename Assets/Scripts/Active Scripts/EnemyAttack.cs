using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Enemy enemy;
    [SerializeField] GameObject playerHP;
    [SerializeField] float difference;
    public float hitThreshold;
    [SerializeField] int attackDamage;
    private float attackRate;
    float nextAttackTime;
    void Start()
    {
        attackRate = enemy.attackRate;
        attackDamage = enemy.damage;
    }
    void Update()
    {
        playerHP = FindClosestTarget();
        difference = Vector3.Distance(transform.position, playerHP.transform.position);
        
        if (Time.time >= nextAttackTime)
        {
            if (difference < hitThreshold)
            {
                playerHP.GetComponent<HealthSystem>().DecreasePlayerHealth(attackDamage);        
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    private UnityEngine.GameObject FindClosestTarget()
    {
        UnityEngine.GameObject[] targets;
        targets = UnityEngine.GameObject.FindGameObjectsWithTag("Health");

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

}
