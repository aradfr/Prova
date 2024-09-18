using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerHandler : MonoBehaviour
{

    [SerializeField] private ServerMocker server;
    
    public Question[] response;

    private String promptJSON;


    // public Question[] GetQuestionsArray(Prompt prompt)
    // {
    //     promptJSON = JsonUtility.ToJson(prompt);
    //     // return GetQuestionsArrayFromServer(promptJSON);
    // }

    //TODO : Add Json to paramethers of the following method
    // public Question[] GetQuestionsArrayFromServer(String stringJSON)
    // {
    //     
    //
    //
    //     
    //
    // }
    
    IEnumerator SendGetRequest(string url, string prompt)
    {
        string encodedPrompt = UnityWebRequest.EscapeURL(prompt);
        string finalUrl = url + "?prompt=" + encodedPrompt;

        UnityWebRequest request = UnityWebRequest.Get(finalUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || 
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            // response = JsonUtility.FromJson(request.result);}
        }
    }



}
