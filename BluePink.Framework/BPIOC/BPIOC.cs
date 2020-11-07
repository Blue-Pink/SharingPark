using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BluePink.Framework.BPIOC;

namespace BluePink.Framework.BPIOC
{
    public class BPIOC : IBPIOC
    {
        /// <summary>
        /// 注册信息存储
        /// </summary>
        private Dictionary<string, BPIOCRegister> _registerDictionary = new Dictionary<string, BPIOCRegister>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IBPIOC NewScoped()
        {
            return new BPIOC
            {
                _registerDictionary = _registerDictionary
            };
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TFrom">归属寄存器</typeparam>
        /// <typeparam name="TTo">实现类</typeparam>
        /// <param name="alias">归属寄存器别名</param>
        /// <param name="values">构造指定参数值</param>
        /// <param name="lifeTimeType">生命周期类型</param>
        public void Register<TFrom, TTo>(string alias = null, object[] values = null, LifeTimeType lifeTimeType = LifeTimeType.Transient) where TTo : TFrom
        {
            alias = ObtainAlias(typeof(TFrom), alias);
            if (_registerDictionary.ContainsKey(alias))
                throw new Exception("Don't repeat registration!Try add and alias for the interface!");
            _registerDictionary.Add(alias, new BPIOCRegister()
            {
                RegisterLifeTime = lifeTimeType,
                RegisterType = typeof(TTo),
                ValueTypeArray = values
            });
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="TFrom">归属寄存器</typeparam>
        /// <param name="alias">归属寄存器别名</param>
        /// <returns>实现类实例化</returns>
        public TFrom Resolve<TFrom>(string alias = null)
        {
            return (TFrom)Resolve(typeof(TFrom), alias);
        }

        /// <summary>
        /// 递归解析
        /// </summary>
        /// <param name="type">归属寄存器</param>
        /// <param name="alias">归属寄存器别名</param>
        /// <returns></returns>
        private object Resolve(Type type, string alias = null)
        {
            //值类型无法构造
            if (type.IsValueType)
                throw new Exception("This type is a values type,but it doesn't have custom attribute [AppointParameterValue].");

            alias = ObtainAlias(type, alias);
            if (!_registerDictionary.ContainsKey(alias))
                throw new Exception("This type not registered or is Non-abstract!");

            var register = _registerDictionary[alias];
            //处理生命周期
            switch (register.RegisterLifeTime)
            {
                case LifeTimeType.Transient:
                    break;
                case LifeTimeType.Singleton:
                    //从单例存储器内读取
                    if (register.TransientMemory is null)
                        break;
                    return register.TransientMemory;
                case LifeTimeType.Scoped:
                    break;
                case LifeTimeType.Thread:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //寄存器注册的实现类.
            type = _registerDictionary[alias].RegisterType;

            #region 构造函数注入
            //构造指定值读取
            var parameterIndex = 0;
            //构建实现类
            dynamic instance = Activator.CreateInstance(type,
                //获取特性指定构造函数.
                (type.GetConstructors()
                     .FirstOrDefault(a => a.IsDefined(typeof(AppointConstructor), true)) ??
                 //无特性时获取参数最多的构造函数.
                 type.GetConstructors()
                     .OrderBy(a => a.GetParameters().Length)
                     .LastOrDefault())?
                //构造函数内所有参数.
                .GetParameters()
                //获取参数类型并进入下一轮解析.
                .Select(parameterInfo => parameterInfo.IsDefined(typeof(AppointParameterValue), true) ||
                                         parameterInfo.ParameterType.IsValueType ||
                                         parameterInfo.ParameterType.Name.ToLower() == "string"
                    //读取构造指定值
                    ? register.ValueTypeArray[parameterIndex++]
                    //构造参数
                    : Resolve(parameterInfo.ParameterType,
                        //追加参数归属别名.
                        parameterInfo.GetCustomAttribute<AppointParameterAlias>()?.Alias ?? ""))
                .ToArray());
            #endregion

            #region 属性注入
            //遍历特性指定属性.
            foreach (var propertyInfo in type
                .GetProperties()
                .Where(a => a.IsDefined(typeof(AppointProperty), true)))
            {
                //构造属性并赋值.
                propertyInfo.SetValue(instance, Resolve(propertyInfo.PropertyType,
                    //追加属性归属别名.
                    propertyInfo.GetCustomAttribute<AppointPropertyAlias>()?.Alias ?? ""));
            }
            #endregion

            #region 函数注入
            //构造指定值读取
            parameterIndex = 0;
            //遍历特性指定函数.
            foreach (var methodInfo in type.GetMethods().Where(a => a.IsDefined(typeof(AppointMethod), true)))
            {
                //执行函数.
                methodInfo.Invoke(instance,
                    methodInfo.GetParameters()
                        .Select(parameterInfo => parameterInfo.IsDefined(typeof(AppointParameterValue), true)
                            //读取构造指定值
                            ? register.ValueTypeArray[parameterIndex++]
                            //构造参数
                            : Resolve(parameterInfo.ParameterType,
                                //追加参数归属别名.
                                parameterInfo.GetCustomAttribute<AppointParameterAlias>()?.Alias ?? ""))
                        .ToArray());
            }
            #endregion

            //处理生命周期
            switch (register.RegisterLifeTime)
            {
                case LifeTimeType.Transient:
                    break;
                case LifeTimeType.Singleton:
                    //存储至单例存储器
                    register.TransientMemory = instance;
                    break;
                case LifeTimeType.Scoped:
                    break;
                case LifeTimeType.Thread:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return instance;
        }

        /// <summary>
        /// 获取别名
        /// </summary>
        /// <param name="type">归属寄存器</param>
        /// <param name="alias">别名</param>
        /// <returns></returns>
        private static string ObtainAlias(Type type, string alias)
        {
            return $"{type.FullName}{alias}";
        }

    }
}
