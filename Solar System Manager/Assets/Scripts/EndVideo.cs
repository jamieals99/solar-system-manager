using UnityEngine;

public class EndVideo : MonoBehaviour
{

    float timer = Manager.timer;
    bool videoPlayed = false;
 
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
    }

    void PlayVideo()
    {
        if (!videoPlayed)
        {
            GameObject camera = GameObject.Find("MainCamera");
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "C:/Users/Teamknowhow/Documents/GitHub/solar-system-manager/Solar System Manager/Assets/Pictures/Solar System Blowing Up.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();
            videoPlayed = true;
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
}
