using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Tests
{
    [TestClass]
    public class RovStateBuilderTest
    {
        [TestMethod]
        public void TestBuildRovState()
        {
            byte status = 1;
            byte heading = 250;
            byte tilt = 55;

            int headingInDegrees = (int)(1.44 * (int)heading);

            byte[] packet = new byte[] { Constants.StartByte, heading, tilt, status, Constants.StopByte };
            RovState state = RovStateBuilder.BuildRovState(packet);

            System.Diagnostics.Debug.WriteLine(state.Error);
            System.Diagnostics.Debug.WriteLine(state.Heading);
            System.Diagnostics.Debug.WriteLine(state.CameraTilt);

            Assert.IsTrue(state.Error);
            Assert.IsTrue(state.Heading == headingInDegrees);
            Assert.IsTrue(state.CameraTilt == (int)tilt);
        }
    }
}
