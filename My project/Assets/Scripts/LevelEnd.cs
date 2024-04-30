using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load
    public GameObject canvas;
    public PlayerController playerController;

    private void Start()
    {
        canvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player enters the trigger area
        if (collision.CompareTag("Player"))
        {
            // Load the next scene
            playerController.stop();
            canvas.SetActive(true);
        }
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
