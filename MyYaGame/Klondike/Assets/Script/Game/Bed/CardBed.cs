using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBed : MonoBehaviour, IDropHandler
{
    public int startingNumberOfCards;
    protected List<Card> _cards = new List<Card>();
    public CardBedState CardBedState;


    public virtual void InsertStartCard(Card insertCard)
    {
        var card = Instantiate(insertCard);
        card.CardItem = insertCard.CardItem;
        card.CardColor = insertCard.CardColor;

        if (_cards.Count > 0)
        {
            card.gameObject.transform.SetParent(_cards.Last().gameObject.transform,
                false);
        }
        else
        {
            card.gameObject.transform.SetParent(transform, false);
        }

        card.CardBed = this;
        card.gameObject.transform.localPosition = Vector3.zero;
        _cards.Add(card);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop-bed");
        GetCards();

        if (!CheckCanMove(eventData))
            GetCard(eventData.pointerDrag).CardNoDrag = true;
            
        CardBedState = GetCardBedState(_cards);

        if(CardBedState.Empty == CardBedState)
        {
            eventData.pointerDrag.transform.SetParent(transform);
        }
        else
        {
            eventData.pointerDrag.transform.SetParent(_cards.Last().gameObject.transform);
        }

        GetCard(eventData.pointerDrag).CardBed = this;
        
        GetCards();
    }

    public virtual bool CheckCanMove(PointerEventData eventData)
    {
        return true;
    }
    protected void GetCards()
    {
        _cards = GetComponentsInChildren<Card>().ToList(); 
    }

    public Card GetCard(GameObject obj)
    {
        return obj.GetComponent<Card>();
    }

    private CardBedState GetCardBedState(List<Card> cards)
    {
        if (cards.Count != 0)
        {
            foreach (var card in cards)
            {
                if (card.CardClose) CardBedState = CardBedState.AllAreClose;
                if (CardBedState == CardBedState.AllAreClose && !card.CardClose) return CardBedState.ThereAreClosed;
            }
            if (CardBedState == CardBedState.AllAreClose) return CardBedState;
            return CardBedState.AllAreOpen;
        }
        return CardBedState.Empty;
    }

    public virtual void InsertCard(Card insertCard)
    {
        GetCards();
        insertCard.gameObject.transform.position = transform.position;
        insertCard.GetComponent<BacklightItem>().Blink(0.01f);
        insertCard.CardNoDrag = false;
        insertCard.CardBed = this;

        if (_cards.Count > 0)
        {
            insertCard.gameObject.transform.SetParent(_cards.Last().gameObject.transform,
                false);
        }
        else
        {
            insertCard.gameObject.transform.SetParent(transform, false);
        }


        insertCard.gameObject.transform.localPosition = Vector3.zero;
        _cards.Add(insertCard);
    }
}