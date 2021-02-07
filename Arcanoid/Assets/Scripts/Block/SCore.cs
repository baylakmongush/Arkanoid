using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCore : MonoBehaviour
{
    public Text score;
    public Text scoreHigh;
    public DataScript DataScript;
    int sc;
    public bool detected = false;
    void Start()
    {
        if (DataScript.level == 1)
        {
            PlayerPrefs.SetInt("score", 0);
            sc = 0;
        }
        else
            sc = PlayerPrefs.GetInt("curr_score");
        int highscore = PlayerPrefs.GetInt("high_score");
        scoreHigh.text = highscore.ToString();
        score.text = sc.ToString();
    }

    void Update()
    {
        if (detected)
        {
            sc++;
            score.text = sc.ToString();
            if (sc > PlayerPrefs.GetInt("high_score"))
            {
                PlayerPrefs.SetInt("high_score", sc);
                scoreHigh.text = sc.ToString();
            }
            detected = false;
        }
    }
}
