using System;
using System.Collections.Generic;
using System.Text;

namespace SharingPark.Framework
{
    public static class BPIOC
    {
        private static readonly Dictionary<string, Type> _iocDictionary = new Dictionary<string, Type>();

        public static void Register<TFrom, TTo>() where TTo : TFrom
        {
            _iocDictionary.Add(typeof(TFrom).FullName!, typeof(TTo));
        }

        public static T Resolve<T>()
        {
            return default(T);
        }


    }
}
