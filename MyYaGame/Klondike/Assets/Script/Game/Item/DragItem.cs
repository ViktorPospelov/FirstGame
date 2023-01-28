using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static DragItem dragItem;
    public Vector3 startPosition;
    public Transform StartParrent;
    private CanvasGroup _canvasGroup;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragItem = this;
        startPosition = transform.position;
        StartParrent = transform.parent;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 1));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragItem = null;
        _canvasGroup.blocksRaycasts = true;
        if (StartParrent == transform.parent)
        {
            transform.position = startPosition;
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}