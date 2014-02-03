using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UisSubsea.RovTopside.Data;
using System.Linq;

namespace UisSubsea.RovTopside.Tests
{
    [TestClass]
    public class PacketBuilderTest
    {
        private PacketBuilder pb;
        private byte[] AllowedPointOfViews = { 0, 1, 2, 4, 5, 6, 8, 9, 10 };

        [TestInitialize]
        public void Init()
        {
            IJoystick jm = new JoystickMock();
            pb = new MainPacketBuilder(jm);
        }

        [TestMethod]
        public void TestButtonsPressed()
        {
            byte buttons = pb.ButtonsPressed();
            Assert.IsTrue(buttons <= 127 && buttons >= 0);
        }

        [TestMethod]
        public void TestPointOfView()
        {
            byte pov = pb.HatPov();
            Assert.IsTrue(AllowedPointOfViews.Contains(pov));
        }

        [TestMethod]
        public void TestRoll()
        {
            byte roll = pb.Roll();
            Assert.IsTrue(isValid(roll));
        }

        [TestMethod]
        public void TestPitch()
        {
            byte pitch = pb.Pitch();
            Assert.IsTrue(isValid(pitch));

        }

        [TestMethod]
        public void TestYaw()
        {
            byte yaw = pb.Yaw();
            Assert.IsTrue(isValid(yaw));
        }

        [TestMethod]
        public void TestThrottle()
        {
            byte throttle = pb.Throttle();
            Assert.IsTrue(isValid(throttle));
        }

        private Boolean isValid(int value)
        {
            if (value <= 250 && value >= 0)
            {
                return true;
            }
            else return false;
        }
    }
}