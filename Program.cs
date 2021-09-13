using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Mil_Sin
{   
    /*
    *File System for the program works as so
    *---------------------------------------------------------
    *(game)/Maps/ -- is for map files
    *(game)/Config/ -- is the configuration files for the game
    *---------------------------------------------------------
    *TERRAIN GUIDE!
    *---------------------------------------------------------
    * 0x01 = plains
    * 0x02 = light forest
    * 0x03 = heavy forest
    * 0x04 = lightly forested hills
    * 0x05 = heavily forested hills
    * 0x06 = lightly forested mountains
    * 0x07 = heavily forested mountains 
    * 0x08 = desert
    * 0x09 = desert hills
    * 0x0a = desert mountains
    * 0x0b = swamp plains
    * 0x0c = light forest swamp
    * 0x0d = heavily forested swamp
    * 0x0e = River
    * 0x0f = Urban I(Suburban)
    * 0x10 = Urban II(Small Town)
    * 0x11 = Urban III(Large City)
    * 0x12 = Road I(Dirt road)
	* 0x13 = Road II(Two lane road)
	* 0x14 = Road III(Highway)
	* 0x15 = River I(Creek)
	* 0x16 = River II(Small River)
	* 0x17 = River III(Mississippi)
	* 
    */
	class t_t
	{
		public byte value_ = 0x00;
		public byte level_ = 0x00;
	}
    class row
    {
        public byte[] row_b = new byte[32] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
    }
    class map
    {
        public row[] rows = new row[32];
        public row[] row_terrain = new row[32];
    }
    class Program
    {
        private static map map_ = new map();

        private static string[] FINAL_RENDER = new string[32];

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
        private static row row_10 = new row();
        private static row row_11 = new row();
        private static row row_12 = new row();
        private static row row_13 = new row();
        private static row row_14 = new row();
        private static row row_15 = new row();
        private static row row_16 = new row();
        private static row row_17 = new row();
        private static row row_18 = new row();
        private static row row_19 = new row();
        private static row row_1a = new row();
        private static row row_1b = new row();
        private static row row_1c = new row();
        private static row row_1d = new row();
        private static row row_1e = new row();
        private static row row_1f = new row();
		/*
        private static row row_00t = new row();
        private static row row_01t = new row();
        private static row row_02t = new row();
        private static row row_03t = new row();
        private static row row_04t = new row();
        private static row row_05t = new row();
        private static row row_06t = new row();
        private static row row_07t = new row();
        private static row row_08t = new row();
        private static row row_09t = new row();
        private static row row_0at = new row();
        private static row row_0bt = new row();
        private static row row_0ct = new row();
        private static row row_0dt = new row();
        private static row row_0et = new row();
        private static row row_0ft = new row();
        private static row row_10t = new row();
        private static row row_11t = new row();
        private static row row_12t = new row();
        private static row row_13t = new row();
        private static row row_14t = new row();
        private static row row_15t = new row();
        private static row row_16t = new row();
        private static row row_17t = new row();
        private static row row_18t = new row();
        private static row row_19t = new row();
        private static row row_1at = new row();
        private static row row_1bt = new row();
        private static row row_1ct = new row();
        private static row row_1dt = new row();
        private static row row_1et = new row();
        private static row row_1ft = new row();
        */
        private static Thread[] THR_ARR = new Thread[32];
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
            THR_ARR[0x10] = new Thread(() => THREADED_REND(row_10, 0x10));
            THR_ARR[0x11] = new Thread(() => THREADED_REND(row_11, 0x11));
            THR_ARR[0x12] = new Thread(() => THREADED_REND(row_12, 0x12));
            THR_ARR[0x13] = new Thread(() => THREADED_REND(row_13, 0x13));
            THR_ARR[0x14] = new Thread(() => THREADED_REND(row_14, 0x14));
            THR_ARR[0x15] = new Thread(() => THREADED_REND(row_15, 0x15));
            THR_ARR[0x16] = new Thread(() => THREADED_REND(row_16, 0x16));
            THR_ARR[0x17] = new Thread(() => THREADED_REND(row_17, 0x17));
            THR_ARR[0x18] = new Thread(() => THREADED_REND(row_18, 0x18));
            THR_ARR[0x19] = new Thread(() => THREADED_REND(row_19, 0x19));
            THR_ARR[0x1a] = new Thread(() => THREADED_REND(row_1a, 0x1a));
            THR_ARR[0x1b] = new Thread(() => THREADED_REND(row_1b, 0x1b));
            THR_ARR[0x1c] = new Thread(() => THREADED_REND(row_1c, 0x1c));
            THR_ARR[0x1d] = new Thread(() => THREADED_REND(row_1d, 0x1d));
            THR_ARR[0x1e] = new Thread(() => THREADED_REND(row_1e, 0x1e));
            THR_ARR[0x1f] = new Thread(() => THREADED_REND(row_1f, 0x1f));
        }
		/*
			0x01 = Artillery
			0x02 = Infantry
			0x03 = Tank
			0x04 = Engineers
		*/
        static void Main(string[] args)
        {
			row_5.row_b[0x00] = 0x01;
			row_6.row_b[0x00] = 0x01;
			row_7.row_b[0x00] = 0x01;
			row_7.row_b[0x03] = 0x03;
			row_8.row_b[0x02] = 0x04;
			row_6.row_b[0x02] = 0x04;
			row_4.row_b[0x02] = 0x02;
			row_a.row_b[0x02] = 0x02;
			row_8.row_b[0x00] = 0x01;
			row_9.row_b[0x00] = 0x01;
            RENDER();

            string json = JsonConvert.SerializeObject(map_);
            File.WriteAllText("C:/mono/Maps/map.json",json);
        }
        static void RENDER()
        {
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
            map_.rows[0x10] = row_10;
            map_.rows[0x11] = row_11;
            map_.rows[0x12] = row_12;
            map_.rows[0x13] = row_13;
            map_.rows[0x14] = row_14;
            map_.rows[0x15] = row_15;
            map_.rows[0x16] = row_16;
            map_.rows[0x17] = row_17;
            map_.rows[0x18] = row_18;
            map_.rows[0x19] = row_19;
            map_.rows[0x1a] = row_1a;
            map_.rows[0x1b] = row_1b;
            map_.rows[0x1c] = row_1c;
            map_.rows[0x1d] = row_1d;
            map_.rows[0x1e] = row_1e;
            map_.rows[0x1f] = row_1f;
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
            THR_ARR[0x10].Start();
            THR_ARR[0x11].Start();
            THR_ARR[0x12].Start();
            THR_ARR[0x13].Start();
            THR_ARR[0x14].Start();
            THR_ARR[0x15].Start();
            THR_ARR[0x16].Start();
            THR_ARR[0x17].Start();
            THR_ARR[0x18].Start();
            THR_ARR[0x19].Start();
            THR_ARR[0x1a].Start();
            THR_ARR[0x1b].Start();
            THR_ARR[0x1c].Start();
            THR_ARR[0x1d].Start();
            THR_ARR[0x1e].Start();
            THR_ARR[0x1f].Start();
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
            Console.WriteLine(FINAL_RENDER[0x10]);
            Console.WriteLine(FINAL_RENDER[0x11]);
            Console.WriteLine(FINAL_RENDER[0x12]);
            Console.WriteLine(FINAL_RENDER[0x13]);
            Console.WriteLine(FINAL_RENDER[0x14]);
            Console.WriteLine(FINAL_RENDER[0x15]);
            Console.WriteLine(FINAL_RENDER[0x16]);
            Console.WriteLine(FINAL_RENDER[0x17]);
            Console.WriteLine(FINAL_RENDER[0x18]);
            Console.WriteLine(FINAL_RENDER[0x19]);
            Console.WriteLine(FINAL_RENDER[0x1a]);
            Console.WriteLine(FINAL_RENDER[0x1b]);
            Console.WriteLine(FINAL_RENDER[0x1c]);
            Console.WriteLine(FINAL_RENDER[0x1d]);
            Console.WriteLine(FINAL_RENDER[0x1e]);
            Console.WriteLine(FINAL_RENDER[0x1f]);
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
            THR_ARR[0x0f] = new Thread(() => THREADED_REND(row_f, 0x1f));
            THR_ARR[0x10] = new Thread(() => THREADED_REND(row_0, 0x10));
            THR_ARR[0x11] = new Thread(() => THREADED_REND(row_1, 0x11));
            THR_ARR[0x12] = new Thread(() => THREADED_REND(row_2, 0x12));
            THR_ARR[0x13] = new Thread(() => THREADED_REND(row_3, 0x13));
            THR_ARR[0x14] = new Thread(() => THREADED_REND(row_4, 0x14));
            THR_ARR[0x15] = new Thread(() => THREADED_REND(row_5, 0x15));
            THR_ARR[0x16] = new Thread(() => THREADED_REND(row_6, 0x16));
            THR_ARR[0x17] = new Thread(() => THREADED_REND(row_7, 0x17));
            THR_ARR[0x18] = new Thread(() => THREADED_REND(row_8, 0x18));
            THR_ARR[0x19] = new Thread(() => THREADED_REND(row_9, 0x19));
            THR_ARR[0x1a] = new Thread(() => THREADED_REND(row_a, 0x1a));
            THR_ARR[0x1b] = new Thread(() => THREADED_REND(row_b, 0x1b));
            THR_ARR[0x1c] = new Thread(() => THREADED_REND(row_c, 0x1c));
            THR_ARR[0x1d] = new Thread(() => THREADED_REND(row_d, 0x1d));
            THR_ARR[0x1e] = new Thread(() => THREADED_REND(row_e, 0x1e));
            THR_ARR[0x1f] = new Thread(() => THREADED_REND(row_f, 0x1f));
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
                return "* ";
            }
			if(value == 0x02)
			{
				return "X ";
			}
			if(value == 0x03)
			{
				return "T ";
			}
			if(value == 0x04)
			{
				return "E ";
			}
			else
			{
				return "NN";
			}
        }
        static string ROW_REND(row row_)
        {
            string row_a = "|00|01|02|03|04|05|06|07|08|09|0a|0b|0c|0d|0e|0f|10|11|12|13|14|15|16|17|18|19|1a|1b|1c|1d|1e|1f|";
            if (row_.row_b[0x00] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x00]);
                row_a = row_a.Replace("00", replace_);
            }
            if (row_.row_b[0x01] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x01]);
                row_a = row_a.Replace("01", replace_);
            }
            if (row_.row_b[0x02] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x02]);
                row_a = row_a.Replace("02", replace_);
            }
            if (row_.row_b[0x03] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x03]);
                row_a = row_a.Replace("03", replace_);
            }
            if (row_.row_b[0x04] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x04]);
                row_a = row_a.Replace("04", replace_);
            }
            if (row_.row_b[0x05] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x05]);
                row_a = row_a.Replace("05", replace_);
            }
            if (row_.row_b[0x06] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x06]);
                row_a = row_a.Replace("06", replace_);
            }
            if (row_.row_b[0x07] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x07]);
                row_a = row_a.Replace("07", replace_);
            }
            if (row_.row_b[0x08] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x08]);
                row_a = row_a.Replace("08", replace_);
            }
            if (row_.row_b[0x09] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x09]);
                row_a = row_a.Replace("09", replace_);
            }
            if (row_.row_b[0x0a] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0a]);
                row_a = row_a.Replace("0a", replace_);
            }
            if (row_.row_b[0x0b] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0b]);
                row_a = row_a.Replace("0b", replace_);
            }
            if (row_.row_b[0x0c] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0c]);
                row_a = row_a.Replace("0c", replace_);
            }
            if (row_.row_b[0x0d] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0d]);
                row_a = row_a.Replace("0d", replace_);
            }
            if (row_.row_b[0x0e] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0e]);
                row_a = row_a.Replace("0e", replace_);

            }
            if (row_.row_b[0x0f] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x0f]);
                row_a = row_a.Replace("0f", replace_);
            }



            if (row_.row_b[0x10] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x10]);
                row_a = row_a.Replace("10", replace_);
            }
            if (row_.row_b[0x11] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x11]);
                row_a = row_a.Replace("11", replace_);
            }
            if (row_.row_b[0x12] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x12]);
                row_a = row_a.Replace("12", replace_);
            }
            if (row_.row_b[0x13] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x13]);
                row_a = row_a.Replace("13", replace_);
            }
            if (row_.row_b[0x14] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x14]);
                row_a = row_a.Replace("14", replace_);
            }
            if (row_.row_b[0x15] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x15]);
                row_a = row_a.Replace("15", replace_);
            }
            if (row_.row_b[0x16] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x16]);
                row_a = row_a.Replace("16", replace_);
            }
            if (row_.row_b[0x17] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x17]);
                row_a = row_a.Replace("17", replace_);
            }
            if (row_.row_b[0x18] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x18]);
                row_a = row_a.Replace("18", replace_);
            }
            if (row_.row_b[0x19] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x19]);
                row_a = row_a.Replace("19", replace_);
            }
            if (row_.row_b[0x1a] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x1a]);
                row_a = row_a.Replace("1a", replace_);
            }
            if (row_.row_b[0x1b] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x1b]);
                row_a = row_a.Replace("1b", replace_);
            }
            if (row_.row_b[0x1c] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x1c]);
                row_a = row_a.Replace("1c", replace_);
            }
            if (row_.row_b[0x1d] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x1d]);
                row_a = row_a.Replace("1d", replace_);
            }
            if (row_.row_b[0x1e] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x1e]);
                row_a = row_a.Replace("1e", replace_);

            }
            if (row_.row_b[0x1f] != 0x00)
            {
                string replace_ = FIND(row_.row_b[0x1f]);
                row_a = row_a.Replace("1f", replace_);
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
