using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject card;
    public Image human;
    public Image robot;
    public Image economy;
    public Image ecology;
    public Image humanImpact;
    public Image robotImpact;
    public Image economyImpact;
    public Image ecologyImpact;

    void Update()
    {
        human.fillAmount = (float) GameManager.human / GameManager.maxValue;
        robot.fillAmount = (float) GameManager.robot / GameManager.maxValue;
        economy.fillAmount = (float) GameManager.economy / GameManager.maxValue;
        ecology.fillAmount = (float) GameManager.ecology / GameManager.maxValue;

        if(card.transform.position.x > 0)
        {
            if(gameManager.currentCard.cardHumanRight!=0){
                humanImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.cardRobotRight!=0){
                robotImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.cardEconomyRight!=0){
                economyImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.cardEcologyRight!=0){
                ecologyImpact.transform.localScale = new Vector3(1,1,0);
            }
        }
        else if(card.transform.position.x < 0){
            if(gameManager.currentCard.cardHumanLeft!=0){
                humanImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.cardRobotLeft!=0){
                robotImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.cardEconomyLeft!=0){
                economyImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.cardEcologyLeft!=0){
                ecologyImpact.transform.localScale = new Vector3(1,1,0);
            }
        }
        else{
            humanImpact.transform.localScale = new Vector3(0,0,0);
            robotImpact.transform.localScale = new Vector3(0,0,0);
            economyImpact.transform.localScale = new Vector3(0,0,0);
            ecologyImpact.transform.localScale = new Vector3(0,0,0);
        }
    }
}
