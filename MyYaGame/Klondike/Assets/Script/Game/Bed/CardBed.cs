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

        if (_cards.Count > 0)
        {
            card.gameObject.transform.SetParent(_cards.Last().gameObject.transform,
                false);
        }
        else
        {
            card.gameObject.transform.SetParent(transform, false);
        }

        card.gameObject.transform.localPosition = Vector3.zero;
        _cards.Add(card);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop-bed");
        GetCards();
        CardBedState = GetCardBedState(_cards);

        if(CardBedState.Empty == CardBedState)
        {
            eventData.pointerDrag.transform.SetParent(transform);
        }
        else
        {
            eventData.pointerDrag.transform.SetParent(_cards.Last().gameObject.transform);
        }

        GetCards();
        
        switch (CardBedState)
        {
            case CardBedState.Empty:
                GetCard(eventData.pointerDrag).Indent = 0f;
                break;
            case CardBedState.AllAreClose:
                GetCard(eventData.pointerDrag).Indent = Constant.Setting.ClosePlayCardIndent;
                break;
            default:
                GetCard(eventData.pointerDrag).Indent = Constant.Setting.OpenCardIndent;
                break;
        }
    }

    private void GetCards()
    {
        _cards = GetComponentsInChildren<Card>().ToList(); 
    }

    private Card GetCard(GameObject obj)
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
                if (CardBedState == CardBedState.AllAreClose && !card.CardClose) 
                    return CardBedState.ThereAreClosed;
            }
            if (CardBedState == CardBedState.AllAreClose) return CardBedState;
            return CardBedState.AllAreOpen;
        }
        return CardBedState.Empty;
    }
}