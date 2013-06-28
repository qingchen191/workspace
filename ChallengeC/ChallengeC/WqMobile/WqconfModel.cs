using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Common;

namespace ChallengeC.WqMobile
{
    public class WqconfModel
    {
        public DateTime datevalue { get; set; }
        public int idwqconf { get; set; }
        public int intvalue { get; set; }
        public string name { get; set; }
        public string strvalue { get; set; }

        public WqconfModel(MySqlDataReader dr)
        {
            this.idwqconf = PublicMethod.GetInt(dr["idwqconf"]);
            this.name = PublicMethod.GetString(dr["name"]);
            this.intvalue = PublicMethod.GetInt(dr["intvalue"]);
            this.strvalue = PublicMethod.GetString(dr["strvalue"]);
            this.datevalue = PublicMethod.GetDateTime(dr["datevalue"]);
        }


    }
}