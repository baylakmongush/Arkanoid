using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public NextLevel NextLevel;
    public Text score;
    public void RestartButton()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("curr_score"));
        NextLevel.StartLevel(0);
    }
}
