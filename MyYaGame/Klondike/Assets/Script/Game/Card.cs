using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [FormerlySerializedAs("clubs")] [SerializeField]
    private GameObject _clubs;

    [FormerlySerializedAs("diamonds")] [SerializeField]
    private GameObject _diamonds;

    [FormerlySerializedAs("hearts")] [SerializeField]
    private GameObject _hearts;

    [FormerlySerializedAs("spades")] [SerializeField]
    private GameObject _spades;

    [FormerlySerializedAs("cardClose")] [SerializeField]
    private GameObject _cardClose;

    [SerializeField] private GameObject[] ImagCard;
    [SerializeField] private TextMeshProUGUI dignity;
    [SerializeField] private TextMeshProUGUI dignity2;

    public CardColor CardColor { get; set; }

    public CardItem CardItem { get; set; }

    public bool CardClose { get; set; }

    public bool CardNoDrag { get; set; } = false;

    public float Indent;

    public CardBed CardBed;

    private int _dignity;

    private Vector2 _starPostion;
    private Vector2 _endPostion;
    private float _step = 0f;
    private float _progress = 0f;

    public void MoveCard(Vector2 starPostion, Vector2 endPostion)
    {
        _starPostion = starPostion;
        _endPostion = endPostion;
        _step = 0.05f;
    }

    private void FixedUpdate()
    {
        if (_step > 0)
        {
            transform.position = Vector2.Lerp(_starPostion, _endPostion, _progress);
            _progress += _step;
            if (_progress > 1)
            {
                _step = 0;
                gameObject.transform.localPosition = Vector3.zero;
                if (CardBed is PlayBed)
                {
                    gameObject.transform.Translate(new Vector3(0,
                        CardBed.CardBedState == CardBedState.Empty ? 0 : -Constant.Setting.ClosePlayCardIndent));
                    CardBed.GetCardBedState(null);
                }
            }
        }
    }

    public void SetCard(CardItem cardItem)
    {
        _dignity = cardItem.CardDignity;
        _cardClose.SetActive(false);
        CardClose = false;
        CardItem = cardItem;
        ClearAll();
        SetSuitCardCalor();
        SetCardDignity(cardItem.CardDignity);
        SetCardSuit();

        
        foreach (var i in ImagCard) i.SetActive(false);
            
        if (_dignity > 10 && _dignity < 14)
        {
            Debug.Log(_dignity);
            foreach (var Ic in ImagCard)
            {
                Ic.SetActive(false);
                if (Convert.ToInt32(Ic.name) == _dignity)
                {
                 Ic.SetActive(true);
                }
            }
        }
    }


    public void OnCardClick()
    {
        if (CardBed is DumpBed && ((DumpBed)CardBed).DeckEmty())
        {
            ((DumpBed)CardBed).ReturnDeck();
            return;
        }

        if (CardBed is PlayBed || CardBed is DeckBed)
        {
            if (CardClose)
            {
                _cardClose.SetActive(false);
                CardClose = false;
                if (CardBed is PlayBed) return;
                ((DeckBed)CardBed).SetCardDumpBed(this);
            }
            else
            {
                if (CardBed is DeckBed || !CardClose)
                {
                    ((DeckBed)CardBed).SetCardDumpBed(this);
                }
            }
        }
    }

    public void SetCardClose(bool CardState)
    {
        CardClose = CardState;
        _cardClose.SetActive(CardClose);
    }

    private void SetCardSuit()
    {
        if (CardItem.CardSuit == CardSuit.Clubs) _clubs.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Diamonds) _diamonds.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Hearts) _hearts.SetActive(true);
        if (CardItem.CardSuit == CardSuit.Spades) _spades.SetActive(true);
    }

    private void SetCardDignity(int cardDignity)
    {
        if (cardDignity < 11 && cardDignity > 1)
        {
            dignity.text = cardDignity.ToString();
            dignity2.text = dignity.text;
            return;
        }

        if (cardDignity == 11) dignity.text = "В";
        if (cardDignity == 12) dignity.text = "Д";
        if (cardDignity == 13) dignity.text = "K";
        if (cardDignity == 14) dignity.text = "Т";
        dignity2.text = dignity.text;
    }

    private void SetSuitCardCalor()
    {
        if (CardItem.CardSuit == CardSuit.Hearts || CardItem.CardSuit == CardSuit.Diamonds)
        {
            CardColor = CardColor.Red;
            dignity.color = Color.red;
            dignity2.color = Color.red;
            return;
        }

        CardColor = CardColor.Black;
        dignity.color = Color.black;
        dignity2.color = Color.black;
    }

    private void ClearAll()
    {
        dignity.text = "";
        _clubs.SetActive(false);
        _diamonds.SetActive(false);
        _hearts.SetActive(false);
        _spades.SetActive(false);
    }
}