using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timePerFinish = 30;

    public GameObject panelDie;

    Image timerBar;
    public static float maTime = 120f;
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
