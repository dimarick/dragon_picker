using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int score;
    private int multipler;
    private string scorePattern;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        scorePattern = text.text;
    }

    void Update()
    {
        text.text = scorePattern + " " + score + "x" + multipler;
    }

    public void AddScore(int score)
    {
        this.score += score * multipler;
    }

    public void AddMultipler(int multipler)
    {
        this.multipler += multipler;
    }

    public void ResetMultipler()
    {
        this.multipler = 0;
    }
}
