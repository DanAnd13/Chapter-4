using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAppsAndGames : MonoBehaviour
{
    public GameObject[] gamesCategoriesContents;
    public GameObject[] appsCategoriesContents;
    private GameObject[] _apps;
    private AppsParams[] _appsParam;
    private GameObject[] _games;
    private AppsParams[] _gamesParam;

    private void Awake()
    {
        LoadAppsAndGamesFromResources();
    }
    private void Start()
    {
        LoadAppsInContent();
        LoadGamesInContent();
    }
    private void LoadAppsAndGamesFromResources()
    {
        // Load Apps and initialize the arrays
        _apps = Resources.LoadAll<GameObject>("Apps");
        _appsParam = new AppsParams[_apps.Length];

        for (int i = 0; i < _apps.Length; i++)
        {
            _appsParam[i] = _apps[i].GetComponent<AppsParams>();
        }

        // Load Games and initialize the arrays
        _games = Resources.LoadAll<GameObject>("Games");
        _gamesParam = new AppsParams[_games.Length];

        for (int i = 0; i < _games.Length; i++)
        {
            _gamesParam[i] = _games[i].GetComponent<AppsParams>();
        }
    }
    private void LoadAppsInContent()
    {
        for (int i = 0; i < appsCategoriesContents.Length; i++)
        {
            string categoryName = appsCategoriesContents[i].name;

            for (int j = 0; j < _apps.Length; j++)
            {
                AppsParams appsParam = _appsParam[j];

                foreach (var appsType in appsParam.appsType)
                {
                    if (appsType.ToString() == categoryName)
                    {
                        GetParentForObject(_apps[j], appsCategoriesContents[i]);
                        break;
                    }
                }
            }
        }
    }
    private void LoadGamesInContent()
    {
        for (int i = 0; i < gamesCategoriesContents.Length; i++)
        {
            string categoryName = gamesCategoriesContents[i].name;

            for (int j = 0; j < _games.Length; j++)
            {
                AppsParams gameParam = _gamesParam[j];

                foreach (var gameType in gameParam.appsType)
                {
                    if (gameType.ToString() == categoryName)
                    {
                        GetParentForObject(_games[j], gamesCategoriesContents[i]);
                        break;
                    }
                }
            }
        }
    }
    private void GetParentForObject(GameObject obj, GameObject parent)
    {
        GameObject instance = Instantiate(obj, Vector2.zero, Quaternion.identity);
        instance.transform.SetParent(parent.transform, false);
    }
}
