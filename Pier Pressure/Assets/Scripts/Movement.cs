using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MaxVelocity = 0.2f;
    public Vector3 Velocity = new Vector3(0.0f, 0.0f, 0.0f);
    public float Acceleration = 5.0f;
    public float TurnRate = 90.0f;
    public float brakeSpeed = 2.0f;
    public bool HasBraked = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateSub();
        moveSub();
    }
    void rotateSub()
    {
        float rotationDelta = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotationDelta += TurnRate * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotationDelta -= TurnRate * Time.deltaTime;
        }
        transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), rotationDelta);
    }
    void moveSub()
    {
        transform.position += Velocity;
        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            Velocity = transform.up * Acceleration * Time.deltaTime;
            if (Velocity.sqrMagnitude >= (MaxVelocity * MaxVelocity))
            {
                Velocity = Velocity.normalized * MaxVelocity;
            }
            HasBraked = false;
        }
        //Backward
        if (Input.GetKey(KeyCode.S))
        {
            
            Velocity /= 1.0f + (brakeSpeed * 0.01f);
            if ((Velocity.x <= 0.001f && Velocity.x > 0.0f) || (Velocity.x >= -0.001f && Velocity.x < 0.0f))
            {
                Velocity = new Vector3(0.0f, Velocity.y, 0.0f);
            }

            if ((Velocity.y <= 0.001f && Velocity.y > 0.0f) || (Velocity.y >= -0.001f && Velocity.y < 0.0f))
            {
                Velocity = new Vector3(Velocity.x, 0.0f, 0.0f);
            }
            if (Velocity.sqrMagnitude <= 0.001f && HasBraked == false)
            {
                HasBraked = true;
            }
            if (HasBraked == true)
            {
                Velocity = -(transform.up * Acceleration * Time.deltaTime) / 2;
                if (Velocity.sqrMagnitude <= -(MaxVelocity * MaxVelocity))
                {
                    Velocity = -(Velocity.normalized * MaxVelocity) / 2;
                }
            }
        }
        //Drag Effect
        if (Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.W) == false)
        {
            Velocity /= 1.0f + ((brakeSpeed * 0.01f) * 0.25f);
            if ((Velocity.x <= 0.001f && Velocity.x > 0.0f) || (Velocity.x >= -0.001f && Velocity.x < 0.0f))
            {
                Velocity = new Vector3(0.0f, Velocity.y, 0.0f);
            }

            if ((Velocity.y <= 0.001f && Velocity.y > 0.0f) || (Velocity.y >= -0.001f && Velocity.y < 0.0f))
            {
                Velocity = new Vector3(Velocity.x, 0.0f, 0.0f);
            }
        }
    }
}
