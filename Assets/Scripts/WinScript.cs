using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScript : MonoBehaviour
{

    public int pointAmount = 200;

    public GameObject winPanel;
    public GameObject losePanel;

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
            PlayerMovement p = other.gameObject.GetComponent<PlayerMovement>();
            if (p.hitCorrect)
            {
                GameManager.Instance.addPoints(pointAmount);
                SoundManager.Instance.PlayWinSound();
                winPanel.SetActive(true);
                GameManager.Instance.winGame();
            }
            else {
                //GameManager.Instance.addPoints(pointAmount);
                //SoundManager.Instance.PlayWinSound();
                losePanel.SetActive(true);
                GameManager.Instance.loseGame();
            }
        }
    }
}
