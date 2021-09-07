using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Mil_Sinm
{   
    /*
    *File System for the program works as so
    *---------------------------------------------------------
    *(game)/Maps/ -- is for map files
    *(game)/Config/ -- is the configuration files for the game
    *---------------------------------------------------------
    */
    class row
    {
        public byte[] row_b = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
    }
    class map
    {
        public row[] rows = new row[16];
        public row[] row_terrain = new row[16];
        public row[] row_alt = new row[16];
    }
    class Program
    {
        private static map map_ = new map();

        private static string[] FINAL_RENDER = new string[16];

        private static row row_0 = new row();
        private static row row_1 = new row();
        private static row row_2 = new row();
        private static row row_3 = new row();
        private static row row_4 = new row();
        private static row row_5 = new row();
        private static row row_6 = new row();
        private static row row_7 = new row();
        private static row row_8 = new row();
        private static row row_9 = new row();
        private static row row_a = new row();
        private static row row_b = new row();
        private static row row_c = new row();
        private static row row_d = new row();
        private static row row_e = new row();
        private static row row_f = new row();

        private static row row_0t = new row();
        private static row row_1t = new row();
        private static row row_2t = new row();
        private static row row_3t = new row();
        private static row row_4t = new row();
        private static row row_5t = new row();
        private static row row_6t = new row();
        private static row row_7t = new row();
        private static row row_8t = new row();
        private static row row_9t = new row();
        private static row row_at = new row();
        private static row row_bt = new row();
        private static row row_ct = new row();
        private static row row_dt = new row();
        private static row row_et = new row();
        private static row row_ft = new row();

        private static row row_0a = new row();
        private static row row_1a = new row();
        private static row row_2a = new row();
        private static row row_3a = new row();
        private static row row_4a = new row();
        private static row row_5a = new row();
        private static row row_6a = new row();
        private static row row_7a = new row();
        private static row row_8a = new row();
        private static row row_9a = new row();
        private static row row_aa = new row();
        private static row row_ba = new row();
        private static row row_ca = new row();
        private static row row_da = new row();
        private static row row_ea = new row();
        private static row row_fa = new row();

        private static Thread[] THR_ARR = new Thread[16];
        static Program()
        {
            THR_ARR[0x00] = new Thread(() => THREADED_REND(row_0, 0x00));
            THR_ARR[0x01] = new Thread(() => THREADED_REND(row_1, 0x01));
            THR_ARR[0x02] = new Thread(() => THREADED_REND(row_2, 0x02));
            THR_ARR[0x03] = new Thread(() => THREADED_REND(row_3, 0x03));
            THR_ARR[0x04] = new Thread(() => THREADED_REND(row_4, 0x04));
            THR_ARR[0x05] = new Thread(() => THREADED_REND(row_5, 0x05));
            THR_ARR[0x06] = new Thread(() => THREADED_REND(row_6, 0x06));
            THR_ARR[0x07] = new Thread(() => THREADED_REND(row_7, 0x07));
            THR_ARR[0x08] = new Thread(() => THREADED_REND(row_8, 0x08));
            THR_ARR[0x09] = new Thread(() => THREADED_REND(row_9, 0x09));
            THR_ARR[0x0a] = new Thread(() => THREADED_REND(row_a, 0x0a));
            THR_ARR[0x0b] = new Thread(() => THREADED_REND(row_b, 0x0b));
            THR_ARR[0x0c] = new Thread(() => THREADED_REND(row_c, 0x0c));
            THR_ARR[0x0d] = new Thread(() => THREADED_REND(row_d, 0x0d));
            THR_ARR[0x0e] = new Thread(() => THREADED_REND(row_e, 0x0e));
            THR_ARR[0x0f] = new Thread(() => THREADED_REND(row_f, 0x0f));
        }
        static void Main(string[] args)
        {
            row_0.row_b[0x00] = 0x01;
            row_1.row_b[0x01] = 0x01;
            row_2.row_b[0x02] = 0x01;
            row_3.row_b[0x03] = 0x01;
            row_4.row_b[0x04] = 0x01;
            row_5.row_b[0x05] = 0x01;
            row_6.row_b[0x06] = 0x01;
            row_7.row_b[0x07] = 0x01;
            row_8.row_b[0x08] = 0x01;
            row_9.row_b[0x09] = 0x01;
            row_a.row_b[0x0a] = 0x01;
            row_b.row_b[0x0b] = 0x01;
            row_c.row_b[0x0c] = 0x01;
            row_d.row_b[0x0d] = 0x01;
            row_e.row_b[0x0e] = 0x01;
            row_f.row_b[0x0f] = 0x01;

            map_.rows[0x00] = row_0;
            map_.rows[0x01] = row_1;
            map_.rows[0x02] = row_2;
            map_.rows[0x03] = row_3;
            map_.rows[0x04] = row_4;
            map_.rows[0x05] = row_5;
            map_.rows[0x06] = row_6;
            map_.rows[0x07] = row_7;
            map_.rows[0x08] = row_8;
            map_.rows[0x09] = row_9;
            map_.rows[0x0a] = row_a;
            map_.rows[0x0b] = row_b;
            map_.rows[0x0c] = row_c;
            map_.rows[0x0d] = row_d;
            map_.rows[0x0e] = row_e;
            map_.rows[0x0f] = row_f;

            RENDER();

            string json = JsonConvert.SerializeObject(map_);
            File.WriteAllText("C:/Server/map.json",json);
            string data = File.ReadAllText("C:/Server/map.json");
            map_ = JsonConvert.DeserializeObject<map>(data);

            row_0 = map_.rows[0x00];
            row_1 = map_.rows[0x01];
            row_2 = map_.rows[0x02];
            row_3 = map_.rows[0x03];
            row_4 = map_.rows[0x04];
            row_5 = map_.rows[0x05];
            row_6 = map_.rows[0x06];
            row_7 = map_.rows[0x07];
            row_8 = map_.rows[0x08];
            row_9 = map_.rows[0x09];
            row_a = map_.rows[0x0a];
            row_b = map_.rows[0x0b];
            row_c = map_.rows[0x0c];
            row_d = map_.rows[0x0d];
            row_e = map_.rows[0x0e];
            row_f = map_.rows[0x0f];


        }
        static void RENDER()
        {
            THR_ARR[0x00].Start();
            THR_ARR[0x01].Start();
            THR_ARR[0x02].Start();
            THR_ARR[0x03].Start();
            THR_ARR[0x04].Start();
            THR_ARR[0x05].Start();
            THR_ARR[0x06].Start();
            THR_ARR[0x07].Start();
            THR_ARR[0x08].Start();
            THR_ARR[0x09].Start();
            THR_ARR[0x0a].Start();
            THR_ARR[0x0b].Start();
            THR_ARR[0x0c].Start();
            THR_ARR[0x0d].Start();
            THR_ARR[0x0e].Start();
            THR_ARR[0x0f].Start();
            Console.WriteLine(FINAL_RENDER[0x00]);
            Console.WriteLine(FINAL_RENDER[0x01]);
            Console.WriteLine(FINAL_RENDER[0x02]);
            Console.WriteLine(FINAL_RENDER[0x03]);
            Console.WriteLine(FINAL_RENDER[0x04]);
            Console.WriteLine(FINAL_RENDER[0x05]);
            Console.WriteLine(FINAL_RENDER[0x06]);
            Console.WriteLine(FINAL_RENDER[0x07]);
            Console.WriteLine(FINAL_RENDER[0x08]);
            Console.WriteLine(FINAL_RENDER[0x09]);
            Console.WriteLine(FINAL_RENDER[0x0a]);
            Console.WriteLine(FINAL_RENDER[0x0b]);
            Console.WriteLine(FINAL_RENDER[0x0c]);
            Console.WriteLine(FINAL_RENDER[0x0d]);
            Console.WriteLine(FINAL_RENDER[0x0e]);
            Console.WriteLine(FINAL_RENDER[0x0f]);
            THR_ARR[0x00] = new Thread(() => THREADED_REND(row_0, 0x00));
            THR_ARR[0x01] = new Thread(() => THREADED_REND(row_1, 0x01));
            THR_ARR[0x02] = new Thread(() => THREADED_REND(row_2, 0x02));
            THR_ARR[0x03] = new Thread(() => THREADED_REND(row_3, 0x03));
            THR_ARR[0x04] = new Thread(() => THREADED_REND(row_4, 0x04));
            THR_ARR[0x05] = new Thread(() => THREADED_REND(row_5, 0x05));
            THR_ARR[0x06] = new Thread(() => THREADED_REND(row_6, 0x06));
            THR_ARR[0x07] = new Thread(() => THREADED_REND(row_7, 0x07));
            THR_ARR[0x08] = new Thread(() => THREADED_REND(row_8, 0x08));
            THR_ARR[0x09] = new Thread(() => THREADED_REND(row_9, 0x09));
            THR_ARR[0x0a] = new Thread(() => THREADED_REND(row_a, 0x0a));
            THR_ARR[0x0b] = new Thread(() => THREADED_REND(row_b, 0x0b));
            THR_ARR[0x0c] = new Thread(() => THREADED_REND(row_c, 0x0c));
            THR_ARR[0x0d] = new Thread(() => THREADED_REND(row_d, 0x0d));
            THR_ARR[0x0e] = new Thread(() => THREADED_REND(row_e, 0x0e));
            THR_ARR[0x0f] = new Thread(() => THREADED_REND(row_f, 0x0f));
            Thread.Sleep(50);
        }
        static void THREADED_REND(row row_, byte value)
        {
            FINAL_RENDER[value] = ROW_REND(row_);
        }
        static string FIND(byte value)
        {
            if(value == 0x01)
            {
                return "*";
            }
            return "";
        }
        static string ROW_REND(row row_)
        {
            string row_a = "|_0_|_1_|_2_|_3_|_4_|_5_|_6_|_7_|_8_|_9_|_a_|_b_|_c_|_d_|_e_|_f_|";
            if (row_.row_b[0x00] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x00]);
                row_a = row_a.Replace("0", replace_);
            }
            if (row_.row_b[0x01] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x01]);
                row_a = row_a.Replace("1", replace_);
            }
            if (row_.row_b[0x02] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x02]);
                row_a = row_a.Replace("2", replace_);
            }
            if (row_.row_b[0x03] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x03]);
                row_a = row_a.Replace("3", replace_);
            }
            if (row_.row_b[0x04] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x04]);
                row_a = row_a.Replace("4", replace_);
            }
            if (row_.row_b[0x05] != 0x05)
            {
                string replace_ = FIND(row_.row_b[0x05]);
                row_a = row_a.Replace("5", replace_);
            }
            if (row_.row_b[0x06] != 0x06)
            {
                string replace_ = FIND(row_.row_b[0x06]);
                row_a = row_a.Replace("6", replace_);
            }
            if (row_.row_b[0x07] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x07]);
                row_a = row_a.Replace("7", replace_);
            }
            if (row_.row_b[0x08] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x08]);
                row_a = row_a.Replace("8", replace_);
            }
            if (row_.row_b[0x09] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x09]);
                row_a = row_a.Replace("9", replace_);
            }
            if (row_.row_b[0x0a] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0a]);
                row_a = row_a.Replace("a", replace_);
            }
            if (row_.row_b[0x0b] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0b]);
                row_a = row_a.Replace("b", replace_);
            }
            if (row_.row_b[0x0c] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0c]);
                row_a = row_a.Replace("c", replace_);
            }
            if (row_.row_b[0x0d] != 0x0d)
            {
                string replace_ = FIND(row_.row_b[0x0d]);
                row_a = row_a.Replace("d", replace_);
            }
            if (row_.row_b[0x0e] != 0x0e)
            {
                string replace_ = FIND(row_.row_b[0x0e]);
                row_a = row_a.Replace("e", replace_);

            }
            if (row_.row_b[0x0f] != 0x0f)
            {
                string replace_ = FIND(row_.row_b[0x0f]);
                row_a = row_a.Replace("f", replace_);
            }
            string out_ = row_a;
            out_ = out_.Replace("|"," ");
            out_ = out_.Replace("_"," ");
            out_ = out_.Replace("0", " ");
            out_ = out_.Replace("1", " ");
            out_ = out_.Replace("2", " ");
            out_ = out_.Replace("3", " ");
            out_ = out_.Replace("4", " ");
            out_ = out_.Replace("5", " ");
            out_ = out_.Replace("6", " ");
            out_ = out_.Replace("7", " ");
            out_ = out_.Replace("8", " ");
            out_ = out_.Replace("9", " ");
            out_ = out_.Replace("a", " ");
            out_ = out_.Replace("b", " ");
            out_ = out_.Replace("c", " ");
            out_ = out_.Replace("d", " ");
            out_ = out_.Replace("e", " ");
            out_ = out_.Replace("f", " ");
            return out_;
        }
    }
}
