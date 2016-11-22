using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yohoo.Core
{
    public class Singleton<T> where T: class, new()
    {
        private static T _intance;

        public static T Instance
        {
            get
            {
                if(_intance == null)
                {
                    _intance = System.Activator.CreateInstance<T>();
                }
                return _intance;
            }
        }
    }
}
