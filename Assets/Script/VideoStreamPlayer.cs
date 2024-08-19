using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStreamPlayer : MonoBehaviour, IPointerClickHandler
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    private void OnEnable()
    {
        rawImage.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        rawImage.gameObject.SetActive(true);
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
    void OnVideoPrepared(VideoPlayer vp)
    {
        rawImage.texture = vp.texture;
        vp.Play();
    }
}
