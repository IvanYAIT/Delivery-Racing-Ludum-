using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Game
{
    private GameObject _winPanel;

    public static Action OnGameEnd;
    public Game(GameObject winPanel)
    {
        _winPanel = winPanel;
        HealthSystem.OnZeroHealth += Restart;
        FinishSystem.OnEndPath += Win;
        PetrolSystem.OnZeroPetrol += Restart;
    }

    public void Win()
    {
        Time.timeScale = 0;
        FinishSystem.OnEndPath -= Win;
        _winPanel.SetActive(true);
    }

    public void Restart()
    {
        HealthSystem.OnZeroHealth -= Restart;
        PetrolSystem.OnZeroPetrol -= Restart;
        FinishSystem.OnEndPath -= Win;
        OnGameEnd?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        
}