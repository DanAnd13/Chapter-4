using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountView : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Button scrollToLeft;
    public Button scrollToRight;
    public Canvas mainMenuCanvas;
    public Canvas accountSettingsCanvas;

    private void Start()
    {
        scrollToRight.onClick.AddListener(ScrollToRight);
        scrollToLeft.onClick.AddListener(ScrollToLeft);
    }
   private void ScrollToRight()
    {
        mainMenuCanvas.sortingOrder = 0;
        accountSettingsCanvas.sortingOrder = 1;
        scrollRect.horizontalNormalizedPosition = 0f;
    }
   private void ScrollToLeft()
    {
        mainMenuCanvas.sortingOrder = 1;
        accountSettingsCanvas.sortingOrder = 0;
        scrollRect.horizontalNormalizedPosition = 1f;
    }
}
