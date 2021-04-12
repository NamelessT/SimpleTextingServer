using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Xml;
/*
 * ===========================================================================================
 * This is the server code for the simple messing program
 * all comms are encrypted and the server uses mulithreading for handling comms
 * up to 16 connections
 * ===========================================================================================
 * WRITEN BY JOE VOISEY
 * APRIL 11 2021
 * ===========================================================================================
 * THIS CANNOT BE USED FOR FINANCIAL GAIN, THIS CODE IS FREE AND PERMITTED FOR PERSONAL USE 
 * ===========================================================================================
 */
namespace CommandServer
{
    class Program
    {
        private static byte key_num = 0;
        private static bool[] CLIENT_KEY_ACTIVE = new bool[16];
        private static IPAddress SERVER_IP = IPAddress.Parse("192.168.1.88");
        private static int SERVER_PORT = 78;
        //^^ *Variables for manual configuration before compilation*

        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);

        //^^ Encryption keysize can be changed
        private static IPAddress[] WHITELIST = new IPAddress[16];
        //^^ Whitelist
        private static Thread[] WRT_THREADS = new Thread[16];
        private static Socket[] SOC_ARRAY = new Socket[16];
        private static bool[] ACTIVE = new bool[16];
        private static bool[] RUNNIN = new bool[16];
        //^^ The amount of Threads in the bracket, is the amount of clients the server can handle at once
        //^^ DO NOT CHANGE!!!

        private static RSAParameters PubKey = csp.ExportParameters(false);
        private static RSAParameters Privkey = csp.ExportParameters(true);
        private static RSAParameters[] CLIENTKEY_ARRAY = new RSAParameters[16];
        //^^ Server Keys for encryption

        private static bool[] THREAD_ACT = new bool[16];
        private static XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
        private static byte[] key_bytes = new byte[1024];
        static Program()
        {
            WHITELIST[0] = IPAddress.Parse("148.72.166.12");
            //^^ This is were you declare the IP's for the WhiteList
            StringWriter sr = new StringWriter();
            xs.Serialize(sr, PubKey);
            string key = sr.ToString();
            key = key.Replace("utf-16", "ASCII");
            key_bytes = Encoding.ASCII.GetBytes(key);

        }
        private static TcpListener server = new TcpListener(SERVER_IP, SERVER_PORT);
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("INIT");
                for (int i = 0; i <= RUNNIN.Length - 1; i++)
                {
                    RUNNIN[i] = false;
                }
                for (int i = 0; i <= CLIENT_KEY_ACTIVE.Length - 1; i++)
                {
                    CLIENT_KEY_ACTIVE[i] = false;
                }
                for (int i = 0; i <= THREAD_ACT.Length - 1; i++)
                {
                    THREAD_ACT[i] = false;
                }
                WRT_THREADS[0] = new Thread(() => LISTN(0, SOC_ARRAY[0]));
                WRT_THREADS[1] = new Thread(() => LISTN(1, SOC_ARRAY[1]));
                WRT_THREADS[2] = new Thread(() => LISTN(2, SOC_ARRAY[2]));
                WRT_THREADS[3] = new Thread(() => LISTN(3, SOC_ARRAY[3]));
                WRT_THREADS[4] = new Thread(() => LISTN(4, SOC_ARRAY[4]));
                WRT_THREADS[5] = new Thread(() => LISTN(5, SOC_ARRAY[5]));
                WRT_THREADS[6] = new Thread(() => LISTN(6, SOC_ARRAY[6]));
                WRT_THREADS[7] = new Thread(() => LISTN(7, SOC_ARRAY[7]));
                WRT_THREADS[8] = new Thread(() => LISTN(8, SOC_ARRAY[8]));
                WRT_THREADS[9] = new Thread(() => LISTN(9, SOC_ARRAY[9]));
                WRT_THREADS[10] = new Thread(() => LISTN(10, SOC_ARRAY[10]));
                WRT_THREADS[11] = new Thread(() => LISTN(11, SOC_ARRAY[11]));
                WRT_THREADS[12] = new Thread(() => LISTN(12, SOC_ARRAY[12]));
                WRT_THREADS[13] = new Thread(() => LISTN(13, SOC_ARRAY[13]));
                WRT_THREADS[14] = new Thread(() => LISTN(14, SOC_ARRAY[14]));
                WRT_THREADS[15] = new Thread(() => LISTN(15, SOC_ARRAY[15]));
                //^^ For Loop Initializes the Thread[]
                Thread CONN = new Thread(new ThreadStart(CONN_HANDL));
                //^^ Thread Handles connections
                Thread HAND = new Thread(new ThreadStart(ACTIVE_HANDL));
                //^^ Thread Handles incoming messages and such


                CONN.Start();

