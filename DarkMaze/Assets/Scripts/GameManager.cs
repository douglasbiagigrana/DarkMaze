using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    bool gameHasEnded = false;
    
    public float restartDelay = 2f;
    public void RestartGame()
    {
        if (gameOver == false)
        {
            gameOver = true;
            Invoke("Restart", restartDelay);
        }
        
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("End", restartDelay + 2);
        }

    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void End()
    {
        SceneManager.LoadScene("Menu");
    }
}
