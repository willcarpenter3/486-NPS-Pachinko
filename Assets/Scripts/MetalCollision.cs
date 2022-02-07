using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalCollision : MonoBehaviour
{
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SoundManager.Instance.PlayBarrelCollisionSound();
            GameObject particle = Instantiate(sparkEffect, collision.contacts[0].point, collision.transform.rotation);
            particle.GetComponent<ParticleSystem>().Play();
            Destroy(particle, 1f);
        }
    }
}
