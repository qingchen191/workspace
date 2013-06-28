using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeC.WqMobile
{
    public class CPUModel
    {
        public CPUModel(string cpuName, int maxc, int minc, int curc)
        {
            CpuName = cpuName;
            Maxc = maxc;
            Minc = minc;
            Curc = curc;
        }



        private string cpuName;

        public string CpuName
        {
            get { return cpuName; }
            set { cpuName = value; }
        }
        private int maxc;

        public int Maxc
        {
            get { return maxc; }
            set { maxc = value; }
        }
        private int minc;

        public int Minc
        {
            get { return minc; }
            set { minc = value; }
        }
        private int curc;

        public int Curc
        {
            get { return curc; }
            set { curc = value; }
        }

    }
}