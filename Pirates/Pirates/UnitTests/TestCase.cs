using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pirates.UnitTests
{
    class TestCase
    {
        private String name;
        public TestCase(String name)
        {
            this.name = name;
        }

        public virtual void run(StreamWriter writer)
        {
            writer.WriteLine(name);
            writer.WriteLine();
        }

        protected void logResult(StreamWriter writer, TestResult result)
        {
            if (!result.result)
            {
                writer.WriteLine("---FAIL---");
                writer.WriteLine(result.testMethodName + " failed on assertion number " + result.assertionFailNumber);
                writer.WriteLine("Check code for more details");
            }
            else
            {
                writer.WriteLine(result.testMethodName + " passed");
            }
            writer.WriteLine("--------------");
        }

        protected bool assertTrue(bool logicalCondition)
        {
            try
            {
                return logicalCondition;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected bool assertFalse(bool logicalCondition)
        {
            try 
            {
                return !logicalCondition;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected bool assertEqual(object recived, object expected)
        {
            try
            {
                return recived.Equals(expected);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected bool assertNotEqual(object recived, object expected)
        {
            try 
            {
                return !recived.Equals(expected);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected bool assertNull(object received)
        {
            try
            {
                return received == null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected bool assertNotNull(object received)
        {
            try
            {
                return received != null;
            }            
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
