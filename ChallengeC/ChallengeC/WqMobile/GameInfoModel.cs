using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Common;

namespace ChallengeC.WqMobile
{
    public class GameInfoModel
    {
        public string game { get; set; }
        public int viewcnt { get; set; }
        public int clickcnt { get; set; }
        public decimal amount { get; set; }


        public GameInfoModel(MySqlDataReader dr)
        {
            this.game = PublicMethod.GetString(dr["game"]);
            this.viewcnt = PublicMethod.GetInt(dr["viewcnt"]);
            this.clickcnt = PublicMethod.GetInt(dr["clickcnt"]);
            this.amount = PublicMethod.GetDecimal(dr["amount"]);
        }
    }
}