using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Dragable : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    
    [SerializeField] private Canvas _canvas; 
    [SerializeField] private GameObject _dropable;
    
    private RectTransform _rectTransform,_dropableRectTransform;
    private CanvasGroup _canvasGroup;
    
    
    private Vector2 _originalPosition;
     

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPosition = _rectTransform.position;
        _dropableRectTransform = _dropable.GetComponent<RectTransform>();
        _originalPosition = _rectTransform.anchoredPosition;  
        _canvasGroup = GetComponent<CanvasGroup>();
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.8f;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        HandlePos();
        _canvasGroup.blocksRaycasts = true;
        
    }

    private void HandlePos()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(_dropableRectTransform, _rectTransform.position, null))
        {
            _rectTransform.position = _dropableRectTransform.position;
            QuestionManager.Instance.CheckCorrectAnswer(gameObject);  
        }
        else
        {
            _rectTransform.anchoredPosition = _originalPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // dividing to canvas scaler is redundant since everything has a scale of 1 but we put it there to be sure 
        _rectTransform.anchoredPosition += eventData.delta/ _canvas.scaleFactor ;
    }

    public void Correct()
    {
        QuestionManager.Instance.score++;
        gameObject.GetComponent<Image>().color = Color.green;
    }

    public void Wrong()
    {
        
        gameObject.GetComponent<Image>().color = Color.red;
    }
}
