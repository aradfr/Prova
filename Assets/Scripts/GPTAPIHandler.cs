using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.Events;
using OpenAI.Chat;
using OpenAI;
using Message = OpenAI.Threads.Message;


public class GPTAPIHandler : MonoBehaviour
{


    public Message msg;
    public OpenAIClient api = new OpenAIClient("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");
    private ChatRequest chatRequest;
    private string res;
    
    void Start()
    {
        
    }

    IEnumerator GetRequest(String url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError :
                Debug.Log("Connection Error");
                break;
            case UnityWebRequest.Result.DataProcessingError :
                Debug.Log("Data Processing Error");
                break;
            case UnityWebRequest.Result.Success :
                res = webRequest.downloadHandler.text;
                break;
                
                
                
        }
    }

    
}
