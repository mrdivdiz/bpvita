using UnityEngine;

public class URLManager : Singleton<URLManager>
{

    private void Awake()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
        Singleton<URLManager>.instance = this;
    }

    private void Start()
    {
        this.GenerateURLBaseString();
    }

    private void GenerateURLBaseString()
    {
        this.m_baseURLString = "http://cloud.rovio.com/link/redirect/?";
        switch (DeviceInfo.ActiveDeviceFamily)
        {
            case DeviceInfo.DeviceFamily.Android:
                this.m_baseURLString += "d=android";
                break;
            case DeviceInfo.DeviceFamily.Pc:
                this.m_baseURLString += "d=windows";
                break;
            case DeviceInfo.DeviceFamily.Osx:
                this.m_baseURLString += "d=osx";
                break;
            case DeviceInfo.DeviceFamily.BB10:
                this.m_baseURLString += "d=blackberry";
                break;
            case DeviceInfo.DeviceFamily.WP8:
                this.m_baseURLString += "d=wp8";
                break;
        }
        this.m_baseURLString += "&p=bps";
        if (Singleton<BuildCustomizationLoader>.Instance.IsContentLimited)
        {
            this.m_baseURLString += "&a=free";
        }
        else if (Singleton<BuildCustomizationLoader>.Instance.IsHDVersion)
        {
            this.m_baseURLString += "&a=HD";
        }
        else
        {
            this.m_baseURLString += "&a=full";
        }
        this.m_baseURLString = this.m_baseURLString + "&v=" + Singleton<BuildCustomizationLoader>.Instance.ApplicationVersion;
        this.m_baseURLString += "&r=game";
        this.m_baseURLString = this.m_baseURLString + "&c=" + Singleton<BuildCustomizationLoader>.Instance.CustomerID;
        this.m_baseURLString = this.m_baseURLString + "&i=" + SystemInfo.deviceUniqueIdentifier;
    }

    public string MakeProductTarget(string target)
    {
        if (Singleton<BuildCustomizationLoader>.Instance.CustomerID != "Rovio" && DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Android)
        {
            target = target + "_" + Singleton<BuildCustomizationLoader>.Instance.CustomerID;
        }
        return target;
    }

    public void OpenURL(LinkType type)
    {
        string text = "&t=";
        switch (type)
        {
            case URLManager.LinkType.Youtube:
                text += "rovioyoutube";
                break;
            case URLManager.LinkType.Facebook:
                text += "facebook";
                break;
            case URLManager.LinkType.Twitter:
                text += "twitter";
                break;
            case URLManager.LinkType.Renren:
                text += "renren";
                break;
            case URLManager.LinkType.Weibos:
                text += "weibo";
                break;
            case URLManager.LinkType.YoutubeChina:
                text += "youku";
                break;
            case URLManager.LinkType.Eula:
                text += "eula";
                break;
            case URLManager.LinkType.Privacy:
                text += "privacypolicy";
                break;
            case URLManager.LinkType.FBLike:
                text += "facebooklike";
                break;
            case URLManager.LinkType.GetPCRegistrationKey:
                text += this.MakeProductTarget("badpiggiesfullpc");
                break;
            case URLManager.LinkType.CrossPromoClassic:
                text += this.MakeProductTarget("angrybirdsfull");
                break;
            case URLManager.LinkType.CrossPromoSpace:
                text += this.MakeProductTarget("angrybirdsspacefull");
                break;
            case URLManager.LinkType.CrossPromoAlex:
                text += this.MakeProductTarget("amazingalexfull");
                break;
            case URLManager.LinkType.CrossPromoShop:
                text += "shop";
                break;
            case URLManager.LinkType.CrossPromoNewsLetter:
                text += string.Empty;
                break;
            case URLManager.LinkType.CrossPromoSeasons:
                text += this.MakeProductTarget("angrybirdsseasonsfull");
                break;
            case URLManager.LinkType.BadPiggiesAppStore:
                if (Singleton<BuildCustomizationLoader>.Instance.IsContentLimited)
                {
                    text += "badpiggiesfree";
                }
                else if (Singleton<BuildCustomizationLoader>.Instance.CustomerID == "amazon")
                {
                    text += "badpiggiesfull_amazon";
                }
                else
                {
                    text += "badpiggiesfull";
                }
                break;
            case URLManager.LinkType.CrossPromoStarWars:
                text += "angrybirdsstarwarsfull";
                break;
            case URLManager.LinkType.CrossPromoStarWars2:
                text += this.MakeProductTarget("angrybirdsstarwars2full");
                break;
            case URLManager.LinkType.CrossPromoAngryBirdsFriends:
                text += this.MakeProductTarget("angrybirdsfriendsfull");
                break;
            case URLManager.LinkType.CrossPromoAngryBirdsGo:
                text += this.MakeProductTarget("angrybirdsgofull");
                break;
            case URLManager.LinkType.CrossPromoAngryBirdsRio:
                text += this.MakeProductTarget("angrybirdsriofull");
                break;
            case URLManager.LinkType.MajorLazerMusic:
                text += this.MakeProductTarget("badpiggiestune");
                break;
            case URLManager.LinkType.AppRaterLink:
                if (Singleton<BuildCustomizationLoader>.Instance.IsContentLimited)
                {
                    text += "badpiggiesfree";
                }
                else
                {
                    text += "badpiggiesfull";
                }
                break;
        }
        if (DeviceInfo.IsDesktop && Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        Application.OpenURL(this.m_baseURLString + text);
    }

    private string m_baseURLString = string.Empty;

    public enum LinkType
    {
        Youtube,
        Facebook,
        Twitter,
        Renren,
        Weibos,
        YoutubeChina,
        Eula,
        Privacy,
        FBLike,
        GetPCRegistrationKey,
        CrossPromoClassic,
        CrossPromoSpace,
        CrossPromoAlex,
        CrossPromoShop,
        CrossPromoNewsLetter,
        CrossPromoSeasons,
        BadPiggiesAppStore,
        CrossPromoStarWars,
        CrossPromoStarWars2,
        CrossPromoAngryBirdsFriends,
        CrossPromoAngryBirdsGo,
        CrossPromoAngryBirdsRio,
        MajorLazerMusic,
        AppRaterLink
    }
}
