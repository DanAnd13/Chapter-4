using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAccountIcon : MonoBehaviour
{
    public Image accountIcon;
    private Sprite _accountPicture;
    private void Awake()
    {
        LoadIcon();
    }
    private void LoadIcon()
    {
        _accountPicture = Resources.Load<Sprite>("User_Icon");
        accountIcon.sprite = _accountPicture;
    }
}
