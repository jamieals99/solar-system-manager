using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public static float Score = 0; // Score starts at -100 as object starts in triggerbox.

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="Planet") // If planet enters trigger then it'll add points, moon won't add points.
        {
            Score += 20f * collision.gameObject.transform.lossyScale.x * collision.gameObject.GetComponent<Orbit>().radius; // Increases score by 100 whenever an object enters the triggerbox.
            //Debug.Log("Score: " + Score); // Displays score to the debug log.
        }
        else if (collision.gameObject.tag=="Moon")
        {
            Score += 10;
            //Debug.Log("Score: " + Score);
        }
    }

}
