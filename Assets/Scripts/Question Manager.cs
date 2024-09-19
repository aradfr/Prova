using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class QuestionManager : MonoBehaviour
{
    #region Singleton

    static QuestionManager _instance;

    public static QuestionManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
        prompt = new Prompt();
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    #endregion
    

    [SerializeField] private ServerHandler serverHandler;
    [SerializeField] private RectTransform dropableRectTransform;

    public Question[] questionsArray ;
    public Question currentQuestion;
    public String[] currentQuestionTxtArray;
    public Prompt prompt;

    
    public static int index = -1;
    public int score = 0;

    public void NextQuestion()
    {
        //TODO : Change the index approach of iterating in questions
        index++;
        currentQuestion = questionsArray[index];
        //maybe its better to do the next line in its panel
        currentQuestionTxtArray = currentQuestion.questionTxt.Split(currentQuestion.missingWord);
    }


    public void GetQuestions()
    {
        questionsArray = serverHandler.GetQuestionsArrayFromServer(prompt);
        
        
    }
    

    public void CheckCorrectAnswer(GameObject dragable)
    {
        
        TextMeshProUGUI choosedOption = dragable.GetComponentInChildren<TextMeshProUGUI>();
        
        if (choosedOption.text == currentQuestion.missingWord) dragable.GetComponent<Dragable>().Correct();
        else if (choosedOption.text != currentQuestion.missingWord) dragable.GetComponent<Dragable>().Wrong();
        else Debug.Log("TMP error");
        
      

    }
}

