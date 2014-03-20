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
            byte heading = 123;
            byte frontTilt = 55;
            byte rearTilt = 42;
            byte depth = 34;
            byte distanceToBottom = 166;
            byte distance = 160;

            int headingInDegrees = (int)(2 * (int)heading);
            int frontCameraInDegrees = (int)((int)frontTilt);
            int rearCameraInDegrees = (int)((int)rearTilt);
            int depthInCm = (int)(3 * (int)depth);
            int distanceToBottomInCm = (int)(3 * (int)distanceToBottom);
            int distanceInCm = (int)(2 * (int)distance);

            byte[] packet = new byte[] {heading, frontTilt, rearTilt, status, 
                distance, depth, distanceToBottom};
            RovState state = RovStateBuilder.BuildRovState(packet);

            System.Diagnostics.Debug.WriteLine(state.Error);
            System.Diagnostics.Debug.WriteLine(state.Heading);
            System.Diagnostics.Debug.WriteLine(state.FrontCameraTilt);
            System.Diagnostics.Debug.WriteLine(state.RearCameraTilt);
            System.Diagnostics.Debug.WriteLine(state.Distance);
            System.Diagnostics.Debug.WriteLine(state.Depth);
            System.Diagnostics.Debug.WriteLine(state.DistanceToBottom);

            Assert.IsTrue(state.Error);
            Assert.IsTrue(state.Heading == headingInDegrees);
            Assert.IsTrue(state.FrontCameraTilt == frontCameraInDegrees);
            Assert.IsTrue(state.RearCameraTilt == rearCameraInDegrees);
            Assert.IsTrue(state.Distance == distanceInCm);
            Assert.IsTrue(state.Depth == depthInCm);
            Assert.IsTrue(state.DistanceToBottom == distanceToBottomInCm);           
        }
    }
}
