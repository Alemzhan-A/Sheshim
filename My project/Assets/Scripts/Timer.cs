using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component
    public RocketScript rocketScript; // Reference to the RocketScript component
    private float startTime;
    private float timeout = 10.0f; // Timeout after 60 seconds

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game2")
        {
            startTime = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game2")
        {
            float t = Time.time - startTime;

            if (t >= timeout)
            {
                if (rocketScript.isLive)
                {
                    timerText.text = "You Win!";
                }
                else
                {
                    timerText.text = "Game Over";
                }
            }
            else
            {
                float remainingTime = timeout - t;
                string minutes = ((int)remainingTime / 60).ToString();
                string seconds = (remainingTime % 60).ToString("f2");

                timerText.text = minutes + ":" + seconds; // Update the TextMeshProUGUI component
            }
        }
    }
}