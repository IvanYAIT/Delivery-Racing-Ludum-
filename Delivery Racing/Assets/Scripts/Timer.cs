using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timePerFinish = 10;

    public GameObject panelDie;

    Image timerBar;
    public static float maTime = 100f;
    float timeLeft;

    public bool isActive;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maTime;
        isActive = panelDie.activeSelf;
        FinishChecker.OnFinish += AddTime;
        Game.OnGameEnd += EndGame;
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
            FinishChecker.OnFinish -= AddTime;
            panelDie.SetActive(!isActive);
        }
    }

    private void EndGame()
    {
        FinishChecker.OnFinish -= AddTime;
        Game.OnGameEnd -= EndGame;
    }

    public void AddTime()
    {
        timeLeft += timePerFinish;
        if (timeLeft >= maTime)
            timeLeft = maTime;
        
    }
}
