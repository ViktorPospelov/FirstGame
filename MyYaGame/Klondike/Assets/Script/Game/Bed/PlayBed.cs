using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayBed : CardBed
{
    public override void InsertStartCard(Card insertCard, DeckBed deckBed)
    {
        base.InsertStartCard(insertCard, deckBed);

        if (_cards.Count > 1)
            _cards.Last().gameObject.transform.Translate(new Vector3(0, -Constant.Setting.ClosePlayCardIndent));

        if (_cards.Count != startingNumberOfCards)
        {
            _cards.Last().SetCardClose(true);
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);

        switch (CardBedState)
        {
            case CardBedState.Empty:
                GetCard(eventData.pointerDrag).Indent = 0f;
                break;
            case CardBedState.AllAreClose:
                GetCard(eventData.pointerDrag).Indent = Constant.Setting.ClosePlayCardIndent;
                break;
            default:
                GetCard(eventData.pointerDrag).Indent = Constant.Setting.OpenCardIndent;
                break;
        }
    }

    public override bool CheckCanMove(PointerEventData eventData)
    {
        GetCards();
        if (_cards.Count > 0 && !_cards.Last().CardClose)
        {
            if(GetCard(eventData.pointerDrag).CardItem.CardDignity != _cards.Last().CardItem.CardDignity-1) return false;
            if (GetCard(eventData.pointerDrag).CardColor == _cards.Last().CardColor) return false;
        }

        if (_cards.Count == 0 && GetCard(eventData.pointerDrag).CardItem.CardDignity != 13) return false;

        return true;
    }
}