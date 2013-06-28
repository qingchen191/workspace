using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeC.WqMobile
{
    public class GameInfo
    {
        public GameInfo(string _pnam, string _key, string _asId, string _pkg, string _ppv,string _appid,string _asAdid)
        {
            Pnam = _pnam;
            Key = _key;
            AsId = _asId;
            Pkg = _pkg;
            Ppv = _ppv;
            Appid = _appid;
            AsAdid = _asAdid;
        }
        public GameInfo(WqgameModel gameModel)
        {
            Pnam = gameModel.name;
            Key = gameModel.key;
            AsId = gameModel.asid;
            Pkg = gameModel.pkg;
            Ppv = gameModel.ppv;
            Appid = gameModel.appid;
            AsAdid = gameModel.asadid;
        }

        private string pnam;
        private string key;
        private string asId;
        private string pkg;
        private string ppv;
        private string appid;
        private string asAdid;

        public string AsAdid
        {
            get { return asAdid; }
            set { asAdid = value; }
        }

        public string Appid
        {
            get { return appid; }
            set { appid = value; }
        }

        public string Ppv
        {
            get { return ppv; }
            set { ppv = value; }
        }

        public string Pkg
        {
            get { return pkg; }
            set { pkg = value; }
        }

        public string AsId
        {
            get { return asId; }
            set { asId = value; }
        }


        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Pnam
        {
            get { return pnam; }
            set { pnam = value; }
        }
    }
}