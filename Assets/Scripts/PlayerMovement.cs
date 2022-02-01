using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    private float movementX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        Debug.Log(movementX);
    }

    private void OnDrop(InputValue movementValue)
    {
        // Turn on gravity
        rb.useGravity = true;
        // Disable player movement
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX * 0.5f, 0.0f, 0.0f);

        // Check the bounds of the player
        if (player.transform.position.x + movement.x <= 10.0f && player.transform.position.x + movement.x >= -10.0f)
        {   
            player.transform.position += movement;
        }
    }
}
