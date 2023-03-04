using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinishBed : CardBed
{
    private CardSuit _cardSuit;
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        
        GetCard(eventData.pointerDrag).Indent = 0f;
    }
    public override bool CheckCanMove(PointerEventData eventData)
    {
        GetCards();
        if (_cards.Count == 0)
        {
            if (GetCard(eventData.pointerDrag).CardItem.CardDignity == 14) return true;
        }

        if (_cards[0].CardItem.CardSuit != GetCard(eventData.pointerDrag).CardItem.CardSuit) return false;

        if (_cards.Last().CardItem.CardDignity + 1 == GetCard(eventData.pointerDrag).CardItem.CardDignity)
                return true;
        if (_cards.Count == 1 && GetCard(eventData.pointerDrag).CardItem.CardDignity == 2) return true;
        
        return false;
    }
}
