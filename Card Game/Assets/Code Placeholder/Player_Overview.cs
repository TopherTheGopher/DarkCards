using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Overview : MonoBehaviour
{
    // temp to be removed
    public GameObject cardTemp;

    // Cards in Hand
    public List<GameObject> cardsInHand;

    // Card location on board
    public GameObject cardCenter;
    public float cardOffset = 0.66f;

    // deck and drawing
    public List<GameObject> deck;
    public List<GameObject> discardPile;
    public int cardsToDraw = 5;
    private int maxCardsInHand = 12;

    // Playfield
    public GameObject selectedCard;
    
    private void shuffle(bool discardStack, bool hand)
	{
        // add the discard pile back into the deck
        if (discardStack)
		{
			for (int i = discardPile.Count - 1; i >= 0; --i)
			{
                deck.Add(discardPile[i]);
                discardPile.RemoveAt(i);
			}
		}
        // add your hand back into the deck
        if (hand)
		{
            for (int i = cardsInHand.Count - 1; i >= 0; --i)
            {
                deck.Add(cardsInHand[i]);
                cardsInHand.RemoveAt(i);
            }
        }
        // shuffle
        for(int i = 0; i < deck.Count; ++i)
		{
            GameObject temp = deck[i];
            int randInt = Random.Range(i, deck.Count);
            deck[i] = deck[randInt];
            deck[randInt] = temp;
		}
	}
    
    public void DrawCard()
	{
        GameObject tmpCard = Instantiate(cardTemp);
        tmpCard.transform.SetParent(cardCenter.transform);
        cardsInHand.Add(tmpCard);
        CardDrawn();
    }

    private void CardDrawn()
	{
        // Check to see if card can be drawn (set amount of cards allowed in their hand)
        SpreadHand();
    }

    private void SpreadHand()
    {
        //Even
        if (cardsInHand.Count % 2 == 0)
        {
            //Left
            for (int i = 1; i <= cardsInHand.Count / 2; ++i)
            {
                cardsInHand[i - 1].transform.localPosition = new Vector3(
                    (cardOffset * (i - (cardsInHand.Count / 2))) - (cardOffset / 2), 0.0f, 0.0f);
            }
            //Right
            for (int i = cardsInHand.Count / 2; i < cardsInHand.Count; ++i)
            {
                cardsInHand[i].transform.localPosition = new Vector3(
                    (cardOffset / 2) + (cardOffset * (i - (cardsInHand.Count / 2))), 0.0f, 0.0f);
            }
        }
        //Odd
        else
        {
            // Both Left and Right
            for (int i = 0; i < cardsInHand.Count; ++i)
            {
                cardsInHand[i].transform.localPosition = new Vector3(
                    (cardOffset * (i - (cardsInHand.Count / 2))), 0.0f, 0.0f);
            }
        }
    }

}