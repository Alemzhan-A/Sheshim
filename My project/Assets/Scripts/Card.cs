using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Card : ScriptableObject
{
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string leftQuote;
    public string rightQuote;
    public string dialogue;
    public int cardHumanLeft;
    public int cardRobotLeft;
    public int cardEconomyLeft;
    public int cardEcologyLeft;
    public int cardHumanRight;
    public int cardRobotRight;
    public int cardEconomyRight;
    public int cardEcologyRight;
    public void Left()
    {
        Debug.Log(cardName + "swiped left");
        GameManager.human += cardHumanLeft;
        GameManager.robot += cardRobotLeft;
        GameManager.ecology += cardEcologyLeft;
        GameManager.economy += cardEconomyLeft;
    }
    public void Right()
    {
        Debug.Log(cardName + "swiped right");
        
        GameManager.human += cardHumanRight;
        GameManager.robot += cardRobotRight;
        GameManager.ecology += cardEcologyRight;
        GameManager.economy += cardEconomyRight;
    }
}