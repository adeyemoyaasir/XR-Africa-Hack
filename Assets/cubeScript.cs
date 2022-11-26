using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour
{
    
    bool isPressed = false;

    public float rotSpeed;

    public void pressed()
    {
        isPressed = true;
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void released()
    {
        isPressed = false;
        GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
    }
}
