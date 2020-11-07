using System.Collections.Generic;

namespace BluePink.Framework.BPIOC
{
    public interface IBPIOC
    {
        /// <summary>
        /// 创建一个新的作用域
        /// </summary>
        /// <returns></returns>
        public IBPIOC NewScoped();
        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TFrom">归属寄存器</typeparam>
        /// <typeparam name="TTo">实现类</typeparam>
        /// <param name="alias">归属寄存器别名</param>
        /// <param name="values">构造指定参数值</param>
        /// <param name="lifeTimeType">生命周期类型</param>
        public void Register<TFrom, TTo>(string alias = null, object[] values = null,LifeTimeType lifeTimeType=LifeTimeType.Transient) where TTo : TFrom;
        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="TFrom">归属寄存器</typeparam>
        /// <param name="alias">归属寄存器别名</param>
        /// <returns>实现类实例化</returns>
        public TFrom Resolve<TFrom>(string alias = null);

    }
}
