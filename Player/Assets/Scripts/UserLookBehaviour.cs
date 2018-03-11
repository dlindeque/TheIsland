using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserLookBehaviour : MonoBehaviour
{

    public float rotationSpeed;
    public float returnSpeed;
    public Transform head;
    public Transform eyes;

    public float maxHeadHorizontalAngle;
    public float maxHeadUpAngle;
    public float maxHeadDownAngle;
    public float maxEyesHorizontalAngle;
    public float maxEyesVerticalAngle;

    private float x = 0f;
    private float y = 0f;

    private void FixedUpdate()
    {
        // Increase angle based on key
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            y -= Time.deltaTime * (rotationSpeed + returnSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            y += Time.deltaTime * (rotationSpeed + returnSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            x -= Time.deltaTime * (rotationSpeed + returnSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            x += Time.deltaTime * (rotationSpeed + returnSpeed);
        }

        // Return back to 0,0 and calculate head and eyes rotations
        float headx = 0f, heady = 0f;
        if (y > 0)
        {
            // looking right
            y -= Time.deltaTime * returnSpeed;
            if (y < 0) y = 0;
            float m = maxHeadHorizontalAngle + maxEyesHorizontalAngle;
            if (y > m) y = m;
            heady = y * maxHeadHorizontalAngle / m;
        }
        else if (y < 0)
        {
            // looking left
            y += Time.deltaTime * returnSpeed;
            if (y > 0) y = 0;
            float m = maxHeadHorizontalAngle + maxEyesHorizontalAngle;
            if (y < -m) y = -m;
            heady = y * maxHeadHorizontalAngle / m;
        }

        if (x > 0)
        {
            // looking down
            x -= Time.deltaTime * returnSpeed;
            if (x < 0) x = 0;
            float m = maxHeadDownAngle + maxEyesVerticalAngle;
            if (x > m) x = m;
            headx = x * maxHeadDownAngle / m;
        }
        else if (x < 0)
        {
            // looking up
            x += Time.deltaTime * returnSpeed;
            if (x > 0) x = 0;
            float m = maxHeadUpAngle + maxEyesVerticalAngle;
            if (x < -m) x = -m;
            headx = x * maxHeadUpAngle / m;
        }

        head.rotation = transform.rotation * Quaternion.Euler(0f, heady, 0f) * Quaternion.Euler(headx, 0f, 0f);
        eyes.rotation = transform.rotation * Quaternion.Euler(0f, y, 0f) * Quaternion.Euler(x + 25, 0f, 0f);
    }
}
