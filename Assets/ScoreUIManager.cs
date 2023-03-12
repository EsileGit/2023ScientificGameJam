using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    private int currentScore = 0;
    private float cellLifePercent = 1;
    private float timeSinceLastScoring = 0;
    GameObject score;
    GameObject cellLife;
    void Start()
    {
        currentScore = 0;
        score = GameObject.FindWithTag("scoreTag");
        cellLife = GameObject.FindWithTag("cellLifeTag");
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastScoring += Time.deltaTime;
        if (timeSinceLastScoring > 1)
        {
            UpdateScore();
            timeSinceLastScoring = 0;
        }
    }

    private void UpdateScore()
    {
        GameObject[] viral = GameObject.FindGameObjectsWithTag("viralRNA");
        GameObject[] cell = GameObject.FindGameObjectsWithTag("RNA");

        int nbViralRNA = 0;
        foreach (GameObject respawn in viral)
            nbViralRNA++;
        currentScore += nbViralRNA;

        int nbCellRNA = 0;
        foreach (GameObject respawn in cell)
            nbCellRNA++;

        if (nbCellRNA > nbViralRNA)
        {
            cellLifePercent += 0.1f;
        }
        else
        {
            cellLifePercent -= 0.1f;
        }
        if (cellLifePercent < 0)
            cellLifePercent = 0;
        if (cellLifePercent > 1)
            cellLifePercent = 1;

    }

    void UpdateUI()
    {
        score.GetComponent<TextMeshProUGUI>().text = "" + currentScore;
        cellLife.GetComponent<TextMeshProUGUI>().text = cellLifePercent * 100 + "%";
    }
}
