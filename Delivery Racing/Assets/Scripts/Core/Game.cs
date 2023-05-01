using UnityEngine;
using System;

public class Game
{
    private GameObject _winPanel;
    private GameObject _losePanel;
    private AudioSource _winAudioSource;  
    private AudioSource _loseAudioSource;

    public static Action OnGameEnd;
    public Game(GameObject winPanel, GameObject losePanel, AudioSource winAudioSource, AudioSource loseAudioSource)
    {
        _winPanel = winPanel;
        _losePanel = losePanel;
        _winAudioSource = winAudioSource;
        _loseAudioSource = loseAudioSource;
        HealthSystem.OnZeroHealth += Lose;
        FinishSystem.OnEndPath += Win;
        PetrolSystem.OnZeroPetrol += Lose;
    }

    public void Win()
    {
        Time.timeScale = 0;
        HealthSystem.OnZeroHealth -= Lose;
        PetrolSystem.OnZeroPetrol -= Lose;
        FinishSystem.OnEndPath -= Win;
        _winPanel.SetActive(true);
        _winAudioSource.Play();
        OnGameEnd?.Invoke();
    }

    public void Lose()
    {
        HealthSystem.OnZeroHealth -= Lose;
        PetrolSystem.OnZeroPetrol -= Lose;
        FinishSystem.OnEndPath -= Win;
        Time.timeScale = 0;
        _losePanel.SetActive(true);
        _loseAudioSource.Play();
        OnGameEnd?.Invoke();
    }
}