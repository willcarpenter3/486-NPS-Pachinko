using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScript : MonoBehaviour
{
    public bool win = true;

    public int pointAmount = 200;

    public GameObject winPanel;

    public TextMeshProUGUI pointText;

    private void Awake()
    {
        Time.timeScale = 1;

        pointText.text = pointAmount.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.addPoints(pointAmount);
            SoundManager.Instance.PlayWinSound();
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
    }
}
