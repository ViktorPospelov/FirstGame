using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    [SerializeField] private Transform tranform1;
    [SerializeField] private Transform tranform2;
    
    [SerializeField] private Card Card;
    [SerializeField] private GameObject CardBed;
    
    void Start()
    {

        var i = Instantiate(CardBed);
        
        i.transform.SetParent(tranform1.transform,false);
        
        var g = Instantiate(Card.gameObject).GetComponent<Card>();
        g.gameObject.transform.SetParent(i.transform,false);
        g.SetCard(CardSuit.Spades,12);
        
        
        
        
        
    }
}
