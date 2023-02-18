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
    [SerializeField] private Card _card;
    [SerializeField] private BacklightItem _backlightItem;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _dragLayer = GameObject.FindWithTag("DragLayer").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
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
        Debug.Log("OnDrag");
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
        Debug.Log("OnEndDrag");
        _canvasGroup.blocksRaycasts = true;
       
        if (_dragLayer == transform.parent || _card.CardClose || _card.CardNoDrag)
        {
            transform.position = _startPosition;
            transform.SetParent(_startParrent);
            _backlightItem.Blink();
            _card.CardNoDrag = false;
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