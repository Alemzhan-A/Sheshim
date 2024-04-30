using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class match : MonoBehaviour
{
    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                UpdateTea(collider.transform.position);
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    counter.IncrementCounter();
                    Done();
                }

                return;
            }

            

        }
        UpdateTea(newPosition);
        
    }

    void Done()
    {
        Destroy(this);
    }

    private void OnMouseUp()
    {
        UpdateTea(startPosition);
    }
    private void UpdateTea(Vector3 newPosition)
    {
        

        transform.position = newPosition;

    }
}
