using System;
using System.Collections.Generic;
using System.Text;

namespace BluePink.Framework.BPIOC
{
    /// <summary>
    /// 指定函数注入
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AppointMethod : Attribute { }

}
