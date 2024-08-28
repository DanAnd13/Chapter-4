using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEvent : MonoBehaviour
{
    private LoadAssetBundleOnClick _event;
    private void Start()
    {
        _event = FindObjectOfType<LoadAssetBundleOnClick>();
    }

    public void GetOnClickEvent()
    {
        _event.buttonName = gameObject.name;
        _event.OnButtonClick();
    }
}
