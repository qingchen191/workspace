using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Net;

namespace ChallengeC.WqMobile
{
    public class GenerateMethod
    {

        private static Random random = new Random();

        public static String getMac()
        {
            String val = "";

            for (int i = 0; i < 12; i++)
            {
                String charOrNum = random.Next(2) % 2 == 0 ? "char" : "num"; // 输出字母还是数字

                if ("char".Equals(charOrNum)) // 字符串
                {
                    val += (char)(97 + random.Next(6)); // 小写字母（a-f）
                }
                else if ("num".Equals(charOrNum)) // 数字
                {
                    val += random.Next(10);
                }

                if ((i % 2 == 1) && (i < 11))
                {
                    val += ":";
                }
            }

            return val;
        }

        public static String sha1Mac(String mac)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(mac);
            SHA1 sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);
            //StringBuilder EnText = new StringBuilder(); 
            //Console.WriteLine("--- Message Digest ---");
            string str = BitConverter.ToString(hashBytes, 1);
            //for (int i = 0; i < hashBytes.Length; i++)
            //{
            //    EnText.AppendFormat("{0:X2}", hashBytes[i]); 
            //    //Console.Write("{0:X}", hashBytes[i]); Console.Write(" ");
            //}
            return str.Replace("-", "");
        }

        public static String getBssid()
        {
            String val = "";

            //Random random = new Random();
            for (int i = 0; i < 12; i++)
            {
                String charOrNum = random.Next(2) % 2 == 0 ? "char" : "num"; // 输出字母还是数字

                if ("char".Equals(charOrNum)) // 字符串
                {
                    val += (char)(97 + random.Next(6)); // 小写字母（a-f）
                }
                else if ("num".Equals(charOrNum)) // 数字
                {
                    val += random.Next(10);
                }

                if ((i % 2 == 1) && (i < 11))
                {
                    val += ":";
                }
            }

            return val;
        }

        public static string getImei()
        {
            // IMEI
            return getNumByLength(20);
        }

        public static string getDid()
        {
            // DID设备编号
            return getNumByLength(15);
        }

        public static string getImsi(Carrier op)
        {
            // IMSI
            return op.Mcc + op.Mnc + getNumByLength(10);
        }


        public static String getIP()
        {

            //Random random = new Random();
            int no = random.Next(Constant.ipArray.Length/2);

            int begin = Constant.ipArray[no, 0];
            int end = Constant.ipArray[no, 1];

            int range = end - begin;

            int add = random.Next(range);

            int newIp = begin + add;


            byte[] arr = BitConverter.GetBytes(newIp);
            System.Text.StringBuilder item = new System.Text.StringBuilder();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                item.Append(arr[i].ToString() + ".");
            }


            return item.ToString().Substring(0, item.ToString().Length - 1);
        }

        public static string getLat()
        {
            // 范围是北纬21-43

            string latStr = "";
            //Random random = new Random();
            int lat = random.Next(23) + 21;

            latStr = lat + "." + getNumByLength(8);
            return latStr;
        }

        public static string getLng()
        {
            // 范围是东经102-121

            string lngStr = "";
            //Random random = new Random();
            int lng = random.Next(20) + 102;

            lngStr = lng + "." + getNumByLength(8);
            return lngStr;
        }

        public static string getCid()
        {
            // 基站编号
            return getNumByLength(5);
        }

        public static string getLac()
        {
            // 基站区域编号
            return getNumByLength(4);
        }



        public static string getCt()
        {
            // 网络连接方式
            string str = "";
            int model = random.Next(3);
            switch (model)
            {
                case 0:
                    str = "2G";
                    break;
                case 1:
                    str = "3G";
                    break;
                case 2:
                    str = "WIFI";
                    break;
                default:
                    str = "3G";
                    break;
            }
            return str;
        }


        public static string getNumByLength(int length)
        {

            String val = "";

            //Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                val += random.Next(10);
            }

            return val;

        }
    }

}