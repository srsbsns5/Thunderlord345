using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{ 
    public bool canAttack {get ; private set;}
    [Header("Weapon Stats")]
    public Weapon weaponEquipped;
    int damage;
    float fireRate;
    float nextAttackTime = 0f;
    int ammo;
    float cooldown;

    void Start()
    {
        damage = weaponEquipped.damage;
        fireRate = weaponEquipped.fireRate;
        ammo = weaponEquipped.ammo;
        cooldown = weaponEquipped.cooldown;

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
    }
}
