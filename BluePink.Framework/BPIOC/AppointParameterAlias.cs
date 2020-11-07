using System;
using System.Collections.Generic;
using System.Text;

namespace BluePink.Framework.BPIOC
{
    /// <summary>
    /// 指定参数归属别名
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class AppointParameterAlias : Attribute
    {
        public string Alias { get; }

        public AppointParameterAlias(string alias)
        {
            Alias = alias;
        }
    }
}
