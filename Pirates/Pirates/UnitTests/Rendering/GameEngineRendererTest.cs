using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Pirates.Rendering;
using Pirates.GameObjects;

namespace Pirates.UnitTests.Rendering
{
    class GameEngineRendererTest : TestCase
    {
        private static String NAME = "GameEngineRendererTest";
        public GameEngineRendererTest()
            : base(NAME)
        {
            //empty, implement this if you need
        }

        private TestResult onMapElementAddedTest()
        {
            GameEngineRenderer renderer = new GameEngineRenderer(null);
            bool result = true;
            int assertions = 0;
            int testLevel = 2;
            TerrainObject testObject = new TerrainObject(testLevel);
            result &= assertTrue(renderer.getObjectsToRender().Count == 0);
            ++assertions;
            if (!result)
            {
                return new TestResult(result, "onMapElementAddedTest", assertions);
            }
            renderer.addTerrain(testObject);
            result &= assertTrue(renderer.getObjectsToRender().ContainsKey(testLevel));
            ++assertions;
            if (!result)
            {
                return new TestResult(result, "onMapElementAddedTest", assertions);
            }
            return new TestResult(result, "onMapElementAddedTest", -1);
        }

        private TestResult addTerrainTest()
        {
            GameEngineRenderer renderer = new GameEngineRenderer(null);
            bool result = true;
            int assertions = 0;
            int testLevel = 2;
            TerrainObject testObject = new TerrainObject(testLevel);
            result &= assertTrue(renderer.getTerrain().Count == 0);
            ++assertions;
            if (!result)
            {
                return new TestResult(result, "addTerrainTest", assertions);
            }
            renderer.addTerrain(testObject);
            result &= assertEqual(renderer.getTerrain().ElementAt(0), testObject);
            ++assertions;
            if (!result)
            {
                return new TestResult(result, "addTerrainTest", assertions);
            }
            return new TestResult(result, "addTerrainTest", -1);
        }

        public override void run(StreamWriter writer)
        {
            base.run(writer);
            logResult(writer, onMapElementAddedTest());
            logResult(writer, addTerrainTest());
        }
    }
}
