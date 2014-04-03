using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace UisSubsea.RovTopside.StressTest
{
    public class Program
    {
        private const int numberOfBytes = 20;
        private const byte startByte = 255;
        private const byte stopByte = 251;

        private static StreamWriter w;
        private static SerialPort port;
        private static Random r;
        private static IList<byte> outputBuffer;
        private static IList<byte> inputBuffer;      

        private static void Main(string[] args)
        {
            initializeComponents();

            Log("Starting stress test", w);
            Console.WriteLine("\n------ Starting stress test ------\n");

            while (true)
            {
                try
                {
                    generatePackageOfRandomBytes();
                    writePackageToSerialPort();
                    readPackageFromSerialPort();
                    comparePackages();
                    clearBuffers();                   
                }
                catch (Exception)
                {
                    cleanUp();
                }
            }
        }

        private static void initializeComponents()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

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

            inputBuffer = new List<Byte>(numberOfBytes);
            outputBuffer = new List<Byte>(numberOfBytes);

            r = new Random();
        }

        private static void generatePackageOfRandomBytes()
        {
            // Fill output buffer with random bytes.
            Log("Generating random bytes", w);

            for (int i = 0; i < numberOfBytes; i++)
            {
                byte next = (byte)r.Next(0, 251);
                outputBuffer.Add(next);
            }
        }

        private static void writePackageToSerialPort()
        {
            // Send the random bytes over the serial port.
            Log("Writing bytes to serial port", w);

            // Add start and stop byte according to the
            // communication protocol.
            outputBuffer.Insert(0, (byte)startByte);
            outputBuffer.Add((byte)stopByte);

            byte[] stateArray = outputBuffer.ToArray();

            Log(String.Join(", ", stateArray), w);

            port.Write(stateArray, 0, stateArray.Length);
        }

        private static void readPackageFromSerialPort()
        {
            waitForStartByte();
            bufferDataUntilStopByteIsReceived();
        }

        private static void waitForStartByte()
        {
            bool startByteReceived = false;

            while (!startByteReceived)
            {
                int data = port.ReadByte();

                if ((byte)data == startByte)
                {
                    inputBuffer.Add((byte)data);
                    startByteReceived = true;
                }
            }
        }

        private static void bufferDataUntilStopByteIsReceived()
        {
            // Received bytes from the serial port
            // until stop byte is received.
            Log("Waiting on bytes from serial port", w);

            bool stopByteReceived = false;
            while (!stopByteReceived)
            {
                int data = port.ReadByte();

                inputBuffer.Add((byte)data);

                if ((byte)data == stopByte)
                    stopByteReceived = true;
            }
        }

        private static void comparePackages()
        {
            int mismatchCount = 0;

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
        }

        private static void clearBuffers()
        {
            //Clear the buffers.
            outputBuffer.Clear();
            inputBuffer.Clear();
        }

        // Log messages with a timestamp
        private static void Log(string logMessage, TextWriter w)
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
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("\r\n[SHUTDOWN] Shutting down...");
            cleanUp();
        }

        // Clean up used resources on error or exit
        private static void cleanUp()
        {
            w.Close();

            if (port.IsOpen)
                port.Close();
        }
    }
}
