using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;

    public AudioSource pickUpSound;

    public AudioSource putDownSound;

    public AudioSource collisionSound;

    public AudioSource winSound;

    public AudioSource cannonSound;

    public void PlayPickUpSound()
    {
        pickUpSound.Play();
    }

    public void PlayPutDownSound()
    {
        putDownSound.Play();
    }

    public void PlayCollisionSound()
    {
        collisionSound.Play();
    }

    public void PlayWinSound()
    {
        winSound.Play();
    }

    public void PlayCannonSound()
    {
        cannonSound.Play();
    }
}
