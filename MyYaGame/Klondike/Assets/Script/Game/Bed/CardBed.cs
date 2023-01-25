using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBed : MonoBehaviour,IDragHandler
{
    public int startingNumberOfCards;
    public float CardIndentation = 0f;
    private float _currentIndent = 0f;

    public void InsertStartCard(Card insertCard)
    {
        var card = Instantiate(insertCard.gameObject).GetComponent<Card>();
        card.gameObject.transform.SetParent(transform, false);
        card.gameObject.transform.Translate(new Vector3(0, 
            card.gameObject.transform.position.y+_currentIndent));
        _currentIndent -= CardIndentation;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var item = Card.dragItem;
        if (item!=null)
        {
            item.transform.SetParent(transform);
        }
    }
}