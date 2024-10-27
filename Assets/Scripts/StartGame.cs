using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startButton; // Reference to the button in the UI

    public void Start()
    {
        // Ensure that the button is assigned and add a listener to it
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGameonPlay);
        }
    }

    // Method to load the next scene when the button is clicked
    public void StartGameonPlay()
    {
        SceneManager.LoadScene(1);
    }
}
