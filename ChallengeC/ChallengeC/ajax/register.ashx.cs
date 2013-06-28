using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChallengeC.Bll;
using ChallengeC.Model;
using Common;

namespace ChallengeC.ajax
{
    /// <summary>
    /// register 的摘要说明
    /// </summary>
    public class register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string rtnStr = "";

            try
            {
                rtnStr = saveUser(context);
            }
            catch (Exception ex)
            {
                rtnStr = ex.Message;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"resStatus\":\"" + rtnStr + "\"}");
            context.Response.Flush();
            context.Response.End();
        }

        private string saveUser(HttpContext context)
        {
            string username = context.Request.Params.Get("username");
            string password = context.Request.Params.Get("password");
            string email = context.Request.Params.Get("email");
            string tel = context.Request.Params.Get("mobile");
            if (StringHelper.IsEmpty(username))
            {
                throw new Exception("用户名不能为空。");
            }

            if (StringHelper.IsEmpty(password))
            {
                throw new Exception("密码不能为空。");
            }

            if (StringHelper.IsEmpty(email))
            {
                throw new Exception("邮箱地址不能为空。");
            }

            if (StringHelper.IsEmpty(tel))
            {
                throw new Exception("手机号不能为空。");
            }

            UserModel user = new UserModel();
            user.username = username;
            user.email = email;
            user.tel = tel;
            user.password = password;

            UserBll userBll = new UserBll();
            if (userBll.SaveUser(user))
            {
                return "ok";
            }
            else
            {
                throw new Exception("数据库异常，新用户保存失败。");
            }
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