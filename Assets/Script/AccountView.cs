using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountView : MonoBehaviour
{
    public ScrollRect scrollRect; // ��������� �� ScrollRect
    public Button scrollToLeft; // ������ ��� ���������� �� �����
    public Button scrollToRight; // ������ ��� ���������� �� ����

    void Start()
    {
        // ����'����� ������ �� ���������� �� ������
        scrollToRight.onClick.AddListener(ScrollToRight);
        scrollToLeft.onClick.AddListener(ScrollToLeft);
    }

    // ����� ��� ���������� �� �����
    void ScrollToRight()
    {
        scrollRect.horizontalNormalizedPosition = 0f;
    }

    // ����� ��� ���������� �� ����
    void ScrollToLeft()
    {
        scrollRect.horizontalNormalizedPosition = 1f;
    }
}
