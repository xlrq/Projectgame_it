using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isLevelCompleted;
    public GameObject gameOverScreen;
    public GameObject levelCompletedScreene;

    private void Awake()
    {
        isGameOver = false;
        isLevelCompleted= false;
    }
    private void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        else if (isLevelCompleted)
        {
            levelCompletedScreene.SetActive(true);
        }
    }

    public void replayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
