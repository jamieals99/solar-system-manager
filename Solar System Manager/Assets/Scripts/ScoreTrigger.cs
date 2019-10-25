using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private int score = -100;


    void OnTriggerEnter()
    {
        score = score + 100;
        Debug.Log(score);
    }

}
