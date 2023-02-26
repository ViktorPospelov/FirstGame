using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DumpBed : CardBed
{
    
    [SerializeField] private DeckBed deckBed;
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);

        eventData.pointerDrag.gameObject.GetComponent<Card>().SetCardClose(false);
    }
    public void ReturnDeck()
    {
        GetCards();
        deckBed.SetCardBack(_cards);
        _cards = null;
    }

    public bool DeckEmty()
    {
        if (deckBed.DeckEmty()) return true;

        return false;
    }
}