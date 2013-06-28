using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Common;

namespace ChallengeC.WqMobile
{
    public class WqgameModel
    {
        public int game_id { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string asid { get; set; }
        public string pkg { get; set; }
        public string ppv { get; set; }
        public string appid { get; set; }
        public string asadid { get; set; }
        public string user_name { get; set; }


        public WqgameModel(MySqlDataReader dr)
        {
            this.game_id = PublicMethod.GetInt(dr["game_id"]);
            this.name = PublicMethod.GetString(dr["name"]);
            this.key = PublicMethod.GetString(dr["key"]);
            this.asid = PublicMethod.GetString(dr["asid"]);
            this.pkg = PublicMethod.GetString(dr["pkg"]);
            this.ppv = PublicMethod.GetString(dr["ppv"]);
            this.appid = PublicMethod.GetString(dr["appid"]);
            this.asadid = PublicMethod.GetString(dr["asadid"]);
            this.user_name = PublicMethod.GetString(dr["user_name"]);
        }
    }
}