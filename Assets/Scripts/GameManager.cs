using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Actual important variables

    public TextMeshProUGUI pointText;

    private bool isPlaying = false;

    private int points = 0;

    private float multiplier = 1;

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

    public void addPoints (int numToAdd)
    {
        points += (int) Mathf.Ceil(numToAdd * multiplier); //not sure why had to cast here?
        pointText.text = points.ToString();
    }

    public void increaseMultiplier()
    {
        multiplier += 0.1f;
    }

}
