using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    private bool buttonHasBeenPressed_ = false;
    private bool buttonIsPressable_ = true;
    public bool ButtonHasBeenPressed => buttonHasBeenPressed_;
    public bool ButtonIsPressable => buttonIsPressable_;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.layer == LayerMask.NameToLayer("Player")) || (buttonIsPressable_ = true))
        {
            buttonHasBeenPressed_ = true;
            buttonIsPressable_ = false;
            Debug.Log("button 1 pressed");

        }
    }
}

