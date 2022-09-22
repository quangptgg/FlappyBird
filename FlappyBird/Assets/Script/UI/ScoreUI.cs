using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Score: " + Level.Instance.playerScore.ToString();          
    }
}
