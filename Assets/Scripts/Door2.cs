using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    private bool player2Ready_ = false;
    public bool Player2Ready => player2Ready_;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player2Ready_ = true;
            Debug.Log("Player 2 Ready");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player2Ready_ = false;
            Debug.Log("Player 2 not Ready");
        }
    }
}
