using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public bool win = true;

    public GameObject winPanel;
    public GameObject losePanel;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            if (win)
            {
                winPanel.SetActive(true);
            }
            else
            {
                losePanel.SetActive(true);
            }
        }
    }
}
