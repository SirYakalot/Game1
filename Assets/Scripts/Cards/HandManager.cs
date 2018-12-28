using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : StateScript
{
    public List<Card> queuedCards = new List<Card>();
    private List<GameObject> cardSlots = new List<GameObject>();
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    // Start is called before the first frame update
    void Start()
    {
        cardSlots.Add(slot1);
        cardSlots.Add(slot2);
        cardSlots.Add(slot3);
        cardSlots.Add(slot4);
        cardSlots.Add(slot5);

        Go(Idle(), null);
    }

    private IEnumerator Idle()
    {
        yield return new WaitUntil(() => queuedCards.Count > 0);
        Go(AddCardToHand(), null);
    }

    private IEnumerator AddCardToHand()
    {
        // this obviously doesn't work - just putting here to test once. 
        cardSlots[0].GetComponent<CardSlot>().CardInstance = queuedCards[0];
        
        if (queuedCards.Count == 0)
        {
            Go(Idle(), null);
            yield break;
        }
        else
        {
            Go(AddCardToHand(), null);
            yield break;
        }
    }
}
