using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int playerToReference;
    public PlayerController playerReference;
    public PlayerTwoController playerTwoReference;

    public bool isDead;

    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;
    public Text healthText;

    void Start()
    {
        EventManager.ChangeHealth();
        EventManager.UpdatePlayerHealth += UpdateHealthUI;

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
        UpdateHealthUI();

        if (currentHealth <= 0) PlayerDie();
    }

    void UpdateHealthUI()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        healthText.text = currentHealth + "/" + maxHealth;
    }

    void PlayerDie()
    {
        isDead = true;

        switch (playerToReference)
        {
            case 1: 
                playerReference.gameObject.SetActive(false);
                break;

            case 2: 
                playerTwoReference.gameObject.SetActive(false);
                break;

            default:
                Debug.LogError("Player reference is null.");
                break;
        }
    }
}
