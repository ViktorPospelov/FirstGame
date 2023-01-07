using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    [SerializeField] private GameObject tranform1;
    [SerializeField] private GameObject tranform2;
    
    [SerializeField] private GameObject Card;
    [SerializeField] private GameObject CardBed;
    
    void Start()
    {

        Instantiate(CardBed, tranform1.transform.parent);
        var r =Instantiate(CardBed, tranform2.transform.parent);
        
        var i = Instantiate(Card, r.transform.parent).GetComponent<Card>();
        i.SetCard(CardSuit.Hearts,13);
    }
}
