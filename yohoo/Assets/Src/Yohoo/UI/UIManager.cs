using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yohoo.Core;
using Yohoo.Resource;
using UnityEngine;

public struct UIPathInfo
{
    public int Id;
    public string Url;
}

public class UIPath
{
    public static UIPathInfo HeroListPanel;
    
}

public class UIManager : Singleton<UIManager>, ICommon
{
    public class OpenUIInfo
    {
        public int id;
        public string url;
        public GameObject Res;
        public GameObject Panel;
    }

    public GameObject uiRoot = null;

    private Dictionary<int, OpenUIInfo> m_UIDict = new Dictionary<int, OpenUIInfo>();

    public UIPathInfo GetPathInfo(int id, string url)
    {
        UIPathInfo info = new UIPathInfo();
        info.Id = id;
        info.Url = "UI/Panel/" + url;
        return info;
    }

    public void Init()
    {
        UIPath.HeroListPanel = GetPathInfo(1, "HeroListPanel");
    }

    public void Tick(int deltaTime)
    {

    }

    public void Release()
    {

    }

    public void ShowUI(UIPathInfo ui)
    {
        string url = ui.Url;
        if (string.IsNullOrEmpty(url))
        {
            return;
        }
        if(m_UIDict.ContainsKey(ui.Id))
        {
            m_UIDict[ui.Id].Panel.SetActive(true);
            return;
        }

        GameObject res = ResourceManager.Instance.LoadObject(url) as GameObject;

        OpenUIInfo info = new OpenUIInfo();
        info.id = ui.Id;
        info.url = ui.Url;
        info.Res = res;
        info.Panel = NGUITools.AddChild(uiRoot, res);
        m_UIDict[ui.Id] = info;
    }

    public void CloseUI(UIPathInfo ui)
    {
        if(m_UIDict.ContainsKey(ui.Id))
        {
            m_UIDict[ui.Id].Panel.SetActive(false);
        }
    }
}
