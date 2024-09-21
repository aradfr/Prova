using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;  
    private Button selectedButton;

    private void Start()
    {
        selectedButton = null;
    }
    
    public void OnButtonClicked(Button clickedButton)
    {
        if (selectedButton == clickedButton)
            return;
        if (selectedButton != null)
        {
            DeselectButton(selectedButton);
        }
        SelectButton(clickedButton);
    }
    
    private void SelectButton(Button button)
    {
        selectedButton = button;
        button.image.color = Color.green;  
    }
    
    private void DeselectButton(Button button)
    {
        button.image.color = Color.white;  
    }
}