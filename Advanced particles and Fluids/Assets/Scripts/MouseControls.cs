using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour
{
    public GameObject leftClicker;
    public GameObject rightClicker;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(leftClicker, transform.position, Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(rightClicker, transform.position, Quaternion.identity);
        }
    }
}
