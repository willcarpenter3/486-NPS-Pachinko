using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject player;
    private Rigidbody rb;
    private float movementX;
    private bool paused = false;

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
    }

    private void OnPause(InputValue pause)
    {
        if (!paused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            paused = true;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            paused = false;
        }
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
