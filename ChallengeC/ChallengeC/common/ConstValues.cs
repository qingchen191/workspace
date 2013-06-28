using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ChallengeC.common
{
    public class ConstValues
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["MySqlStr"].ConnectionString;
    }
}