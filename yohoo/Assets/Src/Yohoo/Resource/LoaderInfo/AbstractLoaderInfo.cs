using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yohoo.Resource
{
    public abstract class AbstractLoaderInfo
    {
        public enum ResType
        {
            Text,
            GameObject,
            Object
        }

        public int LoadIndex = 0;

        public bool isValid = false;

        public ResType resType = ResType.Object;

        public ResourceManager.OnResourceCallBack callback = null;

        public abstract System.Object GetRes();

        public abstract bool IsComplete();
    }
}
