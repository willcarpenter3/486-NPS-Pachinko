using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;

    public AudioSource pickUpSound;

    public AudioSource putDownSound;

    public AudioSource boxCollisionSound;

    public AudioSource barrelCollisionSound;

    public AudioSource winSound;

    public AudioSource cannonSound;

    //Singleton Stuff

    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void PlayPickUpSound()
    {
        pickUpSound.Play();
    }

    public void PlayPutDownSound()
    {
        putDownSound.Play();
    }

    public void PlayBoxCollisionSound()
    {
        boxCollisionSound.Play();
    }

    public void PlayBarrelCollisionSound()
    {
        barrelCollisionSound.Play();
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
