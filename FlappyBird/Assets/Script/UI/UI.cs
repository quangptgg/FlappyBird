using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Button buttonComponent;

    void Start()
    {
        buttonComponent = GetComponentInChildren<Button>();
    }

    void Update()
    {
        GameState currenGameState = Level.Instance.gameState;

        if (currenGameState == GameState.LOSE || currenGameState == GameState.WIN)
        {
            SetButtonText();
            ActivateButton();
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

    public void ActivateButton()
    {
        buttonComponent.gameObject.SetActive(true);
    }

    private void SetButtonText()
    {
        string buttonText = Level.Instance.gameState == GameState.WIN ?
            "You WON! Next Level" : "You LOSE! Try again";
        buttonComponent.GetComponentInChildren<Text>().text = buttonText;
    }
}
