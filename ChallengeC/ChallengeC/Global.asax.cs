using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ChallengeC.WqMobile;
using System.Net;
using System.IO;
using System.Timers;

namespace ChallengeC
{
    public class Global : System.Web.HttpApplication
    {
        private Timer timer3D;

        protected void Application_Start(object sender, EventArgs e)
        {
            UtilMethod.SaveLog("appStart", "Application start.");
            
            if (this.timer3D == null)
            {
                this.timer3D = new Timer(80 * 1000); // 间隔80秒
            }
            this.timer3D.Elapsed += new ElapsedEventHandler(this.timer3D_Elapsed);
            this.timer3D.AutoReset = true;
            this.timer3D.Enabled = true;
            this.timer3D.Start();

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            UtilMethod.SaveLog("appEnd", "Application end.");

            if (this.timer3D != null)
            {
                this.timer3D.Enabled = false;
                this.timer3D.Stop();
                this.timer3D.Close();
            }
            UtilMethod.RefreshApp();
        }

        public void timer3D_Elapsed(object source, ElapsedEventArgs e)
        {
            UtilMethod.DealGame("%C4%90ua Phi Thuy%E1%BB%81n 3D");
        }


    }
}