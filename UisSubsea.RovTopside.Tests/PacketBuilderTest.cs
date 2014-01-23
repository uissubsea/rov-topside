﻿using System;
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
            pb = new PacketBuilder(jm);
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
    }
}