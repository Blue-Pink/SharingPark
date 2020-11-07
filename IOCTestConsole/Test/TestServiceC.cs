using System;
using System.Collections.Generic;
using System.Text;

namespace IOCTestConsole.ITest
{
    public class TestServiceC : ITestServiceC
    {
        private ITestServiceA _serviceA;
        private ITestServiceB _serviceB;

        public TestServiceC(ITestServiceA serviceA, ITestServiceB serviceB)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;
        }
    }
}
