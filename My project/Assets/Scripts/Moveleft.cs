using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moveleft : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float deadZone = -45;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game2")
        {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
        }
    }
}
