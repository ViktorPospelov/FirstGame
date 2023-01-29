using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBed : MonoBehaviour, IDropHandler
{
    public int startingNumberOfCards;
    public float CardIndentation = 0f;
    private List<Card> _cards = new List<Card>();

    public void InsertStartCard(Card insertCard) //устоновить карту 
    {
        var card = Instantiate(insertCard.gameObject).GetComponent<Card>(); //встваить карту

        if (_cards.Count > 0) //если карты в колоде есть
        {
            card.gameObject.transform.SetParent(_cards[_cards.Count - 1].gameObject.transform,
                false); //встваить в другую карту
        }
        else //если нету
        {
            card.gameObject.transform.SetParent(transform, false); //встваить текуший кардБед
        }

        card.gameObject.transform.Translate(new Vector3(0,
            -CardIndentation)); //подвинуть на отступ вниз

        _cards.Add(card); //добавить карту в список
    }

    public void OnDrop(PointerEventData eventData) //при сбросе над бед
    {
        _cards = GetComponentsInChildren<Card>().ToList(); //взятрь карты 
        if (eventData.pointerDrag != null) //если не ноль
        {
            if (_cards.Count > 0) //если в списке карт этого обьекта больше 0
            {
                
                eventData.pointerDrag.transform.SetParent(_cards[_cards.Count - 1].gameObject.transform); //то карта в карту
                
            }
            else //иначе
            {
                eventData.pointerDrag.transform.SetParent(transform);
                
            }
        }
    }
}
    