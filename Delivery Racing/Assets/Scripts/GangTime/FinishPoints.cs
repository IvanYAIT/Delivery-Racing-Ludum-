using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TackeObject.Object -= 1;
            TextTime.ObjectSum += 1;
            Destroy(gameObject);
            TackeObject._text.text = "��������� �� �������� ��� ������� ������ ������";
            TextTime._textSum.text = "���� ��������� " + TextTime.ObjectSum.ToString();
            Timer.maTime -= 7f;
        }
    }
}

