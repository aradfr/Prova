using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using static QuestionManager;

public class Localizer : MonoBehaviour
{
    private bool localeActive;
    public int currentLocaleId;

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
        Instance.prompt.localeId = _localeId;
        currentLocaleId = _localeId;
        localeActive = false;
    }

    
}
