using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulateQuestion : MonoBehaviour
{
    public List<Question> questionBank;

    public List<GameObject> answerBlocks;

    private List<TextMeshProUGUI> answerTexts;

    private TextMeshProUGUI questionText;
    private TextMeshProUGUI answerZeroText;
    private TextMeshProUGUI answerOneText;
    private TextMeshProUGUI answerTwoText;
    private TextMeshProUGUI answerThreeText;

    


    void Awake()
    {
        //Grab our text elements
        //This method of doing this is iffy - but we know we're not gonna mess with it so it should be fine
        questionText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        answerTexts = new List<TextMeshProUGUI>();
        answerTexts.Add(gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
        answerTexts.Add(gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>());
        answerTexts.Add(gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>());
        answerTexts.Add(gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>());
    }

    void Start()
    {
        //Grab a random question from our bank
        Question q = questionBank[Random.Range(0, questionBank.Count)];

        //Set texts on board
        questionText.text = q.question;

        answerTexts[0].text = q.answerZero;
        answerTexts[1].text = q.answerOne;
        answerTexts[2].text = q.answerTwo;
        answerTexts[3].text = q.answerThree;

        //Hide C&D blocks if necessary
        if (!q.fourAnswers)
        {
            answerBlocks[2].SetActive(false);
            answerBlocks[3].SetActive(false);
        }

        //Set correct answer
        answerBlocks[q.correctAnswer].GetComponent<Draggable>().setRight();
    }
}
