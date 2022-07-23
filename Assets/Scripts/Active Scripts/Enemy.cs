using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class GameObject : ScriptableObject 
{
    public float health;
    public float attackRate;
    public int damage;
    public int moveSpeed;
    public int expDropped;
    public int spawnCost;
}