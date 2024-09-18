using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Sprite greenSprite,redSprite;

    private RectTransform _rectTransform,_originalRectTransform;
    private CanvasGroup _canvasGroup;
    
     

    private void Awake()
    {
        _originalRectTransform = _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0f;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        QuestionManager.Instance.HanldeDragablePosition(gameObject,_originalRectTransform);
        _canvasGroup.blocksRaycasts = true;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        // dividing to canvas scaler is redundant since everything has a scale of 1 but we put it there to be sure 
        _rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor ;
    }

    public void Correct()
    {
        QuestionManager.Instance.score++;
        // gameObject.GetComponent<Sprite>() = greenSprite;
    }

    public void Wrong()
    {
        QuestionManager.Instance.score--;
    }
}
