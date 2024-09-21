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

    public GameObject[] optionsBlue,optionsNude,options;
    public Question[] questionsArray ;
    public Question currentQuestion;
    public String[] currentQuestionTxtArray;
    public Prompt prompt;  

    
    public int score = 0;
    [Range(0,3)] public int currenQuestionNumber ;
    

    public void NextQuestion()
    {
        var cycler = new ArrayCycler<Question>(questionsArray);
        
        currentQuestion = cycler.GetNextItem();
        if (currentQuestion is null) Debug.Log("current Q null");
            //maybe its better to do the next line in its panel
        currentQuestionTxtArray = currentQuestion.questionTxt.Split(currentQuestion.missingWord);
        currenQuestionNumber++;
        foreach (var go in options)
        {
            go.GetComponent<Dragable>().enabled = true;
        }
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
        
        foreach (var go in options)
        {
            go.GetComponent<Dragable>().enabled = false;
        }
      

    }
}

