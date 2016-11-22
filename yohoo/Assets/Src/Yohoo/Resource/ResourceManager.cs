using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yohoo.Core;
using UnityEngine;
using Yohoo.Resource;

public class ResourceManager : Singleton<ResourceManager>, ICommon
{
    private RemoteLoader m_RemoteLoader = null;
    private ResourcesLoader m_ResourcesLoader = null;

    private List<AbstractLoaderInfo> _LoadingResList = new List<AbstractLoaderInfo>();

    public delegate void OnResourceCallBack(int index, System.Object obj);

    public void Init()
    {
        m_RemoteLoader = new RemoteLoader();
        m_ResourcesLoader = new ResourcesLoader();
    }

    public void Tick(int uDeltaTimeMS)
    {
        for (int i = 0; i < _LoadingResList.Count; i++)
		{
            AbstractLoaderInfo info = _LoadingResList[i];
            if(info.isValid)
            {
                if(info.IsComplete())
                {
                    if(info.callback != null)
                    {
                        info.isValid = false;
                        info.callback(info.LoadIndex, info.GetRes());
                    }
                    _LoadingResList.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    public void Release()
    {

    }

    private static int _LoadIndex = 0;
    private static int GetLoadIndex()
    {
        return ++_LoadIndex;
    }

    private void AddLoader(AbstractLoaderInfo info)
    {
        info.isValid = true;
        _LoadingResList.Add(info);
    }

    /// <summary>
    /// 基于WWW加载远程Url的文本
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public int LoadRemoteTextByWWW(string url, OnResourceCallBack callback)
    {
        int loadIndex = GetLoadIndex();
        RemoteLoaderInfo info = m_RemoteLoader.LoadRemoteUrlByWWW(url);
        info.resType = AbstractLoaderInfo.ResType.Text;
        info.callback = callback;
        info.LoadIndex = loadIndex;
        this.AddLoader(info);
        return loadIndex;
    }

    public System.Object LoadObject(string url)
    {
        return m_ResourcesLoader.LoadObject(url);
    }

    public string LoadText(string url)
    {
        return m_ResourcesLoader.LoadText(url);
    }
}
