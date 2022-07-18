using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject 
{
    public float health;
    public float stamina;
    public int moveSpeed;

    //see if i can add abilities in the future lol 
    //for now there'll be 1 default character
}