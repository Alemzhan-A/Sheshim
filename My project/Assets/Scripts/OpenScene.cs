using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainPage");
    }
}
