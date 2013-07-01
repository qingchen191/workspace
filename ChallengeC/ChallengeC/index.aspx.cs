using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using ChallengeC.WqMobile;
using System.Text;
using ChallengeC.common;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;


namespace ChallengeC
{
    public partial class index : System.Web.UI.Page
    {
        //private string urlPre = "http://s2s.adwaken.cn/recommend/getad?";
        //private String mac;
        //private String sha1mac;
        //private GameInfo game;

        protected void Page_Load(object sender, EventArgs e)
        {
            //WqgameBll gameBll = new WqgameBll();
            //List<WqgameModel> gameList = gameBll.GetAllGames();
            
            //foreach (WqgameModel game in gameList)
            //{
            //    GameList.Items.Add(game.chnname);
            //}
            GameList.Items.Clear();
            GameList.Items.Add("太空竞速");
            GameList.Items.Add("星星");
            GameList.Items.Add("保卫钓鱼岛");
            GameList.Items.Add("疯狂摩托");
            GameList.Items.Add("竞技摩托");

            requestedDeliveryDateTextBox.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

        }

        protected void GameList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>  
        /// 日期选择图标被点击  
        /// </summary>  
        protected void ImageButton_Click(object sender, EventArgs eventArgs)  
       {  
           //控制日历的显示与隐藏  
           calendar.Visible = !calendar.Visible;  
       }

        /// <summary>  
        /// 选择日期，通过AJAX触发  
        /// </summary>  
        protected void RequestedDeliveryDateCalendar_SelectionChanged(object sender, EventArgs eventArgs)
        {
            requestedDeliveryDateTextBox.Text = requestedDeliveryDateCalendar.SelectedDate.ToString("yyyy-MM-dd");

            // 隐藏日历  
            calendar.Visible = false;

            //设置日历下textbox的焦点，方便用户输入。移除或改变下行代码设置为您自己的控件  
            //someTextBox.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label3.Text = GameList.SelectedValue + "|" + requestedDeliveryDateTextBox.Text;
            string gameName = GameList.SelectedValue;
            WqWebBll webBll = new WqWebBll();
            List<GameInfoModel> gameInfoList = webBll.GetGamesInfo(requestedDeliveryDateTextBox.Text, GameList.SelectedValue);

            foreach (GameInfoModel info in gameInfoList)
            {
                TableRow row = new TableRow();
                TableCell cellgame = new TableCell();
                cellgame.Text = info.game;
                row.Cells.Add(cellgame);

                TableCell viewcnt = new TableCell();
                viewcnt.Text = info.viewcnt.ToString();
                row.Cells.Add(viewcnt);

                TableCell clickcnt = new TableCell();
                clickcnt.Text = info.clickcnt.ToString();
                row.Cells.Add(clickcnt);

                TableCell amount = new TableCell();
                amount.Text = info.amount.ToString();
                row.Cells.Add(amount);

                ViewTable1.Rows.Add(row);
            }
        }  

        #region old
        //private void viewWQ(int game)
        //{
        //    string urlParam = generateParam(game);

        //    TextBox1.Text = urlPre + urlParam;

        //    // 获取广告列表JSON数据
        //    string jsonStr = getAdJson(urlPre + urlParam);

        //    List<String> adUrls = new List<string>();

        //    JavaScriptSerializer json = new JavaScriptSerializer();
        //    AdsJsonModel jsonAds = json.Deserialize<AdsJsonModel>(jsonStr);

        //    String viewUrl = "";
        //    List<String> clickUrlList = new List<string>();

        //    if (jsonAds.status.Equals("ok"))
        //    {
        //        if (jsonAds.beacons.Count > 0)
        //        {
        //            Beacon viewBeacon = jsonAds.beacons[0];
        //            viewUrl = viewBeacon.url;
        //        }
        //        if (jsonAds.ads.Count > 0)
        //        {
        //            foreach (AdModel ad in jsonAds.ads)
        //            {
        //                if (ad.beacons.Count > 0)
        //                {
        //                    Beacon clickBeacon = ad.beacons[0];
        //                    clickUrlList.Add(clickBeacon.url);
        //                }
        //            }
        //        }
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    foreach (String url in clickUrlList)
        //    {
        //        sb.Append(url);
        //        sb.Append("</br>");
        //    }
        //    String newIP = GenerateMethod.getIP();
        //    viewUrl = Regex.Replace(viewUrl, @"(\d+\.\d+\.\d+\.\d+)", newIP);

        //    sb.Append(viewUrl);

        //    TextBox2.Text = sb.ToString();

        //    //展示
        //    string viewRtn = getAdJson(viewUrl);


        //    TextBox3.Text = "viewRtn:" + viewRtn + "|||viewUrl:" + viewUrl;
        //}

        //private void clickWQ(int game)
        //{

        //    string urlParam = generateParam(game);

        //    TextBox1.Text = urlPre + urlParam;

        //    // 获取广告列表JSON数据
        //    string jsonStr = getAdJson(urlPre + urlParam);

        //    List<String> adUrls = new List<string>();

        //    JavaScriptSerializer json = new JavaScriptSerializer();
        //    AdsJsonModel jsonAds = json.Deserialize<AdsJsonModel>(jsonStr);

