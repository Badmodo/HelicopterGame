using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private Vector3 axis;

    [SerializeField]
    private float spinSpeed = 10f;
    
    void Update()
    {
        transform.Rotate(axis, spinSpeed);
    }
}
