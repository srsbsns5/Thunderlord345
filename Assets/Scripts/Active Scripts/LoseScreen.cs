using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoseScreen : MonoBehaviour 
{
    public bool showlose;
    public float delay;
    public Text titleLine;
    public Text quote;
    public Text killCount;
    public Text coinCount;
    public Text waveCount;
    public GameObject selectableObject;
    
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
        EventManager.CoinCollect += IncreaseCoinCount;
    }

    private void Update()
    {
        if (showlose)
        {
            EventSystem.current.SetSelectedGameObject(null);
            ShowLoseScreen();
            showlose= false;
        }

        if (bg.activeInHierarchy)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else Time.timeScale = 1f;
    }

    public void ShowLoseScreen()
    {
        bg.SetActive(true);

        EventSystem.current.SetSelectedGameObject(selectableObject);
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