        //    String viewUrl = "";
        //    List<String> clickUrlList = new List<string>();

        //    if (jsonAds.status.Equals("ok"))
        //    {
        //        if (jsonAds.beacons.Count > 0)
        //        {
        //            Beacon viewBeacon = jsonAds.beacons[0];
        //            viewUrl = viewBeacon.url;
        //        }
        //        if (jsonAds.ads.Count > 0)
        //        {
        //            foreach (AdModel ad in jsonAds.ads)
        //            {
        //                if (ad.beacons.Count > 0)
        //                {
        //                    Beacon clickBeacon = ad.beacons[0];
        //                    clickUrlList.Add(clickBeacon.url);
        //                }
        //            }
        //        }
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    foreach (String url in clickUrlList)
        //    {
        //        sb.Append(url);
        //        sb.Append("</br>");
        //    }
        //    String newIP = GenerateMethod.getIP();
        //    viewUrl = Regex.Replace(viewUrl, @"(\d+\.\d+\.\d+\.\d+)", newIP);

        //    sb.Append(viewUrl);

        //    TextBox2.Text = sb.ToString();

        //    //展示
        //    string viewRtn = getAdJson(viewUrl);

        //    //点击
        //    Random clickRandom = new Random();
        //    string clickUrl = clickUrlList[clickRandom.Next(clickUrlList.Count)];
        //    clickUrl = Regex.Replace(clickUrl, @"(\d+\.\d+\.\d+\.\d+)", newIP);
        //    string clickRtn = getAdJson(clickUrl);

        //    TextBox3.Text = "viewRtn:" + viewRtn + "|||clickUrl:" + clickUrl + "|||clickRtn:" + clickRtn;

        //}


        //private string generateParam(int gameNo)
        //{
        //    Random rand = new Random();

        //    CPUModel cpu = Constant.cpus[rand.Next(Constant.cpus.Length)];
        //    Carrier carr = new Carrier();
        //    game = Constant.games[gameNo];
        //    Device dev = Constant.devices[rand.Next(Constant.devices.Length)];
        //    mac = GenerateMethod.getMac();
        //    sha1mac = GenerateMethod.sha1Mac(mac);

        //    StringBuilder paramSB = new StringBuilder();
        //    paramSB.Append("maxc=" + cpu.Maxc);
        //    paramSB.Append("&mcc=" + carr.Mcc);
        //    paramSB.Append("&dev=" + sha1mac);
        //    paramSB.Append("&curc=" + cpu.Curc);
        //    paramSB.Append("&lng=" + GenerateMethod.getLng());
        //    paramSB.Append("&mac=" + mac);
        //    paramSB.Append("&bss=" + GenerateMethod.getBssid());
        //    paramSB.Append("&lac=" + GenerateMethod.getLac());
        //    paramSB.Append("&md=" + dev.Md);
        //    paramSB.Append("&minc=" + cpu.Minc);
        //    paramSB.Append("&sv=3.0.4");//广告版本？"3.0.4","3.0.5"
        //    paramSB.Append("&mnc=" + carr.Mnc);//跟运营商有关后两位“01、02、03”
        //    paramSB.Append("&mf=" + dev.Mf);//制造厂商
        //    paramSB.Append("&dpi=" + dev.Dpi);
        //    paramSB.Append("&pnam=" + game.Pnam);//游戏名
        //    paramSB.Append("&key=" + game.Key);//用户KEY
        //    paramSB.Append("&lat=" + GenerateMethod.getLat());//东经
        //    paramSB.Append("&op=" + carr.Op);//运营商
        //    paramSB.Append("&sr=" + dev.Sr);//屏幕尺寸
        //    paramSB.Append("&imei=" + GenerateMethod.getImei());
        //    paramSB.Append("&cpu=" + cpu.CpuName);
        //    paramSB.Append("&as=" + game.AsId);
        //    paramSB.Append("&pkg=" + game.Pkg);
        //    paramSB.Append("&did=" + GenerateMethod.getDid());
        //    paramSB.Append("&cid=" + GenerateMethod.getCid());
        //    paramSB.Append("&ct=" + GenerateMethod.getCt());
        //    paramSB.Append("&ppv=" + game.Ppv);
        //    paramSB.Append("&ch=");//暂时没有值
        //    paramSB.Append("&imsi=" + GenerateMethod.getImsi(carr));
        //    paramSB.Append("&ac=40#anchor");

        //    return paramSB.ToString();
        //}

        //private string getAdJson(String url)
        //{
        //    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
        //    myReq.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0; en-us; Xoom Build/HRI39) AppleWebKit/534.13 (KHTML, like Gecko) Version/4.0 Safari/534.13";
        //    myReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        //    myReq.KeepAlive = true;
        //    //myReq.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
        //    myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.8");
        //    HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();

        //    Stream receviceStream = result.GetResponseStream();
        //    StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
        //    string strHTML = readerOfStream.ReadToEnd();
        //    readerOfStream.Close();
        //    receviceStream.Close();
        //    result.Close();

        //    return strHTML;
        //}

        //protected void btnSetInterval_Click(object sender, EventArgs e)
        //{

        //}
        #endregion
    }
}