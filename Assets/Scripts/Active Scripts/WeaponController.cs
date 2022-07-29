using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{ 
    public LayerMask enemylayer;
    //public bool canAttack {get ; private set;}

    [Header("Weapon Stats")]
    public Weapon weaponEquipped;
    int damage;
    float fireRate;
    int ammo;
    float cooldown;
    float range;

    float nextAttackTime = 0f;
    void Start()
    {
        damage = weaponEquipped.damage;
        fireRate = weaponEquipped.fireRate;
        ammo = weaponEquipped.ammo;
        cooldown = weaponEquipped.cooldown;
        range = weaponEquipped.range;
        
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f/ fireRate;
            }
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, range, enemylayer);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
            if (enemy.GetComponent<EnemyController>())
                print("true");
        }
    }

    private void OnDrawGizmos()  
    {   
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
