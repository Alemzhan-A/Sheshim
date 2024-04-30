using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuzzle : MonoBehaviour
{
    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;
    public float tar = 15f;
    public GameObject form;
    bool finish;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    /*private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            mousePos = Input.mousePosition;
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        move = false;
        if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= tar && Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 5f)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
        }
    }*/
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && name.Equals(collider.name))
            {
                
                if (name.Equals(collider.name))
                {
                    UpdatePos(collider.transform.position);
                    collider.gameObject.SetActive(false);
                    col.enabled = false;
                    count1.IncrementCounter();
                    Done();
                }

                return;
            }



        }
        UpdatePos(newPosition);

    }
    void Done()
    {
        Destroy(this);
    }

    void UpdatePos(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    // Update is called once per frame
    
}
