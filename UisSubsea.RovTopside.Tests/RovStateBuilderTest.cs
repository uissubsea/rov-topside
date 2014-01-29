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
            byte startByte = 251;
            byte stopByte = 255;
            byte status = 1;
            byte heading = 250;
            byte tilt = 55;

            int headingInDegrees = (int)(1.44 * (int)heading);

            byte[] packet = new byte[] { startByte, status, heading, tilt, stopByte };
            RovState state = RovStateBuilder.BuildRovState(packet);

            System.Diagnostics.Debug.WriteLine(state.Error);
            System.Diagnostics.Debug.WriteLine(headingInDegrees);
            System.Diagnostics.Debug.WriteLine(state.CameraTilt);

            Assert.IsTrue(state.Error);
            Assert.IsTrue(state.Heading == headingInDegrees);
            Assert.IsTrue(state.CameraTilt == (int)tilt);
        }
    }
}
