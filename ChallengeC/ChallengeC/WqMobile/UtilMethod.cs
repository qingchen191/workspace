using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

namespace ChallengeC.WqMobile
{
    public class UtilMethod
    {
        public static void SaveLog(string type, string content)
        {

            ThreadlogModel log = new ThreadlogModel();
            log.type = type;
            log.content = content;
            log.logtime = DateTime.Now;
            ThreadlogBll logbll = new ThreadlogBll();
            logbll.Savelog(log);
        }

        public static void RefreshApp()
        {

            string strUrl = "http://m.qingchen191.com/index.aspx";
            System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strUrl);
            System.Net.HttpWebResponse _HttpWebResponse = (System.Net.HttpWebResponse)_HttpWebRequest.GetResponse();
            System.IO.Stream _Stream = _HttpWebResponse.GetResponseStream();//得到回写的字节流
            StreamReader readStream = new StreamReader(_Stream, Encoding.UTF8);
            string outputString = readStream.ReadToEnd();
            _HttpWebResponse.Close();
            readStream.Close();
            SaveLog("refresh", outputString != null ? outputString.Substring(0, 80) : "refresh failed!");
        }

        public static int GetBaseRateByHour()
        {

            int nowHour = DateTime.Now.Hour;
            int viewRate = 6;
            switch (nowHour)
            {
                case 0:
                    viewRate = 10;
                    break;
                case 1:
                case 2:
                    viewRate = 13;
                    break;

                case 3:
                case 4:
                    viewRate = 18;
                    break;

                case 5:
                case 6:
                    viewRate = 19;
                    break;

                case 7:
                case 8:
                    viewRate = 12;
                    break;

                case 9:
                    viewRate = 9;
                    break;
                case 10:
                    viewRate = 8;
                    break;

                case 11:
                case 12:
                    viewRate = 7;
                    break;

                case 13:
                case 14:
                    viewRate = 7;
                    break;

                case 15:
                case 16:
                    viewRate = 7;
                    break;

                case 17:
                case 18:
                    viewRate = 7;
                    break;

                case 19:
                    viewRate = 6;
                    break;
                case 20:
                case 21:
                    viewRate = 5;
                    break;

                case 22:
                    viewRate = 6;
                    break;
                case 23:
                    viewRate = 8;
                    break;

                default:
                    viewRate = 7;
                    break;
            }
            return viewRate;
        }

        public static void DealGame(string gameName, int rate)
        {
            WqgameBll gameBll = new WqgameBll();
            WqgameModel game = gameBll.GetModelByName(gameName);
            WqCore bll = new WqCore(new GameInfo(game));
            Random rand = new Random(DateTime.Now.Millisecond);

            int baseRate = GetBaseRateByHour();
            UtilMethod.SaveLog("timerElapsed", gameName + " timer is started. rate is " + rate + ".baseRate is " + baseRate);

            if (rand.Next(baseRate) <= 5)
            {
                //UtilMethod.SaveLog("view", gameName + " is viewed.");
                bll.viewWQ();
                Thread.Sleep(rand.Next(100, 1000));
                if (rand.Next(baseRate) <= 1)
                {
                    bll.viewWQ();
                }
            }

            // 点击频率为1/(baseRate + rate)
            if (rand.Next(baseRate + rate) == 1)
            {
                Thread.Sleep(rand.Next(500, 3000));
                bll.clickWQ();
            }

        }

        public static void DealGame(string gameName)
        {
            WqgameBll gameBll = new WqgameBll();
            WqgameModel game = gameBll.GetModelByName(gameName);
            WqCore bll = new WqCore(new GameInfo(game));
            Random rand = new Random(DateTime.Now.Millisecond);

            UtilMethod.SaveLog("manual", gameName + " manual click.");

            bll.viewWQ();
            Thread.Sleep(rand.Next(500, 3000));
            bll.clickWQ();

        }
    }
}