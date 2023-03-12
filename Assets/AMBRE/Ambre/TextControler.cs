using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextControler : MonoBehaviour
{
    [SerializeField] private List<string> textesAMettre;
    [SerializeField] private float tempApparition;
    [SerializeField] private float tempDisparition;
    [SerializeField] private float tempReste;
    [SerializeField] private TextMeshProUGUI text;
    int index = 0;
    float timer = 0;
    [SerializeField] bool isSmooth;
    bool isDisepearing;
    bool isSpawning;
    bool isWaiting;
    bool asSmooth;
    bool ischanging;
    float appearPercent;
    float disappearPercent;

    void Start()
    {
        if (!isSmooth)
            DoTextPop();
        else
        {
            appearPercent = 1/(tempApparition * 50);
            disappearPercent = 1/(tempApparition * 50);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            isSpawning = true;
            asSmooth = true;
            text.text = textesAMettre[index];
        }
    }

    private void FixedUpdate()
    {
        if (asSmooth)
        {
            timer += Time.fixedDeltaTime;
            if (isSpawning)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + appearPercent);
                if (timer >= tempApparition)
                {
                    isSpawning = false;
                    isWaiting = true;
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    timer = 0;
                }
            }
            if (isWaiting && timer>=tempReste)
            {
                if (timer >= tempReste)
                {
                    isWaiting = false;
                    isDisepearing = true;
                    timer = 0;
                }
            }
            if (isDisepearing)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - disappearPercent);
                if (timer >= tempDisparition)
                {
                    isDisepearing = false;
                    ischanging = true;
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    timer = 0;
                }
            }
            if (ischanging)
            {
                index++;
                if (index < textesAMettre.Count)
                {
                    ischanging = false;
                    isSpawning = true;
                    timer = 0;
                    text.text = textesAMettre[index];
                }
                else
                    asSmooth = false;
            }
        }
       
    }

    private void DoTextPop()
    {
        if (index < textesAMettre.Count)
            StartCoroutine(AppearText());
    }

    IEnumerator AppearText()
    {
        text.text = textesAMettre[index];
        index++;
        yield return new WaitForSeconds(tempReste);
        text.text = null;
        StartCoroutine(DisepearText());
    }

    IEnumerator DisepearText()
    {
        yield return new WaitForSeconds(tempDisparition);
        DoTextPop();
    }
}
