using BluePink.Framework.BPIOC;
using IOCTestConsole.ITest;

namespace IOCTestConsole.Test
{
    public class TestServiceE : ITestServiceE
    {
        public int ParameterValue { get; }
        public string ParameterValue2 { get; }

        [AppointConstructor]
        public TestServiceE( int parameterValue,  string parameterValue2)
        {
            ParameterValue = parameterValue;
            ParameterValue2 = parameterValue2;
        }

    }
}
