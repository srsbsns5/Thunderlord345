using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{ 
    public LayerMask enemylayer;
    public bool canAttack {get ; private set;}
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

        canAttack = true;
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
        print("ATTACK");
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, range, enemylayer);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(5);
        }
    }

    private void OnDrawGizmos()  
    {      
        Gizmos.DrawSphere(transform.position, range);
    }
}
