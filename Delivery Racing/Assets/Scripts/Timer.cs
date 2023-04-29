using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public GameObject panelDie;

    Image timerBar;
    public float maTime = 10f;
    float timeLeft;

    public bool isActive;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maTime;
        isActive = panelDie.activeSelf;
    }
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maTime;
        }
        else
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            panelDie.SetActive(!isActive);
        }
    }
}
