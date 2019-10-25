using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private int score = -100; // Score starts at -100 as object starts in triggerbox.


    void OnTriggerEnter()
    {
        score = score + 100; // Increases score by 100 whenever an object enters the triggerbox.
        Debug.Log(score); // Displays score to the debug log.
    }

}
