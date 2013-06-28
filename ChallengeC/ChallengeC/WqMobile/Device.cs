using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeC.WqMobile
{
    public class Device
    {
        public Device(string _md, string _mf, string _dpi, string _sr)
        {
            Md = _md;
            Mf = _mf;
            Dpi = _dpi;
            Sr = _sr;

        }
        private string md;
        private string mf;
        private string dpi;
        private string sr;

        public string Sr
        {
            get { return sr; }
            set { sr = value; }
        }

        public string Dpi
        {
            get { return dpi; }
            set { dpi = value; }
        }

        public string Mf
        {
            get { return mf; }
            set { mf = value; }
        }


        public string Md
        {
            get { return md; }
            set { md = value; }
        }

    }
}