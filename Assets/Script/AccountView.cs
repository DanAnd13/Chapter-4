using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountView : MonoBehaviour
{
    public ScrollRect scrollRect; // Посилання на ScrollRect
    public Button scrollToLeft; // Кнопка для переміщення до верху
    public Button scrollToRight; // Кнопка для переміщення до низу

    void Start()
    {
        // Прив'язуємо методи до натискання на кнопки
        scrollToRight.onClick.AddListener(ScrollToRight);
        scrollToLeft.onClick.AddListener(ScrollToLeft);
    }

    // Метод для переміщення до верху
    void ScrollToRight()
    {
        scrollRect.horizontalNormalizedPosition = 0f;
    }

    // Метод для переміщення до низу
    void ScrollToLeft()
    {
        scrollRect.horizontalNormalizedPosition = 1f;
    }
}
