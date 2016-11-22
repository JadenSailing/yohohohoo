using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yohoo.Core
{
    public interface ICommon
    {
        void Init();
        void Tick(int uDeltaTimeMS);
        void Release();
    }
}
