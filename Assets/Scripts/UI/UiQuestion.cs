using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiQuestion : UIBase
{
    [SerializeField] private GameObject before,after;
    [SerializeField] private Dragable[] options;
    [SerializeField] private TextMeshProUGUI score,currentQuestionNumber;
    [SerializeField] public UI.UIState state;
    
    
    protected override void BeforeActivation()
    {
        
    }


    protected override void AfterActivation()
    {
        NextQuestion();
    }

    protected override void BeforeDeactivation()
    {
        
    }

    protected override void AfterDeactivation()
    {
        
    }

    public void OnClickSubmit()
    {
        UI.Instance.NextState(state);
    }

    public void OnClickNext()
    {
        NextQuestion();
    }

    public void NextQuestion()
    {
        
        QuestionManager.Instance.NextQuestion();
        before.GetComponent<TextMeshProUGUI>().text = QuestionManager.Instance.currentQuestionTxtArray[0];
        after.GetComponent<TextMeshProUGUI>().text = QuestionManager.Instance.currentQuestionTxtArray[1];
        
        currentQuestionNumber.text = new string("Question #"+$"{QuestionManager.Instance.currenQuestionNumber.ToString()}");
        
       RandomizeOptionsAndSet();

    }

    private void RandomizeOptionsAndSet()
    {{
            string[] textOptions = QuestionManager.Instance.currentQuestion.options.ToArray();
            
            System.Random random = new System.Random();
            textOptions = textOptions.OrderBy(x => random.Next()).ToArray();
            
            for (int i = 0; i < options.Length; i++)
            {
                options[i].SetText(textOptions[i]);
                options[i].Reset();
                //TODO : change color to sprite
                options[i]._rectTransform.anchoredPosition = 
                    QuestionManager.Instance.options[i].originalPosition;
            }
        }
        
        
    }



}
