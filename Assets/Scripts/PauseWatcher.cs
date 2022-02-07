using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseWatcher : MonoBehaviour
{
    
    public GameObject pausePanel;
    public InputAction escape;
    
    private bool paused = false;

    private void OnEnable() {
        escape.Enable();
        escape.performed += EscPressed;
    }

    private void OnDisable() {
        escape.performed -= EscPressed;
        escape.Disable();
    }

    private void EscPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Escape Pressed");
        if (context.ReadValue<float>() > 0)
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

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Escape)) 
        //{
        //    if (!paused) 
        //    {
        //        Time.timeScale = 0;
        //        pausePanel.SetActive(true);
        //        paused = true;
        //    }
        //    else
        //    {
        //        Time.timeScale = 1;
        //        pausePanel.SetActive(false);
        //        paused = false;
        //    }
        //}
    }
}
