using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckBed : CardBed
{
    [SerializeField] private DumpBed dumpBed;

    public override void InsertStartCard(Card insertCard)
    {
        base.InsertStartCard(insertCard);
        
        _cards.Last().gameObject.transform.Translate(new Vector3(-Constant.Setting.CloseCardIndent,
            Constant.Setting.CloseCardIndent));

        _cards.Last().SetCardClose(true);

    }

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        
            eventData.pointerDrag.gameObject.GetComponent<Card>().SetCardClose(true);
            GetCard(eventData.pointerDrag).Indent = 0f;
    }

    public void SetCardDumpBed(Card insertCard)
    {
        dumpBed.InsertCard(insertCard);
    }
}
