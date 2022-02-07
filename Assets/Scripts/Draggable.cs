using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool wrong = true;

    public Material goodMat;
    public Material badMat;

    private bool playing = false;
    private bool bouncy = false;
    private bool fallThrough = false;
    private bool killVelocity = false;


    private void Start()
    {
        if (wrong)
        {
            int rand = Random.Range(0, 2);
            switch(rand)
            {
                case 0:
                    bouncy = true;
                    break;
                case 1:
                    fallThrough = true;
                    break;
                default:
                    break;
            }
        }
        
    }

    public void setRight()
    {
        wrong = false;
        bouncy = false;
        fallThrough = false;
        killVelocity = false;
    }


    private void Update() {
        if (!playing && GameManager.Instance.getIsPlaying())
        {
            playing = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }


    }
    void OnCollisionEnter(Collision collision)
    {

        //Collision with player
        if (collision.collider.CompareTag("Player"))
        {
            if (bouncy) //Bounce the ball
            {
                Debug.Log("Bounce");
                collision.rigidbody.AddExplosionForce(30f, transform.position, 5f, 0f, ForceMode.Impulse);
            }
            else if (fallThrough) //Fall Through
            {
                Debug.Log("fallThrough");
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            }
            else if (killVelocity) //Kill Velocity
            {
                Debug.Log("Kill Velocity");
                collision.rigidbody.velocity = Vector3.zero;
                collision.rigidbody.angularVelocity = Vector3.zero;
            }

            //Deal with materials
            if (wrong)
            {
                GetComponent<MeshRenderer>().material = badMat;
            }
            else
            {
                GetComponent<MeshRenderer>().material = goodMat;
            }

            //Handle Points
            if (wrong)
            {
                GameManager.Instance.addPoints(-10);
                GameManager.Instance.decreaseMultiplier();
            }
            else
            {
                GameManager.Instance.addPoints(10);
                GameManager.Instance.increaseMultiplier();
            }
        }
     
        //Don't collide with stage elements, should be able to place wherever the player wants
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Peg") || collision.collider.CompareTag("Draggable"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
