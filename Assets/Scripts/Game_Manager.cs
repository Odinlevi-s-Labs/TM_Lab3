using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    private bool gameHasEnded = false;
    void Start()
    {
        Stats.instanse.onPlayerDeathCallback += EndGame;
        
    }

    // Update is called once per frame
    void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Restart();
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
