using UnityEngine;

public class Level : SingletonMonoBehavior<Level>
{
    [HideInInspector] public int playerScore = 0;
    [HideInInspector] public GameState gameState = GameState.PLAYING;
    public GameObject starsContainer;
    public string sceneName;

    public void ResetLevel()
    {
        playerScore = 0;
        starsContainer.GetComponent<StarContainer>().ResetStars();
        GetComponentInChildren<DynamicObstacle>().ResetObstacle();
    }

    public void LoseGame()
    {
        gameState = GameState.LOSE;
        Time.timeScale = 0.0f;
    }

    public void WinGame()
    {
        gameState = GameState.WIN;
        Time.timeScale = 0.0f;
    }

    public void IncreasePlayerPoint()
    {
        playerScore += 1;
        if (playerScore == 3)
        {
            WinGame();
        }
    }
}
