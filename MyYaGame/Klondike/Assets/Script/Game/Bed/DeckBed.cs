using UnityEngine;
using UnityEngine.EventSystems;

public class DeckBed : CardBed
{
    public override void InsertStartCard(Card insertCard)
    {
        base.InsertStartCard(insertCard);
        
        _cards[_cards.Count-1].gameObject.transform.Translate(new Vector3(-CardIndentation,
            CardIndentation));

        _cards[_cards.Count - 1].SetCardClose(true);

    }
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        
        eventData.pointerDrag.gameObject.GetComponent<Card>().SetCardClose(true);
    }
}
