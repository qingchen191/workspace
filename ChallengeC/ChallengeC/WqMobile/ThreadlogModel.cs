using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Common;

namespace ChallengeC.WqMobile
{
    public class ThreadlogModel
    {
        public int idthreadlog { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public DateTime logtime { get; set; }
        public string user { get; set; }

        public ThreadlogModel()
        {

        }

        public ThreadlogModel(MySqlDataReader dr)
        {
            this.idthreadlog = PublicMethod.GetInt(dr["idthreadlog"]);
            this.type = PublicMethod.GetString(dr["type"]);
            this.content = PublicMethod.GetString(dr["content"]);
            this.logtime = PublicMethod.GetDateTime(dr["logtime"]);
            this.user = PublicMethod.GetString(dr["user"]);
        }
    }
}