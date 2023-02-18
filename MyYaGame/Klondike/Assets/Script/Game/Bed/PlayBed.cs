using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayBed : CardBed
{
    public override void InsertStartCard(Card insertCard)
    {
        base.InsertStartCard(insertCard);

        if(_cards.Count>1)_cards.Last().gameObject.transform.Translate(new Vector3(0,-Constant.Setting.ClosePlayCardIndent));

        if (_cards.Count != startingNumberOfCards)
        {
            _cards.Last().SetCardClose(true);
        }
    }

    public override bool CheckCanMove(PointerEventData eventData)
    {
        if (_cards.Count > 0 && !_cards.Last().CardClose)
        { 
            if (GetCard(eventData.pointerDrag).CardColor == _cards.Last().CardColor) return false;
        }

        return true;
    }
}