using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject levelGameObject;
    private Button buttonComponent;

    void Start()
    {
        buttonComponent = GetComponentInChildren<Button>();
    }

    void Update()
    {
        GameState currenGameState = levelGameObject.GetComponent<Level>().gameState;

        if (currenGameState == GameState.LOSE || currenGameState == GameState.WIN)
        {
            ActivateButton(currenGameState);
        }
        else
        {
            DeactiveButton();
        }
    }

    public void ClickButton()
    {
        buttonComponent.ClickButton();
    }

    public void DeactiveButton()
    {
        buttonComponent.gameObject.SetActive(false);
    }

    public void ActivateButton(GameState gameState)
    {
        string buttonText = gameState == GameState.WIN ?
            "You WON! Next Level" : "You LOSE! Try again";
        buttonComponent.GetComponentInChildren<Text>().text = buttonText;
        buttonComponent.gameObject.SetActive(true);
    }
}
