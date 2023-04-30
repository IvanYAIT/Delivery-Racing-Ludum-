using UnityEngine.SceneManagement;

public class Game
{
    public Game()
    {
        HealthSystem.OnZeroHealth += Restart;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HealthSystem.OnZeroHealth -= Restart;
    }
        
}