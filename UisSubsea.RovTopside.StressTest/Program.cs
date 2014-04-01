using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace UisSubsea.RovTopside.StressTest
{
    class Program
    {
        private static StreamWriter w;
        private static SerialPort port;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            const int numberOfBytes = 20;

            // The file to log to.
            w = File.AppendText("log.txt");

            Console.WriteLine("IMPORTANT NOTE:  Use Ctrl + C to cancel the test\r\n");

            Log("Initializing COM1 for communication", w);
            Console.WriteLine("[INIT] Initializing COM1 for communication");

            // The receiving part must have matching properties.
            port = new SerialPort("COM1", 56000, Parity.None, 8, StopBits.One);

            Log("Opening COM-port", w);
            Console.WriteLine("[INIT] Opening COM-port");

            if (!port.IsOpen)
                port.Open();

            Log("Initializing buffers", w);
            Console.WriteLine("[INIT] Initializing buffers");

            ICollection<byte> inputBuffer = new List<Byte>(numberOfBytes);
            ICollection<byte> outputBuffer = new List<Byte>(numberOfBytes);

            Random r = new Random();

            Log("Starting stress test", w);
            Console.WriteLine("\n------ Starting stress test ------\n");

            while (true)
            {
                try
                {
                    int mismatchCount = 0;
                    
                    // Fill output buffer with random bytes.
                    Log("Generating random bytes", w);

                    for (int i = 0; i < numberOfBytes; i++)
                    {
                        byte next = (byte)r.Next(0, 251);
                        outputBuffer.Add(next);
                    }

                    // Send the random bytes over the serial port.
                    Log("Writing bytes to serial port", w);

                    byte[] stateArray = outputBuffer.ToArray();
                    Log(String.Join(", ", stateArray), w);
                    port.Write(stateArray, 0, stateArray.Length);

                    // Received bytes from the serial port.
                    Log("Waiting on bytes from serial port", w);

                    for (int i = 0; i < numberOfBytes; i++)
                    {
                        int data = port.ReadByte();
                        inputBuffer.Add((byte)data);
                    }

                    // Compare the received bytes with the ones that where sent.
                    // If they are not equal, register a failed test.
                    for (int i = 0; i < numberOfBytes; i++)
                    {
                        if (!(outputBuffer.ElementAt(i).Equals(inputBuffer.ElementAt(i))))
                        {
                            mismatchCount++;

                            Log("Byte mismatch (" + mismatchCount + ")!", w);
                            var currentTime = DateTime.Now.ToString("HH:mm:ss");
                            Console.WriteLine("[FAIL] " + currentTime + "   byte mismatch (" + mismatchCount + ")!");
                        }
                    }

                    //Clear the buffers.
                    outputBuffer.Clear();
                    inputBuffer.Clear();
                }
                catch (Exception)
                {
                    cleanUp();
                }
            }
        }

        // Log messages with a timestamp
        static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        // Use Ctrl+C to exit the application properly.
        // If not, the clean up code will not be executed.
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("\r\n[SHUTDOWN] Shutting down...");
            cleanUp();
        }

        // Clean up used resources on error or exit
        static void cleanUp()
        {
            w.Close();

            if (port.IsOpen)
                port.Close();
        }
    }
}
