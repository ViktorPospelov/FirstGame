using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _startPosition;
    private Transform _startParrent;
    private Vector3 _localTransform;
    private CanvasGroup _canvasGroup;
    private Transform _dragLayer;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _dragLayer = GameObject.FindWithTag("DragLayer").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
            _startPosition = transform.position;
            _startParrent = transform.parent;
        

        _canvasGroup.blocksRaycasts = false;

        _localTransform = transform.localPosition - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x,
            eventData.position.y, 1));
        eventData.pointerDrag.transform.SetParent(_dragLayer);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x,
            eventData.position.y, 1) + _localTransform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        if (_dragLayer == transform.parent)
        {
            transform.position = _startPosition;
            transform.SetParent(_startParrent);
        }
        else
        {
            transform.localPosition = Vector3.zero;
            transform.Translate(new Vector3(0,
                -0.5f));
        }
    }
}