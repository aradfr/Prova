using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    #region Singleton

    static QuestionManager _instance;
    public static QuestionManager Instance { get { return _instance; } }

    private void Awake () {
        _instance = this;
    }

    private void OnDestroy () {
        _instance = null;
    }

    #endregion

    public Question[] questions = new Question[10];
    public Prompt prompt;
}

