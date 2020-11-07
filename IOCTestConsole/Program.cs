using System;
using BluePink.Framework.BPIOC;
using IOCTestConsole.ITest;
using IOCTestConsole.Test;
using SharingPark.BLL;
using SharingPark.DAL;
using BluePink.Framework;
using SharingPark.IBLL;
using SharingPark.IDAL;
using SharingPark.Model.SQLServerTest;

namespace IOCTestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BPIOC.Register<IUserDAL, UserDAL>();
            //BPIOC.Register<IUserBLL, UserBLL>();
            //var userBLL = BPIOC.Resolve<IUserBLL>();
            //IBPIOC bpioc = new BPIOC();
            //bpioc.Register<ITestServiceA, TestServiceA>();
            //bpioc.Register<ITestServiceB, TestServiceB>();
            //bpioc.Register<ITestServiceC, TestServiceC>();
            //bpioc.Register<ITestServiceD, TestServiceD>();
            //bpioc.Register<ITestServiceE, TestServiceE>(values: new object[] { 111, "Blue Pink" });
            //bpioc.Register<ITestServiceE, TestServiceE2>("2");
            //bpioc.Register<IIocTest, IocTestAlias>("Alias", new object[] { 15 });

            //var iocTestAlias = bpioc.Resolve<IIocTest>("Alias");

            //bpioc.Register<IIocTest, IocTest>(lifeTimeType: LifeTimeType.Singleton);
            //var iocTest = bpioc.Resolve<IIocTest>();
            //var iocTest2 = bpioc.Resolve<IIocTest>();
            //ReferenceEquals(iocTest, iocTest2);//True

            //var bpioc2 = bpioc.NewScoped();
            //var serviceA = bpioc.Resolve<ITestServiceA>();
            //var serviceA2 = bpioc2.Resolve<ITestServiceA>();
            //ReferenceEquals(serviceA, serviceA2);//False

            var count = new SQLServerTest().Db.Queryable<T_Users>().Count();
            Console.WriteLine(count);

        }
    }

    internal interface IIocTest
    {
    }
    internal class IocTest : IIocTest
    {
        private ITestServiceA _serviceA;
        private ITestServiceB _serviceB;
        private ITestServiceC _serviceC;
        [AppointProperty]
        public ITestServiceD TestServiceD { get; set; }
        [AppointConstructor]
        public IocTest(ITestServiceA serviceA, ITestServiceB serviceB)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;
        }

        public IocTest(ITestServiceA serviceA,
            ITestServiceB serviceB,
            ITestServiceC serviceC)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;
            _serviceC = serviceC;
        }

        private ITestServiceE _serviceE;
        [AppointMethod]
        public void TestMethod(ITestServiceE serviceE)
        {
            _serviceE = serviceE;
        }
    }

    internal class IocTestAlias : IIocTest
    {
        [AppointPropertyAlias("2")]
        public ITestServiceE ServiceE { get; set; }

        private ITestServiceE _serviceE;
        private int _parameterValue;
        public IocTestAlias(ITestServiceE serviceE, [AppointParameterValue] int parameterValue)
        {
            _serviceE = serviceE;
            _parameterValue = parameterValue;
        }
        //[AppointMethod]
        //public void IocTestAliasMethod([AppointParameterAlias("2")]ITestServiceE serviceE)
        //{
        //    _serviceE = serviceE;
        //}


        public void TestMethod(ITestServiceE serviceE)
        {
            throw new NotImplementedException();
        }
    }
}
