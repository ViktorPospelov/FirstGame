using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dealer : MonoBehaviour
{
    private List<CardItem> _deck = new List<CardItem>();

    [SerializeField] private Card _card;
    [SerializeField] private CardBed[] _cardBeds;

    private void Start()
    {
        _deck = GetCardDeck52();
        SetStartMap();
    }

    private void SetStartMap()
    {
        int installedCard = 0;
        foreach (var bed in _cardBeds)
        {
            var numberOfCards = bed.startingNumberOfCards;
            for (int i = 0; i < numberOfCards; i++)
            {
                _card.SetCard(_deck[installedCard]);
                installedCard++;
                _card.CardItem.CardBed = bed;
                bed.InsertStartCard(_card);
            }
        }
    }

    #region CreateDeck
    private List<CardItem> GetCardDeck52()
    {
        for (int i = 0; i < Enum.GetNames(typeof(CardSuit)).ToArray().Length; i++)
        {
            MakeСardLine((CardSuit)i);
        }
        Shuffle(_deck);
        return _deck;
    } 
    private void MakeСardLine(CardSuit suit)
    {
        for (int i = 2; i <= 14; i++)
        {
            var card = new CardItem(suit,i);
            _deck.Add(card); 
        }
    } 
    private List<CardItem> Shuffle(List<CardItem> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            CardItem temp = deck[i];
            int randomIndex = Random.Range(0, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
        return deck;
    }
   #endregion
}
