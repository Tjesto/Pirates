using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Pirates.UnitTests.Rendering;

namespace Pirates.UnitTests
{
    class TestRunner
    {
        protected StreamWriter writer;
        protected List<TestCase> tests;

        protected static TestRunner instance;

        protected TestRunner()
        {
            tests = new List<TestCase>();
            writer = new StreamWriter(@"../TestsResults/UnitTests.txt", true);
            writer.WriteLine("Tests for version " + (Utils.DEBUG ? "Debug" : "Release"));
            writer.WriteLine(DateTime.Now);
            writer.WriteLine();
            createTests();
        }

        protected void createTests()
        {
            tests.Add(new GameEngineRendererTest());
        }

        public void runTests()
        {
            foreach (TestCase test in tests)
            {
                test.run(writer);
                writer.WriteLine("End test");
                writer.WriteLine();
            }
            string finalMessage = "Test completed at " + DateTime.Now;
            writer.WriteLine(finalMessage);
            writer.Close();
            MessageBox.Show(finalMessage, "Tests finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static TestRunner getInstance()
        {
            if (instance == null)
            {
                instance = new TestRunner();
            }
            return instance;
        }
    }
}
