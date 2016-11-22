using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Yohoo.Resource
{
    public class RemoteLoaderInfo : AbstractLoaderInfo
    {
        public string url = "";
        public WWW www = null;

        public override bool IsComplete()
        {
            if(www == null)
            {
                return false;
            }
            else
            {
                return www.isDone;
            }
        }

        public override System.Object GetRes()
        {
            if(resType == ResType.Text)
                {
                    if(www.isDone)
                    {
                        return www.text;
                    }
                }
                return null;
        }
    }
}
