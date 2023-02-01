using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DumpBed : CardBed
{
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);

        eventData.pointerDrag.gameObject.GetComponent<Card>().SetCardClose(false);
    }
}