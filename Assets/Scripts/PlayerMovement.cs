using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject container;
    public GameObject pointer;
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
    }

    private void OnDrop(InputValue drop)
    {
        // Disable pointer
        pointer.SetActive(false);
        // Turn on gravity
        rb.useGravity = true;
        // Disable player movement
        player.GetComponent<PlayerMovement>().enabled = false;
        GameManager.Instance.setIsPlaying(true);
        // Launch the player in the direction of the pointer
        rb.AddForce(pointer.transform.up * -1000f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Peg") || collision.gameObject.CompareTag("Draggable"))
        {
            // Disable the collided object after a short delay
            StartCoroutine("DisablePeg", collision.gameObject);

            // Play sound
            //SoundManager.Instance.PlayCollisionSound();
            if (collision.gameObject.CompareTag("Peg"))
            {
                GameManager.Instance.addPoints(5); //Add points only for peg hits
                SoundManager.Instance.PlayBarrelCollisionSound();
            }
            else
            {
                SoundManager.Instance.PlayBoxCollisionSound();
            }
        }
    }

    private IEnumerator DisablePeg(GameObject peg)
    {
        yield return new WaitForSeconds(0.5f);
        // Disable the collided object after a short delay
        peg.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);

        Vector3 currentRotation = container.transform.rotation.eulerAngles;
        Vector3 newRotation = new Vector3(0.0f, 0.0f, currentRotation.z + movement.x);
        
        // Bound checking on the angle
        float angle = newRotation.z;
        angle = (angle > 180) ? angle - 360 : angle;
        if (angle >= -80.0f && angle <= 80.0f)
        {
            // Rotate the container
            container.transform.rotation = Quaternion.Euler(newRotation);
        }

    }
}
