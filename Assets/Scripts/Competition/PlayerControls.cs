using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{

    private float inputX;
    private float inputY;
    private Vector2 inputVector;
    public UnityEvent<Vector2> onInput;

    void Update() // Get keyboard inputs
   {
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");
        inputVector = new Vector2(inputX, inputY).normalized;
        onInput.Invoke(inputVector);
   }
}
