using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEnd : UIBase
{

    [SerializeField] private GameObject[] stars = new GameObject[3];
    [SerializeField] private UI.UIState state;
    
    
    protected override void BeforeActivation()
    {
        DeactiveStars();
    }

    protected override void AfterActivation()
    {
        
        int upper = QuestionManager.Instance.score / 3;
        StartCoroutine(SpawnStars(upper));
    }

    protected override void BeforeDeactivation()
    {
        
    }

    private void DeactiveStars()
    {
        foreach (var s in stars)
        {
            s.SetActive(false);
        }
    }
    protected override void AfterDeactivation()
    {
        DeactiveStars();
    }

    public void OnReplay()
    {
        UI.Instance.NextState(UI.UIState.Argument);
    }

    public void OnReturn()
    {
        
        UI.Instance.NextState(state);
    }

    
    public IEnumerator SpawnStars(int upper)
    {
        

            for (int i = 0; i < upper; i++)
            {
                stars[i].SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }
        
    }
}
