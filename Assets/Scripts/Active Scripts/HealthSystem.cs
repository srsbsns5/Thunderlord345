using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int playerToReference;
    public PlayerController playerReference;
    public PlayerTwoController playerTwoReference;

    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;
    public Text healthText;

    void Start()
    {
        EventManager.ChangeHealth();
        EventManager.UpdatePlayerHealth += UpdateHealth;

        if (playerToReference == 1)
        {
            playerReference = FindObjectOfType<PlayerController>();
    
            maxHealth = playerReference.character.health;;
            currentHealth = maxHealth;
            healthText.text = currentHealth + "/" + maxHealth;

        }
        else if (playerToReference == 2)
        {
            playerTwoReference = FindObjectOfType<PlayerTwoController>();

            maxHealth = playerTwoReference.character.health;;
            currentHealth = maxHealth;
            healthText.text = currentHealth + "/" + maxHealth;

        }
    }

    public void AdjustPlayerHealth(int amountToChange)
    {
        currentHealth += amountToChange;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        healthText.text = currentHealth + "/" + maxHealth;
    }
}
