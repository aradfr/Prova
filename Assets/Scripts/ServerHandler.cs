using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Networking;

public class ServerHandler : MonoBehaviour
{
    
    [SerializeField] private String url; 
    
    public Question[] response;

    private String promptJSON;

    #region JSONS
    
        public static readonly String jsonResponseEnglish = @"
        [
            {""question"": ""It's important to arrive to the school in designated hours"",""missingWord"": ""arrive"",""wrongWords"": [""write"", ""visit""]},
            {""question"": ""The sun sets in the west"",""missingWord"": ""sets"",""wrongWords"": [""rides"", ""cooks""]},
            {""question"": ""It's important to drink plenty of water"",""missingWord"": ""drink"",""wrongWords"": [""eat"", ""run""]},
        ]";
        public static readonly String jsonResponseItalian = @"
        [
            {""questionTxt"": ""É Importante Arrivare a scoula in orario"", ""missingWord"": ""arrivare"",""wrongWords"": [""arrivo"", ""arriverò""] },
            {""questionTxt"": ""Il sole tramonta a ovest"",""missingWord"": ""tramonta"",""wrongWords"": [""splende"", ""riscalda""]}
            {""questionTxt"": ""È fondamentale bere molta acqua"",""missingWord"": ""bere"",""wrongWords"": [""camminare"", ""studiare""]}
        ]";
    #endregion
    
    public Question[] GetQuestionsArrayFromServer(Prompt prompt)
    {
        String stringJSON = JsonUtility.ToJson(prompt);
        StartCoroutine(SendGetRequest(url,stringJSON));
        return response;
    }
    public IEnumerator SendGetRequest(String url, String prompt)
    {
        yield return new WaitForSeconds(1);

        switch (QuestionManager.Instance.prompt.localeId)
        {
            case 0 :
                response = JsonUtility.FromJson<Question[]>(jsonResponseEnglish);
                break;
            case 1 :
                response = JsonUtility.FromJson<Question[]>(jsonResponseItalian);
                break;
            default:
                Debug.Log("Error in response");
                break;
            
        }
        
        foreach (Question q in response)
        {
                Debug.Log(q.questionTxt + ": " + q.missingWord);
        }
    }
    
    // IEnumerator SendGetRequest(String url, String prompt)
    // {
    //     String encodedPrompt = UnityWebRequest.EscapeURL(prompt);
    //     String finalUrl = url + "?prompt=" + encodedPrompt;
    //
    //     UnityWebRequest request = UnityWebRequest.Get(finalUrl);
    //     yield return request.SendWebRequest();
    //
    //     if (request.result == UnityWebRequest.Result.ConnectionError || 
    //         request.result == UnityWebRequest.Result.ProtocolError)
    //     {
    //         Debug.LogError(request.error);
    //     }
    //     else
    //     {
    //         response = JsonUtility.FromJson<Question[]>(request.downloadHandler.text);
    //     }
    // }
    




}
