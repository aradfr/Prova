using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft;
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
        questionsArray = new Question[questionsNumbers];
        prompt = new Prompt();
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    #endregion

    //Initialized in awake()
    [SerializeField] private int questionsNumbers;

    [SerializeField] private ServerHandler serverHandler;
    [SerializeField] private ServerMocker serverMocker;
    [SerializeField] private bool isMocking;
    
    public Question[] questionsArray ;
    public Question currentQuestion;
    public String[] currentQuestionTxtArray;
    public Prompt prompt;
    public int index;
    
    public void NextQuestion()
    {
        //TODO : Change the index approach of iterating in questions
        index++;
        currentQuestion = questionsArray[index];
        currentQuestionTxtArray = currentQuestion.questionTxt.Split(currentQuestion.missingWord);
    }

    public void GetQuestionsFromServerHandler(Prompt prompt)
    {
        if (isMocking)
        {
            questionsArray = serverMocker.GetQuestionArray(prompt);
        }
        else
        {
            //questionsArray = serverHandler.GetQuestionsArray(prompt);
            
        }
    }
    
}

