using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    public DataScript DataScript;
    int sc;
    public bool detected = false;
    void Start()
    {
        sc = DataScript.score;
        score.text = sc.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (detected)
        {
            sc++;
            score.text = sc.ToString();
            PlayerPrefs.SetInt("score", sc);
            detected = false;
        }
    }
}
