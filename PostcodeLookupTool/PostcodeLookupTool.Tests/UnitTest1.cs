using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using PostcodeLookupTool.Interfaces;
using PostcodeLookupTool.UX;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PostcodeLookupTool.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IPostcodeLookup> mock;

        [TestMethod]
        public void TestMethod1()
        {
            //This is a test in progress, please ignore.

            //string sInput = "{\"TN9\":\"Delivery from Warehouse\"},{\"TN9 1AP\":\"No Deliveries\"},{\"TN8\":\"Delivery from Warehouse\"},{\"TN11\":\"Delivery from Warehouse\"},{\"TN1\":\"Van Delivery, Collect from Tunbridge Wells\"},{\"TN2\":\"Van Delivery, Collect from Tunbridge Wells\"},{\"TN10\":\"Van Delivery\"},{\"TN13\":\"Delivery from Sevenoaks, Collect from Sevenoaks\"},{\"TN14\":\"Delivery from Sevenoaks, Collect from Sevenoaks\"},{\"TN15\":\"Collect from Sevenoaks\"},{\"ME\":\"No Deliveries\"},{\"ME10\":\"Collect from Kitchen\"},{\"ME10 3\":\"Collect from Kitchen, Delivery  from Sittingbourne\"},{\"IV\":\"No Deliveries\"},{\"All others\":\"Delivery by Courier\"}";

            //JsonConvert.DeserializeObject<string[]>(sInput);

            //string[] sOutput = new string[] { };
        }

        [TestMethod]
        public void GetValidDeliveryOptionsTest_Available_AreEqual()
        {
            string sInput = "ME10 3";
            string[] sOutput = new string[] { "ME10 3", "Collect from Kitchen, Delivery  from Sittingbourne" };

            Mock<IPostcodeLookup> _mock = new Mock<IPostcodeLookup>();

            _mock.Setup(m => m.GetValidDeliveryOptions(sInput)).Returns(() => sOutput);

            PostcodeLookup postcodeLookup = new PostcodeLookup(_mock.Object);

            string[] sTest = postcodeLookup.GetValidDeliveryOptions(sInput);

            //Assert.AreEqual(sOutput, sTest);

            CollectionAssert.AreEqual(sOutput, sTest);
        }

        [TestMethod]
        public void ConsoleArgumentsTest()
        {
            //Program program = new Program();
        }

        [TestMethod]
        public void GetValidDeliveryOptionsTest_Unavailable_AreEqual()
        {
            string sInput = "SM5 1RT";
            string[] sOutput = new string[] { "All others", "Delivery by Courier" };

            Mock<IPostcodeLookup> _mock = new Mock<IPostcodeLookup>();

            _mock.Setup(m => m.GetValidDeliveryOptions(sInput)).Returns(() => sOutput);

            PostcodeLookup postcodeLookup = new PostcodeLookup(_mock.Object);

            string[] sTest = postcodeLookup.GetValidDeliveryOptions(sInput);

            //Assert.AreEqual(sOutput, sTest);

            CollectionAssert.AreEqual(sOutput, sTest);
        }
    }
}
