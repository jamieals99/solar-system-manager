using UnityEngine;

public class MoonScoreTrigger : MonoBehaviour
{
    public static int moonScore = -10; // Score starts at -10 as object starts in triggerbox.

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Moon") // If moon enters trigger then it'll add points, planet won't add points.
        {
            moonScore += 10; // Increases score by 100 whenever an object enters the triggerbox.
            Debug.Log("Moon score: " + moonScore); // Displays score to the debug log.
        }
    }
}
