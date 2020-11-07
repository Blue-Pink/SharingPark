using System;
using System.Collections.Generic;
using System.Text;
using IOCTestConsole.ITest;

namespace IOCTestConsole.Test
{
    public class TestServiceB : ITestServiceB
    {
        private ITestServiceA _serviceA;

        public TestServiceB(ITestServiceA serviceA)
        {
            _serviceA = serviceA;
        }
    }
}
