using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvingDoors2 : MonoBehaviour

{
    [SerializeField] private Button2 button;

    void Update()
    {
        if ((button.ButtonHasBeenPressed == true) || (button.ButtonIsPressable == false))
        {
            //Debug.Log("Doors 2 mouve");
            transform.Translate(0, -3, 0);
        }
    }
}
