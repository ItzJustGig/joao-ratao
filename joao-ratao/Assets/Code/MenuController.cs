using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame() {
        SceneManager.LoadScene("Level");
    }

    public void options() {
        SceneManager.LoadScene("Options");
    }

    public void exitGame() {
        Application.Quit();
    }
}