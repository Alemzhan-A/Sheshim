using System.Collections;
using System.Collections.Generic;
using TMPro;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int rollDice = 1;
    public GameObject cardGameObject;
    public SpriteRenderer cardSpriteRenderer;
    public CardController mainCardController;
    public float fMovingSpeed;
    public InterfaceManager InterfaceManager;
    public float fRotatingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public float divideValue;
    public float backdivideValue;
    public float fRotationCoef;
    public AudioSource swipe;
    public static int maxValue = 100;
    public int minValue = 0;
    public Vector2 defaultPositionCard;

    public ResourceManager resourceManager;
    Vector3 pos;
    public float fTransparency;
    public Color textColor;
    public Color actionBackgroundColor;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    public string leftQuote;
    public string rightQuote;
    public SpriteRenderer actionBackground;
    public Card currentCard;
    public bool isSubstitung = false;
    public Vector3 cardRotation;
    public Vector3 initRotation;
    public static int human;
    public static int robot;
    public static int economy;
    public static int ecology;
    public static int cardNum;
    public int n = 0;

    void Start()
    {
        LoadCard(currentCard);
    }

    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        actionBackground.color = actionBackgroundColor;
        if (cardGameObject.transform.position.x < 0)
        {
            actionQuote.text = leftQuote;
        }
        else
        {
            actionQuote.text = rightQuote;
        }
    }
    void Update()
    {
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        actionBackgroundColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / backdivideValue, fTransparency);
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                if (InterfaceManager.human.fillAmount <= 0)
                {
                    if (n == 0)
                    {
                        n += 1;
                    }
                    else
                    {
                        LoadCard(resourceManager.cards[39]);
                    }
                }
                else if (InterfaceManager.robot.fillAmount <= 0)
                {
                    if (n == 0)
                    {
                        n += 1;
                    }
                    else
                    {
                        LoadCard(resourceManager.cards[38]);
                    }
                }
                else if (InterfaceManager.ecology.fillAmount <= 0)
                {
                    if (n == 0)
                    {
                        n += 1;
                    }
                    else
                    {
                        LoadCard(resourceManager.cards[40]);
                    }
                }
                else if (InterfaceManager.economy.fillAmount <= 0)
                {
                    if (n == 0)
                    {
                        n += 1;
                    }
                    else
                    {
                        LoadCard(resourceManager.cards[41]);
                    }
                }
                else
                {
                    NewCard();
                }
            }
        }
        else if (cardGameObject.transform.position.x > fSideMargin)
        {
        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            textColor.a = 0;
        }
        else if (cardGameObject.transform.position.x > -fSideTrigger)
        {
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                if (InterfaceManager.human.fillAmount <= 0)
                {
                    if (n == 0)
                    {
                        n += 1;
                    }
                    else
                    {
                        LoadCard(resourceManager.cards[39]);
                    }
                }
                else if (InterfaceManager.robot.fillAmount <= 0)
                {
                    if (n == 0)
                    {
                        n += 1;
                    }
                    else
                    {
                        LoadCard(resourceManager.cards[38]);
                    }
                }
                else if (InterfaceManager.ecology.fillAmount <= 0)
                {
                    if (n == 0)
                    {
                        n += 1;
                    }
                    else
                    {
                        LoadCard(resourceManager.cards[40]);
                    }
                }
                else if (InterfaceManager.economy.fillAmount <= 0)
                {
                    if (n == 0)
                    {
                        n += 1;
                    }
                    else
                    {
                        LoadCard(resourceManager.cards[41]);
                    }
                }
                else
                {
                    NewCard();
                }
            }
        }
        UpdateDialogue();
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, cardGameObject.transform.position.x * fRotationCoef);

        }
        else if (!isSubstitung)
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultPositionCard, fMovingSpeed);
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (isSubstitung)
        {
            cardGameObject.transform.eulerAngles = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, fRotatingSpeed);
        }

        characterDialogue.text = currentCard.dialogue;
        if (cardGameObject.transform.eulerAngles == cardRotation)
        {
            isSubstitung = false;
        }

    }


    public void LoadCard(Card card)
    {
        currentCard = card;
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        characterDialogue.text = card.dialogue;
        cardGameObject.transform.position = defaultPositionCard;
        cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        isSubstitung = true;
        cardGameObject.transform.eulerAngles = initRotation;
        swipe.Play();
    }


    public void NewCard()
    {
        rollDice += 1;
        LoadCard(resourceManager.cards[rollDice]);
    }

}