                HAND.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        private static void ACTIVE_HANDL()
        {
            try
            {


                while (true)
                {
                    if (ACTIVE[0] && RUNNIN[0] == false)
                    {
                        WRT_THREADS[0].Start();
                        RUNNIN[0] = true;
                    }
                    if (ACTIVE[1] && RUNNIN[1] == false)
                    {
                        WRT_THREADS[1].Start();
                        RUNNIN[1] = true;
                    }
                    if (ACTIVE[2] && RUNNIN[2] == false)
                    {
                        WRT_THREADS[2].Start();
                        RUNNIN[2] = true;
                    }
                    if (ACTIVE[3] && RUNNIN[3] == false)
                    {
                        WRT_THREADS[3].Start();
                        RUNNIN[3] = true;
                    }
                    if (ACTIVE[4] && RUNNIN[4] == false)
                    {
                        WRT_THREADS[4].Start();
                        RUNNIN[4] = true;
                    }
                    if (ACTIVE[5] && RUNNIN[5] == false)
                    {
                        WRT_THREADS[5].Start();
                        RUNNIN[5] = true;
                    }
                    if (ACTIVE[6] && RUNNIN[6] == false)
                    {
                        WRT_THREADS[6].Start();
                        RUNNIN[6] = true;
                    }
                    if (ACTIVE[7] && RUNNIN[7] == false)
                    {
                        WRT_THREADS[7].Start();
                        RUNNIN[7] = true;
                    }
                    if (ACTIVE[8] && RUNNIN[8] == false)
                    {
                        WRT_THREADS[8].Start();
                        RUNNIN[8] = true;
                    }
                    if (ACTIVE[9] && RUNNIN[9] == false)
                    {
                        WRT_THREADS[9].Start();
                        RUNNIN[9] = true;
                    }
                    if (ACTIVE[10] && RUNNIN[10] == false)
                    {
                        WRT_THREADS[10].Start();
                        RUNNIN[10] = true;
                    }
                    if (ACTIVE[11] && RUNNIN[11] == false)
                    {
                        WRT_THREADS[11].Start();
                        RUNNIN[11] = true;
                    }
                    if (ACTIVE[12] && RUNNIN[12] == false)
                    {
                        WRT_THREADS[12].Start();
                        RUNNIN[12] = true;
                    }
                    if (ACTIVE[13] && RUNNIN[13] == false)
                    {
                        WRT_THREADS[13].Start();
                        RUNNIN[13] = true;
                    }
                    if (ACTIVE[14] && RUNNIN[14] == false)
                    {
                        WRT_THREADS[14].Start();
                        RUNNIN[14] = true;
                    }
                    if (ACTIVE[15] && RUNNIN[15] == false)
                    {
                        WRT_THREADS[15].Start();
                        RUNNIN[15] = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        //^^ Handles the active connections(saves threads)
        private static void WRIT()
        {
            while (true)
            {
                string msg = Console.ReadLine();
                if (msg == "//quit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    byte[] msg_bytes = System.Text.Encoding.ASCII.GetBytes(msg);
                    STR(17, msg_bytes);
                }
            }
        }
        private static void LISTN(byte swich, Socket s)
        {
            while (true)
            {
                try
                {
                    byte[] msg_bytes = new byte[256];
                    s.Receive(msg_bytes);
                    csp.ImportParameters(Privkey);
                    msg_bytes = csp.Decrypt(msg_bytes, false);
                    EndPoint s_ep = s.RemoteEndPoint;
                    Console.WriteLine(s_ep.ToString() + " Said:\n" + Encoding.ASCII.GetString(msg_bytes) + "\n" + "________________________________________");
                    STR(swich, msg_bytes);
                }
                catch (Exception e)
                {
                    DISCONNT(swich);
                }
            }
        }
        private static void DISCONNT(byte swich)
        {
            try
            {
                key_num--;
                ACTIVE[swich] = false;
                RUNNIN[swich] = false;
                CLIENT_KEY_ACTIVE[swich] = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        private static void STR(byte swich, byte[] msg)
        {
            try
            {
                for (int i = 0; i <= 15; i++)
                {
                    if (swich == i)
                    {
                        i++;
                    }
                    else
                    {
                        if (CLIENT_KEY_ACTIVE[i])
                        {

                            try
                            {
                                csp.ImportParameters(CLIENTKEY_ARRAY[i]);
                                msg = csp.Encrypt(msg, false);
                                Socket s = SOC_ARRAY[i];
                                s.Send(msg);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                                Console.ReadLine();
                            }
                        }
                        if (CLIENT_KEY_ACTIVE[i] == false)
                        {
                            i++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        private static void CONN_HANDL()
        {
            try
            {
                while (true)
                {
                    server.Start();
                    Socket s = server.AcceptSocket();
                    EndPoint s_ep = s.RemoteEndPoint;
                    Console.WriteLine("Connection Made with " + s_ep.ToString());
                    Console.WriteLine("Accept Connection? (Y or N)");
                    string res = Console.ReadLine();
                    if (res == "N")
                    {
                        s.Close();
                    }
                    RSAParameters ClientKey;
                    byte[] ClientKeyBytes = new byte[1024];
                    s.Send(key_bytes);
                    s.Receive(ClientKeyBytes);
                    using (Stream str = new MemoryStream(ClientKeyBytes))
                    {
                        ClientKey = (RSAParameters)xs.Deserialize(str);
                    }
                    CLIENTKEY_ARRAY[key_num] = ClientKey;
                    ACTIVE[key_num] = true;
                    SOC_ARRAY[key_num] = s;
                    CLIENT_KEY_ACTIVE[key_num] = true;
                    key_num++;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
    }
}
/*
 * =================================================================================================================
 * NOTES FOR LINUX!
 * =================================================================================================================
 * The server code has not been experimented on Android, do not recommend  
 * this code has been used with Linux using MONO C# in terminal. The System.Security.Cryptography RSA Library is slow on Linux 
 * so Windows is recommended, for exiting the application thru terminal type "//quit" in the writeline
 *==================================================================================================================
 */
