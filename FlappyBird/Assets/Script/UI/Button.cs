using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ClickButton()
    {
        if (Level.Instance.gameState == GameState.LOSE)
        {
            Level.Instance.ResetLevel();
            Player.Instance.ResetPlayer();
        }
        else if (Level.Instance.gameState == GameState.WIN)
        {
            SceneManager.LoadScene(Level.Instance.sceneName);
        }

        ResumeGame();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Level.Instance.gameState = GameState.PLAYING;
    }
}
