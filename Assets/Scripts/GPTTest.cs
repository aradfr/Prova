using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;

public class GPTTest : MonoBehaviour
{
    private void Start()
    {
        // Call an async method in Unity from Start() using Task.Run or StartCoroutine for async behavior
        Task.Run(async () => await GetTestAsync());
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Send request"))
        {
            Debug.Log("kossher");
        }
        
        
    }

    // This method is now async and will handle the API call
    public async Task GetTestAsync()
    {
        // Instantiate OpenAIClient using your API key
        OpenAIClient api = new OpenAIClient("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");

        // Create a list of messages for the chat
        List<Message> messages = new List<Message>
        {
            new Message(Role.System, "You are a helpful assistant."),
            new Message(Role.User, "Who won the world series in 2020?"),
            new Message(Role.Assistant, "The Los Angeles Dodgers won the World Series in 2020."),
            new Message(Role.User, "Where was it played?")
        };

        // Ensure you are using the correct model name (e.g., gpt-4)
        ChatRequest chatRequest = new ChatRequest(messages, Model.GPT4);

        // Use await to get the response asynchronously
        ChatResponse response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);

        // Access the first choice from the response
        Choice choice = response.FirstChoice;

        // Log the response in Unity's console
        Debug.Log(choice.Message.Content);
    }
}