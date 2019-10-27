using UnityEngine;

public class EndVideo : MonoBehaviour
{
    [SerializeField] Transform gameUI;

    [SerializeField] Transform endUI;

    float timer = Manager.timer;
    bool videoPlayed = false;
    float victoryScore;

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
        EndScreen();
    }

    void PlayVideo()
    {
        if (!videoPlayed)
        {
            victoryScore = ScoreTrigger.Score;
            GameObject camera = GameObject.Find("MainCamera");
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "file://Assets/Pictures/SolarSystemBlowingUp.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();
            videoPlayed = true;
            DisableUI();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer = Manager.timer;
        if (timer == 0)
        {
            PlayVideo();
        }
    }

    void DisableUI()
    {
        gameUI.gameObject.SetActive(false);
    }

    void EndScreen()
    {
        endUI.gameObject.SetActive(true);
    }
}