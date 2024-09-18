using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UiQuestion : UIBase
{
    [SerializeField] public GameObject missingWord,before,after;
    [SerializeField] public GameObject optionsSlot;
    [SerializeField] public GameObject optionPrefab;
    
    


    protected override void BeforeActivation()
    {
        
    }


    protected override void AfterActivation()
    {
        
    }

    protected override void BeforeDeactivation()
    {
        
    }

    protected override void AfterDeactivation()
    {
        
    }

    public void OnClickNext()
    {
        QuestionManager.Instance.NextQuestion();
        before.GetComponent<TextMeshProUGUI>().text = QuestionManager.Instance.currentQuestionTxtArray[0];
        after.GetComponent<TextMeshProUGUI>().text = QuestionManager.Instance.currentQuestionTxtArray[1];
        //TODO : handle options
        // foreach (var option in QuestionManager.Instance.currentQuestion.wrongWords)
        // {
        //     // options.Append(option);
        //
        // }
        // Instantiate(optionPrefab, optionsSlot.transform);
    }
    



}
