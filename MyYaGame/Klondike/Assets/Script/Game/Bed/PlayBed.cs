using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayBed : CardBed
{
    public override void InsertStartCard(Card insertCard)
    {
        base.InsertStartCard(insertCard);

        if(_cards.Count>1)_cards.Last().gameObject.transform.Translate(new Vector3(0,
            transform.position.y-Constant.Setting.OpenCardIndent));

        if (_cards.Count != startingNumberOfCards)
        {
            _cards.Last().SetCardClose(true);
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        if (eventData.pointerDrag != null)
        {
            _cards.Last().gameObject.transform.Translate(new Vector3(0,
                -Constant.Setting.OpenCardIndent));
        }
    }
    
}