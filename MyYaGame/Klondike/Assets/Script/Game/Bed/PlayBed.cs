using UnityEngine;

public class PlayBed : CardBed
{
    public override void InsertStartCard(Card insertCard)
    {
        base.InsertStartCard(insertCard);

        if(_cards.Count>1)_cards[_cards.Count - 1].gameObject.transform.Translate(new Vector3(0,
            transform.position.y-CardIndentation));

        if (_cards.Count != startingNumberOfCards)
        {
            _cards[_cards.Count - 1].SetCardClose(true);
        }
    }
}