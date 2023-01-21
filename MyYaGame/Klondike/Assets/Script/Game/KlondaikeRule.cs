using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlondaikeRule
{
    private List<CardItem> _deck = new List<CardItem>();
    public List<CardItem> GatCardDeck52()
    {
        MakeСardLine(CardSuit.Diamonds);
        MakeСardLine(CardSuit.Hearts);
        MakeСardLine(CardSuit.Spades);
        MakeСardLine(CardSuit.Clubs);
        return _deck;
    }

    private void MakeСardLine(CardSuit suit)
    {
        for (int i = 2; i <= 14; i++)
        {
            var card = new CardItem(suit,i);
            _deck.Add(card); 
        }

        Shuffle(_deck);
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
