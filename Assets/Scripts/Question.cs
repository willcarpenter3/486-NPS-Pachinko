using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class Question : ScriptableObject
{
    public string question;

    public bool fourAnswers;
    public string answerZero;
    public string answerOne;
    public string answerTwo;
    public string answerThree;
    public int correctAnswer;
}
