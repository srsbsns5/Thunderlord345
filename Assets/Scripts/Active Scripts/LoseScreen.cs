using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour 
{
    public float delay;
    public Text titleLine;
    public Text quote;
    public AudioSource audioS;
    public AudioSource audioSTwo;

    private void OnEnable() 
    {
        StartCoroutine(SetLine());
        Time.timeScale = 0f;
    }

    public IEnumerator SetLine()
    {
        audioS.Play();
        string[] titleLines = new string[] 
        {
            "SLAYER GETS SLAYED", "FFFFFFFFF", "THIS IS LOSS", "L + Ratio"
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
            "Your troubles are taken care of.", "This is definitely one of the playthroughs!", "One of you is the problem.", ":("
        };
        string randomQuote = quoteLines[Random.Range(0, quoteLines.Length)];

        quote.text = randomQuote;

        yield return new WaitForSecondsRealtime(delay);

        ShowStats();
    }

    public void ShowStats()
    {
        audioSTwo.Play();
        print("stats r showing");
    }
}
