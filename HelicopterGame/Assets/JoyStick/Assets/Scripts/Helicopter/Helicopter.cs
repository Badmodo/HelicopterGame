using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float upSpeed = 2f;
    [SerializeField]
    private float maxSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Quaternion deviceRotation = DeviceRotation.Get();

        transform.rotation = deviceRotation;

        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);

        rb.AddForce(transform.up * upSpeed, ForceMode.Acceleration);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
