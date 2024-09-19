using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UiQuestion : UIBase
{
    [SerializeField] private GameObject before,after;
    [SerializeField] private GameObject[] options;

    protected override void BeforeActivation()
    {
        
    }


    protected override void AfterActivation()
    {
        NextQuestion();
    }

    protected override void BeforeDeactivation()
    {
        
    }

    protected override void AfterDeactivation()
    {
        
    }

    public void OnClickNext()
    {
        NextQuestion();
    }

    public void NextQuestion()
    {
        QuestionManager.Instance.NextQuestion();
        before.GetComponent<TextMeshProUGUI>().text = QuestionManager.Instance.currentQuestionTxtArray[0];
        after.GetComponent<TextMeshProUGUI>().text = QuestionManager.Instance.currentQuestionTxtArray[1];

        int upper = QuestionManager.Instance.currentQuestion.options.Length;
        for (int i = 0; i < upper; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text =
                QuestionManager.Instance.currentQuestion.options[i];
        }
        

    }



}
