using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DumpBed : CardBed
{
    
    [SerializeField] private DeckBed deckBed;
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        
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

    public override bool CheckCanMove(PointerEventData eventData)
    {
        return false;
    }
}