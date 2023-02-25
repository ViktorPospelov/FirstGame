using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [FormerlySerializedAs("clubs")] [SerializeField]
    private GameObject _clubs;

    [FormerlySerializedAs("diamonds")] [SerializeField]
    private GameObject _diamonds;

    [FormerlySerializedAs("hearts")] [SerializeField]
    private GameObject _hearts;

    [FormerlySerializedAs("spades")] [SerializeField]
    private GameObject _spades;

    [FormerlySerializedAs("cardClose")] [SerializeField]
    private GameObject _cardClose;


    [SerializeField] private TextMeshProUGUI dignity;

    public CardColor CardColor { get; set; }

    public CardItem CardItem { get; set; }

    public bool CardClose { get; set; }

    public bool CardNoDrag { get; set; } = false;

    public float Indent;

    public CardBed CardBed;


    public void SetCard(CardItem cardItem)
    {
        _cardClose.SetActive(false);
        CardClose = false;
        CardItem = cardItem;
        ClearAll();
        SetSuitCardCalor();
        SetCardDignity(cardItem.CardDignity);
        SetCardSuit();
    }

    public void OnCardClick()
    {
        if (CardBed is PlayBed || CardBed is DeckBed)
        {
            if (!CardClose) return;

            _cardClose.SetActive(false);
            CardClose = false;
        }  

        if (CardBed is DeckBed)
        {
            ((DeckBed)CardBed).SetCardDumpBed(this);
        }
    }

    public void SetCardClose(bool CardState)
    {
        CardClose = CardState;
        _cardClose.SetActive(CardClose);
    }

    private void SetCardSuit()
    {
        if (CardItem.CardSuit == CardSuit.Clubs) _clubs.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Diamonds) _diamonds.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Hearts) _hearts.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Spades) _spades.SetActive(true);
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
        _clubs.SetActive(false);
        _diamonds.SetActive(false);
        _hearts.SetActive(false);
        _spades.SetActive(false);
    }
}