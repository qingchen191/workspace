using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;
using System.IO;

namespace ChallengeC.weixin
{
    /// <summary>
    /// ReplyApi 的摘要说明
    /// </summary>
    public class ReplyApi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Weixin _wx = new Weixin();

            string postStr = "";

            if (System.Web.HttpContext.Current.Request.HttpMethod.ToLower() == "post")
            {

                Stream s = System.Web.HttpContext.Current.Request.InputStream;

                byte[] b = new byte[s.Length];

                s.Read(b, 0, (int)s.Length);

                postStr = Encoding.UTF8.GetString(b);

                if (!string.IsNullOrEmpty(postStr)) //请求处理
                {

                    _wx.Handle(postStr);

                }

            }

            else
            {

                _wx.Auth();

            }


            //String token = "qingchen191";
            //String signature = context.Request.Params["signature"];
            //String timestamp = context.Request.Params["timestamp"];
            //String nonce = context.Request.Params["nonce"];
            //String echostr = context.Request.Params["echostr"];
            //String[] sigArray = new String[3];
            //sigArray[0] = timestamp;
            //sigArray[1] = nonce;
            //sigArray[2] = token;

            //Array.Sort(sigArray);
            //String output = "";
            //String text = sigArray[0] + sigArray[1] + sigArray[2];

            //if (isFromWeixin(text, signature))
            //{
            //    output = echostr;
            //}
            //else
            //{
            //    output = echostr;
            //}


            //context.Response.ContentType = "text/plain";
            //context.Response.Write(output);
        }

        private bool isFromWeixin(String sigArray, String signature)
        {
            String signed = FormsAuthentication.HashPasswordForStoringInConfigFile(sigArray, "SHA1");
            return signed.Equals(signature);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}