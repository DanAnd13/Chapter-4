using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppsParam : MonoBehaviour
{
    public typeOfApps appsType;
    public content appsContent;
    public audience appsAudience;
    public internetConnection appsInet;
    public styleOfApps appsStyle;
    public enum typeOfApps
    {
        Game,
        App
    }
    public enum content
    {
        Free,
        Paid
    }
    public enum audience
    {
        ForKids,
        Adult
    }
    public enum internetConnection
    {
        With,
        Whithout
    }
    public enum styleOfApps
    {
        SocialMedia,
        MP3_MP4,
        Informational,
        Shop,
        Strategy,
        Racing,
        Survival,
        Action,
        Relax,
        Building
    }
}
