using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Actual important variables
    private bool isPlaying = false;

    //Singleton stuff

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void setIsPlaying(bool status)
    {
        isPlaying = status;
    }

    public bool getIsPlaying()
    {
        return isPlaying;
    }

}
