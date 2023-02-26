using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score;

    TMP_Text Score_t;


    void Start()
    {
        Score_t=GetComponent<TMP_Text>();
        Score_t.text = "";
    }

    public void Score_increase(int score_point)
    {
        score += score_point;
        Score_t.text = score.ToString();
    }
}
