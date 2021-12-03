using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MOVE_SPEED = 12f;
    private Rigidbody2D compRB;
    private Vector2 movement;

    private void Awake()
    {
        compRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            MovementInput();
        }
    }
    private void FixedUpdate()
    {
        compRB.velocity = movement * MOVE_SPEED;
    }
    void MovementInput()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
    }
}
