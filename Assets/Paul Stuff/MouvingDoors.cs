using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvingDoors : MonoBehaviour
{

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        Debug.Log("Doors mouve");
        //position += Vector3.up * 10.0f;
        transform.Translate(0, -3, 0);
        }
    }
}
