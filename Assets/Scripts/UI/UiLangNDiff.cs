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

    private Difficulty _currentDifficulty;
    
    [SerializeField] public Button[] difficultyButtons = new Button[4];
    [SerializeField] public UI.UIState state;


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
        // SelectButton(_difficulty);
        // DeSelectOthersThan(_difficulty);
        QuestionManager.Instance.prompt.difficulty = (Difficulty) _difficulty;
        isSet = true;

    }

    private void DeSelectOthersThan(int difficulty)
    {
        
    }

    private void SelectButton(int index)
    {
        //
        EventSystem.current.SetSelectedGameObject(difficultyButtons[index].gameObject);
    }
}
