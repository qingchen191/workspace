using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using ChallengeC.Model;
using MySql.Data.MySqlClient;
using System.Configuration;
using ChallengeC.Bll;

namespace ChallengeC.ajax
{
    /// <summary>
    /// Login1 的摘要说明
    /// </summary>
    public class Login1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string username = context.Request.Params.Get("username");
            string password = context.Request.Params.Get("password");
            string rtnStr = "";

            UserBll userBll = new UserBll();
            UserModel user = userBll.GetModelByName(username);
            if (user.password.Equals(password))
            {
                rtnStr = "ok";
            }
            else
            {
                rtnStr = "用户名或者密码错误。";
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"resStatus\":\"" + rtnStr + "\"}");  
            context.Response.Flush();
            context.Response.End();

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