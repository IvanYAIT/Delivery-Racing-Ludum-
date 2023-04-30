using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void BuutonStartGames()
    {
        SceneManager.LoadScene(1);
    }
    public void BuutonSettings()
    {
        SceneManager.LoadScene(2);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
