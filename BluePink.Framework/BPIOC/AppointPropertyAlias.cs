using System;
using System.Collections.Generic;
using System.Text;

namespace BluePink.Framework.BPIOC
{
    /// <summary>
    /// 指定属性归属别名
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AppointPropertyAlias : AppointProperty
    {
        public string Alias { get; }

        public AppointPropertyAlias(string alias)
        {
            Alias = alias;
        }
    }
}
