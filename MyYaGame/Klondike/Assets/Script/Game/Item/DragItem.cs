using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float Indent;
    private Vector3 _startPosition;
    private Transform _startParrent;
    private Vector3 _localTransform;
    private CanvasGroup _canvasGroup;
    private Transform _dragLayer;
    private CardBed _starCardBed;
    
    [SerializeField] private Card _card;
    [SerializeField] private BacklightItem _backlightItem;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _dragLayer = GameObject.FindWithTag("DragLayer").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       _starCardBed = _card.CardBed;
        
        _startPosition = transform.position;
        _startParrent = transform.parent;
        _canvasGroup.blocksRaycasts = false;

        if (!_card.CardClose)
        {
            _localTransform = transform.localPosition - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x,
                eventData.position.y, 1));
            eventData.pointerDrag.transform.SetParent(_dragLayer);
        }
        else
        {
            Debug.Log("Работает");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        if (!_card.CardClose)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x,
                eventData.position.y, 1) + _localTransform);
        }
        else
        {
            transform.position = _startPosition;
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
       
        _canvasGroup.blocksRaycasts = true;
       
        if (_dragLayer == transform.parent || _card.CardClose || _card.CardNoDrag)
        {
            transform.position = _startPosition;
            transform.SetParent(_startParrent);
            _backlightItem.Blink(0.02f);
            _card.CardNoDrag = false;
            _card.CardBed = _starCardBed;
        }
        else
        {
            transform.localPosition = Vector3.zero;
            
            Indent = _card.Indent;
            if (Indent == 0f)
            {
                transform.Translate(new Vector3(0, 0));
            }
            else
            {
                transform.Translate(new Vector3(0, -Indent));        
            }
        }
        
    }
   
}