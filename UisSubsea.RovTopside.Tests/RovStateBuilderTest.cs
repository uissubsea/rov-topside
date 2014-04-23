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
            int frontCameraInDegrees = (int)frontTilt - 75;
            int rearCameraInDegrees = (int)(rearTilt*-1)+30;
            int depthInCm = (int)(3 * (int)depth);
            int distanceToBottomInCm = (int)(3 * (int)distanceToBottom);
            int distanceInCm = (int)(2 * (int)distance);

            byte[] packet = new byte[] {status, heading, frontTilt, rearTilt, distance, 
                depth, distanceToBottom};
            RovState state = RovStateBuilder.BuildRovState(packet);

            System.Diagnostics.Debug.WriteLine(status + "\t" + state.Error);
            System.Diagnostics.Debug.WriteLine(headingInDegrees + "\t" + state.Heading);
            System.Diagnostics.Debug.WriteLine(frontCameraInDegrees + "\t" + state.FrontCameraTilt);
            System.Diagnostics.Debug.WriteLine(rearCameraInDegrees + "\t" + state.RearCameraTilt);
            System.Diagnostics.Debug.WriteLine(distanceInCm + "\t" + state.Distance);
            System.Diagnostics.Debug.WriteLine(depthInCm + "\t" + state.Depth);
            System.Diagnostics.Debug.WriteLine(distanceToBottomInCm + "\t" + state.DistanceToBottom);

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
