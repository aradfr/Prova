using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;

public class ServerHandler : MonoBehaviour
{

    [SerializeField] private ServerMocker server;
    
    public Question[] response;
    
    

    public void JsonSerilizer(Prompt prompt)
    {
        //TODO :serialize the prompt to Json
    }

    //TODO : Add Json to paramethers of the following method
    // public Question[] JsonDeserilizer()
    // {
    //     //desrilize JSON and fill the following variables and use the constructor to make a question with it
    //     String questionTxt = new string(""), missingWord = new string("");
    //     String[] wrongWords = new string[];
    //     
    //     
    //     
    // }

}
