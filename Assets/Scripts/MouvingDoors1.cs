using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvingDoors1 : MonoBehaviour

{
    [SerializeField] private Button1 button;

    void Update()
    {
        if ((button.ButtonHasBeenPressed == true) || (button.ButtonIsPressable == false))
        {
        //Debug.Log("Doors mouve");
        transform.Translate(0, -3, 0);
        }
    }
}
