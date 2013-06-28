using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Common;

namespace ChallengeC.WqMobile
{
    public class WqtabModel
    {
        public DateTime addtime { get; set; }
        public string game { get; set; }
        public int idwqtab { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string url { get; set; }

        public WqtabModel(MySqlDataReader dr)
        {
            this.idwqtab = PublicMethod.GetInt(dr["idwqtab"]);
            this.type = PublicMethod.GetString(dr["type"]);
            this.url = PublicMethod.GetString(dr["url"]);
            this.status = PublicMethod.GetString(dr["status"]);
            this.addtime = PublicMethod.GetDateTime(dr["addtime"]);
            this.game = PublicMethod.GetString(dr["game"]);
        }

        public WqtabModel()
        {
        }

    }
}