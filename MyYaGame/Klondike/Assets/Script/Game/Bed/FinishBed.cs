using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinishBed : CardBed
{
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        
        GetCard(eventData.pointerDrag).Indent = 0f;
    }
}
