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
    private CanvasGroup _lowerCanvasGroup;

    private void Awake()
    {
        _lowerCanvasGroup = mainMenuCanvas.gameObject.AddComponent<CanvasGroup>();
    }
    private void Start()
    {
        scrollToRight.onClick.AddListener(ScrollToRight);
        scrollToLeft.onClick.AddListener(ScrollToLeft);
    }

   private void ScrollToRight()
    {
        StartCoroutine(ScrollToRightAnimation());
    }
    private IEnumerator ScrollToRightAnimation()
    {
        mainMenuCanvas.sortingOrder = 0;
        accountSettingsCanvas.sortingOrder = 1;
        scrollRect.vertical = true;
        scrollRect.horizontal = true;
        while (scrollRect.horizontalNormalizedPosition > 0)
        {
            scrollRect.horizontalNormalizedPosition -= 0.05f;
            _lowerCanvasGroup.alpha -= 0.01f;
            yield return null;
        }
        scrollRect.horizontal = false;
    }
   private void ScrollToLeft()
    {
        StartCoroutine (ScrollToLeftAnimation());
    }
    private IEnumerator ScrollToLeftAnimation()
    {
        scrollRect.vertical = true;
        scrollRect.horizontal = true;
        while (scrollRect.horizontalNormalizedPosition < 1)
        {
            scrollRect.horizontalNormalizedPosition += 0.05f;
            _lowerCanvasGroup.alpha += 0.01f;
            yield return null;
        }
        mainMenuCanvas.sortingOrder = 1;
        accountSettingsCanvas.sortingOrder = 0;
        scrollRect.horizontal = false;
    }
}
