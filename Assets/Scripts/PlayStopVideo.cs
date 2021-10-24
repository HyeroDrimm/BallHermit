using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStopVideo : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer videoPlayer; 

    private void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
    }
    public void PlayVideo()
    {
        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }
}
