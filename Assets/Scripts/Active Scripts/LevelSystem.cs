using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSystem : MonoBehaviour
{
    public GameObject playerHealth;
    HealthSystem healthSystem;
    public AudioSource audioS;
    
    [Header("Statistics")]
    public int level;
    public float currentXP;
    public float requiredXP;
    private float lerpTimer;
    private float delayTimer;
    [Header ("UI")]
    public Image frontXPBar;
    public Image backXPBar;
    public Image xpBarHolder;
    public Text levelText;
    public Text xpText;

    [Header ("Calculations")]
    public float additionMultiplier = 10;
    public float powerMultiplier = 2;
    public float divisionMultiplier = 7;

    void Start()
    {
        frontXPBar.fillAmount = currentXP /requiredXP;
        backXPBar.fillAmount = currentXP /requiredXP;
        levelText.text = "LV " + level;

        requiredXP = CalculateRequiredXP();

        healthSystem = playerHealth.GetComponent<HealthSystem>();
    }

    void Update()
    {
        UpdateXPUI();

        if(currentXP >= requiredXP)
        {
            LevelUp();
        }

    }

    void UpdateXPUI()
    {
        float xpFraction = currentXP / requiredXP;
        float FXP = frontXPBar.fillAmount;

        if (FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXPBar.fillAmount = xpFraction;
            if (delayTimer > 1)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                frontXPBar.fillAmount = Mathf.Lerp(FXP, backXPBar.fillAmount, percentComplete);
            }
        }

        xpText.text = currentXP + "/" + requiredXP;
        levelText.text = "LV " + level;

    }
    public void GainEXP(float xpGained)
    {
        currentXP += xpGained;
        lerpTimer = 0f;
        delayTimer = 0f;
    }
    public void LevelUp()
    {
        level++;
        audioS.Play();

        frontXPBar.fillAmount = 0;
        backXPBar.fillAmount = 0;
        currentXP = Mathf.RoundToInt(currentXP - requiredXP);
        
        //Increase stats
        healthSystem.maxHealth = Mathf.RoundToInt(healthSystem.maxHealth + level * 2.5f);

        requiredXP = CalculateRequiredXP();
    }

    private int CalculateRequiredXP()
    {
        int solveForRequiredXP = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXP += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier,levelCycle / divisionMultiplier));
        }
        return solveForRequiredXP / 4;
    }
}
