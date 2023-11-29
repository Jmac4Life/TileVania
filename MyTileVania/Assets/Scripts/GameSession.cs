using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int intPlayerLives = 3;

    // Start is called before the first frame update
    void Awake()
    {
        int intNumGameSession = FindObjectsOfType<GameSession>().Length;
        if (intNumGameSession > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (intPlayerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    void TakeLife()
    {
        intPlayerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }


}
