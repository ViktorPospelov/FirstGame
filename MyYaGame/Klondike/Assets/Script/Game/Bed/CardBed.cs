using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBed : MonoBehaviour, IDropHandler
{
    public int startingNumberOfCards;
    protected List<Card> _cards = new List<Card>();


    public virtual void InsertStartCard(Card insertCard)
    {
        var card = Instantiate(insertCard);

        if (_cards.Count > 0)
        {
            card.gameObject.transform.SetParent(_cards.Last().gameObject.transform,
                false);
        }
        else
        {
            card.gameObject.transform.SetParent(transform, false);
        }

        card.gameObject.transform.localPosition = Vector3.zero;
        _cards.Add(card);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        _cards = GetComponentsInChildren<Card>().ToList();
        startingNumberOfCards = _cards.Count;

        if (eventData.pointerDrag != null)
        {
            if (_cards.Count > 0)
            {
                eventData.pointerDrag.transform.SetParent(_cards.Last().gameObject.transform);
            }
            else
            {
                eventData.pointerDrag.transform.SetParent(transform);
            }

            if (_cards.Count > 1)
            {
                eventData.pointerDrag.gameObject.transform.Translate(new Vector3(0,
                    -Constant.Setting.OpenCardIndent));
            }

            _cards = GetComponentsInChildren<Card>().ToList();

            if (_cards.Last().CardClose)
            {
                _cards.Last().Indent = Constant.Setting.CloseCardIndent;
            }
            else
            {
                _cards.Last().Indent = Constant.Setting.OpenCardIndent;
            }
            

        }
    }
}