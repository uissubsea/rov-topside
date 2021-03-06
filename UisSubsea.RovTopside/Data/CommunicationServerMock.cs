﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UisSubsea.RovTopside.Data
{
    public class CommunicationServerMock : ICommunicationServer
    {
        private JoystickStateStore stateStore;
        public event EventHandler<DataReceivedEventArgs> RovStateReceived;
        private ICollection<byte> inputBuffer;
        private Random random;
        int data = 0;

        public CommunicationServerMock(JoystickStateStore stateStore)
        {
            this.stateStore = stateStore;
            inputBuffer = new List<byte>(5);
            random = new Random();
        }

        public void Serve() 
        {
            while(true)
            {
                for (int i = 0; i < 5; i++)
                {
                    inputBuffer.Add((byte)(data));
                }
                invokePacketReceived();
                inputBuffer.Clear();
                Thread.Sleep(100);

                data++;
                if (data == 251)
                    data = 0;
            }
        }

        private void invokePacketReceived()
        {
            DataReceivedEventArgs args = new DataReceivedEventArgs();
            args.Data = inputBuffer.ToArray();
            OnRovStateReceived(args);
        }
       
        // This method is virtual to ensure that it can be overridden in a derived class.
        protected virtual void OnRovStateReceived(DataReceivedEventArgs e)
        {
            EventHandler<DataReceivedEventArgs> handler = RovStateReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
