using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBed : MonoBehaviour, IDropHandler
{
    public int startingNumberOfCards;
    public float CardIndentation = 0f;
    protected List<Card> _cards = new List<Card>();

    public virtual void InsertStartCard(Card insertCard) 
    {
        var card = Instantiate(insertCard);
        
        if (_cards.Count > 0)
        {
            card.gameObject.transform.SetParent(_cards[_cards.Count - 1].gameObject.transform,
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
        _cards = GetComponentsInChildren<Card>().ToList(); 
        if (eventData.pointerDrag != null)
        {
            if (_cards.Count > 0)
            {
                eventData.pointerDrag.transform.SetParent(_cards[_cards.Count - 1].gameObject.transform);
            }
            else
            {
                eventData.pointerDrag.transform.SetParent(transform);
            }
           if(_cards.Count>1) _cards[_cards.Count-1].gameObject.transform.Translate(new Vector3(0,
                -CardIndentation));
        }
    }
}
    