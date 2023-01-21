using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    [SerializeField] private Transform tranform1;
    [SerializeField] private Transform tranform2;

    [SerializeField] private Card Card;
    [SerializeField] private GameObject CardBed;

    void Start()
    {
        var u = new KlondaikeRule().GatCardDeck52();

        var i = Instantiate(CardBed);

        float otst = 0f;
        
        foreach (var cI in u)
        {
            otst-=0.5f;
            i.transform.SetParent(tranform1.transform, false);

            var g = Instantiate(Card.gameObject).GetComponent<Card>();
            g.gameObject.transform.SetParent(i.transform, false);
            g.gameObject.transform.Translate(new Vector3(g.gameObject.transform.position.x,g.gameObject.transform.position.y+otst));
            g.SetCard(cI);
            
            
        }
    }
}