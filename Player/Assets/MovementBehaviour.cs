using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour {

    public float walkingSpeed;
    public float turingSpeed;
    public float runningSpeed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                var changeInPosition = transform.forward * Time.deltaTime * runningSpeed;

                transform.position = transform.position + changeInPosition;
            }
            else
            {
                var changeInPosition = transform.forward * Time.deltaTime * walkingSpeed;

                transform.position = transform.position + changeInPosition;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            var changeInPosition = -transform.forward * Time.deltaTime * walkingSpeed;

            transform.position = transform.position + changeInPosition;
        }

        if (Input.GetKey(KeyCode.D))
        {
            var angle = Time.deltaTime * turingSpeed;
            transform.Rotate(0f, angle, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            var angle = -Time.deltaTime * turingSpeed;
            transform.Rotate(0f, angle, 0f);
        }
    }
}
