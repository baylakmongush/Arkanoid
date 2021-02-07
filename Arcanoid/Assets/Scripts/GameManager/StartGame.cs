using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}
