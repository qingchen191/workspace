using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MySql.Data.MySqlClient;
using ChallengeC.common;

namespace ChallengeC.WqMobile
{
    public class WqtabBll
    {

        public bool SaveWq(WqtabModel wq)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO wqtab(");
            strSql.Append("idwqtab,type,url,status,addtime,game)");
            strSql.Append(" VALUES (");
            strSql.Append("@idwqtab,@type,@url,@status,@addtime,@game)");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@idwqtab", wq.idwqtab), new MySqlParameter("@type", wq.type), new MySqlParameter("@url", wq.url), new MySqlParameter("@status", wq.status), new MySqlParameter("@addtime", wq.addtime), new MySqlParameter("@game", wq.game) };
            return (MySqlHelper.ExecuteNonQuery(ConstValues.connStr, strSql.ToString(), cmdParms) == 1);
        }

    }
}