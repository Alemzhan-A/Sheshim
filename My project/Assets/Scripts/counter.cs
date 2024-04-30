using UnityEngine;
using UnityEngine.SceneManagement;

public class counter : MonoBehaviour
{
    // Static variable to store the global counter
    public static int rightMatchesCounter = 0;

    // Method to increment the counter
    public GameObject menuCanvas; // Reference to the UI canvas for the menu screen
    public string nextLevelName; // Name of the next level scene
    public int targetCounterValue = 5; // Target value for the counter to proceed to the next level

    private void Start()
    {
        // Hide the menu canvas initially
        menuCanvas.SetActive(false);
    }

    private void Update()
    {
        // Check if the counter reaches the target value
        if (rightMatchesCounter >= targetCounterValue)
        {
            // Show the menu canvas
            menuCanvas.SetActive(true);
        }
    }

    // Method to load the next level
    public void LoadNextLevel()
    {
        // Load the next level scene
        SceneManager.LoadScene(nextLevelName);
    }
    public static void IncrementCounter()
    {
        rightMatchesCounter++;
    }
    
}
