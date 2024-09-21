using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utilities.Extensions;

public abstract class UIBase : MonoBehaviour
{

    protected RectTransform RectTransform;
    protected Vector2 TransitionDirection = Vector2.right ;
    
    private float _timer,_smoothStep;
    private Vector2 _initialPosition;
    private Vector2  _finalPosition;
    private TransitionState _transitionState = TransitionState.Idle;

    private float _transitionDuration = 1;
    protected abstract void BeforeActivation();
    protected abstract void AfterActivation();
    protected abstract void BeforeDeactivation();
    protected abstract void AfterDeactivation();
    

    public void StateDeactive()
    {
        BeforeDeactivation();
        Transition(TransitionState.Deactivating);

    }

    private void Transition(TransitionState nextState)
    {
        
        
        if (RectTransform is null)
        {
            RectTransform = GetComponent<RectTransform>();
        }

        if (UI.Instance.isBlue)
        {
            TransitionDirection = Vector2.left ;
        }
        _transitionDuration = UI.Instance.uiTransitionDuration;
        _timer = 0;
        switch (nextState)
        {
            case TransitionState.Activating:
                _initialPosition = RectTransform.anchoredPosition = RectTransform.rect.size * -TransitionDirection;
                _finalPosition = Vector2.zero;
                break;
            case  TransitionState.Deactivating:
                _finalPosition = RectTransform.rect.size * TransitionDirection;
                _initialPosition = RectTransform.anchoredPosition;
                break;
        }

        _transitionState = nextState;

    }
    
    public void StateActive()
    {
        BeforeActivation();
        Active();
        
    }

    public void Active()
    {
        gameObject.SetActive(true);
        Transition(TransitionState.Activating);
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
        AfterDeactivation();
    }


    protected virtual void Update()
    {
        if (_transitionState != TransitionState.Idle)
        {
            _timer += Time.deltaTime;
            _smoothStep = MathHelper.GetEaseFlow(_timer/_transitionDuration, MathHelper.NemoEaseMode.CubicIn);
            if (_smoothStep >= 1)
            {
                RectTransform.anchoredPosition = _finalPosition;
                switch (_transitionState)
                {
                    case TransitionState.Deactivating:
                        Deactive();
                        break;
                    case TransitionState.Activating:
                        AfterActivation();
                        break;
                    
                }
                _transitionState = TransitionState.Idle;
            }
            else
            {
                RectTransform.anchoredPosition = Vector2.Lerp(_initialPosition,_finalPosition,_smoothStep);
            }
            

        }
    }

    
    private enum TransitionState
    {
        Activating,
        Deactivating,
        Idle,
    }
}
