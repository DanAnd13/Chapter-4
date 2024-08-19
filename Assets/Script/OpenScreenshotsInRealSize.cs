using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenScreenshotsInRealSize : MonoBehaviour, IPointerClickHandler
{
    public Canvas zoomCanvas;
    public Image zoomedImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        Image img = GetComponent<Image>();

        if (img != null)
        {
            zoomCanvas.gameObject.SetActive(true);

            zoomedImage.sprite = img.sprite;
        }
    }
    public void OnCloseZoomCanvas()
    {
        zoomCanvas.gameObject.SetActive(false);
    }
}
