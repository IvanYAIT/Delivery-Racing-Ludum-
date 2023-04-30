using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextTime : MonoBehaviour
{

    public static int ObjectSum;
    public static TMP_Text _textSum;

    void Start()
    {
        _textSum = GetComponent<TMP_Text>();
        _textSum.text = "Твоя репутация " + ObjectSum.ToString();
    }

}
