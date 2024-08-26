using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class LoadAssetBundleOnClick : MonoBehaviour
{
    public Transform content;
    public Image icon;
    public TextMeshProUGUI title;
    public GameObject appsCanvas;
    private Image[] _targetImages;

    private void Awake()
    {
        _targetImages = new Image[content.childCount];
        for (int i = 0; i < content.childCount; i++)
        {
            _targetImages[i] = content.GetChild(i).GetComponent<Image>();
        }
    }
    public void OnButtonClick(Button button)
    {
        string bundleName = button.name;
        StartCoroutine(LoadAssetBundle(bundleName));
        appsCanvas.SetActive(true);
    }

    private IEnumerator LoadAssetBundle(string bundleName)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, bundleName);

        AssetBundleCreateRequest bundleRequest = AssetBundle.LoadFromFileAsync(path);
        yield return bundleRequest;

        AssetBundle bundle = bundleRequest.assetBundle;
        if (bundle == null)
        {
            Debug.LogError($"Failed to load AssetBundle: {bundleName}");
            yield break;
        }

        Sprite[] sprites = bundle.LoadAllAssets<Sprite>();

        icon.sprite = sprites[0];
        title.text = bundleName;
        for (int i = 1;  i < sprites.Length; i++)
        {
            _targetImages[i-1].sprite = sprites[i];
        }

        bundle.Unload(false);
    }
}
