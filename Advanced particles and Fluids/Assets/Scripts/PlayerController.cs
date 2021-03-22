using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
 

        [SerializeField]
        private float Speed = 15f;
        [SerializeField]
        private float JumpPower = 8f;

        private Rigidbody2D rB;
        private Vector2 UpdateForce;

        // Start is called before the first frame update
        void Start()
        {
            rB = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            UpdateForce = Vector2.right * horizontal * Speed;

            if (Input.GetButtonDown("Jump"))
            {
                rB.velocity = new Vector2(rB.velocity.x, 0);
                rB.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            rB.AddForce(UpdateForce);
        }
}
