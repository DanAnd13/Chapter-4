using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadAppsAndGames : MonoBehaviour
{
    public GameObject gamesMainWindow;
    public GameObject appsMainWindow;
    public GameObject categoriesContent;
    public GameObject[] gamesCategoriesContents;
    public GameObject[] appsCategoriesContents;
    private bool _isApps = true;
    private Button[] _apps;
    private AppsParams[] _appsParam;
    private Button[] _games;
    private AppsParams[] _gamesParam;
    private LoadAssetBundleOnClick onClickEvent;

    private void Awake()
    {
        LoadAppsAndGamesFromResources();
        onClickEvent = GetComponent<LoadAssetBundleOnClick>();
    }
    private void Start()
    {
        for (int i = 0; i < appsCategoriesContents.Length; i++)
        {
            LoadAppsInContent(appsCategoriesContents[i].name, appsCategoriesContents[i]);
        }
        for (int i = 0; i < gamesCategoriesContents.Length; i++)
        {
            LoadGamesInContent(gamesCategoriesContents[i].name, gamesCategoriesContents[i]);
        }

    }

    public void TypeOfApp(bool type)
    {
        _isApps = type;
    }
    public void GetAppsAndGamesCategories(GameObject categoryName)
    {
        if (_isApps)
        {
            LoadAppsInContent(categoryName.name, categoriesContent);
        }
        else
        {
            LoadGamesInContent(categoryName.name, categoriesContent);
        }
    }
    public void LoadMainWindow()
    {
        if (_isApps)
        {
            appsMainWindow.SetActive(true);
        }
        else
        {
            gamesMainWindow.SetActive(true);
        }
        Debug.LogError("Buttons");
    }
    private void LoadAppsAndGamesFromResources()
    {
        _apps = Resources.LoadAll<Button>("Apps");
        _appsParam = new AppsParams[_apps.Length];

        for (int i = 0; i < _apps.Length; i++)
        {
            _appsParam[i] = _apps[i].GetComponent<AppsParams>();
        }

        _games = Resources.LoadAll<Button>("Games");
        _gamesParam = new AppsParams[_games.Length];

        for (int i = 0; i < _games.Length; i++)
        {
            _gamesParam[i] = _games[i].GetComponent<AppsParams>();
        }
    }
    private void ClearAllChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    private void LoadAppsInContent(string categoryName, GameObject parent)
    {
        ClearAllChildren(parent);
        for (int j = 0; j < _apps.Length; j++)
        {
            AppsParams appsParam = _appsParam[j];
            foreach (var appsType in appsParam.appsType)
            {
                if (appsType.ToString() == categoryName)
                {
                    GetParentForObject(_apps[j], parent);
                    break;
                }
            }
        }
    }
    private void LoadGamesInContent(string categoryName, GameObject parent)
    {
        ClearAllChildren(parent);
        for (int j = 0; j < _games.Length; j++)
        {
            AppsParams gameParam = _gamesParam[j];
            foreach (var gameType in gameParam.appsType)
            {
                if (gameType.ToString() == categoryName)
                {
                    GetParentForObject(_games[j], parent);
                    break;
                }
            }
        }
    }
    private void GetParentForObject(Button obj, GameObject parent)
    {
        GameObject instance = Instantiate(obj.gameObject, Vector2.zero, Quaternion.identity);
        instance.gameObject.name = obj.name;
        instance.transform.SetParent(parent.transform, false);
    }
}
