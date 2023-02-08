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
        _cards = GetComponentsInChildren<Card>().ToList();
        CardBedState = GetCardBedState(_cards);

        switch (CardBedState)
        {
            case CardBedState.Empty:
                eventData.pointerDrag.transform.SetParent(transform);
                _cards.Last().Indent = 0f;
                
                break;
            case CardBedState.ThereAreClosed:
                
                break;
            case CardBedState.AllAreOpen:
                
                break;
        }
        

        if (eventData.pointerDrag != null)
        {
            if (_cards.Count > 0)
            {
                eventData.pointerDrag.transform.SetParent(_cards.Last().gameObject.transform);
            }
            else
            {
                /// 0
            }

            if (_cards.Count > 1)
            {
                eventData.pointerDrag.gameObject.transform.Translate(new Vector3(0,
                    -Constant.Setting.OpenCardIndent));
            }

            _cards = GetComponentsInChildren<Card>().ToList();
            
            if (_cards.Count > 1)
            {
                if (_cards.Last().CardClose)
                {
                    _cards.Last().Indent = Constant.Setting.CloseCardIndent;
                }
                else
                {
                    _cards.Last().Indent = Constant.Setting.OpenCardIndent;
                }
            }
            else
            {
                // 0
            }
        }
    }

    private CardBedState GetCardBedState(List<Card> cards)
    {
        if (cards.Count != 0)
        {
            foreach (var card in cards)
            {
                if (card.CardClose) return CardBedState.ThereAreClosed;
            }
            return CardBedState.AllAreOpen;
        }
        return CardBedState.Empty;
    }
}