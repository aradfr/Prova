using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiArgument : UIBase
{
    public TMP_InputField input;

    [SerializeField] private UI.UIState state;

    protected override void BeforeActivation()
    {

    }

    protected override void AfterActivation()
    {
        //TODO:Animation
    }

    protected override void BeforeDeactivation()
    {

    }

    protected override void AfterDeactivation()
    {

    }

    public void OnSubmit()
    {
        UI.Instance.NextState(state);
    }

    public void SendArgToPrompt()
    {
        
        QuestionManager.Instance.prompt.argument = input.text;
        QuestionManager.Instance.GetQuestions();
    }

}    