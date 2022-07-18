using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
   public int damage;
   public float fireRate;
   public int ammo; //or durability for melee weapons. how many times player can attack before resting
   public float cooldown; //or reload speed
   public float range;
}
