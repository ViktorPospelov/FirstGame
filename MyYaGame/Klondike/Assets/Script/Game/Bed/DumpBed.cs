using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DumpBed : CardBed
{
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);

        eventData.pointerDrag.gameObject.GetComponent<Card>().SetCardClose(false);
    }

    public void InsertCard(Card insertCard)
    {
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