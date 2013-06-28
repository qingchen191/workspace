using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

namespace ChallengeC.WqMobile
{
    public class WqCore
    {
        private GameInfo gameInfo;
        private string mac;
        private string sha1mac;
        private string urlPre = "http://s2s.adwaken.cn/recommend/getad?";

        public WqCore(GameInfo game)
        {
            this.gameInfo = game;
        }

        // Methods
        public void clickWQ()
        {
            string jsonStr = this.getAdJson(this.urlPre + this.generateParam());
            List<string> adUrls = new List<string>();
            AdsJsonModel jsonAds = new JavaScriptSerializer().Deserialize<AdsJsonModel>(jsonStr);
            string viewUrl = "";
            List<string> clickUrlList = new List<string>();
            if (jsonAds.status.Equals("ok"))
            {
                if (jsonAds.beacons.Count > 0)
                {
                    Beacon viewBeacon = jsonAds.beacons[0];
                    viewUrl = viewBeacon.url;
                }
                if (jsonAds.ads.Count > 0)
                {
                    foreach (AdModel ad in jsonAds.ads)
                    {
                        if (ad.beacons.Count > 0)
                        {
                            Beacon clickBeacon = ad.beacons[0];
                            clickUrlList.Add(clickBeacon.url);
                        }
                    }
                }
            }
            string newIP = GenerateMethod.getIP();
            this.viewWQ(viewUrl, newIP);
            Random sleepRand = new Random();
            Thread.Sleep(sleepRand.Next(1000, 4000));
            this.clickWQ(clickUrlList, newIP);
        }

        private void clickWQ(List<string> clickUrlList, string newIP)
        {
            Random clickRandom = new Random();
            int clickIndex = clickRandom.Next(clickUrlList.Count);
            string clickUrl = clickUrlList[clickIndex];
            clickUrl = Regex.Replace(clickUrl, @"(\d+\.\d+\.\d+\.\d+)", newIP);
            string clickRtn = this.getAdJson(clickUrl);
            WqtabModel wq = new WqtabModel();
            wq.url = clickUrl;
            wq.type = "click";
            wq.game = this.gameInfo.Pnam;
            wq.status = clickRtn.Contains("ok") ? "ok" : "ng";
            wq.addtime = DateTime.Now;
            WqtabBll bll = new WqtabBll();
            bll.SaveWq(wq);
            if (clickRandom.Next(4) == 1)
            {
                Thread.Sleep(clickRandom.Next(3000, 6000));
                int secondIndex = 0;
                if (clickIndex == 0)
                {
                    secondIndex = clickIndex + 1;
                }
                else
                {
                    secondIndex = clickIndex - 1;
                }
                clickUrl = clickUrlList[secondIndex];
                clickUrl = Regex.Replace(clickUrl, @"(\d+\.\d+\.\d+\.\d+)", newIP);
                clickRtn = this.getAdJson(clickUrl);
                wq.url = clickUrl;
                wq.type = "click";
                wq.game = this.gameInfo.Pnam;
                wq.status = clickRtn.Contains("ok") ? "ok" : "ng";
                wq.addtime = DateTime.Now;
                bll.SaveWq(wq);
            }
        }

        private string generateParam()
        {
            Random rand = new Random();
            CPUModel cpu = Constant.cpus[rand.Next(Constant.cpus.Length)];
            Carrier carr = new Carrier();
            Device dev = Constant.devices[rand.Next(Constant.devices.Length)];
            this.mac = GenerateMethod.getMac();
            this.sha1mac = GenerateMethod.sha1Mac(this.mac);
            StringBuilder paramSB = new StringBuilder();
            paramSB.Append("maxc=" + cpu.Maxc);
            paramSB.Append("&mcc=" + carr.Mcc);
            paramSB.Append("&dev=" + this.sha1mac);
            paramSB.Append("&curc=" + cpu.Curc);
            paramSB.Append("&lng=" + GenerateMethod.getLng());
            paramSB.Append("&mac=" + this.mac);
            paramSB.Append("&bss=" + GenerateMethod.getBssid());
            paramSB.Append("&lac=" + GenerateMethod.getLac());
            paramSB.Append("&md=" + dev.Md);
            paramSB.Append("&minc=" + cpu.Minc);
            paramSB.Append("&sv=3.0.4");
            paramSB.Append("&mnc=" + carr.Mnc);
            paramSB.Append("&mf=" + dev.Mf);
            paramSB.Append("&dpi=" + dev.Dpi);
            paramSB.Append("&pnam=" + this.gameInfo.Pnam);
            paramSB.Append("&key=" + this.gameInfo.Key);
            paramSB.Append("&lat=" + GenerateMethod.getLat());
            paramSB.Append("&op=" + carr.Op);
            paramSB.Append("&sr=" + dev.Sr);
            paramSB.Append("&imei=" + GenerateMethod.getImei());
            paramSB.Append("&cpu=" + cpu.CpuName);
            paramSB.Append("&as=" + this.gameInfo.AsId);
            paramSB.Append("&pkg=" + this.gameInfo.Pkg);
            paramSB.Append("&did=" + GenerateMethod.getDid());
            paramSB.Append("&cid=" + GenerateMethod.getCid());
            paramSB.Append("&ct=" + GenerateMethod.getCt());
            paramSB.Append("&ppv=" + this.gameInfo.Ppv);
            paramSB.Append("&ch=");
            paramSB.Append("&imsi=" + GenerateMethod.getImsi(carr));
            paramSB.Append("&ac=40#anchor");
            return paramSB.ToString();
        }

        private string getAdJson(string url)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0; en-us; Xoom Build/HRI39) AppleWebKit/534.13 (KHTML, like Gecko) Version/4.0 Safari/534.13";
            myReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            myReq.KeepAlive = true;
            myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.8");
            HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
            Stream receviceStream = result.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream, Encoding.GetEncoding("utf-8"));
            string strHTML = readerOfStream.ReadToEnd();
            readerOfStream.Close();
            receviceStream.Close();
            result.Close();
            return strHTML;
        }

        public void viewWQ()
        {
            string jsonStr = this.getAdJson(this.urlPre + this.generateParam());
            List<string> adUrls = new List<string>();
            AdsJsonModel jsonAds = new JavaScriptSerializer().Deserialize<AdsJsonModel>(jsonStr);
            string viewUrl = "";
            List<string> clickUrlList = new List<string>();
            if (jsonAds.status.Equals("ok"))
            {
                if (jsonAds.beacons.Count > 0)
                {
                    Beacon viewBeacon = jsonAds.beacons[0];
                    viewUrl = viewBeacon.url;
                }
                if (jsonAds.ads.Count > 0)
                {
                    foreach (AdModel ad in jsonAds.ads)
                    {
                        if (ad.beacons.Count > 0)
                        {
                            Beacon clickBeacon = ad.beacons[0];
                            clickUrlList.Add(clickBeacon.url);
                        }
                    }
                }
            }
            string newIP = GenerateMethod.getIP();
            this.viewWQ(viewUrl, newIP);
        }

        private void viewWQ(string viewUrl, string newIP)
        {
            viewUrl = Regex.Replace(viewUrl, @"(\d+\.\d+\.\d+\.\d+)", newIP);
            string viewRtn = this.getAdJson(viewUrl);
            WqtabModel wq = new WqtabModel();
            wq.url = viewUrl;
            wq.game = this.gameInfo.Pnam;
            wq.type = "view";
            wq.status = viewRtn.Contains("ok") ? "ok" : "ng";
            wq.addtime = DateTime.Now;
            new WqtabBll().SaveWq(wq);
        }

    }
}