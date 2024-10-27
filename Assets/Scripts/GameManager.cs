using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI gameOverText;
    public AudioSource winMusic;

    public void GameOver(bool win)
    {
        gameOverUI.SetActive(true); // Show the game over UI
        string result = win ? "You win! Aparna rules Vancouver!" : "You lose! Try again!";
        winMusic.Play();
        
        if (gameOverText != null)
        {
            gameOverText.text = result; // Display the result message
        }

        Debug.Log(result); // Log the result in the console
    }

    public void RestartGame()
    {
        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

