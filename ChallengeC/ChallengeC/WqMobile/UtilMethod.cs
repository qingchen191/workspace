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

        public static int GetBaseRateByHour(int interval)
        {

            int nowHour = DateTime.Now.Hour;
            int viewRate = 2;
            int clickRate = 3;
            switch (nowHour)
            {
                case 0:
                case 1:
                case 2:
                    viewRate = 3;
                    clickRate = 4;
                    break;

                case 3:
                case 4:
                    viewRate = 4;
                    clickRate = 5;
                    break;

                case 5:
                case 6:
                    viewRate = 5;
                    clickRate = 6;
                    break;

                case 7:
                case 8:
                    viewRate = 3;
                    clickRate = 4;
                    break;

                case 9:
                case 10:
                    viewRate = 2;
                    clickRate = 3;
                    break;

                case 11:
                case 12:
                    viewRate = 4;
                    clickRate = 5;
                    break;

                case 13:
                case 14:
                    viewRate = 3;
                    clickRate = 4;
                    break;

                case 15:
                case 16:
                    viewRate = 2;
                    clickRate = 3;
                    break;

                case 17:
                case 18:
                    viewRate = 3;
                    clickRate = 4;
                    break;

                case 19:
                case 20:
                    viewRate = 2;
                    clickRate = 3;
                    break;

                case 21:
                case 22:
                    viewRate = 2;
                    clickRate = 2;
                    break;

                case 23:
                    viewRate = 2;
                    clickRate = 3;
                    break;

                default:
                    viewRate = 2;
                    clickRate = 3;
                    break;
            }
            return viewRate + interval;
        }

        public static void DealGame(string gameName, int interval)
        {
            WqgameBll gameBll = new WqgameBll();
            WqgameModel game = gameBll.GetModelByName(gameName);
            WqCore bll = new WqCore(new GameInfo(game));
            Random rand = new Random();

            int baseRate = UtilMethod.GetBaseRateByHour(interval);

            if (rand.Next(baseRate) == 1)
            {
                bll.viewWQ();
            }
            if (rand.Next(baseRate + 1) == 1)
            {
                Random sleepRand = new Random();
                Thread.Sleep(sleepRand.Next(500, 3000));
                bll.clickWQ();
            }

        }
    }
}