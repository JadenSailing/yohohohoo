using System.Collections;
using UnityEngine;

namespace Yohoo.Resource
{
    public class RemoteLoader : AbstractLoader
    {
        public RemoteLoaderInfo LoadRemoteUrlByWWW(string url)
        {
            RemoteLoaderInfo info = new RemoteLoaderInfo();
            info.url = url;
            //ResourceManager.Instance.GetMonoEntry().StartCoroutine(LoadRemoteUrlByWWW(info));
            LoadRemoteUrlByWWW(info);
            return info;
        }

        /*
        IEnumerator LoadRemoteUrlByWWW(RemoteLoaderInfo info)
        {
            WWW www = new WWW(info.url);
            info.www = www;
            yield return www;
        }
         * */

        void LoadRemoteUrlByWWW(RemoteLoaderInfo info)
        {
            WWW www = new WWW(info.url);
            info.www = www;
        }
    }
}
