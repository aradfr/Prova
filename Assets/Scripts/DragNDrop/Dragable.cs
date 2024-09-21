using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Dragable : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    
    [SerializeField] private Canvas _canvas; 
    [SerializeField] private GameObject _dropable;
    [SerializeField] private Sprite defaultSprite,chosenSprite;
    [SerializeField] private TextMeshProUGUI score,optionText;
    private LayoutElement layoutElement;
    public Vector2 originalPosition;
    public RectTransform _rectTransform;
    private Image _image;
    private RectTransform _dropableRectTransform;
    private CanvasGroup _canvasGroup;
    private Color correctColor,wrongColor;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        originalPosition = _rectTransform.position;
        _dropableRectTransform = _dropable.GetComponent<RectTransform>();
        originalPosition = _rectTransform.anchoredPosition;  
        _canvasGroup = GetComponent<CanvasGroup>();
        layoutElement = GetComponent<LayoutElement>();
        _image = GetComponent<Image>();
        ColorUtility.TryParseHtmlString("#DD1D1D",out wrongColor);
        ColorUtility.TryParseHtmlString("#1FB755",out correctColor);
        

    }

    public void SetText(string text)
    {
        optionText.text = text;
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
            print(_rectTransform.position);
            print(_dropableRectTransform.position);
            layoutElement.ignoreLayout = true;
            _image.type = Image.Type.Sliced;
            _rectTransform.position = _dropableRectTransform.position;
            QuestionManager.Instance.CheckCorrectAnswer(gameObject);  
        }
        else
        {
            _rectTransform.anchoredPosition = originalPosition;
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
        score.text = new string("Score : "+$"{QuestionManager.Instance.score.ToString()}");
        _image.sprite = chosenSprite;
        _image.color = correctColor;
    }

    public void Wrong()
    {
        _image.sprite = chosenSprite;
        _image.color = wrongColor;
    }

    public void Reset()
    {
        layoutElement.ignoreLayout = false;
        _image.sprite = defaultSprite;
        _image.type = Image.Type.Simple;
        _image.color = Color.white;
        
    }
}
