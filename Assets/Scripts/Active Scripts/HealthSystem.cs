using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int playerToReference;
    public PlayerController playerReference;
    public PlayerTwoController playerTwoReference;
    public GameObject playerObject;
    public bool isDead;

    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;
    public Text healthText;

    public AudioSource playerHitAudio;
    public GameObject hitParticles;

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

    public void IncreasePlayerHealth(int amountToChange)
    {
        currentHealth += amountToChange;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        UpdateHealthUI();

        if (currentHealth <= 0) PlayerDie();
        if (currentHealth > 0) PlayerAlive();
    }

    public void DecreasePlayerHealth(int amountToChange)
    {
        playerHitAudio.Play();
        Instantiate(hitParticles, transform.position, transform.rotation);
        print("decreasing HP");
        currentHealth -= amountToChange;
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
                playerObject.SetActive(false); //set sprite inactive
                gameObject.SetActive(false); //hp system inactive
                playerReference.weaponSlot.gameObject.SetActive(false);
                playerReference.canMove = false;
                playerReference.gameObject.tag = "Untagged";
                break;

            case 2: 
                playerObject.SetActive(false);
                gameObject.SetActive(false);
                playerTwoReference.weaponSlot.gameObject.SetActive(false);
                playerTwoReference.canMove = false;
                playerTwoReference.gameObject.tag = "Untagged";
                break;

            default:
                Debug.LogError("Player reference is null.");
                break;
        }
    }
    void PlayerAlive()
    {
        isDead = false;

        switch (playerToReference)
        {
            case 1: 
                playerObject.SetActive(true); //set sprite inactive
                gameObject.SetActive(true); //hp system inactive
                playerReference.weaponSlot.gameObject.SetActive(true);
                playerReference.canMove = true;
                playerReference.gameObject.tag = "Player";
                break;

            case 2: 
                playerObject.SetActive(true);
                gameObject.SetActive(true);
                playerTwoReference.weaponSlot.gameObject.SetActive(true);
                playerTwoReference.canMove = true;
                playerTwoReference.gameObject.tag = "Player";
                break;

            default:
                Debug.LogError("Player reference is null.");
                break;
        }        
    }
}
