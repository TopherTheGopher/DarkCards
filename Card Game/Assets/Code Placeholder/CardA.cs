using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Basic Attack
public class CardA : MonoBehaviour
{
    public Player_Overview player;

    public Card_Stats card_Data;

    private int damage = 8;

    private void OnMouseDown()
    {
        player.selectedCard = gameObject;
    }

    private void CardAction(GameObject character)
    {
        // deal damage test
        character.GetComponent<Unit_Stats>().health -= damage;
    }
}
