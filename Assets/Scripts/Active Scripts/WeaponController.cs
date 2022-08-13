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
    void Start()
    {
        EventManager.NewItemEquip();
        EventManager.TakeItem += UpdateWeapon;
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
