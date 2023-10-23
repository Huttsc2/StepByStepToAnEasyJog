using Newtonsoft.Json;
using StepByStepToAnEasyJog.Objects.TraningSheets;
using StepByStepToAnEasyJog.Utils.DataLoaders;

namespace SBSTAEJTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetInit800()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetInit800();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetDev800()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetDev800();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetPeak800()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetPeak800();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetTaper800()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetTaper800();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetAltTaper800()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetAltTaper800();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetInit15003000()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetInit15003000();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetDev15003000()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetDev15003000();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetPeak15003000()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetPeak15003000();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetTaper15003000()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetTaper15003000();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetAltTaper15003000()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetAltTaper15003000();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetInit510()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetInit510();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetDev510()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetDev510();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetPeak510()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetPeak510();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetTaper510()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetTaper510();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetAltTaper510()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetAltTaper510();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetInit2142()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetInit2142();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetDev2142()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetDev2142();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetPeak2142()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetPeak2142();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetTaper2142()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetTaper2142();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_GetAltTaper2142()
        {
            try
            {
                Schedule schedule = new JsonConfigReader().GetAltTaper2142();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}