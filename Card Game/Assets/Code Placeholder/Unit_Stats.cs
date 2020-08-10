using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Stats : MonoBehaviour
{
    public bool friendly;

    public int health;
    public int armor;

    public GameObject player;

    private void OnMouseDown()
    {
        if (player.GetComponent<Player_Overview>().selectedCard != null)
        {
            player.GetComponent<Player_Overview>().selectedCard.SendMessage("CardAction", this.gameObject);
        }
    }
}