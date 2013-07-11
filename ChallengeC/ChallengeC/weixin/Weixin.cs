using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Security;

namespace ChallengeC.weixin
{
    public class Weixin
    {
        private string Token = "weixin_token"; //换成自己的token



        public void Auth()
        {

            string echoStr = System.Web.HttpContext.Current.Request.QueryString["echoStr"];

            if (CheckSignature())
            {

                if (!string.IsNullOrEmpty(echoStr))
                {

                    System.Web.HttpContext.Current.Response.Write(echoStr);

                    System.Web.HttpContext.Current.Response.End();

                }

            }

        }

        public void Handle(string postStr)
        {

            //封装请求类

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(postStr);

            XmlElement rootElement = doc.DocumentElement;

            XmlNode MsgType = rootElement.SelectSingleNode("MsgType");

            RequestXML requestXML = new RequestXML();

            requestXML.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;

            requestXML.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;

            requestXML.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;

            requestXML.MsgType = MsgType.InnerText;

            if (requestXML.MsgType == "text")
            {

                requestXML.Content = rootElement.SelectSingleNode("Content").InnerText;

            }

            else if (requestXML.MsgType == "location")
            {

                requestXML.Location_X = rootElement.SelectSingleNode("Location_X").InnerText;

                requestXML.Location_Y = rootElement.SelectSingleNode("Location_Y").InnerText;

                requestXML.Scale = rootElement.SelectSingleNode("Scale").InnerText;

                requestXML.Label = rootElement.SelectSingleNode("Label").InnerText;

            }

            else if (requestXML.MsgType == "image")
            {

                requestXML.PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText;

            }

            else if (requestXML.MsgType == "event")
            {

                requestXML.Event = rootElement.SelectSingleNode("Event").InnerText;
                requestXML.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;

            }

            //回复消息

            ResponseMsg(requestXML);

        }

        /// <summary>

        /// 验证微信签名

        /// </summary>

        /// * 将token、timestamp、nonce三个参数进行字典序排序

        /// * 将三个参数字符串拼接成一个字符串进行sha1加密

        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。

        /// <returns></returns>

        private bool CheckSignature()
        {

            string signature = System.Web.HttpContext.Current.Request.QueryString["signature"];

            string timestamp = System.Web.HttpContext.Current.Request.QueryString["timestamp"];

            string nonce = System.Web.HttpContext.Current.Request.QueryString["nonce"];

            string[] ArrTmp = { Token, timestamp, nonce };

            Array.Sort(ArrTmp);     //字典排序

            string tmpStr = string.Join("", ArrTmp);

            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");

            tmpStr = tmpStr.ToLower();

            if (tmpStr == signature)
            {

                return true;

            }

            else
            {

                return false;

            }

        }



        /// <summary>

        /// 回复消息(微信信息返回)

        /// </summary>

        /// <param name="weixinXML"></param>

        private void ResponseMsg(RequestXML requestXML)
        {

            try
            {

                string resxml = "";

                Mijiya mi = new Mijiya(requestXML.Content, requestXML.FromUserName);

                if (requestXML.MsgType == "text")
                {

                    //在这里执行一系列操作，从而实现自动回复内容. 

                    string _reMsg = mi.GetReMsg();

                    if (mi.msgType == 1)
                    {

                        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>2</ArticleCount><Articles>";

                        resxml += mi.GetRePic(requestXML.FromUserName);

                        resxml += "</Articles><FuncFlag>1</FuncFlag></xml>";

                    }

                    else
                    {

                        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + _reMsg + "]]></Content><FuncFlag>1</FuncFlag></xml>";

                    }

                }

                else if (requestXML.MsgType == "location")
                {

                    //string city = GetMapInfo(requestXML.Location_X, requestXML.Location_Y);
                    string city = "0";
                    if (city == "0")
                    {

                        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[好啦，我们知道您的位置啦。您可以:" + requestXML.Location_X + "|" + requestXML.Location_Y + "]]></Content><FuncFlag>1</FuncFlag></xml>";

                    }

                    else
                    {

                        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[好啦，我们知道您的位置啦。您可以:" + mi.GetDefault() + "]]></Content><FuncFlag>1</FuncFlag></xml>";

                    }

                }

                else if (requestXML.MsgType == "image")
                {

                    resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[亲,我没有看懂你的意思。您可以:" + mi.GetDefault() + requestXML.PicUrl + "]]></Content><FuncFlag>1</FuncFlag></xml>";

                    //返回10以内条

                    //int size = 10;

                    //resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + size + "</ArticleCount><Articles>";

                    //List<string> list = new List<string>();

                    ////假如有20条查询的返回结果

                    //for (int i = 0; i < 20; i++)

                    //{

                    //    list.Add("1");

                    //}

                    //string[] piclist = new string[] { "/Abstract_Pencil_Scribble_Background_Vector_main.jpg", "/balloon_tree.jpg", "/bloom.jpg", "/colorful_flowers.jpg", "/colorful_summer_flower.jpg", "/fall.jpg", "/fall_tree.jpg", "/growing_flowers.jpg", "/shoes_illustration.jpg", "/splashed_tree.jpg" };

                    //for (int i = 0; i < size && i < list.Count; i++)

                    //{

                    //    resxml += "<item><Title><![CDATA[沈阳-黑龙江]]></Title><Description><![CDATA[元旦特价：￥300 市场价：￥400]]></Description><PicUrl><![CDATA[" + "http://www.hougelou.com" + piclist[i] + "]]></PicUrl><Url><![CDATA[http://www.hougelou.com]]></Url></item>";

                    //}

                    //resxml += "</Articles><FuncFlag>1</FuncFlag></xml>";

                }

                //else if (wx_tmsg.GetMsgCount(requestXML.FromUserName) == 0)
                //{

                //    resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + mi.GetFirst() + "]]></Content><FuncFlag>1</FuncFlag></xml>";



                //}

                else if (requestXML.MsgType == "event")
                {

                    if (requestXML.Event == "subscribe")
                    {
                        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[您好，欢迎来到微微生活秀，我们会给你的生活带来不同的精彩。]]></Content><FuncFlag>1</FuncFlag></xml>";
                    }
                    else if (requestXML.Event == "unsubscribe")
                    {
                        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[感谢您对我们的关注，我们会更加努力，期待您的归来。]]></Content><FuncFlag>1</FuncFlag></xml>";
                    }

                }

                else
                {

                    resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[亲,我没有看懂你的意思。您可以:" + mi.GetDefault() + "]]></Content><FuncFlag>1</FuncFlag></xml>";



                }

                //WriteTxt(resxml);

                System.Web.HttpContext.Current.Response.Write(resxml);

                //WriteToDB(requestXML, resxml, mi.pid);

            }

            catch (Exception ex)
            {

                //WriteTxt("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());

                //wx_logs.MyInsert("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());

            }

        }



        /// <summary>

        /// unix时间转换为datetime

        /// </summary>

        /// <param name="timeStamp"></param>

        /// <returns></returns>

        private DateTime UnixTimeToTime(string timeStamp)
        {

            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            long lTime = long.Parse(timeStamp + "0000000");

            TimeSpan toNow = new TimeSpan(lTime);

            return dtStart.Add(toNow);

        }

        /// <summary>

        /// datetime转换为unixtime

        /// </summary>

        /// <param name="time"></param>

        /// <returns></returns>

        private int ConvertDateTimeInt(System.DateTime time)
        {

            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));

            return (int)(time - startTime).TotalSeconds;

        }
    }
}