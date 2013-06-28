using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeC.WqMobile
{
    public class AdsJsonModel
    {
        public string status { get; set; }
        public string test_mode { get; set; }
        public List<AdModel> ads { get; set; }
        public List<Beacon> beacons { get; set; }
    }


    public class AdModel{

        public string headline { get; set; }
        public string body { get; set; }
        public string download_url { get; set; }
        public string icon_url { get; set; }
        public float size { get; set; }
        public string recommend_type { get; set; }
        public string cost { get; set; }
        public string type { get; set; }
        public List<Beacon> beacons { get; set; }


    }

    public class Beacon
    {
        public string type { get; set; }
        public string url { get; set; }

    }
}