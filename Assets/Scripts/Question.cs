using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft;
using UnityEngine;
using UnityEngine.Serialization;
[Serializable]
public class Question
{



    public String questionTxt;
    public String missingWord;
    public String[] options ;
    

    public Question(String questionTxt, String missingWord, String[] options)
    {
        this.questionTxt = questionTxt;
        this.missingWord = missingWord;
        this.options = options;

    }
    
    

    void Update()
    {
        
    }
}
