using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviour
{
   public Rigidbody rg;
   public float forwardMoveSpeed;
   public float backwardMoveSpeed;
   public float steerSpeed;

   public Vector2 input;
   
   void FixedUpdate() // Apply physics here
   {
       // Accelerate
       float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
       if (input.y == 0) speed = 0;
       rg.AddForce(this.transform.forward * speed, ForceMode.Acceleration);
       // Steer
       float rotation = input.x * steerSpeed * Time.fixedDeltaTime;
       transform.Rotate(0, rotation, 0, Space.World);
   }

   public void SetInputs(Vector2 input)
   {
       this.input = input;
   }

   // getSpeed method
    public float GetSpeed()
    {
         return rg.velocity.magnitude;
    }
}