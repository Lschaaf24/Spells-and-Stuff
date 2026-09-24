using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerFix : MonoBehaviour
{
    void Start()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer != null)
        {
            videoPlayer.playOnAwake = false;
            videoPlayer.Prepare();
        }
    }
}