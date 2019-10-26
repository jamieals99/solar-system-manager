﻿using UnityEngine;

public class EndVideo : MonoBehaviour
{

    float timer = Manager.timer;
    bool videoPlayed = false;
    float victoryScore;

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
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
            EndScreen();
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

    void EndScreen()
    {
        
    }
}