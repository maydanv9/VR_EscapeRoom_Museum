using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PinPadController : MonoBehaviour
{
    [SerializeField] private string codeString;
    [SerializeField] private TMP_Text codeValue;
    [SerializeField] string word = null;
    [SerializeField] int wordIndex = -1;
    [SerializeField] char[] nameChar = new char[5];
    [SerializeField] string alpha = null;

    public void OnButtonPressedCall(string _value)
    {
        if (wordIndex < 4)
        {
            wordIndex++;
            char[] keepchar = _value.ToCharArray();
            nameChar[wordIndex] = keepchar[0];
            alpha = nameChar[wordIndex].ToString();
            word = word + alpha;
            codeValue.text = word;
            EventSystem.current.SetSelectedGameObject(null);

            if (codeValue.text.Equals(codeString))
            {
                codeValue.text = "PogO";
            }
        }
    }

    public void Backspace()
    {
        alpha = null;
        if (wordIndex >= 0)
        {
            wordIndex--;
            for (int i = 0; i < wordIndex + 1; i++)
            {
                alpha = alpha + nameChar[i].ToString();
            }
            word = alpha;
            codeValue.text = word;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void SetCode(string _code)
    {
        codeString = _code;
    }
}
