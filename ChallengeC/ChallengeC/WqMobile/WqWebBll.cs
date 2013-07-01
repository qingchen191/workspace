using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using ChallengeC.common;
using System.Text;

namespace ChallengeC.WqMobile
{
    public class WqWebBll
    {


        public List<GameInfoModel> GetGamesInfo(string date, string gamename)
        {
            List<GameInfoModel> gameList = new List<GameInfoModel>();
            StringBuilder sqlsb = new StringBuilder();
            sqlsb.Append("select v.game,v.cnt viewcnt,c.cnt clickcnt,c.amount from ");
            sqlsb.Append("(select game,count(*) cnt from wqtab where type = 'view' and date_format(addtime,'%Y-%m-%d') = @sdate group by game) v, ");
            sqlsb.Append("(select game,count(*) cnt,count(*)*0.3 amount from wqtab where type = 'click' and date_format(addtime,'%Y-%m-%d') = @sdate group by game) c, ");
            sqlsb.Append("wqgames g ");
            sqlsb.Append("where v.game = c.game and c.game = g.name ");
            if (!String.IsNullOrEmpty(gamename))
            {
                sqlsb.Append(" and g.chnname = @gamename;");
            }


            MySqlParameter[] para = new MySqlParameter[] { new MySqlParameter("@sdate", date), new MySqlParameter("@gamename", gamename) };
            using (MySqlDataReader dr = MySqlHelper.ExecuteReader(ConstValues.connStr, sqlsb.ToString(), para))
            {
                while (dr.Read())
                {
                    gameList.Add(new GameInfoModel(dr));
                }
            }
            return gameList;
        }


    }
}