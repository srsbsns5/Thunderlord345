using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{ 
    public LayerMask enemylayer;
    //public bool canAttack {get ; private set;}

    [Header("Weapon Stats")]
    public Weapon weaponObject;
    int damage;
    float fireRate;
    int ammo;
    float cooldown;
    float range;
    void Awake()
    {
        EventManager.NewItemEquip();

        //NULL CHECKIN
        if(weaponObject != null) EventManager.TakeItem += UpdateWeapon;
        else 
        {
            damage = 0;
            fireRate = 0;
            ammo = 0;
            cooldown = 0;
            range = 0;
        }
    }

    public void UpdateWeapon() //updates all weapon stats
    {
        damage = weaponObject.damage;
        fireRate = weaponObject.fireRate;
        ammo = weaponObject.ammo;
        cooldown = weaponObject.cooldown;
        range = weaponObject.range;

        EventManager.TakeItem -= UpdateWeapon; //unsubscribes
    }
}
