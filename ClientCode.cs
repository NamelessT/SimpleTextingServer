using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Threading;

namespace ClientApplication
{
    /*
 * ===========================================================================================
 * This is the client code for the simple messing program
 * all comms are encrypted and the server protects your IP address from the other clients
 * up to 16 connections
 * ===========================================================================================
 * WRITEN BY JOE VOISEY
 * APRIL 11 2021
 * ===========================================================================================
 * THIS CANNOT BE USED FOR FINANCIAL GAIN, THIS CODE IS FREE AND PERMITTED FOR PERSONAL USE 
 * ===========================================================================================
 */
    class Program
    {
        private static bool GirlsRights = false;
        private static IPAddress SERVER_IP;
        private static int PORT;
        private static RSAParameters serv_key;
        private static XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private static RSAParameters priv_key = csp.ExportParameters(true);
        private static RSAParameters pub_key = csp.ExportParameters(false);
        private static Thread listn_thread = new Thread(new ThreadStart(LISTN));
        private static Thread writ_thread = new Thread(new ThreadStart(WRIT));
        private static Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static void Main(string[] args)
        {
            try
            {
                byte[] msg_bytes = new byte[1024];
                Console.WriteLine("Ip Address?\n");
                string msg = Console.ReadLine();
                SERVER_IP = IPAddress.Parse(msg);
                Console.WriteLine("Port?\n");
                try
                {
                    PORT = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Put in a number dipshit");
                    Console.ReadLine();
                }
                try
                {
                    s.Connect(SERVER_IP, PORT);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Socket Connection failed, aborting(like your mom should have)");
                }
                s.Receive(msg_bytes);
                using (Stream str = new MemoryStream(msg_bytes))
                {
                    serv_key = (RSAParameters)xs.Deserialize(str);
                }
                StringWriter sr = new StringWriter();
                xs.Serialize(sr, pub_key);
                string key = sr.ToString();
                key = key.Replace("utf-16", "ASCII");
                msg_bytes = System.Text.Encoding.ASCII.GetBytes(key);
                s.Send(msg_bytes);
                listn_thread.Start();
                writ_thread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        private static void LISTN()
        {
            while (true)
            {
                byte[] msg_bytes = new byte[1024];
                s.Receive(msg_bytes);
                csp.ImportParameters(priv_key);
                msg_bytes = csp.Decrypt(msg_bytes, false);
                string msg = System.Text.Encoding.ASCII.GetString(msg_bytes);
                Console.WriteLine(msg);
            }
        }
        private static void WRIT()
        {
            while (true)
            {
                string msg = Console.ReadLine();
                if(msg == "//quit")
                {
                    Environment.Exit(0);
                }
                byte[] msg_bytes = System.Text.Encoding.ASCII.GetBytes(msg);
                csp.ImportParameters(serv_key);
                msg_bytes = csp.Encrypt(msg_bytes, false);
                s.Send(msg_bytes);
            }
        }
    }
}
/*
 * =================================================================================================================
 * NOTES FOR LINUX!
 * =================================================================================================================
 * The code can work on Android thru Termux; proot-distro virtual environmets.  
 * However its strongly discouraged because it has bad boot times and not much testing has been done for it(I only ran it once)
 * this code has been used with Linux using MONO C# in terminal. The System.Security.Cryptography RSA Library is slow on Linux 
 * so Windows is recommended, for exiting the application thru terminal type "//quit" in the writeline
 *==================================================================================================================
 */