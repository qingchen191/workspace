using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using ChallengeC.common;

namespace ChallengeC.WqMobile
{
    public class WqgameBll
    {
        public WqgameModel GetModelByName(string name)
        {
            string sql = "select * from wqgames where name=@name";
            MySqlParameter[] para = new MySqlParameter[] { new MySqlParameter("@name", name) };
            using (MySqlDataReader dr = MySqlHelper.ExecuteReader(ConstValues.connStr, sql, para))
            {
                if (dr.Read())
                {
                    return new WqgameModel(dr);
                }
            }
            return null;
        }

        public List<WqgameModel> GetModelByUserName(string username)
        {
            List<WqgameModel> gameList = new List<WqgameModel>();
            string sql = "select * from wqgames where user_name=@username";
            MySqlParameter[] para = new MySqlParameter[] { new MySqlParameter("@username", username) };
            using (MySqlDataReader dr = MySqlHelper.ExecuteReader(ConstValues.connStr, sql, para))
            {
                while (dr.Read())
                {
                    gameList.Add(new WqgameModel(dr));
                }
            }
            return gameList;
        }
        
        public List<WqgameModel> GetAllGames()
        {
            List<WqgameModel> gameList = new List<WqgameModel>();
            string sql = "select * from wqgames";
            using (MySqlDataReader dr = MySqlHelper.ExecuteReader(ConstValues.connStr, sql, null))
            {
                while (dr.Read())
                {
                    gameList.Add(new WqgameModel(dr));
                }
            }
            return gameList;
        }
    }
}