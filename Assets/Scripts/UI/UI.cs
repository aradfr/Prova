using System;
using System.Collections.Generic;
using UnityEngine;

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
     //TODO: add panel types
    }

    public UIBase[] pages;
    public UIState startingState,currentState,prevState;
    
    
    HashSet<UIState> pagesVisited = new HashSet<UIState> ();
    
    
    public Action<UIState, UIState> OnPageChanged;

    private void Start () {
        Instance.OnPageChanged += OnPageChangedCallback;

        SetState (startingState);

        prevState = currentState = startingState;

    }
    

    public void OnBackClick () {
        GoBack ();
    }

    public static void GoBack () {
        if (Instance.pagesVisited.Count > 0) {
            
            
        }
    }

    private void OnDisable () {
        Instance.OnPageChanged -= OnPageChangedCallback;
    } 
    
    

    public static void SetState (UIState state, bool isBack = false, bool dirBack = false) {
        UIBase.Direction dir = (isBack || dirBack) ? UIBase.Direction.RightToLeft : UIBase.Direction.LeftToRight;

        if (!isBack) {
            //TODO : possibly remove duplicate states
            
            
            Instance.pagesVisited.Add (Instance.currentState);
            Debug.Log ("new Page added "+state);
        }
        Instance.prevState = Instance.currentState;
        Instance.pages[(int) Instance.currentState].GoOut (dir);
        Instance.currentState = state;
        Instance.pages[(int) Instance.currentState].ComeIn (dir);

        if (Instance.OnPageChanged != null)
            Instance.OnPageChanged (Instance.prevState, Instance.currentState);
    }

    
    private void OnPageChangedCallback (UI.UIState prevPage, UI.UIState currentPage) {
        

    }

    

    

}