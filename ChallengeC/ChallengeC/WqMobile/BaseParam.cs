using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ChallengeC.WqMobile
{
    public class BaseParam
    {
        public BaseParam(string _appid, string _asStr, string _adid, string _appWqId, string _mac)
        {
            Appid = _appid;
            AsStr = _asStr;
            Mac = _mac;
            Adid = _adid;
            Sid = _appWqId + GenerateMethod.sha1Mac(Mac) + "99";
            Ip = GenerateMethod.getIP();
            R = "kdp4lTf6s";
        }

        public String toViewParam()
        {
            StringBuilder param = new StringBuilder();
            param.Append("appid=" + Appid);
            param.Append("&as=" + AsStr);
            param.Append("&mac=" + Mac);
            param.Append("&adid=99");
            param.Append("&sid=" + Sid);
            param.Append("&ip=" + Ip);
            param.Append("&r=kdp4lTf6s");
            param.Append("&type=view");

            return param.ToString();
        }

        public String toClickParam()
        {
            StringBuilder param = new StringBuilder();
            param.Append("appid=" + Appid);
            param.Append("&as=" + AsStr);
            param.Append("&adid=" + Adid);
            param.Append("&mac=" + Mac);
            param.Append("&sid=" + Sid);
            param.Append("&ip=" + Ip);
            param.Append("&type=click");

            return param.ToString();
        }



        private string appid;
        private string asStr;
        private string mac;
        private string adid;
        private string sid;
        private string ip;
        private string r;

        public string R
        {
            get { return r; }
            set { r = value; }
        }

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        public string Sid
        {
            get { return sid; }
            set { sid = value; }
        }


        public string Adid
        {
            get { return adid; }
            set { adid = value; }
        }

        public string Mac
        {
            get { return mac; }
            set { mac = value; }
        }

        public string AsStr
        {
            get { return asStr; }
            set { asStr = value; }
        }

        public string Appid
        {
            get { return appid; }
            set { appid = value; }
        }

    }
}