using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.UnitTests
{
    class TestResult
    {
        public bool result { set; get; }
        public String testMethodName { set; get; }
        public int assertionFailNumber { set; get; }

        public TestResult(bool result, string name, int assertionNumber)
        {
            this.result = result;
            testMethodName = name;
            assertionFailNumber = assertionNumber;
        }
    }
}
