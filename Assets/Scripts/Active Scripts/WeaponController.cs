using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{ 
    public LayerMask enemylayer;
    //public bool canAttack {get ; private set;}

    public PlayerControls playerInputs;
    private InputAction attack;

    [Header("Weapon Stats")]
    public Weapon weaponEquipped;
    int damage;
    float fireRate;
    int ammo;
    float cooldown;
    float range;

    float nextAttackTime = 0f;
    
    private void Awake() 
    {
        playerInputs = new PlayerControls();
    }

    private void OnEnable() 
    {
        attack = playerInputs.Player.Fire;
        attack.Enable();
    }
    private void OnDisable() 
    {
        attack.Disable();
    }
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
             if (playerInputs.Player.Fire.triggered)
            {
                Attack();
                nextAttackTime = Time.time + 1f/ fireRate;
                FindObjectOfType<LevelSystem>().GainEXP(5);             
            }
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, range, enemylayer);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()  
    {   
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
