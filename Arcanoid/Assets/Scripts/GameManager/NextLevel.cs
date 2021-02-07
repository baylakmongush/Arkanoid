using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Animator fadeAnim;

    public void StartLevel(int indexLevel)
    {
        StartCoroutine(LoadLevel(indexLevel));
    }

    IEnumerator LoadLevel(int indexLevel)
    {
        fadeAnim.SetTrigger("Change");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(indexLevel);
    }
}
