using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MySql.Data.MySqlClient;
using ChallengeC.common;

namespace ChallengeC.WqMobile
{
    public class WqconfBll
    {
        public WqconfModel GetModelByName(string name)
        {
            string sql = "select * from wqconf where name=@name";
            MySqlParameter[] para = new MySqlParameter[] { new MySqlParameter("@name", name) };
            using (MySqlDataReader dr = MySqlHelper.ExecuteReader(ConstValues.connStr, sql, para))
            {
                if (dr.Read())
                {
                    return new WqconfModel(dr);
                }
            }
            return null;
        }

        public int GetTimerInterval()
        {
            return this.GetModelByName("timerinterval").intvalue;
        }

        public bool UpdateTimerInterval(int intvalue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE wqconf SET ");
            strSql.Append("intvalue = @intvalue ");
            strSql.Append("where name = 'timerinterval'");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@intvalue", intvalue) };
            return (MySqlHelper.ExecuteNonQuery(ConstValues.connStr, strSql.ToString(), cmdParms) == 1);
        }

    }
}