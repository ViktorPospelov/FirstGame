

public class CardItem 
{
    public CardItem(CardSuit cardSuit,int cardDignity)
    {
        CardSuit = cardSuit;
        CardDignity = cardDignity;
    }

    public CardSuit CardSuit { get;  set; }
    public int CardDignity { get;  set; }
    
    public CardBed CardBed { get;  set; }
}
