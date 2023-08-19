using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditButton;
    public Button backButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditButton.onClick.AddListener(CreditScene);
        backButton.onClick.AddListener(MainMenu);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball_Game");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credit");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
