using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    

    private void FixedUpdate()
    {
        rb.velocity = movementInput * movementSpeed;
    }
    private void OnMove(InputValue inputValue)
    {
       movementInput = inputValue.Get<Vector2>();
    }
}
