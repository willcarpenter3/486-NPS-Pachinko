using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    private float movementX;

    Input controls;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //controls = new Input();

        //#region ControlMapping
        //controls.Player.Move.performed += OnMove;
        //controls.Player.Move.canceled += ctx => movementX = 0;
        //controls.Player.Move.Enable();
        //controls.Player.Drop.performed += OnDrop;
        //controls.Player.Drop.Enable();
        //#endregion
    }

    //private void OnMove(CallbackContext ctx)
    //{
    //    movementX = ctx.ReadValue<float>();
    //    Vector2 movementVector = movementX * (new Vector2(1f, 0f));
    //    //movementX = movementVector.x;
    //    Debug.Log(movementX);
    //}

    //private void OnDrop(CallbackContext ctx)
    //{
    //    // Turn on gravity
    //    rb.useGravity = true;
    //    // Disable player movement
    //    player.GetComponent<PlayerMovement>().enabled = false;
    //}

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
