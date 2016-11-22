using System.Collections;
using UnityEngine;

namespace Yohoo.Resource
{
    public class ResourcesLoader : AbstractLoader
    {
        public System.Object LoadObject(string url)
        {
            return Resources.Load(url);
        }

        public string LoadText(string url)
        {
            TextAsset obj = Resources.Load(url, typeof(TextAsset)) as TextAsset;
            return obj.text;
        }
    }
}
