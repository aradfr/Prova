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
        prompt = new Prompt();
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    #endregion
    

    [SerializeField] private ServerHandler serverHandler;
    [SerializeField] private ServerMocker serverMocker;
    [SerializeField] private bool isMocking;
    
    public Question[] questionsArray ;
    public Question currentQuestion;
    public String[] currentQuestionTxtArray;
    public Prompt prompt;
    public static int index =0;
    
    public void NextQuestion()
    {
        //TODO : Change the index approach of iterating in questions
        index++;
        currentQuestion = questionsArray[index];
        currentQuestionTxtArray = currentQuestion.questionTxt.Split(currentQuestion.missingWord);
    }


    public void GetQuestions()
    {
        questionsArray = serverHandler.GetQuestionsArrayFromServer(prompt);
    }
    
}

