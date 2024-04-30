using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    public bool isMouseOver;
    public BoxCollider2D thisCard;
    private void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnMouseOver()
    {
        isMouseOver = true;
    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}


public enum CardSprite
{
    Nurzhan, Commubot, Alima, Erlan, Alua, Alizhan, robot,human,ecology, economy, peace, spy, krossovki, robothand
}