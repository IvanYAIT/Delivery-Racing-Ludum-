using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItsGGF : MonoBehaviour
{
    public GameObject Finish;
    public bool isActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TackeObject.Object += 1;
            Finish.SetActive(!isActive);
            TackeObject._text.text = "Ты подобрал его быстрее ищи место выгрузски";
            Destroy(gameObject);
        }
    }

}
