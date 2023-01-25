using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [SerializeField] private GameObject clubs;
    [SerializeField] private GameObject diamonds;
    [SerializeField] private GameObject hearts;
    [SerializeField] private GameObject spades;

    [Header("dignity")] [SerializeField] private TextMeshProUGUI dignity;
    public CardColor CardColor { get; private set; }
    
    public CardItem CardItem { get; set; }

    public static Card dragItem;
    public Vector3 startPosition;
    public Transform StartParrent;


    public void SetCard(CardItem cardItem)
    {
        CardItem = cardItem;
        ClearAll();
        SetSuitCardCalor();
        SetCardDignity(cardItem.CardDignity);
        SetCardSuit();
    }

    private void SetCardSuit()
    {
        if (CardItem.CardSuit == CardSuit.Clubs) clubs.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Diamonds) diamonds.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Hearts) hearts.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Spades) spades.SetActive(true);
    }

    private void SetCardDignity(int cardDignity)
    {
        if (cardDignity < 11 && cardDignity > 1)
        {
            dignity.text = cardDignity.ToString();
            return;
        }

        if (cardDignity == 11) dignity.text = "В";
        if (cardDignity == 12) dignity.text = "Д";
        if (cardDignity == 13) dignity.text = "K";
        if (cardDignity == 14) dignity.text = "Т";
    }

    private void SetSuitCardCalor()
    {
        if (CardItem.CardSuit == CardSuit.Hearts || CardItem.CardSuit == CardSuit.Diamonds)
        {
            CardColor = CardColor.Red;
            return;
        }

        CardColor = CardColor.Black;
    }

    private void ClearAll()
    {
        dignity.text = "";
        clubs.SetActive(false);
        diamonds.SetActive(false);
        hearts.SetActive(false);
        spades.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragItem = this;
        startPosition = transform.position;
        StartParrent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragItem = null;
        if (StartParrent == transform.parent)
        {
            transform.position = startPosition;
        }
        transform.localPosition = Vector3.zero;
    }
}