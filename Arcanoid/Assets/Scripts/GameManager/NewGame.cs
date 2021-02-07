using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public NextLevel NextLevel;
    public DataScript DataScript;
    
    public void NewGameButton()
    {
        Time.timeScale = 1;
        DataScript.level = 1;
        DataScript.score = 0;
        NextLevel.StartLevel(0);
        PlayerPrefs.SetInt("score", 0);
    }
}
