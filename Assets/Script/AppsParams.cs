using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppsParams : MonoBehaviour
{
    public paramOfApps_Games[] appsType;
    public enum paramOfApps_Games
    {
        Recommend,
        SocialMedia,
        Popular,
        Entertainment,
        NewGames,
        Shop,
        Kids,
        Adult,
        Online,
        Offline,
        Paid,
        Free
    }
}
