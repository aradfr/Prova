using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utilities.Extensions;

public abstract class UIBase : MonoBehaviour
{


    
    protected abstract void BeforeActivation();
    protected abstract void AfterActivation();
    protected abstract void BeforeDeactivation();
    protected abstract void AfterDeactivation();

    public virtual void StateDeactive()
    {
        BeforeDeactivation();
        Deactive();
        AfterDeactivation();

    }
   
    public virtual void StateActive()
    {
        BeforeActivation();
        Active();
        AfterActivation();
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }


    

    
}
