using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class ServerHandler : MonoBehaviour
{
    
    [SerializeField] private String url; 
    
    public Question[] response;

    private String promptJSON;

    #region JSONS&Qs
    
        public static readonly String jsonResponseEnglish = @"
        [
            {""questionTxt"": ""It's important to arrive to the school in designated hours"",""missingWord"": ""arrive"",""wrongWords"": [""write"", ""visit""]},
            {""questionTxt"": ""The sun sets in the west"",""missingWord"": ""sets"",""wrongWords"": [""rides"", ""cooks""]},
            {""questionTxt"": ""It's important to drink plenty of water"",""missingWord"": ""drink"",""wrongWords"": [""eat"", ""run""]},
        ]";
        public static readonly String jsonResponseItalian = @"
        [
            {""questionTxt"": ""É Importante Arrivare a scoula in orario"", ""missingWord"": ""arrivare"",""wrongWords"": [""arrivo"", ""arriverò""] },
            {""questionTxt"": ""Il sole tramonta a ovest"",""missingWord"": ""tramonta"",""wrongWords"": [""splende"", ""riscalda""]}
            {""questionTxt"": ""È fondamentale bere molta acqua"",""missingWord"": ""bere"",""wrongWords"": [""camminare"", ""studiare""]}
        ]";
        // Sticky object H
        public Question englishQ1 = new Question("It's important to arrive to the school in designated hours", "arrive",
            new String[] { "arrive","write", "visit" });
        
        public Question englishQ2 = new Question("The sun sets in the west", "sets",
            new String[] { "sets","rides", "cooks" });
        
        public Question englishQ3 = new Question("It's important to drink plenty of water", "drink",
            new String[] { "drink","eat", "run" });
        
        
        public Question italianQ1 = new Question("É Importante arrivare a scoula in orario", "arrivare",
            new String[] { "arrivare","arrivo", "arriverò" });
        
        public Question italianQ2 = new Question("Il sole tramonta a ovest", "tramonta",
            new String[] { "tramonta","splende", "riscalda" });
        
        public Question italianQ3 = new Question("È fondamentale bere molta acqua", "bere",
            new String[] { "bere","camminare", "studiare" });
        
    #endregion
    
    public Question[] GetQuestionsArrayFromServer(Prompt prompt)
    {
        // String stringJSON = JsonUtility.ToJson(prompt);
        // StartCoroutine(SendGetRequest(url,stringJSON));
        switch (QuestionManager.Instance.prompt.localeId)
        {
            //TODO : Prints Q1 twice even if q1 is commented O.O ...---...
            case 0 :
                response = new Question[] { englishQ1, englishQ2, englishQ3 };
                break;
            case 1 :
                response = new Question[] { italianQ1, italianQ2, italianQ3 };
                break;
            default:
                Debug.Log("Error in response");
                break;
            
        }
        return response;
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
    //      //TODO : FromJson questions returns an array
    //         response = JsonUtility.FromJson<Question[]>(request.downloadHandler.text);
    //     }
    // }
    




}
