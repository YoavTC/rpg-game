using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable InconsistentNaming 
public class playerMovement : MonoBehaviour {

    public playerInteract playerInteractScript;
    public chatHandler chatHandlerScript;

    public GameObject player;
    public bool facingRight = false;
    public float speed = 6.5f;

    bool pressUp, pressDown, pressLeft, pressRight;

    void FixedUpdate()
    {
        if (!playerInteractScript.isInteracting)
        {
            UpdateLoc();
        }
    }

    private void UpdateLoc()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement != Vector2.zero)
        {
            transform.position = (Vector2)transform.position + movement.normalized * speed * Time.deltaTime;

            if (movement.x < 0)
            {
                turnPlayer(false);
            }
            else if (movement.x > 0)
            {
                turnPlayer(true);
            }
        }
    }
    private void turnPlayer(bool turnRight)
    {
        if (turnRight && !facingRight)
        {
            Vector3 flip = player.transform.localScale;
            flip.x *= -1;
            player.transform.localScale = flip;
            facingRight = true;
        }
        if (!turnRight && facingRight)
        {
            Vector3 flip = player.transform.localScale;
            flip.x *= -1;
            player.transform.localScale = flip;
            facingRight = false;
        }
    }
}
