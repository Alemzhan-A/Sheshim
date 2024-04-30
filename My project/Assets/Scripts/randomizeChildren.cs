using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class randomizeChildren : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int newSpot = Random.Range(0, transform.childCount);
            Vector3 temp= transform.GetChild(i).position;
            transform.GetChild(i).position = transform.GetChild(newSpot).position;
            transform.GetChild(newSpot).position = temp;
        }
    }
}
