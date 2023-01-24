using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class Dealer
{
    private List<CardItem> _deck = new List<CardItem>();

    private const int Suits = 4;
    public List<CardItem> GatCardDeck52()
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
}
