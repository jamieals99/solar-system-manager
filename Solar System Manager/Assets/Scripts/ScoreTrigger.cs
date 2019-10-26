using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private int score = -100; // Score starts at -100 as object starts in triggerbox.

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="Planet") // If planet enters trigger then it'll add points, moon won't add points.
        {
            score = score + 100; // Increases score by 100 whenever an object enters the triggerbox.
            Debug.Log("Planet score: " + score); // Displays score to the debug log.
        }
    }

}
