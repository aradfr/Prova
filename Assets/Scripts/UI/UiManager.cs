using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class UiManager : MonoBehaviour
{
    private bool localeActive;
    public int currentLocaleId;
    public int difficultyId;

    public void Difficulty(int _difficultyId)
    {
        difficultyId = _difficultyId;
    }

    public void OnSubmit()
    {
        
    }


    //Method to change locale
    public void ChangeLocale(int localeId)
    {
        if (localeActive == true) return;
        StartCoroutine(SetLocale(localeId));
    }

    //Coroutine to change locale
    IEnumerator SetLocale(int _localeId)
    {
        localeActive = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeId];
        currentLocaleId = _localeId;
        localeActive = false;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
