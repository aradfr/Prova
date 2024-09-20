using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEnd : UIBase
{

    [SerializeField] private GameObject[] stars = new GameObject[3];
    
    
    protected override void BeforeActivation()
    {
        
    }

    protected override void AfterActivation()
    {
        int upper = QuestionManager.Instance.score / 3;
        StartCoroutine(SpawnStars(upper));
    }

    protected override void BeforeDeactivation()
    {
        
    }

    protected override void AfterDeactivation()
    {
        
    }

    public void OnReplay()
    {
        //TODO : Go to Question or argument
    }

    public void OnReturn()
    {
        //TODO : Go where this leads
    }

    
    public IEnumerator SpawnStars(int upper)
    {
        yield return new WaitForSeconds(0.5f);
        
        for (int i = 0; i < upper; i++)
        {
            stars[i].SetActive(true);

            // TODO: animate

        }
    }
}
