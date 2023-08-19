using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    // reference untuk button
    public Button mainMenuButton;
    public Button restartButton;

    private void Start()
    {
        // setup event saat button di klik
        mainMenuButton.onClick.AddListener(MainMenu);
        restartButton.onClick.AddListener(RestartScene);
    }

    public void MainMenu()
    {
        // kembali ke main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene()
    {
        // Restart Scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
