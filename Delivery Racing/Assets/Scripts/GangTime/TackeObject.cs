using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TackeObject : MonoBehaviour
{

    public static int Object;
    public static TMP_Text _text;


    void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = "ѕривет ищи скорей нужный нам товар и вези его";
    }

}
