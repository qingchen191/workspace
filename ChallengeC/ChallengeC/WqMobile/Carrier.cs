using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeC.WqMobile
{
    public class Carrier
    {
        
        public Carrier()
        {
            Mcc = "460";

            Random random = new Random();
            int no = random.Next(Constant.carriers.Length);
            Mnc = Constant.carriers[no];
            if (Mnc.Equals("00") || Mnc.Equals("02") || Mnc.Equals("07"))
            {
                Op = "CM";
            }
            else if (Mnc.Equals("01") || Mnc.Equals("06"))
            {
                Op = "CU";
            }
            else if (Mnc.Equals("03") || Mnc.Equals("05"))
            {
                Op = "CT";
            }
            else if (Mnc.Equals("20"))
            {
                Op = "CTT";
            }
            else
            {
                Op = "CU";
            }

        }

        private string op;
        private string mcc;
        private string mnc;

        public string Mnc
        {
            get { return mnc; }
            set { mnc = value; }
        }


        public string Mcc
        {
            get { return mcc; }
            set { mcc = value; }
        }

        public string Op
        {
            get { return op; }
            set { op = value; }
        }
    }
}