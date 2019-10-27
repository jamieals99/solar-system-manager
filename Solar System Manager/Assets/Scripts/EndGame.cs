using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] Transform gameUI, endUI;

    [SerializeField] Text victoryScoreText;

    float timer = Manager.timer;
    float victoryScore;
    bool gameEnd = false;

    void Update()
    {
        timer = Manager.timer;
        if (timer == 0&& !gameEnd)
        {
            victoryScore = Mathf.Round(ScoreTrigger.Score);
            gameEnd = true;
            DisableUI();
            EndScreen();
        }
    }

    void DisableUI()
    {
        gameUI.gameObject.SetActive(false);
    }

    void EndScreen()
    {
        endUI.gameObject.SetActive(true);
        victoryScoreText.text = "Score: " + victoryScore;
    }
}