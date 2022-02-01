using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWatcher : MonoBehaviour
{
    
    public GameObject pausePanel;
    
    private bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
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
    }
}
