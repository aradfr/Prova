using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UIBase : MonoBehaviour
{
    public RectTransform myTransform;
    public enum Direction
    {
        LeftToRight,
        RightToLeft,
        BottomToTop,
        TopToBottom
    }

    
    protected Vector2 startPos, targetPos;
    protected float time, duration;
    protected bool isMoving, isCommingIn;
    protected abstract void BeforeActivate();
    protected abstract void AfterActivate();
    protected abstract void BeforeLeave();
    protected abstract void AfterLeave();
    protected virtual void Update()
    {
        if (isMoving)
        {
            time += Time.deltaTime;
            float flow = MathHelper.GetEaseFlow(time / duration, MathHelper.NemoEaseMode.CubicInOut);

            if (flow >= 1)
            {
                isMoving = false;
                myTransform.anchoredPosition = targetPos;
                if (isCommingIn)
                    AfterActivate();
                else
                {
                    AfterLeave();
                    Deactivate();
                }
            }
            else
            {
                myTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, flow);
            }
                
        }
    }

    
    public virtual void ComeIn(Direction dir = Direction.LeftToRight)
    {
        
        startPos = myTransform.anchoredPosition = myTransform.rect.size * GetActualDir(dir);
        targetPos = Vector2.zero;

        time = 0;
        duration = 0.5f;

        isCommingIn = true;
        isMoving = true;
        Activate();
    }

    public virtual void GoOut(Direction dir = Direction.LeftToRight)
    {
        BeforeLeave();

        startPos = myTransform.anchoredPosition;
        targetPos = myTransform.rect.size * -GetActualDir(dir);

        time = 0;
        duration = 0.5f;

        isCommingIn = false;
        isMoving = true;
    }

    

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false); 
    }

    public static Vector2 GetActualDir(Direction dir)
    {
        Vector2 direction = new Vector2();
        switch (dir)
        {
            case Direction.LeftToRight: direction.x = -1; break;
            case Direction.RightToLeft: direction.x = 1; break;
            case Direction.BottomToTop: direction.y = -1; break;
            case Direction.TopToBottom: direction.y = 1; break;
        }

        return direction;
    }

    
}
