using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text scoreText;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Player " + GameState.playerScore + " - " + GameState.oppenentScore + " Musuh";
    }

}