using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject 
{
    public float health;
    public float attackRate;
    public int damage;
    public int moveSpeed;
}