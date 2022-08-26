using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour 
{
    public bool showlose;
    public float delay;
    public Text titleLine;
    public Text quote;
    public Text killCount;
    public Text coinCount;
    public Text waveCount;
    
    public GameObject bg;
    public AudioSource audioS;
    public AudioSource audioSTwo;

    [Header("Game Statistics")]
    [SerializeField] int enemiesKilled;
    [SerializeField] int coinsPickedUp;
    [SerializeField] int wavesSurvived;

    private void Awake() 
    {
        EventManager.GameEnded += ShowLoseScreen;
        EventManager.SubtractEnemyCount += IncreaseEnemyKillCount;
    }

    private void Update()
    {
        if (showlose)
        {
            ShowLoseScreen();
            showlose= false;
        }
    }

    public void ShowLoseScreen()
    {
        Time.timeScale = 0f;
        bg.SetActive(true);
        StartCoroutine(SetLine());
    }

    void IncreaseEnemyKillCount()
    {
        enemiesKilled++;
    }

    void IncreaseCoinCount()
    {
        coinsPickedUp++;
    }

    public IEnumerator SetLine()
    {
        audioS.Play();
        string[] titleLines = new string[] 
        {
            "SLAYER GETS SLAYED", "FFFFFFFFF", "THIS IS LOSS", "L + Ratio", "Try harder"
        };
        string randomTitle = titleLines[Random.Range(0, titleLines.Length)];

        titleLine.text = randomTitle;

        yield return new WaitForSecondsRealtime(delay);

        StartCoroutine(SetQuote());
    }

    public IEnumerator SetQuote()
    {
        audioS.Play();
        string[] quoteLines = new string[] 
        {
            "Your troubles are taken care of.", "This is definitely one of the playthroughs!", "One of you is the problem.", ":(", "344 Thunderlords look down on you."
        };
        string randomQuote = quoteLines[Random.Range(0, quoteLines.Length)];

        quote.text = randomQuote;

        yield return new WaitForSecondsRealtime(delay);

        ShowStats();
    }

    public void ShowStats()
    {
        audioSTwo.Play();

        wavesSurvived = FindObjectOfType<WaveManager>().currentWave;
        waveCount.text = "Waves survived: " + wavesSurvived;
        killCount.text = "Foes annihilated: " + enemiesKilled;        
        coinCount.text = "Coins collected: " + coinsPickedUp;        
    }
}
