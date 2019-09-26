using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableUIDebug : MonoBehaviour
{
    [SerializeField]
    public enum UIElement { InputField, Text}
    [SerializeField]
    UIElement _myElement = UIElement.InputField;

    [SerializeField]
    FloatVariable _trackedValue;
    // Start is called before the first frame update
    void Start()
    {
        switch (_myElement)
        {
            case UIElement.InputField:
                GetComponent<InputField>().text = _trackedValue.Value.ToString();
                break;
            case UIElement.Text:
                break;
            default:
                break;
        }
    }

    public void UpdateValue()
    {
        switch (_myElement)
        {
            case UIElement.InputField:
                _trackedValue.Value = int.Parse(GetComponent<InputField>().text);
                break;
            case UIElement.Text:
                break;
            default:
                break;
        }
    }
}
