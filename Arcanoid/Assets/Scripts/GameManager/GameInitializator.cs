using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitializator : MonoBehaviour
{
    public DataScript DataScript;
    public Text level;
    public Text currentLevel;

    private float ball_speed = 5.0f;
    private int countBlocks = 8;

    private void Start()
    {
        currentLevel.text = "Level: " + DataScript.level.ToString();
        level.text = DataScript.level.ToString();
        DataScript.ball_speed = ball_speed;
        DataScript.CountBlocks = countBlocks;
    }

}
