using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool playing = false;

    private void Update() {
        if (!playing && GameManager.Instance.getIsPlaying())
        {
            playing = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Peg"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
