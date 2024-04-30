using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTrash : MonoBehaviour
{
    // public GameObject Trash1; // Assign your first trash object in the inspector
    // public GameObject Trash2; // Assign your second trash object in the inspector
    // public float spawnRate = 1f; // The rate at which trash objects are spawned
    // private float nextSpawnTime;
    public GameObject Trashs;
    public float spawnRate = 1f;
    public float height = 10;
    private float timer = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game2")
        {
        SpawnRandomTrash();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game2")
        {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnRandomTrash();
            timer = 0;
        }
        }
    }

    void SpawnRandomTrash()
    {
        // Randomly select a trash object
        float high = transform.position.y - height;
        float low = transform.position.y + height;

        // Instantiate the selected trash object
        Instantiate(Trashs, new Vector2(transform.position.x, Random.Range(low, high)), transform.rotation);
    }
}