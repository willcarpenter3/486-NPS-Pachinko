using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    private float movementX;

    Input controls;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movement)
    {
        //movementX = ctx.ReadValue<float>();
        Vector2 movementVector = movement.Get<Vector2>(); //movementX * (new Vector2(1f, 0f));
        movementX = movementVector.x;
        Debug.Log(movementX);
    }

    private void OnDrop(InputValue drop)
    {
        // Turn on gravity
        rb.useGravity = true;
        // Disable player movement
        player.GetComponent<PlayerMovement>().enabled = false;
        GameManager.Instance.setIsPlaying(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Peg")
        {
            // Disable the collided object
            collision.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX * 0.5f, 0.0f, 0.0f);

        // Check the bounds of the player
        if (player.transform.rotation.y + movement.x <= 80.0f && player.transform.rotation.x + movement.y >= -80.0f)
        {   
            // Rotate the player
            player.transform.Rotate(0.0f, movementX * -1.0f, 0.0f);
        }
    }
}
