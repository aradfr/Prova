using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UI : MonoBehaviour {
    #region Singleton

    static UI _instance;
    public static UI Instance { get { return _instance; } }

    private void Awake () {
        _instance = this;
    }

    private void OnDestroy () {
        _instance = null;
    }

    #endregion

    
    public enum UIState {
     LangNDiff,
     Argument,
     Question,
     End,
    }

    public bool isBlue;
    public float uiTransitionDuration;
    public UIBase[] pagesBlue,pagesNude;
    public UIState startingState,currentState,prevState;
    
    HashSet<UIState> pagesVisited = new HashSet<UIState> ();

    private UIBase[] pages;
    
    private void Start() {

        prevState = currentState = startingState;

    }

    public void SetPages()
    {
        QuestionManager.Instance.SetOptions();
        if ((int)QuestionManager.Instance.prompt.difficulty > 1)
        {
            isBlue = true;
            pages = pagesBlue;
            
        }
        else
        {
            isBlue = false;
            pages = pagesNude;
        }

    }

    
    public void OnBackClick() {
        GoBack ();
    }

    public static void GoBack() {
        if (Instance.pagesVisited.Count > 0) {
            
            
        }
    }

    private void OnDisable() {
        //Instance.OnPageChanged -= OnPageChangedCallback;
    } 
    
    

    public void NextState(UIState state) {

       
        Instance.prevState = Instance.currentState;
        Instance.pages[(int) Instance.currentState].StateDeactive();
        Instance.currentState = NextEnum(state) ;
        Instance.pages[(int) Instance.currentState].StateActive();
        // if (Instance.OnPageChanged != null)
        //     Instance.OnPageChanged?.Invoke(Instance.prevState, Instance.currentState);
    }
    
    public UIState NextEnum(UIState state)
    {
        //TODO : Implement a better way for this (maybe passing the direction or the target scene instead of a enum approach)
        switch (state)
        {
            case UIState.LangNDiff:
                return UIState.Argument;
            case UIState.Argument:
                return UIState.Question;
            case UIState.Question:
                return UIState.End;
            case UIState.End:
                return UIState.LangNDiff;
            default:
                return UIState.LangNDiff;

        }
        
    }
    

    

}