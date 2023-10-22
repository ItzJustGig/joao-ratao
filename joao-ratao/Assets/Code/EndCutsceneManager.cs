using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutsceneManager : MonoBehaviour
{
    public int goToScene = 0;
    public float waitTime = 35.2f;

    void Start()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(goToScene);
    }
}
