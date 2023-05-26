using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO.Ports;
using System.Globalization;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public DataTable school_rows = new DataTable();
        public DataTable card_flash = new DataTable();
        public string[] countarray = new string[20];
        
        public Form2()
        {
            InitializeComponent();
            
            
            
            
            this.Load += new EventHandler(Form2_Load);
            
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {

            button2_Click(this, null);

            //string[] datacolumn5 = new string[8];
            //datacolumn5[0] = "card_no nvarchar(20) ";
            //datacolumn5[1] = "for_cardreader nvarchar(20) ";
            //datacolumn5[2] = "card_type nvarchar(10) ";
            //datacolumn5[3] = "on_off nvarchar(50) ";
            //datacolumn5[4] = "pasword varbinary(30) ";
            //datacolumn5[5] = "update_time datetime ";
            //datacolumn5[6] = "time_range nvarchar(50) ";
            //datacolumn5[7] = "remainder_money nvarchar(10) ";
            
            
            //if (Connect.SearchExist("sysobjects", "*", "type = 'U' AND name = 'Card_message'"))   //已擁有就不建立
            //{

            //}
            //else
            //{
            //    Connect.CreateTable("Card_message", datacolumn5);      //建立資料表

            //}

            //string[] datacolumn1 = new string[4];
            //datacolumn1[0] = "card_no nvarchar(20) ";
            //datacolumn1[1] = "old_pass nvarchar(20) ";
            //datacolumn1[2] = "new_pass nvarchar(20) ";
            //datacolumn1[3] = "update_time nvarchar(50) ";
           

            //if (Connect.SearchExist("sysobjects", "*", "type = 'U' AND name = 'Card_pass'"))   //已擁有就不建立
            //{

            //}
            //else
            //{
            //    Connect.CreateTable("Card_pass", datacolumn1);      //建立資料表

            //}


            //string[] datacolumn2 = new string[2];
            //datacolumn2[0] = "SCHOOL nvarchar(20) ";
            //datacolumn2[1] = "[IPADRESS] nvarchar(30) ";



            //if (Connect.SearchExist("sysobjects", "*", "type = 'U' AND name = 'SCHOOL_IPADRESS'"))   //已擁有就不建立
            //{

            //}
            //else
            //{
            //    Connect.CreateTable("SCHOOL_IPADRESS", datacolumn2);      //建立資料表

            //}


            //string[] datacolumn3 = new string[21];
            //datacolumn3[0] = "SCHOOL nvarchar(20) ";
            //datacolumn3[1] = "building nvarchar(20)";
            //datacolumn3[2] = "building_floor nvarchar(10)";
            //datacolumn3[3] = "classroom nvarchar(20)";
            //datacolumn3[4] = "on_off nvarchar(10)";
            
            //datacolumn3[5] = "ModuleID1 nvarchar(20)";
            //datacolumn3[6] = "ModuleID2 nvarchar(20)";
            //datacolumn3[7] = "agate nvarchar(20)";
            //datacolumn3[8] = "meter nvarchar(20)";
            //datacolumn3[9] = "cardreader nvarchar(20)";
            //datacolumn3[10] = "IP_ADRESS nvarchar(30)";
            //datacolumn3[11] = "update_time datetime";
            //datacolumn3[12] = "region nvarchar(20)";
            //datacolumn3[13] = "Aircon_Status1 nvarchar(20)";
            //datacolumn3[14] = "Aircon_Status2 nvarchar(20)";
            //datacolumn3[15] = "port_no nvarchar(20)";
            
            //datacolumn3[16] = "aircon_temper nvarchar(20)";
            //datacolumn3[17] = "wind_direction nvarchar(20)";
            //datacolumn3[18] = "wind_speed nvarchar(20)";
            //datacolumn3[19] = "aircon_mode nvarchar(20)";
            //datacolumn3[20] = "school_ip nvarchar(20)";

            //if (Connect.SearchExist("sysobjects", "*", "type = 'U' AND name = 'classroom_Summary'"))   //已擁有就不建立
            //{

            //}
            //else
            //{
            //    Connect.CreateTable("classroom_Summary", datacolumn3);      //建立資料表

            //}


            //string[] datacolumn4 = new string[8];
            //datacolumn4[0] = "reader_no nvarchar(20) ";
            //datacolumn4[1] = "remainder_money nvarchar(10)";
           
            //datacolumn4[2] = "time_cost nvarchar(50)";
            //datacolumn4[3] = "on_off nvarchar(10)";
            //datacolumn4[4] = "ordinary_pasword varbinary(30)";
            //datacolumn4[5] = "timecard_pasword varbinary(30)";
            //datacolumn4[6] = "warm_money nvarchar(10)";
            //datacolumn4[7] = "update_time datetime";
            



            //if (Connect.SearchExist("sysobjects", "*", "type = 'U' AND name = 'Card_reader_message'"))   //已擁有就不建立
            //{

            //}
            //else
            //{
            //    Connect.CreateTable("Card_reader_message", datacolumn4);      //建立資料表

            //}
            //string[] datacolumn6 = new string[5];
            //datacolumn6[0] = "agate_ip nvarchar(20) ";
            //datacolumn6[1] = "com1 nvarchar(10)";

            //datacolumn6[2] = "com2 nvarchar(10)";
            //datacolumn6[3] = "com3 nvarchar(10)";
           
            //datacolumn6[4] = "school_ip nvarchar(20)";
            



            //if (Connect.SearchExist("sysobjects", "*", "type = 'U' AND name = 'agate_ip_port'"))   //已擁有就不建立
            //{

            //}
            //else
            //{
            //    Connect.CreateTable("agate_ip_port", datacolumn6);      //建立資料表

            //}
            
        }
        public static ushort crc16_ccitt(byte[] buf, int len)
        {
            int counter;
            ushort crc = 0xFFFF; //0;
            for (counter = 0; counter < len; counter++)
                crc = (ushort)((crc << 8) ^ crc16tab[(crc >> 8) ^ buf[counter]]);
            return crc;
        }

        #region crc16tab
        public static ushort[] crc16tab = {
            0x0000,0x1021,0x2042,0x3063,0x4084,0x50a5,0x60c6,0x70e7,
            0x8108,0x9129,0xa14a,0xb16b,0xc18c,0xd1ad,0xe1ce,0xf1ef,
            0x1231,0x0210,0x3273,0x2252,0x52b5,0x4294,0x72f7,0x62d6,
            0x9339,0x8318,0xb37b,0xa35a,0xd3bd,0xc39c,0xf3ff,0xe3de,
            0x2462,0x3443,0x0420,0x1401,0x64e6,0x74c7,0x44a4,0x5485,
            0xa56a,0xb54b,0x8528,0x9509,0xe5ee,0xf5cf,0xc5ac,0xd58d,
            0x3653,0x2672,0x1611,0x0630,0x76d7,0x66f6,0x5695,0x46b4,
            0xb75b,0xa77a,0x9719,0x8738,0xf7df,0xe7fe,0xd79d,0xc7bc,
            0x48c4,0x58e5,0x6886,0x78a7,0x0840,0x1861,0x2802,0x3823,
            0xc9cc,0xd9ed,0xe98e,0xf9af,0x8948,0x9969,0xa90a,0xb92b,
            0x5af5,0x4ad4,0x7ab7,0x6a96,0x1a71,0x0a50,0x3a33,0x2a12,
            0xdbfd,0xcbdc,0xfbbf,0xeb9e,0x9b79,0x8b58,0xbb3b,0xab1a,
            0x6ca6,0x7c87,0x4ce4,0x5cc5,0x2c22,0x3c03,0x0c60,0x1c41,
            0xedae,0xfd8f,0xcdec,0xddcd,0xad2a,0xbd0b,0x8d68,0x9d49,
            0x7e97,0x6eb6,0x5ed5,0x4ef4,0x3e13,0x2e32,0x1e51,0x0e70,
            0xff9f,0xefbe,0xdfdd,0xcffc,0xbf1b,0xaf3a,0x9f59,0x8f78,
            0x9188,0x81a9,0xb1ca,0xa1eb,0xd10c,0xc12d,0xf14e,0xe16f,
            0x1080,0x00a1,0x30c2,0x20e3,0x5004,0x4025,0x7046,0x6067,
            0x83b9,0x9398,0xa3fb,0xb3da,0xc33d,0xd31c,0xe37f,0xf35e,
            0x02b1,0x1290,0x22f3,0x32d2,0x4235,0x5214,0x6277,0x7256,
            0xb5ea,0xa5cb,0x95a8,0x8589,0xf56e,0xe54f,0xd52c,0xc50d,
            0x34e2,0x24c3,0x14a0,0x0481,0x7466,0x6447,0x5424,0x4405,
            0xa7db,0xb7fa,0x8799,0x97b8,0xe75f,0xf77e,0xc71d,0xd73c,
            0x26d3,0x36f2,0x0691,0x16b0,0x6657,0x7676,0x4615,0x5634,
            0xd94c,0xc96d,0xf90e,0xe92f,0x99c8,0x89e9,0xb98a,0xa9ab,
            0x5844,0x4865,0x7806,0x6827,0x18c0,0x08e1,0x3882,0x28a3,
            0xcb7d,0xdb5c,0xeb3f,0xfb1e,0x8bf9,0x9bd8,0xabbb,0xbb9a,
            0x4a75,0x5a54,0x6a37,0x7a16,0x0af1,0x1ad0,0x2ab3,0x3a92,
            0xfd2e,0xed0f,0xdd6c,0xcd4d,0xbdaa,0xad8b,0x9de8,0x8dc9,
            0x7c26,0x6c07,0x5c64,0x4c45,0x3ca2,0x2c83,0x1ce0,0x0cc1,
            0xef1f,0xff3e,0xcf5d,0xdf7c,0xaf9b,0xbfba,0x8fd9,0x9ff8,
            0x6e17,0x7e36,0x4e55,0x5e74,0x2e93,0x3eb2,0x0ed1,0x1ef0
        };
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text=="")
            {
                MessageBox.Show("沒有com");
            }
            else
            {
                string str = "";
                string aa="";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_reader_message]", "reader_no, time_cost,ordinary_pasword,timecard_pasword,warm_money", "[reader_no] = '" + textBox1.Text + "'");
                str += "8E,";//header
                if (false)
                {
                    MessageBox.Show ( "查無相關資料");
                }
                else
                {
                    aa = Convert.ToInt32(textBox1.Text).ToString("X");//讀卡機號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    //aa = dt1.Rows[0].ItemArray[1].ToString();//費率
                    aa = "6.6.6.6.6.6";
                    string[] cost = aa.Split('.');
                    for (int k = 0; k < cost.Length;k++ )
                    {
                        aa = Convert.ToInt32(cost[k]).ToString("X");
                        while (aa.Length < 4)
                        {
                            aa = "0" + aa;
                        }
                        for (int g = 4; g > 1; g = g - 2)
                        {
                            aa = aa.Insert(g, ",");
                        }
                        str += aa;
                    }
                    string ordinary_pasword ="";
                    string timecard_pasword = "";
                    
                    ordinary_pasword = ((Convert.ToUInt64(textBox1.Text) * 1234) % 1000000000000).ToString();
                    // ordinary_pasword = (((Convert.ToUInt64(textBox1.Text)) / 1000 * 2345678) % 1000000000000).ToString();
                    while (ordinary_pasword.Length < 12)
                    {
                        ordinary_pasword = "0" + ordinary_pasword;
                    }
                    //ordinary_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                    //ordinary_pasword = "0x" + ordinary_pasword;
                    // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                    timecard_pasword = (((Convert.ToUInt64(textBox1.Text)) / 1000 * 3456789) % 1000000000000).ToString();
                    while (timecard_pasword.Length < 12)
                    {
                        timecard_pasword = "0" + timecard_pasword;
                    }
                    //timecard_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                    //timecard_pasword = "0x" + timecard_pasword;
                   
                    //object obj = dt1.Rows[0].ItemArray[2];//一般卡密碼
                    //byte[] buffer = (byte[])obj;
                    //aa = "";
                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = ordinary_pasword;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    /*
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[2].ToString()).ToString("X");//免費卡張數
                    while (aa.Length != 4)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 4; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[3].ToString()).ToString("X");//免費卡起始卡號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[4].ToString()).ToString("X");//時效卡張數
                    while (aa.Length != 4)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 4; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[5].ToString()).ToString("X");//時效卡起始卡號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    */
                    //object obj2 = dt1.Rows[0].ItemArray[3];//時效卡密碼
                    //byte[] buffer2 = (byte[])obj2;
                    //aa = "";
                    //for (int k = 0; k < buffer2.Length; k++) 
                    //{
                    //    string STR = buffer2[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = timecard_pasword;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;

                    aa = Convert.ToInt32("100").ToString("X");//餘額警示
                    while (aa.Length != 2)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 2; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;


                    str += "00,1E,00,00,8E";
                   // aa = aa;
 
                   
                    /*
                string str = "";
                str += "8E,";//header
                str += "11,12,13,14,";//讀卡機號
                str += "00,64,00,64,00,64,00,64,00,00,00,00,";//費率
                str += "FF,FF,FF,FF,FF,FF,";//一般卡密碼
                str += "00,03,";//免費卡張數
                str += "AA,BB,CC,DD,";//免費卡起始卡號
                str += "00,02,";//時效卡張數
                str += "CC,DD,EE,FF,";//時效卡起始卡號
                str += "F1,F2,F3,F4,F5,F6,";//時效卡密碼
                str += "64,";//餘額警示
                str += "8E";//header*/
                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length-3];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j ==0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j<data1.Length-3)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        
                    }
                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 3] = CRC_buffer[1];
                    data2[data2.Length - 2] = CRC_buffer[0];
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    // byte[] accept = new byte[serialPort1.BytesToRead];
                    // serialPort1.Read(accept, 0, accept.Length);
                    serialPort1.Close();
                    MessageBox.Show("請確認是否輸入成功");
                }
                
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string copy = "";
            String[] COMPorts = SerialPort.GetPortNames();
            copy = comboBox1.Text;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("");
            foreach (string port in COMPorts)
            { comboBox1.Items.Add(port); }
            comboBox1.Text = copy;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {
                string str = "flashread";
                string str2 = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_reader_message]", "reader_no, time_cost,ordinary_pasword,timecard_pasword,warm_money", "[reader_no] = '" + textBox1.Text + "'");

                if (false)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    aa = Convert.ToInt32(textBox1.Text).ToString("X");//讀卡機號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    } 
                    str2 += aa;
                    aa = "6.6.6.6.6.6";//費率
                    string[] cost = aa.Split('.');
                    for (int k = 0; k < cost.Length; k++)
                    {
                        aa = Convert.ToInt32(cost[k]).ToString("X");
                        while (aa.Length < 4)
                        {
                            aa = "0" + aa;
                        }
                        for (int g = 4; g > 1; g = g - 2)
                        {
                            aa = aa.Insert(g, " ");
                        }
                        str2 += aa;
                    }

                    string ordinary_pasword = "";
                    string timecard_pasword = "";
                  
                    ordinary_pasword = ((Convert.ToUInt64(textBox1.Text) * 1234) % 1000000000000).ToString();
                    // ordinary_pasword = (((Convert.ToUInt64(textBox1.Text)) / 1000 * 2345678) % 1000000000000).ToString();
                    while (ordinary_pasword.Length < 12)
                    {
                        ordinary_pasword = "0" + ordinary_pasword;
                    }
                    //ordinary_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                    //ordinary_pasword = "0x" + ordinary_pasword;
                    // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                    timecard_pasword = (((Convert.ToUInt64(textBox1.Text)) / 1000 * 3456789) % 1000000000000).ToString();
                    while (timecard_pasword.Length < 12)
                    {
                        timecard_pasword = "0" + timecard_pasword;
                    }
                    //timecard_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                    //timecard_pasword = "0x" + timecard_pasword;
                    //object obj = dt1.Rows[0].ItemArray[2];//一般卡密碼
                    //byte[] buffer = (byte[])obj;
                    //aa = "";
                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = ordinary_pasword;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    /*
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[2].ToString()).ToString("X");//免費卡張數
                    while (aa.Length != 4)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 4; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[3].ToString()).ToString("X");//免費卡起始卡號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[4].ToString()).ToString("X");//時效卡張數
                    while (aa.Length != 4)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 4; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[5].ToString()).ToString("X");//時效卡起始卡號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    */
                    //object obj2 = dt1.Rows[0].ItemArray[3];//時效卡密碼
                    //byte[] buffer2 = (byte[])obj2;
                    //aa = "";
                    //for (int k = 0; k < buffer2.Length; k++) 
                    //{
                    //    string STR = buffer2[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = timecard_pasword;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;

                    aa = Convert.ToInt32("100").ToString("X");//餘額警示
                    while (aa.Length != 2)
                    {
                        aa = "0" + aa;
                    }

                    str2 += aa+" 00 1E";

                    /*
                     str2 += "11 12 13 14 ";//讀卡機號
                     str2 += "00 64 00 64 00 64 00 64 00 00 00 00 ";//費率
                     str2 += "FF FF FF FF FF FF ";//一般卡密碼
                     str2 += "00 03 ";//免費卡張數
                     str2 += "AA BB CC DD ";//免費卡起始卡號
                     str2 += "00 02 ";//時效卡張數
                     str2 += "CC DD EE FF ";//時效卡起始卡號
                     str2 += "F1 F2 F3 F4 F5 F6 ";//時效卡密碼
                     str2 += "64";//餘額警示
                     */
                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string data2 = str;                 //以逗號作分割成字串陣列
                    string ack = "";
                    //  string accept = "";
                    // byte[] accept = new byte[50000];
                    //char[] accept = new char[1500];
                    serialPort1.Write(data2);
                    //Task.Delay(1200).Wait();

                    Thread.Sleep(1000);
                    char[] accept = new char[serialPort1.BytesToRead];
                    /*
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();*/
                    serialPort1.Read(accept, 0, accept.Length);
                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {
                            
                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else if(textBox2.Text==""){
                MessageBox.Show("請輸入卡號");
            }
            else
            {
                string str = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money", "[card_no] = '" + textBox2.Text + "'");
                DataRow[] card_no;
                card_no = card_flash.Select("card = ('" + textBox2.Text + "') ");
                str += "AA,AA,01,30,17,08,";//header
                if (card_no.Count() == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    //object obj = dt1.Rows[0].ItemArray[2];//卡片密碼
                    //byte[] buffer = (byte[])obj;
                    //aa = "";
                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = "";
                    if (card_no[0].ItemArray[2].ToString() == "3")
                    {
                        aa = (((Convert.ToUInt64(card_no[0].ItemArray[0].ToString())) / 1000 * 2345678) % 1000000000000).ToString();
                    }
                    else
                    {
                        aa = (((Convert.ToUInt64(card_no[0].ItemArray[0].ToString())) / 1000 * 3456789) % 1000000000000).ToString();
                    }

                    //textBox3.Text = "FFFFFFFFFFFF";
                    while (aa.Length < 12)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;

                    aa = Convert.ToInt32(card_no[0].ItemArray[2].ToString()).ToString("X");//卡片類型
                    while (aa.Length != 2)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 2; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    
                    str += aa;
                    if (card_no[0].ItemArray[2].ToString() == "2")
                    {
                        aa = "2022.12.28.0.0.2042.12.28.0.0";//卡片使用時間
                    }
                    else
                    {
                        aa = "0.0.0.0.0.0.0.0.0.0";//卡片使用時間
                    }
                   
                    string[] cost = aa.Split('.');
                    for (int k = 0; k < cost.Length; k++)
                    {
                        if (cost[k].Length>2)
                        {
                            cost[k] = (Convert.ToUInt32(cost[k]) % 100).ToString();
                        }
                        aa = Convert.ToInt32(cost[k]).ToString("X");
                        while (aa.Length < 2)
                        {
                            aa = "0" + aa;
                        }
                        for (int g = 2; g > 1; g = g - 2)
                        {
                            aa = aa.Insert(g, ",");
                        }
                        str += aa;
                    }

                    str += "00,";//保留碼

                    aa = (Convert.ToInt32("0")*10000).ToString("X");//餘額要乘10000
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }

                    str += aa;

                    str += "00,00";//check
                  


                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 2];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 2)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                    }
                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 2] = CRC_buffer[1];
                    data2[data2.Length - 1] = CRC_buffer[0];
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    // byte[] accept = new byte[serialPort1.BytesToRead];
                    // serialPort1.Read(accept, 0, accept.Length);
                    serialPort1.Close();
                    MessageBox.Show("請確認是否輸入成功");
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("請輸入卡號");
            }
            else
            {
                string str = "READCARD";
                string str2 = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money", "[card_no] = '" + textBox2.Text + "'");
                DataRow[] card_no;
                card_no = card_flash.Select("card = ('" + textBox2.Text + "') ");
                if (card_no.Count() == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    aa = Convert.ToInt32(card_no[0].ItemArray[2].ToString()).ToString("X");//卡片類型
                    while (aa.Length != 2)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 2; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }

                    str2 += aa;

                    if (card_no[0].ItemArray[2].ToString() == "2")
                    {
                        aa = "2022.12.28.0.0.2042.12.28.0.0";//卡片使用時間
                    }
                    else
                    {
                        aa = "0.0.0.0.0.0.0.0.0.0";//卡片使用時間
                    }
                    string[] cost = aa.Split('.');
                    for (int k = 0; k < cost.Length; k++)
                    {
                        if (cost[k].Length > 2)
                        {
                            cost[k] = (Convert.ToUInt32(cost[k]) % 100).ToString();
                        }
                        aa = Convert.ToInt32(cost[k]).ToString("X");
                        while (aa.Length < 2)
                        {
                            aa = "0" + aa;
                        }
                        for (int g = 2; g > 1; g = g - 2)
                        {
                            aa = aa.Insert(g, " ");
                        }
                        str2 += aa;
                    }

                    str2 += "00 ";//保留碼

                    aa = (Convert.ToInt32("0") * 10000).ToString("X");//餘額要乘10000
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 6; g > 1; g = g - 2)//最後一個不要空格所以是6
                    {
                        aa = aa.Insert(g, " ");
                    }

                    str2 += aa;
                    

                    /*
                     str2 += "11 12 13 14 ";//讀卡機號
                     str2 += "00 64 00 64 00 64 00 64 00 00 00 00 ";//費率
                     str2 += "FF FF FF FF FF FF ";//一般卡密碼
                     str2 += "00 03 ";//免費卡張數
                     str2 += "AA BB CC DD ";//免費卡起始卡號
                     str2 += "00 02 ";//時效卡張數
                     str2 += "CC DD EE FF ";//時效卡起始卡號
                     str2 += "F1 F2 F3 F4 F5 F6 ";//時效卡密碼
                     str2 += "64";//餘額警示
                     */
                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string data2 = str;                 //以逗號作分割成字串陣列
                    string ack = "";
                    //  string accept = "";
                    // byte[] accept = new byte[50000];
                    //char[] accept = new char[1500];
                    serialPort1.Write(data2);
                    //Task.Delay(1200).Wait();

                    Thread.Sleep(1000);
                    char[] accept = new char[serialPort1.BytesToRead];
                    /*
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();*/
                    serialPort1.Read(accept, 0, accept.Length);
                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i, j;
            string debugopen = "debugopen";
            string debugclose = "debugclose";
            string ans = "no";
            string old_pas = "";
            string today;
            DateTime day = DateTime.Now;
            today = day.ToString("yyyy-MM-dd-HH-mm");
            SerialPort serialPort1 = new SerialPort();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {
                
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
                serialPort1.Write(debugopen);
                Task.Delay(1200).Wait();
                char[] accept1 = new char[serialPort1.BytesToRead];
                serialPort1.Read(accept1, 0, accept1.Length);
                string card_no = Convert.ToInt64(textBox2.Text).ToString("x");
                while (card_no.Length < 8)
                {
                    card_no = "0" + card_no;
                }
                for (int g = 6; g > 1; g = g - 2)
                {
                    card_no = card_no.Insert(g, " ");
                }
                if (accept1.Length >= card_no.Length && accept1.Length > 0)
                {
                    for (j = 0; j < accept1.Length - card_no.Length + 1; j++)
                    {
                        j=j;
                        if (accept1[j] == card_no[0])
                        {
                            ans = "";
                            for (i = 0; i < card_no.Length; i++)
                            {
                                if (card_no[i] != accept1[j + i])
                                {
                                    ans = "卡號有誤";

                                }
                            }
                            if (ans == "")
                            {
                                break;
                            }
                        }


                    }
                    if (j == accept1.Length - card_no.Length + 1)
                    {

                        ans = "卡號有誤";


                    }
                }
                else if (accept1.Length != card_no.Length && accept1.Length > 0)
                {
                    ans = "卡號有誤";
                }
                else if (accept1.Length > 0)
                {
                    for (j = 0; j < card_no.Length; j++)
                    {
                        if (card_no[j] != accept1[j])
                        {
                            ans = "卡號有誤從第" + j + "個不一樣";

                        }
                    }
                }
                else
                {
                    ans = "父沒有收到任何東西";
                }
                if (ans == "")
                {

                    MessageBox.Show("卡號確認ok");
                    

                }
                else
                {
                    MessageBox.Show(ans);
                }
                serialPort1.Write(debugclose);
                serialPort1.Close();
            }
            
            int h = 0;
            /*
            for ( h = 0; h < 12; h++)
            {
                if (Uri.IsHexDigit(textBox3.Text[h]) != true)
                {
                    
                    break;
                }
            }*/
            string str2 = "AA AA 02 40 01 05 97";
            string ack = "";
            if (ans!="")
            {

            }/*
            else if(h!=12){
                MessageBox.Show("輸入的密碼非16進制");
            }*/
            else if (comboBox1.Text == "")
            {
                //MessageBox.Show("沒有com");
            }/*
            else if(textBox3.Text.Length!=12){
                MessageBox.Show("請確認是否12碼");
            }*/
            else
            {
                string str = "";
                string aa = "";
                DataTable dt1 = new DataTable();
                dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money", "[card_no] = '" + textBox2.Text + "'");
                str += "AA,AA,01,40,0D,02,";//header
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    object obj = dt1.Rows[0].ItemArray[2];//卡片密碼
                    byte[] buffer = (byte[])obj;
                    aa = "";
                    
                    for (int k = 0; k < buffer.Length; k++)
                    {
                        string STR = buffer[k].ToString("X");
                        while (STR.Length < 2)
                        {
                            STR = "0" + STR;
                        }
                        aa += STR;
                        old_pas += STR;
                       
                    }
                  //  string new_pass;
                   // new_pass = old_pas;
                  //  old_pas = "FFFFFFFFFFFF"; //生產一開始密碼都FF
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    //  aa = "FF,FF,FF,FF,FF,FF,"; //生產一開始密碼都FF
                    str += aa;
                    textBox3.Text = "FFFFFFFFFFFF";
                    aa = textBox3.Text;
                    
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                        
                       
                    }
                   
                    str += aa;
                    str += "00,00";



                    serialPort1.Open();
                 
                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 2];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 2)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                    }
                    
                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 2] = CRC_buffer[1];
                    data2[data2.Length - 1] = CRC_buffer[0];

                    StreamWriter sw = new StreamWriter(".\\密碼修改" + ".txt", true);//TXT備註
                    sw.WriteLine("卡號 ; " + textBox2.Text + "欲將密碼從 " + old_pas+" 改為 "+textBox3.Text);
                    sw.Flush();
                    sw.Close();
                    
                    
                    Connect.Insert("[Card_pass]", "[card_no],[old_pass],[new_pass],[update_time]", textBox2.Text + "','" + old_pas + "','" + textBox3.Text+ "','" +today);
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    byte[] accept = new byte[serialPort1.BytesToRead];
                    serialPort1.Read(accept, 0, accept.Length);

                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包或密碼有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                       // Connect.Edit2("Card_message", "[pasword]", "0x" + textBox3.Text, textBox2.Text, "[card_no]");
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }

                   
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string str = "";
            
            string ack = "";
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else if (!textBox4.Text.All(char.IsDigit))
            {
                MessageBox.Show("請確認是數字");
            }
            else if (textBox4.Text=="")
            {
                MessageBox.Show("請確認是否輸入錯誤");
            }
            else
            {
                string str2 = "";
                string aa = "";
                string bb = "";
                 str2 += "8E,FF,FA,FB,FC,";//header
                 str += "8E FF FA FB FC ";//header
                if (1 == 0)  // 沒用
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    
                   

                    aa=  Convert.ToInt32(textBox4.Text).ToString("X");
                    bb = Convert.ToInt32(textBox4.Text).ToString("X");
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;

                    }
                    while (bb.Length != 8)
                    {
                        bb = "0" + bb;

                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                        bb = bb.Insert(g, " ");

                    }
                    str2 += aa;
                    str2 += "8E";
                    str += bb;
                    str += "8E";




                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 115200;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string[] data1 = str2.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                   
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        
                    }

                    Thread.Sleep(1000);

                    serialPort1.Write(data2, 0, data2.Length);
                    Thread.Sleep(1000);
                    Task.Delay(2500).Wait();
                    string test = "";
                    for (j = 0; j < 10; j++)
                    {
                        byte[] accept = new byte[serialPort1.BytesToRead];

                        serialPort1.Read(accept, 0, accept.Length);
                        if (accept.Length > 6)
                        {
                            test = Encoding.ASCII.GetString(accept);
                            break;
                        }
                        Task.Delay(1000).Wait();
                    }
                    serialPort1.Close();
                   
                    if(test.Contains(str)){
                        MessageBox.Show("輸入ok");
                    }
                    else
                    {
                        MessageBox.Show("錯誤請重新輸入");
                    }
                    /*
                    if (accept.Length >= str.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str.Length + 1; j++)
                        {

                            if (accept[j] == str[0])
                            {
                                ack = "";
                                for (i = 0; i < str.Length; i++)
                                {
                                    if (str[i] != accept[j + i])
                                    {
                                        ack = "收到的封包或密碼有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str.Length; j++)
                        {
                            if (str[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                       
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }
                    */

                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            string str;
            
            string today_st;
            string today_end;
            string dayrange;
            
            string ordinary_pasword="";
            string timecard_pasword = "";
            string path = ".\\匯入資料花蓮.txt";  //讀TXT
            
            int k = 0;
            DateTime day = DateTime.Now;
            today_st = day.ToString("yyyy.MM.dd");
            today_end = (day.AddDays(20)).ToString("yyyy.MM.dd");
            dayrange = today_st+".0.0."+today_end+".0.0";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {

                string[] put = str.Split('_');
              //  DataTable dt5 = new DataTable();   //重複不新增
               // dt5 = Connect.Search("[classroom_Summary]", "[cardreader]", "[cardreader] = '" + put[4] + "'"); 
                if (1==2)
                {

                }
                else
                {
                    
                    DataTable dt1 = new DataTable();
                    dt1 = Connect.Search("[SCHOOL_IPADRESS]", "[IPADRESS]", "[SCHOOL] = '" + put[9] + put[5] + "'");
                    if (dt1.Rows.Count == 0)
                    {
                        MessageBox.Show(put[5] + "沒有學校ip");
                    }
                    else if (dt1.Rows.Count > 1)
                    {
                        MessageBox.Show(put[5] + "有2個一樣名稱的學校");
                    }
                    else
                    {
                        string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                       // string port1 = ((Convert.ToInt32(port[2]) - 51) * 160 + (((Convert.ToInt32(put[4]) % 1000) - 1)  + 11) + 10000).ToString();
                        // string port1 = ((Convert.ToInt32(port[2]) - 51) * 60 + (Convert.ToInt32(put[0]) % 1000 + 10) + 10000).ToString();
                        Connect.Insert("[classroom_Summary]", "region,[ModuleID1],[ModuleID2],[SCHOOL],[building],building_floor ,classroom,[agate],[meter],[cardreader],Aircon_Status1,Aircon_Status2,aircon_temper,wind_direction,wind_speed,aircon_mode,[IP_ADRESS]", put[9] + "','" + put[2] + "','" + put[3] + "','" + put[5] + "','" + put[6] + "','" + put[7] + "','" + put[8] + "','" + put[0] + "','" + put[1] + "','" + put[4] + "','OFF','OFF','26','自動','自動','冷氣','" + dt1.Rows[0].ItemArray[0].ToString() + "." + (Convert.ToInt32(put[0]) % 1000 + 50).ToString());
                        if (put[4]!="")
                        {
                            ordinary_pasword = ((Convert.ToUInt64(put[4]) * 1234) % 1000000000000).ToString();
                           // ordinary_pasword = (((Convert.ToUInt64(put[0])) / 1000 * 2345678) % 1000000000000).ToString();
                            while (ordinary_pasword.Length < 12)
                            {
                                ordinary_pasword = "0" + ordinary_pasword;
                            }
                            //ordinary_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                            ordinary_pasword = "0x" + ordinary_pasword;
                            // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                            timecard_pasword = (((Convert.ToUInt64(put[4])) / 1000 * 3456789) % 1000000000000).ToString();
                            while (timecard_pasword.Length < 12)
                            {
                                timecard_pasword = "0" + timecard_pasword;
                            }
                            //timecard_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                            timecard_pasword = "0x" + timecard_pasword;
                            DataTable dt2 = new DataTable();
                            dt2 = Connect.Search("[Card_reader_message]", "[reader_no]", "[reader_no] = '" + put[4] + "'");
                            if (dt2.Rows.Count == 0)
                            {
                                Connect.Insert("Card_reader_message", "[reader_no],[remainder_money],[time_cost],ordinary_pasword ,timecard_pasword,[warm_money]", put[4] + "','0','6.6.6.6.6.6'," + ordinary_pasword + "," + timecard_pasword + ",'100");
                            }
                        }
                       
                    }
                }
                
                
              
                k++;

               
            }
            MessageBox.Show(" THE END");
            sr.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string str;
            int i = 0;
            DataTable dt11 = new DataTable();
            dt11 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region","[cardreader]like '%001' ");
            
            for (i = 0; i < dt11.Rows.Count; i++)
            {
                string[] port11 = dt11.Rows[i].ItemArray[0].ToString().Split('.');
                DataTable dt7 = new DataTable();
                dt7 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt11.Rows[i].ItemArray[2].ToString() + "' and region ='" + dt11.Rows[i].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port11[0] + "." + port11[1] + "." + port11[2] + ".91'");


                if (dt7.Rows.Count == 0)
                {
                    //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                    //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                    //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                    if (dt11.Rows[i].ItemArray[3].ToString()=="花蓮")
                    {
                        /*
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2001','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2002','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "041','備品一','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".91");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "201','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "201','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2011','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2012','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "041','備品二','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".91");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "202','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "202','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2021','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2022','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "041','備品三','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".91");

                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "203','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "203','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2031','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2032','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "042','備品四','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".92");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "204','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "204','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2041','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2042','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "042','備品五','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".92");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "205','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "205','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2051','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2052','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "042','備品六','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".92");

                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "206','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "206','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2061','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2062','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "043','備品七','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".93");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "207','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "207','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2071','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2072','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "043','備品八','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".93");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "208','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "208','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2081','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2082','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "043','備品九','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".93");
                        */
                    }
                    else
                    {
                        /*
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2005','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2006','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "041','備品一','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".91");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "201','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "201','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2015','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2016','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "041','備品二','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".91");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "202','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "202','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2025','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2026','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "041','備品三','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".91");

                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "203','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "203','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2035','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2036','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "042','備品四','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".92");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "204','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "204','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2045','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2046','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "042','備品五','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".92");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "205','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "205','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2055','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2056','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "042','備品六','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".92");

                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "206','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "206','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2065','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2066','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "043','備品七','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".93");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "207','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "207','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2075','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2076','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "043','備品八','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".93");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],[cardreader],[meter],[ModuleID1],[ModuleID2],agate,[classroom],region,IP_ADRESS", dt11.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "208','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "208','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2085','" + ((Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) % 10000000) / 1000).ToString() + "2086','" + (Convert.ToInt32(dt11.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "043','備品九','" + dt11.Rows[i].ItemArray[3].ToString() + "','" + port11[0] + "." + port11[1] + "." + port11[2] + ".93");
                        */
                    }
                  


                }
            }
           





            DataTable dt1 = new DataTable();
            dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region");

            for (i = 0; i < dt1.Rows.Count; i++)
            {
                try
                {
                    //----------------------------------新增非總表port-------------------------
                    string[] port = dt1.Rows[i].ItemArray[0].ToString().Split('.');
                    /*
                    string port1 = ((Convert.ToInt32(port[2]) - 51) * 160 + (((Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) % 1000) - 1) * 3 + 11) + 10000).ToString();
                    string port2 = ((Convert.ToInt32(port[2]) - 51) * 160 + (((Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) % 1000) - 1) * 3 + 12) + 10000).ToString();
                    string port3 = ((Convert.ToInt32(port[2]) - 51) * 160 + (((Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) % 1000) - 1) * 3 + 13) + 10000).ToString();
                    DataTable dt2 = new DataTable();
                    dt2 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + dt1.Rows[i].ItemArray[0].ToString() + "'");
                    if (dt2.Rows.Count == 0)
                    {
                        Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", dt1.Rows[i].ItemArray[0].ToString() + "','" + port1 + "','" + port2 + "','" + port3);
                    }*/

                    //  --------總表port----------------------
                    DataTable dt3 = new DataTable();
                    dt3 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[i].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[i].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".250'");


                    if (dt3.Rows.Count == 0)
                    {
                        //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                        //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                        //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','總表一','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".250");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','總表二','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".250");
                        Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','總表三','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".250");



                    }



                    //-------------------------------------備品------------------------------------------
                    /*
                     DataTable dt7 = new DataTable();
                     dt7 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[i].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[i].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".200'");


                     if (dt7.Rows.Count == 0)
                     {
                         //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                         //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                         //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                         Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','總表一','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".250");
                         Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','總表二','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".250");
                         Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "200','總表三','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".250");

                         DataTable dt4 = new DataTable();
                         dt4 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".250" + "'");
                         if (dt4.Rows.Count == 0)
                         {
                             port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 3 + 10000).ToString();
                             port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 2 + 10000).ToString();
                             port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 1 + 10000).ToString();
                             Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".250" + "','" + port1 + "','" + port2 + "','" + port3);
                         }
                       
                     }
                 */

                    //  Connect.Edit("[classroom_Summary]", "port_no_2102", port2, dt1.Rows[i].ItemArray[1].ToString(), "agate");
                    //  Connect.Edit("[classroom_Summary]", "port_no_2103", port3, dt1.Rows[i].ItemArray[1].ToString(), "agate");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(dt1.Rows[i].ItemArray[3].ToString() + dt1.Rows[i].ItemArray[2].ToString() + "  " + dt1.Rows[i].ItemArray[1].ToString() + "  " + dt1.Rows[i].ItemArray[0].ToString());
                }

            }
            // ----------------------------------總錶AGATE數量等於2---------------------------------------
            string path = ".\\花蓮總錶2.txt";  //讀TXT
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {
                dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region", "SCHOOL ='" + str + "' AND region  ='花蓮'");
                string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                if (dt1.Rows[0].ItemArray[2].ToString() == str && dt1.Rows[0].ItemArray[3].ToString() == "花蓮")
                {
                    if (dt1.Rows.Count == 0)
                    {

                        MessageBox.Show("找不到花蓮總錶2中 " + str + "的資料");

                    }
                    else
                    {
                        DataTable dt5 = new DataTable();
                        dt5 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[0].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[0].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".249'");


                        if (dt5.Rows.Count == 0)
                        {
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "199','總表四','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "199','總表五','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[i].ItemArray[1].ToString()) / 1000).ToString() + "199','總表六','" + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            /*
                            DataTable dt6 = new DataTable();
                            dt6 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".249" + "'");
                            if (dt6.Rows.Count == 0)
                            {
                                port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 6 + 10000).ToString();
                                port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 5 + 10000).ToString();
                                port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 4 + 10000).ToString();
                                Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".249" + "','" + port1 + "','" + port2 + "','" + port3);
                            }*/

                        }
                    }

                }
            }
            sr.Close();

            string path2 = ".\\南投總錶2.txt";  //讀TXT
            StreamReader sr2 = new StreamReader(path2);
            while ((str = sr2.ReadLine()) != null)
            {
                dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region", "SCHOOL ='" + str + "'AND region  ='南投'");
                string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                if (dt1.Rows[0].ItemArray[2].ToString() == str && dt1.Rows[0].ItemArray[3].ToString() == "南投")
                {
                    if (dt1.Rows.Count == 0)
                    {

                        MessageBox.Show("找不到南投總錶2中 " + str + "的資料");

                    }
                    else
                    {
                        DataTable dt5 = new DataTable();
                        dt5 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[0].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[0].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".249'");


                        if (dt5.Rows.Count == 0)
                        {
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "199','總表四','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "199','總表五','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "199','總表六','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            /*
                            DataTable dt6 = new DataTable();
                            dt6 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".249" + "'");
                            if (dt6.Rows.Count == 0)
                            {
                                port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 6 + 10000).ToString();
                                port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 5 + 10000).ToString();
                                port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 4 + 10000).ToString();
                                Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".249" + "','" + port1 + "','" + port2 + "','" + port3);
                            }*/

                        }
                    }

                }
            }
            sr2.Close();
            // ----------------------------------總錶AGATE數量等於3---------------------------------------
            string path3 = ".\\花蓮總錶3.txt";  //讀TXT
            StreamReader sr3 = new StreamReader(path3);
            while ((str = sr3.ReadLine()) != null)
            {
                dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region", "SCHOOL ='" + str + "'AND region  ='花蓮'");
                string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                if (dt1.Rows[0].ItemArray[2].ToString() == str && dt1.Rows[0].ItemArray[3].ToString() == "花蓮")
                {
                    if (dt1.Rows.Count == 0)
                    {

                        MessageBox.Show("找不到花蓮總錶3中 " + str + "的資料");

                    }
                    else
                    {
                        DataTable dt5 = new DataTable();
                        dt5 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[0].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[0].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".248'");


                        if (dt5.Rows.Count == 0)
                        {
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "198','總表七','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".248");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "198','總表八','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".248");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "198','總表九','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".248");
                            /*
                            DataTable dt6 = new DataTable();
                            dt6 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".248" + "'");
                            if (dt6.Rows.Count == 0)
                            {
                                port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 9 + 10000).ToString();
                                port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 8 + 10000).ToString();
                                port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 7 + 10000).ToString();
                                Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".248" + "','" + port1 + "','" + port2 + "','" + port3);
                            }
                         */
                        }
                    }

                }
            }
            sr3.Close();
            string path4 = ".\\南投總錶3.txt";  //讀TXT
            StreamReader sr4 = new StreamReader(path4);
            while ((str = sr4.ReadLine()) != null)
            {
                dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region", "SCHOOL ='" + str + "'AND region  ='南投'");
                string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                if (dt1.Rows[0].ItemArray[2].ToString() == str && dt1.Rows[0].ItemArray[3].ToString() == "南投")
                {
                    if (dt1.Rows.Count == 0)
                    {

                        MessageBox.Show("找不到南投總錶3中 " + str + "的資料");

                    }
                    else
                    {
                        DataTable dt5 = new DataTable();
                        dt5 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[0].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[0].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".248'");


                        if (dt5.Rows.Count == 0)
                        {
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "198','總表七','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".248");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "198','總表八','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".248");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "198','總表九','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".248");
                            /*
                            DataTable dt6 = new DataTable();
                            dt6 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".248" + "'");
                            if (dt6.Rows.Count == 0)
                            {
                                port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 9 + 10000).ToString();
                                port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 8 + 10000).ToString();
                                port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 7 + 10000).ToString();
                                Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".248" + "','" + port1 + "','" + port2 + "','" + port3);
                            }
                         */
                        }
                    }

                }
            }
            sr4.Close();
            // ----------------------------------總錶AGATE數量等於4---------------------------------------
            string path5 = ".\\花蓮總錶4.txt";  //讀TXT
            StreamReader sr5 = new StreamReader(path5);
            while ((str = sr5.ReadLine()) != null)
            {
                dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region", "SCHOOL ='" + str + "'AND region  ='花蓮'");
                string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                if (dt1.Rows[0].ItemArray[2].ToString() == str && dt1.Rows[0].ItemArray[3].ToString() == "花蓮")
                {
                    if (dt1.Rows.Count == 0)
                    {

                        MessageBox.Show("找不到花蓮總錶4中 " + str + "的資料");

                    }
                    else
                    {
                        DataTable dt5 = new DataTable();
                        dt5 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[0].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[0].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".247'");


                        if (dt5.Rows.Count == 0)
                        {
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "197','總表10','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".247");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "197','總表11','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".247");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "197','總表12','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".247");
                            /*
                            DataTable dt6 = new DataTable();
                            dt6 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".248" + "'");
                            if (dt6.Rows.Count == 0)
                            {
                                port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 9 + 10000).ToString();
                                port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 8 + 10000).ToString();
                                port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 7 + 10000).ToString();
                                Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".248" + "','" + port1 + "','" + port2 + "','" + port3);
                            }
                         */
                        }
                    }

                }
            }
            sr5.Close();
            string path6 = ".\\南投總錶4.txt";  //讀TXT
            StreamReader sr6 = new StreamReader(path6);
            while ((str = sr6.ReadLine()) != null)
            {
                dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region", "SCHOOL ='" + str + "'AND region  ='南投'");
                string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                if (dt1.Rows[0].ItemArray[2].ToString() == str && dt1.Rows[0].ItemArray[3].ToString() == "南投")
                {
                    if (dt1.Rows.Count == 0)
                    {

                        MessageBox.Show("找不到南投總錶4中 " + str + "的資料");

                    }
                    else
                    {
                        DataTable dt5 = new DataTable();
                        dt5 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[0].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[0].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".247'");


                        if (dt5.Rows.Count == 0)
                        {
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "197','總表10','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".247");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "197','總表11','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".247");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "197','總表12','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".247");
                            /*
                            DataTable dt6 = new DataTable();
                            dt6 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".248" + "'");
                            if (dt6.Rows.Count == 0)
                            {
                                port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 9 + 10000).ToString();
                                port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 8 + 10000).ToString();
                                port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 7 + 10000).ToString();
                                Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".248" + "','" + port1 + "','" + port2 + "','" + port3);
                            }
                         */
                        }
                    }

                }
            }
            sr6.Close();
            // ----------------------------------總錶AGATE數量等於5---------------------------------------
            string path7 = ".\\花蓮總錶5.txt";  //讀TXT
            StreamReader sr7 = new StreamReader(path7);
            while ((str = sr7.ReadLine()) != null)
            {
                dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region", "SCHOOL ='" + str + "'AND region  ='花蓮'");
                string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                if (dt1.Rows[0].ItemArray[2].ToString() == str && dt1.Rows[0].ItemArray[3].ToString() == "花蓮")
                {
                    if (dt1.Rows.Count == 0)
                    {

                        MessageBox.Show("找不到花蓮總錶5中 " + str + "的資料");

                    }
                    else
                    {
                        DataTable dt5 = new DataTable();
                        dt5 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[0].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[0].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".246'");


                        if (dt5.Rows.Count == 0)
                        {
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "196','總表13','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".246");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "196','總表14','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".246");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "196','總表15','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".246");
                            /*
                            DataTable dt6 = new DataTable();
                            dt6 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".248" + "'");
                            if (dt6.Rows.Count == 0)
                            {
                                port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 9 + 10000).ToString();
                                port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 8 + 10000).ToString();
                                port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 7 + 10000).ToString();
                                Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".248" + "','" + port1 + "','" + port2 + "','" + port3);
                            }
                         */
                        }
                    }

                }
            }
            sr7.Close();
            string path8 = ".\\南投總錶5.txt";  //讀TXT
            StreamReader sr8 = new StreamReader(path8);
            while ((str = sr8.ReadLine()) != null)
            {
                dt1 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[agate],[SCHOOL],region", "SCHOOL ='" + str + "'AND region  ='南投'");
                string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                if (dt1.Rows[0].ItemArray[2].ToString() == str && dt1.Rows[0].ItemArray[3].ToString() == "南投")
                {
                    if (dt1.Rows.Count == 0)
                    {

                        MessageBox.Show("找不到南投總錶5中 " + str + "的資料");

                    }
                    else
                    {
                        DataTable dt5 = new DataTable();
                        dt5 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "[SCHOOL] ='" + dt1.Rows[0].ItemArray[2].ToString() + "' and region ='" + dt1.Rows[0].ItemArray[3].ToString() + "' and IP_ADRESS ='" + port[0] + "." + port[1] + "." + port[2] + ".246'");


                        if (dt5.Rows.Count == 0)
                        {
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶一','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶二','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            //  Connect.Insert("[classroom_Summary]", "[SCHOOL],[classroom],region,IP_ADRESS", dt1.Rows[i].ItemArray[2].ToString() + "','總錶三','"  + dt1.Rows[i].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".249");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "196','總表13','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".246");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "196','總表14','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".246");
                            Connect.Insert("[classroom_Summary]", "[SCHOOL],agate,[classroom],region,IP_ADRESS", dt1.Rows[0].ItemArray[2].ToString() + "','" + (Convert.ToInt32(dt1.Rows[0].ItemArray[1].ToString()) / 1000).ToString() + "196','總表15','" + dt1.Rows[0].ItemArray[3].ToString() + "','" + port[0] + "." + port[1] + "." + port[2] + ".246");
                            /*
                            DataTable dt6 = new DataTable();
                            dt6 = Connect.Search("[agate_ip_port]", "agate_ip", "agate_ip ='" + port[0] + "." + port[1] + "." + port[2] + ".248" + "'");
                            if (dt6.Rows.Count == 0)
                            {
                                port1 = ((Convert.ToInt32(port[2]) - 50) * 160 - 9 + 10000).ToString();
                                port2 = ((Convert.ToInt32(port[2]) - 50) * 160 - 8 + 10000).ToString();
                                port3 = ((Convert.ToInt32(port[2]) - 50) * 160 - 7 + 10000).ToString();
                                Connect.Insert("[agate_ip_port]", "[agate_ip],[com1],[com2],[com3]", port[0] + "." + port[1] + "." + port[2] + ".248" + "','" + port1 + "','" + port2 + "','" + port3);
                            }
                         */
                        }
                    }

                }
            }
            sr8.Close();
         //   DataTable dt3 = new DataTable();
          //  dt3 = Connect.Search("[classroom_Summary]", "[IP_ADRESS],[cardreader]","port_no is null");
            MessageBox.Show("ok");  
        }

        private void button10_Click(object sender, EventArgs e)
        {

            int i, j;
            string debugopen = "debugopen";
            string debugclose = "debugclose";
            string ans = "no";
            string old_pas = "";
            string today;
            DateTime day = DateTime.Now;
            today = day.ToString("yyyy-MM-dd-HH-mm");
            SerialPort serialPort1 = new SerialPort();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {

                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
                serialPort1.Write(debugopen);
                Thread.Sleep(1000);
                char[] accept1 = new char[serialPort1.BytesToRead];
                serialPort1.Read(accept1, 0, accept1.Length);
                Thread.Sleep(1000);
                string card_no = Convert.ToInt64(textBox2.Text).ToString("x");
                while (card_no.Length < 8)
                {
                    card_no = "0" + card_no;
                }
                for (int g = 6; g > 1; g = g - 2)
                {
                    card_no = card_no.Insert(g, " ");
                }
                if (accept1.Length >= card_no.Length && accept1.Length > 0)
                {
                    for (j = 0; j < accept1.Length - card_no.Length + 1; j++)
                    {
                        j = j;
                        if (accept1[j] == card_no[0])
                        {
                            ans = "";
                            for (i = 0; i < card_no.Length; i++)
                            {
                                if (card_no[i] != accept1[j + i])
                                {
                                    ans = "卡號有誤";

                                }
                            }
                            if (ans == "")
                            {
                                break;
                            }
                        }


                    }
                    if (j == accept1.Length - card_no.Length + 1)
                    {

                        ans = "卡號有誤";


                    }
                }
                else if (accept1.Length != card_no.Length && accept1.Length > 0)
                {
                    ans = "卡號有誤";
                }
                else if (accept1.Length > 0)
                {
                    for (j = 0; j < card_no.Length; j++)
                    {
                        if (card_no[j] != accept1[j])
                        {
                            ans = "卡號有誤從第" + j + "個不一樣";

                        }
                    }
                }
                else
                {
                    ans = "父沒有收到任何東西";
                }
                if (ans == "")
                {

                    MessageBox.Show("卡號確認ok");


                }
                else
                {
                    MessageBox.Show(ans);
                }
                Thread.Sleep(1000);
                serialPort1.Write(debugclose);
                Thread.Sleep(1000);
                serialPort1.Close();
            }

            // Connect.Edit2("Card_message", "[pasword]","0x010203040506", "1", "[card_no]");
            int h = 0;
            /*
            for ( h = 0; h < 12; h++)
            {
                if (Uri.IsHexDigit(textBox3.Text[h]) != true)
                {
                    
                    break;
                }
            }*/
            string str2 = "AA AA 02 40 01 05 97";
            string ack = "";
            if (ans != "")
            {

            }/*
            else if(h!=12){
                MessageBox.Show("輸入的密碼非16進制");
            }*/
            else if (comboBox1.Text == "")
            {
                //MessageBox.Show("沒有com");
            }/*
            else if(textBox3.Text.Length!=12){
                MessageBox.Show("請確認是否12碼");
            }*/
            else
            {
                string str = "";
                string aa = "";
                DataTable dt1 = new DataTable();
                dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money", "[card_no] = '" + textBox2.Text + "'");
                str += "AA,AA,01,40,0D,02,";//header
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    object obj = dt1.Rows[0].ItemArray[2];//卡片密碼
                    byte[] buffer = (byte[])obj;
                    aa = "";

                    for (int k = 0; k < buffer.Length; k++)
                    {
                        string STR = buffer[k].ToString("X");
                        while (STR.Length < 2)
                        {
                            STR = "0" + STR;
                        }
                        aa += STR;
                        old_pas += STR;

                    }
                    string new_pass;
                    new_pass = old_pas;//由於第一次生產所以新密碼等於一開始預設的密碼
                    old_pas = "FFFFFFFFFFFF"; //生產一開始密碼都FF
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    aa = "FF,FF,FF,FF,FF,FF,"; //生產一開始密碼都FF
                    str += aa;
                    textBox3.Text = new_pass;
                    aa = textBox3.Text;

                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");


                    }

                    str += aa;
                    str += "00,00";



                    serialPort1.Open();

                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 2];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 2)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                    }

                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 2] = CRC_buffer[1];
                    data2[data2.Length - 1] = CRC_buffer[0];

                    StreamWriter sw = new StreamWriter(".\\密碼修改" + ".txt", true);//TXT備註
                    sw.WriteLine("卡號 ; " + textBox2.Text + "欲將密碼從 " + old_pas + " 改為 " + textBox3.Text);
                    sw.Flush();
                    sw.Close();


                    Connect.Insert("[Card_pass]", "[card_no],[old_pass],[new_pass],[update_time]", textBox2.Text + "','" + old_pas + "','" + textBox3.Text + "','" + today);
                    Thread.Sleep(1000);
                    serialPort1.Write(data2, 0, data2.Length);
                    Thread.Sleep(1000);
                    byte[] accept = new byte[serialPort1.BytesToRead];

                    serialPort1.Read(accept, 0, accept.Length);

                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包或密碼有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                       // Connect.Edit2("Card_message", "[pasword]", "0x" + textBox3.Text, textBox2.Text, "[card_no]");
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }


                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox5.Text = "";
            //if(textBox1.Text.Length==8){
             
            //    DataTable dt1 = new DataTable();
            //    dt1 = Connect.Search("[classroom_Summary]", "[SCHOOL], [building],[building_floor],[classroom]", "[cardreader] = '" + textBox1.Text + "'");
            //    if (dt1.Rows.Count>0)
            //    {
            //        textBox5.Text = dt1.Rows[0].ItemArray[0].ToString() + dt1.Rows[0].ItemArray[1].ToString() + dt1.Rows[0].ItemArray[2].ToString() + dt1.Rows[0].ItemArray[3].ToString();
            //    }
               
            //}
            textBox5.Text = "";
            if (textBox1.Text.Length == 8)
            {

                string school_num = textBox1.Text.Substring(0, 5);
           
                DataRow[] school;
                school = school_rows.Select("school_num = ('" + school_num + "')");


                if (school.Count() == 1)
                {

                    textBox5.Text = school[0].ItemArray[0].ToString() + " " + textBox1.Text;

                }
                else
                {
                    MessageBox.Show("查無此學校");
                }

            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //textBox5.Text = "";
            //if (textBox4.Text.Length == 8)
            //{
                
            //    DataTable dt1 = new DataTable();
            //    dt1 = Connect.Search("[classroom_Summary]", "[SCHOOL], [building],[building_floor],[classroom]", "[ModuleID1] = '" + textBox4.Text + "'");
            //    if (dt1.Rows.Count > 0)
            //    {
            //        textBox5.Text = dt1.Rows[0].ItemArray[0].ToString() + dt1.Rows[0].ItemArray[1].ToString() + dt1.Rows[0].ItemArray[2].ToString() + dt1.Rows[0].ItemArray[3].ToString();
            //    }
            //    else
            //    {
            //        DataTable dt2 = new DataTable();
            //        dt2 = Connect.Search("[classroom_Summary]", "[SCHOOL], [building],[building_floor],[classroom]", "[ModuleID2] = '" + textBox4.Text + "'");
            //        if (dt2.Rows.Count > 0)
            //        {
            //            textBox5.Text = dt2.Rows[0].ItemArray[0].ToString() + dt2.Rows[0].ItemArray[1].ToString() + dt2.Rows[0].ItemArray[2].ToString() + dt2.Rows[0].ItemArray[3].ToString();
            //        }
            //    }

            //}

            textBox5.Text = "";
            if (textBox4.Text.Length == 8)
            {

                string school_num = textBox4.Text.Substring(0, 4);
                string region = textBox4.Text.Substring(7, 1);
                DataRow[] school;
                if (region == "1" || region == "2")
                {
                    school = school_rows.Select("school_num = ('1" + school_num + "')");
                }
                else
                {
                    school = school_rows.Select("school_num = ('2" + school_num + "')");
                }
              


                if (school.Count() == 1)
                {

                    textBox5.Text = school[0].ItemArray[0].ToString() + " " + textBox4.Text;

                }
                else
                {
                    MessageBox.Show("查無此學校");
                }

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string meter = "";
            string str;
            string str1;
            string str2 = "";
            string today_st;
            string today_end;
            string dayrange;
            string rssi_day;
            string ordinary_pasword = "";
            string timecard_pasword = "";
            string path = ".\\學校IP.txt";  //讀TXT
            int start = 0;
            int k = 0;
            DateTime day = DateTime.Now;
            today_st = day.ToString("yyyy.MM.dd");
            today_end = (day.AddDays(20)).ToString("yyyy.MM.dd");
            dayrange = today_st + ".0.0." + today_end + ".0.0";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {

                string[] put = str.Split('_');
               // Connect.DeleteSpec("[SCHOOL_IPADRESS]", "SCHOOL ='" + put[0] + "' and IPADRESS = '" + put[1]+"'");
                DataTable dt1 = new DataTable();
                dt1 = Connect.Search("[SCHOOL_IPADRESS]", "[SCHOOL]","SCHOOL ='"+put[0]+"'");
                if (dt1.Rows.Count==0)
                {
                    Connect.Insert("[SCHOOL_IPADRESS]", "[SCHOOL],[IPADRESS]", put[0] + "','" + put[1]);
                }
               
               
                k++;

                /*
                else
                {
                    str = str + ",";

                    meter += str;
                }
               */
            }
            MessageBox.Show(" THE END");
            sr.Close();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            string str = "";
            string path = ".\\匯入一般卡片.txt";  //讀TXT
            StreamReader sr1 = new StreamReader(path);
            //DataTable school_rows = new DataTable();
            card_flash.Columns.Add("cardreader", typeof(string));
            card_flash.Columns.Add("card", typeof(string));
            card_flash.Columns.Add("card_type", typeof(string));

            // DataRow[] school_rows;

            while ((str = sr1.ReadLine()) != null)
            {
                string[] aa = str.Split('_');
                card_flash.Rows.Add(aa[0], aa[1], "3");
                card_flash.Rows.Add(aa[0], aa[2], "3");
                card_flash.Rows.Add(aa[0], aa[3], "3");

            }
            sr1.Close();
            
            path = ".\\匯入強制時效卡片.txt";  //讀TXT
            StreamReader sr2 = new StreamReader(path);
            while ((str = sr2.ReadLine()) != null)
            {
                string[] aa = str.Split('_');
                card_flash.Rows.Add(aa[3], aa[1], "1");
                card_flash.Rows.Add(aa[3], aa[2], "2");
               

            }
            sr2.Close();


            string str3 = "";
            path = ".\\學校IP.txt";  //讀TXT
            StreamReader sr3 = new StreamReader(path);
            //DataTable school_rows = new DataTable();
            school_rows.Columns.Add("school", typeof(string));
            school_rows.Columns.Add("ip", typeof(string));
            school_rows.Columns.Add("school_num", typeof(string));

            // DataRow[] school_rows;

            while ((str3 = sr3.ReadLine()) != null)
            {
                string[] aa = str3.Split('_');
                school_rows.Rows.Add(aa[0], aa[1], aa[2]);

            }
            sr3.Close();
            
        }

        private void button12_Click(object sender, EventArgs e)
        {

            string str;

            string today_st;
            string today_end;
            string dayrange;

            string ordinary_pasword = "";
            string timecard_pasword = "";
            string path = ".\\匯入資料南投.txt";  //讀TXT

            int k = 0;
            DateTime day = DateTime.Now;
            today_st = day.ToString("yyyy.MM.dd");
            today_end = (day.AddDays(20)).ToString("yyyy.MM.dd");
            dayrange = today_st + ".0.0." + today_end + ".0.0";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {

                string[] put = str.Split('_');
                //  DataTable dt5 = new DataTable();   //重複不新增
                // dt5 = Connect.Search("[classroom_Summary]", "[cardreader]", "[cardreader] = '" + put[4] + "'"); 
                if (1 == 2)
                {

                }
                else
                {

                    DataTable dt1 = new DataTable();
                    dt1 = Connect.Search("[SCHOOL_IPADRESS]", "[IPADRESS]", "[SCHOOL] = '" + put[9] + put[5] + "'");
                    if (dt1.Rows.Count == 0)
                    {
                        MessageBox.Show(put[5] + "沒有學校ip");
                    }
                    else if (dt1.Rows.Count > 1)
                    {
                        MessageBox.Show(put[5] + "有2個一樣名稱的學校");
                    }
                    else
                    {
                        
                        string[] port = dt1.Rows[0].ItemArray[0].ToString().Split('.');
                       // string port1 = ((Convert.ToInt32(port[2]) - 51) * 160 + (((Convert.ToInt32(put[4]) % 1000) - 1) + 11) + 10000).ToString();
                        // string port1 = ((Convert.ToInt32(port[2]) - 51) * 60 + (Convert.ToInt32(put[0]) % 1000 + 10) + 10000).ToString();
                        Connect.Insert("[classroom_Summary]", "region,[ModuleID1],[ModuleID2],[SCHOOL],[building],building_floor ,classroom,[agate],[meter],[cardreader],Aircon_Status1,Aircon_Status2,aircon_temper,wind_direction,wind_speed,aircon_mode,[IP_ADRESS]", put[9] + "','" + put[2] + "','" + put[3] + "','" + put[5] + "','" + put[6] + "','" + put[7] + "','" + put[8] + "','" + put[0] + "','" + put[1] + "','" + put[4] + "','OFF','OFF','26','自動','自動','冷氣','" + dt1.Rows[0].ItemArray[0].ToString() + "." + (Convert.ToInt32(put[0]) % 1000 + 50).ToString());
                        if (put[4] != "")
                        {
                            ordinary_pasword = ((Convert.ToUInt64(put[4]) * 1234) % 1000000000000).ToString();
                           // ordinary_pasword = (((Convert.ToUInt64(put[0])) / 1000 * 2345678) % 1000000000000).ToString();
                            while (ordinary_pasword.Length < 12)
                            {
                                ordinary_pasword = "0" + ordinary_pasword;
                            }
                            //ordinary_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                            ordinary_pasword = "0x" + ordinary_pasword;
                            // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                            timecard_pasword = (((Convert.ToUInt64(put[4])) / 1000 * 3456789) % 1000000000000).ToString();
                            while (timecard_pasword.Length < 12)
                            {
                                timecard_pasword = "0" + timecard_pasword;
                            }
                            //timecard_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                            timecard_pasword = "0x" + timecard_pasword;
                            DataTable dt2 = new DataTable();
                            dt2 = Connect.Search("[Card_reader_message]", "[reader_no]", "[reader_no] = '" + put[4] + "'");
                            if (dt2.Rows.Count == 0)
                            {
                                Connect.Insert("Card_reader_message", "[reader_no],[remainder_money],[time_cost],ordinary_pasword ,timecard_pasword,[warm_money]", put[4] + "','0','6.6.6.6.6.6'," + ordinary_pasword + "," + timecard_pasword + ",'100");
                            }
                        }
                    }
                }



                k++;


            }
            MessageBox.Show(" THE END");
            sr.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            string str;

            string today_st;
            string today_end;
            string dayrange;

            string ordinary_pasword = "";
            string timecard_pasword = "";
            string path = ".\\匯入一般卡片.txt";  //讀TXT

            int k = 0;
            DateTime day = DateTime.Now;
            today_st = day.ToString("yyyy.MM.dd");
            today_end = (day.AddYears(20)).ToString("yyyy.MM.dd");
            dayrange = today_st + ".0.0." + today_end + ".0.0";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {

                string[] put = str.Split('_');
                //if(Convert.ToUInt64(put[0])/10000000==1){
                //      ordinary_pasword = ((Convert.ToUInt64(put[0]) * 1234) % 1000000000000).ToString();
                //}
                //else{
                //    ordinary_pasword = (((Convert.ToUInt64(put[0])) / 1000 * 2345678) % 1000000000000).ToString();
                //}
                ordinary_pasword = ((Convert.ToUInt64(put[0]) * 1234) % 1000000000000).ToString();
                
               // ordinary_pasword = (((Convert.ToUInt64(put[0])) / 1000 * 2345678) % 1000000000000).ToString();
                while (ordinary_pasword.Length < 12)
                {
                    ordinary_pasword = "0" + ordinary_pasword;
                }

                ordinary_pasword = "0x" + ordinary_pasword;
                // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                timecard_pasword = (((Convert.ToUInt64(put[0])) / 1000 * 3456789) % 1000000000000).ToString();
                while (timecard_pasword.Length < 12)
                {
                    timecard_pasword = "0" + timecard_pasword;
                }
                timecard_pasword = "0x" + timecard_pasword;
                DataTable dt2 = new DataTable();
                dt2 = Connect.Search("[Card_message]", "[card_no]", "[card_no] = '" + put[1] + "'");
                if (dt2.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[1] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }
                DataTable dt3 = new DataTable();
                dt3 = Connect.Search("[Card_message]", "[card_no]", "[card_no] = '" + put[2] + "'");
                if (dt3.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[2] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }
                DataTable dt4 = new DataTable();
                dt4 = Connect.Search("[Card_message]", "[card_no]", "[card_no] = '" + put[3] + "'");
                if (dt4.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[3] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }
              



                k++;


            }
            k=0;
            string path2 = ".\\匯入強制時效卡片.txt";  //讀TXT
            StreamReader sr2 = new StreamReader(path2);
            while ((str = sr2.ReadLine()) != null)
            {

                string[] put = str.Split('_');

                //if (Convert.ToUInt64(put[3]) / 10000000 == 1)
                //{
                //    ordinary_pasword = ((Convert.ToUInt64(put[3]) * 1234) % 1000000000000).ToString();
                //}
                //else
                //{
                //    ordinary_pasword = (((Convert.ToUInt64(put[3])) / 1000 * 2345678) % 1000000000000).ToString();
                //}
                ordinary_pasword = ((Convert.ToUInt64(put[3]) * 1234) % 1000000000000).ToString();
              //  ordinary_pasword = (((Convert.ToUInt64(put[0])) / 1000 * 2345678) % 1000000000000).ToString();
                while (ordinary_pasword.Length < 12)
                {
                    ordinary_pasword = "0" + ordinary_pasword;
                }
                
                ordinary_pasword = "0x" + ordinary_pasword;
                // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                timecard_pasword = (((Convert.ToUInt64(put[3])) / 1000 * 3456789) % 1000000000000).ToString();
                while (timecard_pasword.Length < 12)
                {
                    timecard_pasword = "0" + timecard_pasword;
                }
                timecard_pasword = "0x" + timecard_pasword;
                DataTable dt2 = new DataTable();
                dt2 = Connect.Search("[Card_message]", "[card_no]", "[card_no] = '" + put[1] + "'");
                if (dt2.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[1] + "','" + put[0] + "'," + "'1'" + "," + timecard_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                  //  Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[1] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }
                DataTable dt3 = new DataTable();
                dt3 = Connect.Search("[Card_message]", "[card_no]", "[card_no] = '" + put[2] + "'");
                if (dt3.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[2] + "','" + put[0] + "'," + "'2'" + "," + timecard_pasword + ",'" + dayrange + "','0");
                   // Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[2] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }
                
         



                k++;


            }

            MessageBox.Show(" THE END");
            sr.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string meter = "";
            string str;
            string str1;
            string str2 = "";
            string today_st;
            string today_end;
            string dayrange;
            string rssi_day;
            string ordinary_pasword = "";
            string timecard_pasword = "";
            string path = ".\\花蓮school_ip.txt";  //讀TXT
            
            int start = 0;
            int k = 0;
            DateTime day = DateTime.Now;
            today_st = day.ToString("yyyy.MM.dd");
            today_end = (day.AddDays(20)).ToString("yyyy.MM.dd");
            dayrange = today_st + ".0.0." + today_end + ".0.0";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {

                string[] put = str.Split('_');
                // Connect.DeleteSpec("[SCHOOL_IPADRESS]", "SCHOOL ='" + put[0] + "' and IPADRESS = '" + put[1]+"'");
                DataTable dt1 = new DataTable();
                dt1 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "SCHOOL ='" + put[0] + "' and [region] ='花蓮'");
                if (dt1.Rows.Count > 0)
                {
                    Connect.Edit("[classroom_Summary]", "[school_ip]", put[1], "SCHOOL ='" + put[0] + "' and [region] ='花蓮'");
                }
                else
                {
                    MessageBox.Show("沒有" + put[0]);
                }


                k++;

                /*
                else
                {
                    str = str + ",";

                    meter += str;
                }
               */
            }
            MessageBox.Show(" THE END");
            sr.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string meter = "";
            string str;
            string str1;
            string str2 = "";
            string today_st;
            string today_end;
            string dayrange;
            string rssi_day;
            string ordinary_pasword = "";
            string timecard_pasword = "";
            string path = ".\\南投school_ip.txt";  //讀TXT

            int start = 0;
            int k = 0;
            DateTime day = DateTime.Now;
            today_st = day.ToString("yyyy.MM.dd");
            today_end = (day.AddDays(20)).ToString("yyyy.MM.dd");
            dayrange = today_st + ".0.0." + today_end + ".0.0";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {

                string[] put = str.Split('_');
                // Connect.DeleteSpec("[SCHOOL_IPADRESS]", "SCHOOL ='" + put[0] + "' and IPADRESS = '" + put[1]+"'");
                DataTable dt1 = new DataTable();
                dt1 = Connect.Search("[classroom_Summary]", "[SCHOOL]", "SCHOOL ='" + put[0] + "' and [region] ='南投'");
                if (dt1.Rows.Count > 0)
                {
                    Connect.Edit("[classroom_Summary]", "[school_ip]", put[1], "SCHOOL ='" + put[0] + "' and [region] ='南投'");
                }
                else
                {
                    MessageBox.Show("沒有" + put[0]);
                }


                k++;

                /*
                else
                {
                    str = str + ",";

                    meter += str;
                }
               */
            }
            MessageBox.Show(" THE END");
            sr.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Connect.DeleteSpec("[classroom_Summary]","[classroom] not like '備品%' and [classroom] not like '總%'");
            MessageBox.Show("ok");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("請輸入卡號");
            }
            else
            {
                string str = "READCARD";
                string str2 = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money", "[card_no] = '" + textBox2.Text + "'");
                DataRow[] card_no;
                card_no = card_flash.Select("card = ('" + textBox2.Text + "') ");
                if (card_no.Count() == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    aa = Convert.ToInt32(card_no[0].ItemArray[2].ToString()).ToString("X");//卡片類型
                    while (aa.Length != 2)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 2; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }

                    str2 += aa;

                    if (card_no[0].ItemArray[2].ToString() == "2")
                    {
                        aa = "2022.12.28.0.0.2042.12.28.0.0";//卡片使用時間
                    }
                    else
                    {
                        aa = "0.0.0.0.0.0.0.0.0.0";//卡片使用時間
                    }
                    string[] cost = aa.Split('.');
                    for (int k = 0; k < cost.Length; k++)
                    {
                        if (cost[k].Length > 2)
                        {
                            cost[k] = (Convert.ToUInt32(cost[k]) % 100).ToString();
                        }
                        aa = Convert.ToInt32(cost[k]).ToString("X");
                        while (aa.Length < 2)
                        {
                            aa = "0" + aa;
                        }
                        for (int g = 2; g > 1; g = g - 2)
                        {
                            aa = aa.Insert(g, " ");
                        }
                        str2 += aa;
                    }

                    str2 += "00 ";//保留碼

                    aa = (Convert.ToInt32("0") * 10000).ToString("X");//餘額要乘10000
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 6; g > 1; g = g - 2)//最後一個不要空格所以是6
                    {
                        aa = aa.Insert(g, " ");
                    }

                    str2 += aa;
                    str2 = "Card information:";//出現Card information:等於解開密碼

                    /*
                     str2 += "11 12 13 14 ";//讀卡機號
                     str2 += "00 64 00 64 00 64 00 64 00 00 00 00 ";//費率
                     str2 += "FF FF FF FF FF FF ";//一般卡密碼
                     str2 += "00 03 ";//免費卡張數
                     str2 += "AA BB CC DD ";//免費卡起始卡號
                     str2 += "00 02 ";//時效卡張數
                     str2 += "CC DD EE FF ";//時效卡起始卡號
                     str2 += "F1 F2 F3 F4 F5 F6 ";//時效卡密碼
                     str2 += "64";//餘額警示
                     */
                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string data2 = str;                 //以逗號作分割成字串陣列
                    string ack = "";
                    //  string accept = "";
                    // byte[] accept = new byte[50000];
                    //char[] accept = new char[1500];
                    serialPort1.Write(data2);
                    //Task.Delay(1200).Wait();

                    Thread.Sleep(1000);
                    char[] accept = new char[serialPort1.BytesToRead];
                    /*
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();*/
                    serialPort1.Read(accept, 0, accept.Length);
                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }

                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {
                string str = "flashread";
                string str2 = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_reader_message]", "reader_no, time_cost,ordinary_pasword,timecard_pasword,warm_money", "[reader_no] = '" + textBox1.Text + "'");

                if (false)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    aa = Convert.ToInt32(textBox1.Text).ToString("X");//讀卡機號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    aa = "6.6.6.6.6.6";//費率
                    string[] cost = aa.Split('.');
                    for (int k = 0; k < cost.Length; k++)
                    {
                        aa = Convert.ToInt32(cost[k]).ToString("X");
                        while (aa.Length < 4)
                        {
                            aa = "0" + aa;
                        }
                        for (int g = 4; g > 1; g = g - 2)
                        {
                            aa = aa.Insert(g, " ");
                        }
                        str2 += aa;
                    }

                    string ordinary_pasword = "";
                    string timecard_pasword = "";
                   
                    //ordinary_pasword = ((Convert.ToUInt64(textBox1.Text) * 1234) % 1000000000000).ToString();
                    ordinary_pasword = (((Convert.ToUInt64(textBox1.Text)) / 1000 * 2345678) % 1000000000000).ToString();
                    while (ordinary_pasword.Length < 12)
                    {
                        ordinary_pasword = "0" + ordinary_pasword;
                    }
                    //ordinary_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                    //ordinary_pasword = "0x" + ordinary_pasword;
                    // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                    timecard_pasword = (((Convert.ToUInt64(textBox1.Text)) / 1000 * 3456789) % 1000000000000).ToString();
                    while (timecard_pasword.Length < 12)
                    {
                        timecard_pasword = "0" + timecard_pasword;
                    }
                    //timecard_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                    //timecard_pasword = "0x" + timecard_pasword;
                    //object obj = dt1.Rows[0].ItemArray[2];//一般卡密碼
                    //byte[] buffer = (byte[])obj;
                    //aa = "";
                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = ordinary_pasword;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    /*
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[2].ToString()).ToString("X");//免費卡張數
                    while (aa.Length != 4)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 4; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[3].ToString()).ToString("X");//免費卡起始卡號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[4].ToString()).ToString("X");//時效卡張數
                    while (aa.Length != 4)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 4; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[5].ToString()).ToString("X");//時效卡起始卡號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;
                    */
                    //object obj2 = dt1.Rows[0].ItemArray[3];//時效卡密碼
                    //byte[] buffer2 = (byte[])obj2;
                    //aa = "";
                    //for (int k = 0; k < buffer2.Length; k++) 
                    //{
                    //    string STR = buffer2[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = timecard_pasword;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, " ");
                    }
                    str2 += aa;

                    aa = Convert.ToInt32("100").ToString("X");//餘額警示
                    while (aa.Length != 2)
                    {
                        aa = "0" + aa;
                    }

                    str2 += aa + " 00 1E";

                    /*
                     str2 += "11 12 13 14 ";//讀卡機號
                     str2 += "00 64 00 64 00 64 00 64 00 00 00 00 ";//費率
                     str2 += "FF FF FF FF FF FF ";//一般卡密碼
                     str2 += "00 03 ";//免費卡張數
                     str2 += "AA BB CC DD ";//免費卡起始卡號
                     str2 += "00 02 ";//時效卡張數
                     str2 += "CC DD EE FF ";//時效卡起始卡號
                     str2 += "F1 F2 F3 F4 F5 F6 ";//時效卡密碼
                     str2 += "64";//餘額警示
                     */
                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string data2 = str;                 //以逗號作分割成字串陣列
                    string ack = "";
                    //  string accept = "";
                    // byte[] accept = new byte[50000];
                    //char[] accept = new char[1500];
                    serialPort1.Write(data2);
                    //Task.Delay(1200).Wait();

                    Thread.Sleep(1000);
                    char[] accept = new char[serialPort1.BytesToRead];
                    /*
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();
                    accept = serialPort1.ReadLine();*/
                    serialPort1.Read(accept, 0, accept.Length);
                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }

                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {
                string str = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_reader_message]", "reader_no, time_cost,ordinary_pasword,timecard_pasword,warm_money", "[reader_no] = '" + textBox1.Text + "'");
                str += "8E,";//header
                if (false)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    aa = Convert.ToInt32(textBox1.Text).ToString("X");//讀卡機號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    //aa = dt1.Rows[0].ItemArray[1].ToString();//費率
                    aa = "6.6.6.6.6.6";
                    string[] cost = aa.Split('.');
                    for (int k = 0; k < cost.Length; k++)
                    {
                        aa = Convert.ToInt32(cost[k]).ToString("X");
                        while (aa.Length < 4)
                        {
                            aa = "0" + aa;
                        }
                        for (int g = 4; g > 1; g = g - 2)
                        {
                            aa = aa.Insert(g, ",");
                        }
                        str += aa;
                    }
                    string ordinary_pasword = "";
                    string timecard_pasword = "";
                   
                    //ordinary_pasword = ((Convert.ToUInt64(textBox1.Text) * 1234) % 1000000000000).ToString();
                    ordinary_pasword = (((Convert.ToUInt64(textBox1.Text)) / 1000 * 2345678) % 1000000000000).ToString();
                    while (ordinary_pasword.Length < 12)
                    {
                        ordinary_pasword = "0" + ordinary_pasword;
                    }
                    //ordinary_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                    //ordinary_pasword = "0x" + ordinary_pasword;
                    // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                    timecard_pasword = (((Convert.ToUInt64(textBox1.Text)) / 1000 * 3456789) % 1000000000000).ToString();
                    while (timecard_pasword.Length < 12)
                    {
                        timecard_pasword = "0" + timecard_pasword;
                    }
                    //timecard_pasword ="FFFFFFFFFFFF";   //初始密碼改成FF
                    //timecard_pasword = "0x" + timecard_pasword;

                    //object obj = dt1.Rows[0].ItemArray[2];//一般卡密碼
                    //byte[] buffer = (byte[])obj;
                    //aa = "";
                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = ordinary_pasword;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    /*
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[2].ToString()).ToString("X");//免費卡張數
                    while (aa.Length != 4)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 4; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[3].ToString()).ToString("X");//免費卡起始卡號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[4].ToString()).ToString("X");//時效卡張數
                    while (aa.Length != 4)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 4; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    aa = Convert.ToInt32(dt1.Rows[0].ItemArray[5].ToString()).ToString("X");//時效卡起始卡號
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;
                    */
                    //object obj2 = dt1.Rows[0].ItemArray[3];//時效卡密碼
                    //byte[] buffer2 = (byte[])obj2;
                    //aa = "";
                    //for (int k = 0; k < buffer2.Length; k++) 
                    //{
                    //    string STR = buffer2[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = timecard_pasword;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;

                    aa = Convert.ToInt32("100").ToString("X");//餘額警示
                    while (aa.Length != 2)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 2; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;


                    str += "00,1E,00,00,8E";
                    // aa = aa;


                    /*
                string str = "";
                str += "8E,";//header
                str += "11,12,13,14,";//讀卡機號
                str += "00,64,00,64,00,64,00,64,00,00,00,00,";//費率
                str += "FF,FF,FF,FF,FF,FF,";//一般卡密碼
                str += "00,03,";//免費卡張數
                str += "AA,BB,CC,DD,";//免費卡起始卡號
                str += "00,02,";//時效卡張數
                str += "CC,DD,EE,FF,";//時效卡起始卡號
                str += "F1,F2,F3,F4,F5,F6,";//時效卡密碼
                str += "64,";//餘額警示
                str += "8E";//header*/
                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 3];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 3)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }

                    }
                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 3] = CRC_buffer[1];
                    data2[data2.Length - 2] = CRC_buffer[0];
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    // byte[] accept = new byte[serialPort1.BytesToRead];
                    // serialPort1.Read(accept, 0, accept.Length);
                    serialPort1.Close();
                    MessageBox.Show("請確認是否輸入成功");
                }

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int i, j = 0;
            string debugopen = "debugopen";
            string debugclose = "debugclose";
            string ans = "no";
            string old_pas = "";
            string today;
            string card = "";
            DateTime day = DateTime.Now;
            today = day.ToString("yyyy-MM-dd-HH-mm");
            SerialPort serialPort1 = new SerialPort();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {

                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
                serialPort1.Write(debugopen);
                Task.Delay(1200).Wait();
                char[] accept1 = new char[serialPort1.BytesToRead];
                serialPort1.Read(accept1, 0, accept1.Length);
                //  string card_no = Convert.ToInt64(textBox2.Text).ToString("x");
                /*
                while (card_no.Length < 8)
                {
                    card_no = "0" + card_no;
                }
                for (int g = 6; g > 1; g = g - 2)
                {
                    card_no = card_no.Insert(g, " ");
                }*/
                string card_no = "Card ID is:";
                if (accept1.Length >= card_no.Length && accept1.Length > 0)
                {
                    for (j = 0; j < accept1.Length - card_no.Length + 1; j++)
                    {
                        j = j;
                        if (accept1[j] == card_no[0])
                        {
                            ans = "";
                            for (i = 0; i < card_no.Length; i++)
                            {
                                if (card_no[i] != accept1[j + i])
                                {
                                    ans = "卡號有誤";

                                }
                            }
                            if (ans == "")
                            {
                                break;
                            }
                        }


                    }
                    if (j == accept1.Length - card_no.Length + 1)
                    {

                        ans = "卡號有誤";


                    }
                }
                else if (accept1.Length != card_no.Length && accept1.Length > 0)
                {
                    ans = "卡號有誤";
                }
                else if (accept1.Length > 0)
                {
                    for (j = 0; j < card_no.Length; j++)
                    {
                        if (card_no[j] != accept1[j])
                        {
                            ans = "卡號有誤從第" + j + "個不一樣";

                        }
                    }
                }
                else
                {
                    ans = "父沒有收到任何東西";
                }
                if (ans == "")
                {

                    MessageBox.Show("卡號確認ok");
                    card = accept1[j + 11].ToString() + accept1[j + 12].ToString() + accept1[j + 14].ToString() + accept1[j + 15].ToString() + accept1[j + 17].ToString() + accept1[j + 18].ToString() + accept1[j + 20].ToString() + accept1[j + 21].ToString();
                    textBox2.Text = (Convert.ToInt64(card, 16).ToString());
                    while (textBox2.Text.Length < 10)
                    {
                        textBox2.Text = "0" + textBox2.Text;
                    }

                }
                else
                {
                    MessageBox.Show(ans);
                }
                Thread.Sleep(1000);
                serialPort1.Write(debugclose);
                Thread.Sleep(1000);
                serialPort1.Close();
            }

            int h = 0;
            /*
            for ( h = 0; h < 12; h++)
            {
                if (Uri.IsHexDigit(textBox3.Text[h]) != true)
                {
                    
                    break;
                }
            }*/
            string str2 = "AA AA 02 40 01 05 97";
            string ack = "";
            if (ans != "")
            {

            }/*
            else if(h!=12){
                MessageBox.Show("輸入的密碼非16進制");
            }*/
            else if (comboBox1.Text == "")
            {
                //MessageBox.Show("沒有com");
            }/*
            else if(textBox3.Text.Length!=12){
                MessageBox.Show("請確認是否12碼");
            }*/
            else
            {
                string str = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money,for_cardreader", "[card_no] = '" + textBox2.Text + "'");
                DataRow[] card_no;
                card_no = card_flash.Select("card = ('" + textBox2.Text + "') ");
                str += "AA,AA,01,40,0D,02,";//header
                if (card_no.Count() == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    //object obj = dt1.Rows[0].ItemArray[2];//卡片密碼
                    //byte[] buffer = (byte[])obj;
                    aa = "";

                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //    old_pas += STR;

                    //}
                    //old_pas = ((Convert.ToUInt64(textBox1.Text) * 1234) % 1000000000000).ToString();
                    //while (old_pas.Length < 12)
                    //{
                    //    old_pas = "0" + old_pas;
                    //}
                    //aa = old_pas;
                    //for (int g = 12; g > 1; g = g - 2)
                    //{
                    //    aa = aa.Insert(g, ",");
                    //}
                    old_pas ="FFFFFFFFFFFF";
                    aa = "FF,FF,FF,FF,FF,FF,"; //生產一開始密碼都FF
                    str += aa;
                    if (card_no[0].ItemArray[2].ToString()=="3")
                    {
                        textBox3.Text = (((Convert.ToUInt64(card_no[0].ItemArray[0].ToString())) / 1000 * 2345678) % 1000000000000).ToString();
                    }
                    else
                    {
                        textBox3.Text = (((Convert.ToUInt64(card_no[0].ItemArray[0].ToString())) / 1000 * 3456789) % 1000000000000).ToString();
                    }
                    
                    //textBox3.Text = "FFFFFFFFFFFF";
                    while (textBox3.Text.Length < 12)
                    {
                        textBox3.Text = "0" + textBox3.Text;
                    }
                    aa = textBox3.Text;

                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");


                    }

                    str += aa;
                    str += "00,00";



                    serialPort1.Open();

                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 2];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 2)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                    }

                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 2] = CRC_buffer[1];
                    data2[data2.Length - 1] = CRC_buffer[0];

                    StreamWriter sw = new StreamWriter(".\\密碼修改" + ".txt", true);//TXT備註
                    sw.WriteLine("卡號 ; " + textBox2.Text + "欲將密碼從 " + old_pas + " 改為 " + textBox3.Text);
                    sw.Flush();
                    sw.Close();


                    Connect.Insert("[Card_pass]", "[card_no],[old_pass],[new_pass],[update_time]", textBox2.Text + "','" + old_pas + "','" + textBox3.Text + "','" + today);
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    byte[] accept = new byte[serialPort1.BytesToRead];
                    serialPort1.Read(accept, 0, accept.Length);

                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包或密碼有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                        // Connect.Edit2("Card_message", "[pasword]", "0x" + textBox3.Text, textBox2.Text, "[card_no]");
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }


                }

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int i, j = 0;
            string debugopen = "debugopen";
            string debugclose = "debugclose";
            string ans = "no";
            string old_pas = "";
            string today;
            string card = "";
            DateTime day = DateTime.Now;
            today = day.ToString("yyyy-MM-dd-HH-mm");
            SerialPort serialPort1 = new SerialPort();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {

                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
                serialPort1.Write(debugopen);
                Task.Delay(1200).Wait();
                char[] accept1 = new char[serialPort1.BytesToRead];
                serialPort1.Read(accept1, 0, accept1.Length);
                //  string card_no = Convert.ToInt64(textBox2.Text).ToString("x");
                /*
                while (card_no.Length < 8)
                {
                    card_no = "0" + card_no;
                }
                for (int g = 6; g > 1; g = g - 2)
                {
                    card_no = card_no.Insert(g, " ");
                }*/
                string card_no = "Card ID is:";
                if (accept1.Length >= card_no.Length && accept1.Length > 0)
                {
                    for (j = 0; j < accept1.Length - card_no.Length + 1; j++)
                    {
                        j = j;
                        if (accept1[j] == card_no[0])
                        {
                            ans = "";
                            for (i = 0; i < card_no.Length; i++)
                            {
                                if (card_no[i] != accept1[j + i])
                                {
                                    ans = "卡號有誤";

                                }
                            }
                            if (ans == "")
                            {
                                break;
                            }
                        }


                    }
                    if (j == accept1.Length - card_no.Length + 1)
                    {

                        ans = "卡號有誤";


                    }
                }
                else if (accept1.Length != card_no.Length && accept1.Length > 0)
                {
                    ans = "卡號有誤";
                }
                else if (accept1.Length > 0)
                {
                    for (j = 0; j < card_no.Length; j++)
                    {
                        if (card_no[j] != accept1[j])
                        {
                            ans = "卡號有誤從第" + j + "個不一樣";

                        }
                    }
                }
                else
                {
                    ans = "父沒有收到任何東西";
                }
                if (ans == "")
                {

                    MessageBox.Show("卡號確認ok");
                    card = accept1[j + 11].ToString() + accept1[j + 12].ToString() + accept1[j + 14].ToString() + accept1[j + 15].ToString() + accept1[j + 17].ToString() + accept1[j + 18].ToString() + accept1[j + 20].ToString() + accept1[j + 21].ToString();
                    textBox2.Text = (Convert.ToInt64(card, 16).ToString());
                    while (textBox2.Text.Length < 10)
                    {
                        textBox2.Text = "0" + textBox2.Text;
                    }

                }
                else
                {
                    MessageBox.Show(ans);
                }
                Thread.Sleep(1000);
                serialPort1.Write(debugclose);
                Thread.Sleep(1000);
                serialPort1.Close();
            }

            int h = 0;
            /*
            for ( h = 0; h < 12; h++)
            {
                if (Uri.IsHexDigit(textBox3.Text[h]) != true)
                {
                    
                    break;
                }
            }*/
            string str2 = "AA AA 02 40 01 05 97";
            string ack = "";
            if (ans != "")
            {

            }/*
            else if(h!=12){
                MessageBox.Show("輸入的密碼非16進制");
            }*/
            else if (comboBox1.Text == "")
            {
                //MessageBox.Show("沒有com");
            }/*
            else if(textBox3.Text.Length!=12){
                MessageBox.Show("請確認是否12碼");
            }*/
            else
            {
                string str = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money,for_cardreader", "[card_no] = '" + textBox2.Text + "'");
                DataRow[] card_no;
                card_no = card_flash.Select("card = ('" + textBox2.Text + "') ");
                str += "AA,AA,01,40,0D,02,";//header
                if (card_no.Count() == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    //object obj = dt1.Rows[0].ItemArray[2];//卡片密碼
                    //byte[] buffer = (byte[])obj;
                    aa = "";

                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //    old_pas += STR;

                    //}
                    //old_pas = ((Convert.ToUInt64(textBox1.Text) * 1234) % 1000000000000).ToString();
                    //while (old_pas.Length < 12)
                    //{
                    //    old_pas = "0" + old_pas;
                    //}
                    //aa = old_pas;
                    //for (int g = 12; g > 1; g = g - 2)
                    //{
                    //    aa = aa.Insert(g, ",");
                    //}
                    old_pas = "FFFFFFFFFFFF";
                    aa = "FF,FF,FF,FF,FF,FF,"; //生產一開始密碼都FF
                    str += aa;
                   
                    if (card_no[0].ItemArray[2].ToString() == "3")
                    {
                        textBox3.Text = ((Convert.ToUInt64(card_no[0].ItemArray[0].ToString()) * 1234) % 1000000000000).ToString();
                    }
                    else
                    {
                        textBox3.Text = (((Convert.ToUInt64(card_no[0].ItemArray[0].ToString())) / 1000 * 3456789) % 1000000000000).ToString();
                    }
                    //textBox3.Text = "FFFFFFFFFFFF";
                    while (textBox3.Text.Length < 12)
                    {
                        textBox3.Text = "0" + textBox3.Text;
                    }
                    aa = textBox3.Text;

                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");


                    }

                    str += aa;
                    str += "00,00";



                    serialPort1.Open();

                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 2];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 2)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                    }

                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 2] = CRC_buffer[1];
                    data2[data2.Length - 1] = CRC_buffer[0];

                    StreamWriter sw = new StreamWriter(".\\密碼修改" + ".txt", true);//TXT備註
                    sw.WriteLine("卡號 ; " + textBox2.Text + "欲將密碼從 " + old_pas + " 改為 " + textBox3.Text);
                    sw.Flush();
                    sw.Close();


                    Connect.Insert("[Card_pass]", "[card_no],[old_pass],[new_pass],[update_time]", textBox2.Text + "','" + old_pas + "','" + textBox3.Text + "','" + today);
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    byte[] accept = new byte[serialPort1.BytesToRead];
                    serialPort1.Read(accept, 0, accept.Length);

                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包或密碼有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                        // Connect.Edit2("Card_message", "[pasword]", "0x" + textBox3.Text, textBox2.Text, "[card_no]");
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }


                }

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int i, j = 0;
            string debugopen = "debugopen";
            string debugclose = "debugclose";
            string ans = "no";
            string old_pas = "";
            string today;
            string card = "";
            DateTime day = DateTime.Now;
            today = day.ToString("yyyy-MM-dd-HH-mm");
            SerialPort serialPort1 = new SerialPort();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {

                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
                serialPort1.Write(debugopen);
                Task.Delay(1200).Wait();
                char[] accept1 = new char[serialPort1.BytesToRead];
                serialPort1.Read(accept1, 0, accept1.Length);
                //  string card_no = Convert.ToInt64(textBox2.Text).ToString("x");
                /*
                while (card_no.Length < 8)
                {
                    card_no = "0" + card_no;
                }
                for (int g = 6; g > 1; g = g - 2)
                {
                    card_no = card_no.Insert(g, " ");
                }*/
                string card_no = "Card ID is:";
                if (accept1.Length >= card_no.Length && accept1.Length > 0)
                {
                    for (j = 0; j < accept1.Length - card_no.Length + 1; j++)
                    {
                        
                        if (accept1[j] == card_no[0])
                        {
                            ans = "";
                            for (i = 0; i < card_no.Length; i++)
                            {
                                if (card_no[i] != accept1[j + i])
                                {
                                    ans = "卡號有誤";

                                }
                            }
                            if (ans == "")
                            {
                                break;
                            }
                        }


                    }
                    if (j == accept1.Length - card_no.Length + 1)
                    {

                        ans = "卡號有誤";


                    }
                }
                else if (accept1.Length != card_no.Length && accept1.Length > 0)
                {
                    ans = "卡號有誤";
                }
                else if (accept1.Length > 0)
                {
                    for (j = 0; j < card_no.Length; j++)
                    {
                        if (card_no[j] != accept1[j])
                        {
                            ans = "卡號有誤從第" + j + "個不一樣";

                        }
                    }
                }
                else
                {
                    ans = "父沒有收到任何東西";
                }
                if (ans == "")
                {

                    MessageBox.Show("卡號確認ok");
                    card = accept1[j + 11].ToString() + accept1[j + 12].ToString() + accept1[j + 14].ToString() + accept1[j + 15].ToString() + accept1[j + 17].ToString() + accept1[j + 18].ToString() + accept1[j + 20].ToString() + accept1[j + 21].ToString();
                    textBox2.Text = (Convert.ToInt64(card, 16).ToString());
                    while (textBox2.Text.Length < 10)
                    {
                        textBox2.Text = "0" + textBox2.Text;
                    }

                }
                else
                {
                    MessageBox.Show(ans);
                }
                Thread.Sleep(1000);
                serialPort1.Write(debugclose);
                Thread.Sleep(1000);
                serialPort1.Close();
            }

           
            /*
            for ( h = 0; h < 12; h++)
            {
                if (Uri.IsHexDigit(textBox3.Text[h]) != true)
                {
                    
                    break;
                }
            }*/
            string str2 = "AA AA 02 40 01 05 97";
            string ack = "";
            if (ans != "")
            {

            }/*
            else if(h!=12){
                MessageBox.Show("輸入的密碼非16進制");
            }*/
            else if (comboBox1.Text == "")
            {
                //MessageBox.Show("沒有com");
            }/*
            else if(textBox3.Text.Length!=12){
                MessageBox.Show("請確認是否12碼");
            }*/
            else
            {
                string str = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money,for_cardreader", "[card_no] = '" + textBox2.Text + "'");
                DataRow[] card_no;
                card_no = card_flash.Select("card = ('" + textBox2.Text + "') and card_type = '3'");

                str += "AA,AA,01,40,0D,02,";//header
                if (card_no.Count() == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    //object obj = dt1.Rows[0].ItemArray[2];//卡片密碼
                    //byte[] buffer = (byte[])obj;
                    aa = "";

                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //    old_pas += STR;

                    //}
                    old_pas = ((Convert.ToUInt64(card_no[0].ItemArray[0].ToString()) * 1234) % 1000000000000).ToString();
                    while (old_pas.Length < 12)
                    {
                        old_pas = "0" + old_pas;
                    }
                    aa = old_pas;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    //  aa = "FF,FF,FF,FF,FF,FF,"; //生產一開始密碼都FF
                    str += aa;
                    textBox3.Text = (((Convert.ToUInt64(card_no[0].ItemArray[0].ToString())) / 1000 * 2345678) % 1000000000000).ToString();
                    //textBox3.Text = "FFFFFFFFFFFF";
                    while (textBox3.Text.Length < 12)
                    {
                        textBox3.Text = "0" + textBox3.Text;
                    }
                    aa = textBox3.Text;

                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");


                    }

                    str += aa;
                    str += "00,00";



                    serialPort1.Open();

                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 2];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 2)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                    }

                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 2] = CRC_buffer[1];
                    data2[data2.Length - 1] = CRC_buffer[0];

                    StreamWriter sw = new StreamWriter(".\\密碼修改" + ".txt", true);//TXT備註
                    sw.WriteLine("卡號 ; " + textBox2.Text + "欲將密碼從 " + old_pas + " 改為 " + textBox3.Text);
                    sw.Flush();
                    sw.Close();


                    Connect.Insert("[Card_pass]", "[card_no],[old_pass],[new_pass],[update_time]", textBox2.Text + "','" + old_pas + "','" + textBox3.Text + "','" + today);
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    byte[] accept = new byte[serialPort1.BytesToRead];
                    serialPort1.Read(accept, 0, accept.Length);

                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包或密碼有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                        // Connect.Edit2("Card_message", "[pasword]", "0x" + textBox3.Text, textBox2.Text, "[card_no]");
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }


                }

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int i, j = 0;
            string debugopen = "debugopen";
            string debugclose = "debugclose";
            string ans = "no";
            string old_pas = "";
            string today;
            string card = "";
            DateTime day = DateTime.Now;
            today = day.ToString("yyyy-MM-dd-HH-mm");
            SerialPort serialPort1 = new SerialPort();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else
            {

                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
                serialPort1.Write(debugopen);
                Task.Delay(1200).Wait();
                char[] accept1 = new char[serialPort1.BytesToRead];
                serialPort1.Read(accept1, 0, accept1.Length);
                //  string card_no = Convert.ToInt64(textBox2.Text).ToString("x");
                /*
                while (card_no.Length < 8)
                {
                    card_no = "0" + card_no;
                }
                for (int g = 6; g > 1; g = g - 2)
                {
                    card_no = card_no.Insert(g, " ");
                }*/
                string card_no = "Card ID is:";
                if (accept1.Length >= card_no.Length && accept1.Length > 0)
                {
                    for (j = 0; j < accept1.Length - card_no.Length + 1; j++)
                    {
                        j = j;
                        if (accept1[j] == card_no[0])
                        {
                            ans = "";
                            for (i = 0; i < card_no.Length; i++)
                            {
                                if (card_no[i] != accept1[j + i])
                                {
                                    ans = "卡號有誤";

                                }
                            }
                            if (ans == "")
                            {
                                break;
                            }
                        }


                    }
                    if (j == accept1.Length - card_no.Length + 1)
                    {

                        ans = "卡號有誤";


                    }
                }
                else if (accept1.Length != card_no.Length && accept1.Length > 0)
                {
                    ans = "卡號有誤";
                }
                else if (accept1.Length > 0)
                {
                    for (j = 0; j < card_no.Length; j++)
                    {
                        if (card_no[j] != accept1[j])
                        {
                            ans = "卡號有誤從第" + j + "個不一樣";

                        }
                    }
                }
                else
                {
                    ans = "父沒有收到任何東西";
                }
                if (ans == "")
                {

                    MessageBox.Show("卡號確認ok");
                    card = accept1[j + 11].ToString() + accept1[j + 12].ToString() + accept1[j + 14].ToString() + accept1[j + 15].ToString() + accept1[j + 17].ToString() + accept1[j + 18].ToString() + accept1[j + 20].ToString() + accept1[j + 21].ToString();
                    textBox2.Text = (Convert.ToInt64(card, 16).ToString());
                    while (textBox2.Text.Length < 10)
                    {
                        textBox2.Text = "0" + textBox2.Text;
                    }

                }
                else
                {
                    MessageBox.Show(ans);
                }
                Thread.Sleep(1000);
                serialPort1.Write(debugclose);
                Thread.Sleep(1000);
                serialPort1.Close();
            }

            int h = 0;
            /*
            for ( h = 0; h < 12; h++)
            {
                if (Uri.IsHexDigit(textBox3.Text[h]) != true)
                {
                    
                    break;
                }
            }*/
            string str2 = "AA AA 02 40 01 05 97";
            string ack = "";
            if (ans != "")
            {

            }/*
            else if(h!=12){
                MessageBox.Show("輸入的密碼非16進制");
            }*/
            else if (comboBox1.Text == "")
            {
                //MessageBox.Show("沒有com");
            }/*
            else if(textBox3.Text.Length!=12){
                MessageBox.Show("請確認是否12碼");
            }*/
            else
            {
                string str = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money,for_cardreader", "[card_no] = '" + textBox2.Text + "'");
                DataRow[] card_no;
                card_no = card_flash.Select("card = ('" + textBox2.Text + "') and card_type = '3'");
                str += "AA,AA,01,40,0D,02,";//header
                if (card_no.Count() == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    //object obj = dt1.Rows[0].ItemArray[2];//卡片密碼
                    //byte[] buffer = (byte[])obj;
                    aa = "";

                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //    old_pas += STR;

                    //}

                    old_pas = (((Convert.ToUInt64(card_no[0].ItemArray[0].ToString())) / 1000 * 2345678) % 1000000000000).ToString();
                    while (old_pas.Length < 12)
                    {
                        old_pas = "0" + old_pas;
                    }
                    aa = old_pas;
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    //  aa = "FF,FF,FF,FF,FF,FF,"; //生產一開始密碼都FF
                    str += aa;
                    textBox3.Text = ((Convert.ToUInt64(card_no[0].ItemArray[0].ToString()) * 1234) % 1000000000000).ToString();
                    //textBox3.Text = "FFFFFFFFFFFF";
                    while (textBox3.Text.Length < 12)
                    {
                        textBox3.Text = "0" + textBox3.Text;
                    }
                    aa = textBox3.Text;

                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");


                    }

                    str += aa;
                    str += "00,00";



                    serialPort1.Open();

                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 2];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 2)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                    }

                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 2] = CRC_buffer[1];
                    data2[data2.Length - 1] = CRC_buffer[0];

                    StreamWriter sw = new StreamWriter(".\\密碼修改" + ".txt", true);//TXT備註
                    sw.WriteLine("卡號 ; " + textBox2.Text + "欲將密碼從 " + old_pas + " 改為 " + textBox3.Text);
                    sw.Flush();
                    sw.Close();


                    Connect.Insert("[Card_pass]", "[card_no],[old_pass],[new_pass],[update_time]", textBox2.Text + "','" + old_pas + "','" + textBox3.Text + "','" + today);
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    byte[] accept = new byte[serialPort1.BytesToRead];
                    serialPort1.Read(accept, 0, accept.Length);

                    serialPort1.Close();
                    if (accept.Length >= str2.Length && accept.Length > 0)
                    {
                        for (j = 0; j < accept.Length - str2.Length + 1; j++)
                        {

                            if (accept[j] == str2[0])
                            {
                                ack = "";
                                for (i = 0; i < str2.Length; i++)
                                {
                                    if (str2[i] != accept[j + i])
                                    {
                                        ack = "收到的封包或密碼有錯";

                                    }
                                }
                                if (ack == "")
                                {
                                    break;
                                }
                            }


                        }
                        if (j == accept.Length - str2.Length + 1)
                        {

                            ack = "收到的封包有錯";


                        }
                    }
                    else if (accept.Length != str2.Length && accept.Length > 0)
                    {
                        ack = "收到的封包有缺";
                    }
                    else if (accept.Length > 0)
                    {
                        for (j = 0; j < str2.Length; j++)
                        {
                            if (str2[j] != accept[j])
                            {
                                ack = "封包從第" + j + "個不一樣";

                            }
                        }
                    }
                    else
                    {
                        ack = "父沒有收到任何東西";
                    }
                    if (ack == "")
                    {
                        // Connect.Edit2("Card_message", "[pasword]", "0x" + textBox3.Text, textBox2.Text, "[card_no]");
                        MessageBox.Show("確認ok");

                    }
                    else
                    {
                        MessageBox.Show(ack);
                    }


                }

            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string str;

            string today_st;
            string today_end;
            string dayrange;

            string ordinary_pasword = "";
            string timecard_pasword = "";
            string path = ".\\匯入一般卡片.txt";  //讀TXT

            int k = 0;
            DateTime day = DateTime.Now;
            today_st = day.ToString("yyyy.MM.dd");
            today_end = (day.AddYears(20)).ToString("yyyy.MM.dd");
            dayrange = today_st + ".0.0." + today_end + ".0.0";
            StreamReader sr = new StreamReader(path);
            while ((str = sr.ReadLine()) != null)
            {

                string[] put = str.Split('_');

                // ordinary_pasword = ((Convert.ToUInt64(put[0]) * 1234) % 1000000000000).ToString();
                 ordinary_pasword = (((Convert.ToUInt64(put[0])) / 1000 * 2345678) % 1000000000000).ToString();
                while (ordinary_pasword.Length < 12)
                {
                    ordinary_pasword = "0" + ordinary_pasword;
                }

                ordinary_pasword = "0x" + ordinary_pasword;
                // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                timecard_pasword = (((Convert.ToUInt64(put[0])) / 1000 * 3456789) % 1000000000000).ToString();
                while (timecard_pasword.Length < 12)
                {
                    timecard_pasword = "0" + timecard_pasword;
                }
                timecard_pasword = "0x" + timecard_pasword;
                DataTable dt2 = new DataTable();
                dt2 = Connect.Search("[Card_message1]", "[card_no]", "[card_no] = '" + put[1] + "'");
                if (dt2.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message1]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[1] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }
                DataTable dt3 = new DataTable();
                dt3 = Connect.Search("[Card_message1]", "[card_no]", "[card_no] = '" + put[2] + "'");
                if (dt3.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message1]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[2] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }
                DataTable dt4 = new DataTable();
                dt4 = Connect.Search("[Card_message1]", "[card_no]", "[card_no] = '" + put[3] + "'");
                if (dt4.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message1]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[3] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }




                k++;


            }
            k = 0;
            string path2 = ".\\匯入強制時效卡片.txt";  //讀TXT
            StreamReader sr2 = new StreamReader(path2);
            while ((str = sr2.ReadLine()) != null)
            {

                string[] put = str.Split('_');

                //  ordinary_pasword = ((Convert.ToUInt64(put[3]) * 1234) % 1000000000000).ToString();

                  ordinary_pasword = (((Convert.ToUInt64(put[3])) / 1000 * 2345678) % 1000000000000).ToString();
                while (ordinary_pasword.Length < 12)
                {
                    ordinary_pasword = "0" + ordinary_pasword;
                }

                ordinary_pasword = "0x" + ordinary_pasword;
                // timecard_pasword = ((Convert.ToUInt64(99999999) * 5678) % 1000000000000).ToString();
                timecard_pasword = (((Convert.ToUInt64(put[3])) / 1000 * 3456789) % 1000000000000).ToString();
                while (timecard_pasword.Length < 12)
                {
                    timecard_pasword = "0" + timecard_pasword;
                }
                timecard_pasword = "0x" + timecard_pasword;
                DataTable dt2 = new DataTable();
                dt2 = Connect.Search("[Card_message1]", "[card_no]", "[card_no] = '" + put[1] + "'");
                if (dt2.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message1]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[1] + "','" + put[0] + "'," + "'1'" + "," + timecard_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                    //  Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[1] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }
                DataTable dt3 = new DataTable();
                dt3 = Connect.Search("[Card_message1]", "[card_no]", "[card_no] = '" + put[2] + "'");
                if (dt3.Rows.Count == 0)
                {
                    Connect.Insert("[Card_message1]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[2] + "','" + put[0] + "'," + "'2'" + "," + timecard_pasword + ",'" + dayrange + "','0");
                    // Connect.Insert("[Card_message]", "[card_no],[for_cardreader],[card_type],[pasword] ,[time_range],[remainder_money]", put[2] + "','" + put[0] + "'," + "'3'" + "," + ordinary_pasword + ",'0.0.0.0.0.0.0.0.0.0','0");
                }





                k++;


            }

            MessageBox.Show(" THE END");
            sr.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("沒有com");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("請輸入卡號");
            }
            else
            {
                string str = "";
                string aa = "";
                //DataTable dt1 = new DataTable();
                //dt1 = Connect.Search("[Card_message]", "card_no,card_type,pasword,time_range,remainder_money", "[card_no] = '" + textBox2.Text + "'");
                DataRow[] card_no;
                card_no = card_flash.Select("card = ('" + textBox2.Text + "') ");
                str += "AA,AA,01,30,17,08,";//header
                if (card_no.Count() == 0)
                {
                    MessageBox.Show("查無相關資料");
                }
                else
                {
                    //object obj = dt1.Rows[0].ItemArray[2];//卡片密碼
                    //byte[] buffer = (byte[])obj;
                    //aa = "";
                    //for (int k = 0; k < buffer.Length; k++)
                    //{
                    //    string STR = buffer[k].ToString("X");
                    //    while (STR.Length < 2)
                    //    {
                    //        STR = "0" + STR;
                    //    }
                    //    aa += STR;
                    //}
                    aa = "";
                    if (card_no[0].ItemArray[2].ToString() == "3")
                    {
                        aa = ((Convert.ToUInt64(card_no[0].ItemArray[0].ToString()) * 1234) % 1000000000000).ToString();
                       
                    }
                    else
                    {
                        aa = (((Convert.ToUInt64(card_no[0].ItemArray[0].ToString())) / 1000 * 3456789) % 1000000000000).ToString();
                    }

                    //textBox3.Text = "FFFFFFFFFFFF";
                    while (aa.Length < 12)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 12; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }
                    str += aa;

                    aa = Convert.ToInt32(card_no[0].ItemArray[2].ToString()).ToString("X");//卡片類型
                    while (aa.Length != 2)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 2; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }

                    str += aa;
                    if (card_no[0].ItemArray[2].ToString() == "2")
                    {
                        aa = "2022.12.28.0.0.2042.12.28.0.0";//卡片使用時間
                    }
                    else
                    {
                        aa = "0.0.0.0.0.0.0.0.0.0";//卡片使用時間
                    }

                    string[] cost = aa.Split('.');
                    for (int k = 0; k < cost.Length; k++)
                    {
                        if (cost[k].Length > 2)
                        {
                            cost[k] = (Convert.ToUInt32(cost[k]) % 100).ToString();
                        }
                        aa = Convert.ToInt32(cost[k]).ToString("X");
                        while (aa.Length < 2)
                        {
                            aa = "0" + aa;
                        }
                        for (int g = 2; g > 1; g = g - 2)
                        {
                            aa = aa.Insert(g, ",");
                        }
                        str += aa;
                    }

                    str += "00,";//保留碼

                    aa = (Convert.ToInt32("0") * 10000).ToString("X");//餘額要乘10000
                    while (aa.Length != 8)
                    {
                        aa = "0" + aa;
                    }
                    for (int g = 8; g > 1; g = g - 2)
                    {
                        aa = aa.Insert(g, ",");
                    }

                    str += aa;

                    str += "00,00";//check



                    int i, j;
                    SerialPort serialPort1 = new SerialPort();
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    string[] data1 = str.Split(',');                 //以逗號作分割成字串陣列
                    for (i = 0; i < data1.Length; i++)               //要轉BYTE把前面第一個字是0的刪除例01改為1
                    {
                        if (data1[i].Substring(0, 1) == "0")
                        {
                            data1[i].Remove(1);
                        }

                    }
                    byte[] data2 = new byte[data1.Length];
                    byte[] Regist_byte_Output = new byte[data1.Length - 2];
                    for (j = 0; j < data1.Length; j++)
                    {
                        data2[j] = byte.Parse(data1[j], NumberStyles.HexNumber);   //data1[i]轉16進制字串轉BYTEPARSE存進去
                        if (j == 0)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                        else if (j < data1.Length - 2)
                        {
                            Regist_byte_Output[j] = byte.Parse(data1[j], NumberStyles.HexNumber);
                        }
                    }
                    byte[] CRC_buffer = new byte[2];
                    CRC_buffer = BitConverter.GetBytes(crc16_ccitt(Regist_byte_Output, Regist_byte_Output.Length)); // 算出CRC,但轉Byte時Byte高低位元會相反須注意
                    data2[data2.Length - 2] = CRC_buffer[1];
                    data2[data2.Length - 1] = CRC_buffer[0];
                    serialPort1.Write(data2, 0, data2.Length);
                    Task.Delay(1200).Wait();
                    // byte[] accept = new byte[serialPort1.BytesToRead];
                    // serialPort1.Read(accept, 0, accept.Length);
                    serialPort1.Close();
                    MessageBox.Show("請確認是否輸入成功");
                }

            }
        }

       
        

        
        
    }
}


