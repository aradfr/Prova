using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft;
using UnityEngine;
using UnityEngine.Serialization;

public class Question : MonoBehaviour
{



    public String questionTxt;
    public String missingWord;
    public String[] wrongWords ;
    

    public Question(String questionTxt, String missingWord, String[] wrongWords)
    {
        this.questionTxt = questionTxt;
        this.missingWord = missingWord;
        this.wrongWords = wrongWords;

    }
    
    

    void Update()
    {
        
    }
}
