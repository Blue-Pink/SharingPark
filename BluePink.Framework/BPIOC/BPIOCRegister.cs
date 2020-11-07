using System;
using System.Collections.Generic;
using System.Text;

namespace BluePink.Framework.BPIOC
{
    /// <summary>
    /// 注册器
    /// </summary>
    public class BPIOCRegister
    {
        /// <summary>
        /// 生命周期
        /// </summary>
        internal LifeTimeType RegisterLifeTime { get; set; }
        /// <summary>
        /// 注册类型
        /// </summary>
        internal Type RegisterType { get; set; }
        /// <summary>
        /// 单例存储
        /// </summary>
        internal object TransientMemory { get; set; }
        /// <summary>
        /// 构造参数指定值存储
        /// </summary>
        internal object[] ValueTypeArray { get; set; }

    }

    /// <summary>
    /// 生命周期管理
    /// </summary>
    public enum LifeTimeType
    {
        /// <summary>
        /// 瞬时
        /// </summary>
        Transient,
        /// <summary>
        /// 单例
        /// </summary>
        Singleton,
        /// <summary>
        /// 作用域
        /// </summary>
        Scoped,
        /// <summary>
        /// 线程
        /// </summary>
        Thread,
    }
}
