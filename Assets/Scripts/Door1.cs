using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    private bool player1Ready_ = false;
    public bool Player1Ready => player1Ready_;
    [SerializeField] private Door2 secondDoor;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player1Ready_ = true;
            Debug.Log("Player 1 Ready");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player1Ready_ = false;
            Debug.Log("Player 1 not Ready");
        }
    }

    void Update()
    {
        if ((Player1Ready == true) || (secondDoor.Player2Ready == true))
        {
            Debug.Log("Endgame");
        }
    }
}



