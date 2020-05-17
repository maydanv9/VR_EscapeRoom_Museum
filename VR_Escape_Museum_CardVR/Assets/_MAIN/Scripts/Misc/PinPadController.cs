﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PinPadController : MonoBehaviour
{
    [SerializeField] private string codeString; 
    [SerializeField] private TMP_Text codeValue;
    string word = null;
    int wordIndex = -1;
    char[] nameChar = new char[5];
    string alpha = null;
    //Metoda wywoływana na przycisku 1,2,3 itd...
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
                //TO DO: Open doors
                Debug.Log("Open doors");
            }
        }
    }
    //Metoda wywoływana na przycisku DEL
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
    //Metoda wywoływania na początku stanu z miejsca, gdzie generowane są zagadki.
    public void SetCode(string _code)
    {
        codeString = _code;
    }
}
