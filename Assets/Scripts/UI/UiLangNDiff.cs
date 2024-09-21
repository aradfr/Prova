using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiLangNDiff : UIBase
{

    [SerializeField] private UI.UIState state;
    [SerializeField] private Button[] buttons;
    
    private Difficulty _currentDifficulty,_previousDifficulty;
    

    private bool isSet;
    
    public enum Difficulty
    {
        Maternal,
        Elementary,
        Highschool1,
        Highschool2,
    }

    protected override void BeforeActivation()
    {
        isSet = false;

    }

    protected override void AfterActivation()
    {
        //TODO : Animate entrance

    }

    protected override void BeforeDeactivation()
    {
        //TODO : Animate going out

    }

    protected override void AfterDeactivation()
    {
        

    }
    public void OnClickSubmit()
    {

        if (isSet !=true)
        {
            Debug.Log("set difficulty");
        }

        UI.Instance.SetPages();
        UI.Instance.NextState(state);
    }
    

    public void OnSelectDifficulty(int _difficulty)
    {
        QuestionManager.Instance.prompt.difficulty = (Difficulty) _difficulty;
        isSet = true;
        _currentDifficulty = (Difficulty) _difficulty; 
        if (_currentDifficulty == _previousDifficulty)
        {
            
        }
        
    }
}
