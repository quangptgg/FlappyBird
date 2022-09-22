using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject levelGameObject;

    public void ClickButton()
    {
        Level level = levelGameObject.GetComponent<Level>();

        if (level.gameState == GameState.LOSE)
        {
            levelGameObject.GetComponent<Level>().ResetLevel();
            playerGameObject.GetComponent<Player>().ResetPlayer();
        }
        else if (level.gameState == GameState.WIN)
        {
            SceneManager.LoadScene(level.sceneName);
        }
        
        Time.timeScale = 1.0f;
        levelGameObject.GetComponent<Level>().gameState = GameState.PLAYING;
    }
}
