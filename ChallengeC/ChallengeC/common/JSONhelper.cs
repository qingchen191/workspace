using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.IO;
using System.Reflection;

namespace Common
{
    public class JSONhelper
    {
        public static string IListToJSON<T>(IList<T> list, string ClassName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"" + ClassName + "\":[");
            foreach (T t in list)
            {
                sb.Append(ModelToJSON(t) + ",");
            }

            string _temp = sb.ToString().TrimEnd(',');
            _temp += "]}";
            return _temp;
        }

        /// <summary>
        /// 将指定串值转换JSON格式
        /// </summary>
        /// <param name="name">Key值</param>
        /// <param name="value">value值</param>
        /// <returns></returns>
        public static string StringToJson(string name, string value)
        {
            return "{\"" + name + ":\"" + value + "\"}";
        }

        /// <summary>
        /// 将指定串值转换JSON格式
        /// </summary>
        /// <param name="name">Key值</param>
        /// <param name="value">value值</param>
        /// <returns></returns>
        public static string StringToJson(string name, int value)
        {
            return "{\"" + name + "\":" + value.ToString() + "}";
        }

        /// <summary>
        /// 将数组转换为JSON格式的字符串
        /// </summary>
        /// <typeparam name="T">数据类型，如string,int ...</typeparam>
        /// <param name="list">泛型list</param>
        /// <param name="propertyname">JSON的类名</param>
        /// <returns></returns>
        public static string ArrayToJSON<T>(List<T> list, string propertyname)
        {
            StringBuilder sb = new StringBuilder();
            if (list.Count > 0)
            {
                sb.Append("[{\"");
                sb.Append(propertyname);
                sb.Append("\":[");

                foreach (T t in list)
                {
                    sb.Append("\"");
                    sb.Append(t.ToString());
                    sb.Append("\",");
                }

                string _temp = sb.ToString();
                _temp = _temp.TrimEnd(',');

                _temp += "]}]";

                return _temp;
            }
            else
                return "";
        }

        public static string DataTableToJSON(DataTable dt, string dtName)
        {
            string s = DataTableToJSONJquery(dt);
            s = "{\"" + dtName + "\":" + s + "}";
            return s;
        }

        public static string DataTableToJSONJquery(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("{");
                    for (int n = 0; n < dt.Columns.Count; n++)
                    {
                        sb.AppendFormat("\"{0}\":\"{1}\",", dt.Columns[n].ColumnName.ToLower(), dt.Rows[i][n].ToString().Replace("\"", "“").Replace("'", "‘").Replace("\r", "\\r").Replace("\n", "\\n").Replace("<", "＜").Replace(">", "＞"));
                    }
                    sb.Remove(sb.Length - 1,1);
                    sb.Append("},");
                }
                sb.Remove(sb.Length - 1, 1).Insert(0,"[").Append("]");
                return sb.ToString();
            }
            return "";           
        }

        public static string RowToJSON(DataRow row)
        {
            StringBuilder sb = new StringBuilder();
            if (row == null)
                return "";
            sb.Append("{");
            for (int n = 0; n < row.Table.Columns.Count; n++)
            {
                sb.AppendFormat("\"{0}\":\"{1}\",", row.Table.Columns[n].ColumnName.ToLower(), row[n].ToString().Replace("\"", "“").Replace("'", "‘").Replace("\r", "\\r").Replace("\n", "\\n").Replace("<", "＜").Replace(">", "＞"));
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");
            return sb.ToString();
        }

        //public static string RowToJSON(DataRow dr)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    StringWriter sw = new StringWriter(sb);
        //    JsonSerializer ser = new JsonSerializer();
        //    using (JsonWriter jw = new JsonWriter(sw))
        //    {
        //        jw.WriteStartObject();
        //        foreach (DataColumn dc in dr.Table.Columns)
        //        {
        //            jw.WritePropertyName(dc.ColumnName);
        //            if (dr[dc] != null && dr[dc] != DBNull.Value && dr[dc].ToString() != "")
        //                ser.Serialize(jw, dr[dc]);
        //            else
        //                ser.Serialize(jw, "");
        //        }
        //        jw.WriteEndObject();
        //        jw.Close();
        //        sw.Close();
        //    }
        //    return sb.ToString();
        //}

        public static string ArrayToJSON(string[] strs)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Length; i++)
            {
                sb.AppendFormat("'{0}':'{1}',", i + 1, strs[i]);
            }
            if (sb.Length > 0)
                return "{" + sb.ToString().TrimEnd(',') + "}";
            return "";
        }

        /// <summary>
        /// 将字符串数组转为JSON串
        /// </summary>
        /// <param name="strs">数组</param>
        /// <param name="v">数组key值</param>
        /// <param name="t">数组值</param>
        /// <returns></returns>
        public static string ItemsToJSON(string[] strs,string v,string t)
        {
            return DataTableToJSONJquery(ControlHelper.ItemsToTable(strs, v, t));
        }

        public static string ArrayToJSON(string[] strs, string var)
        {
            return var+"="+ArrayToJSON(strs);
        }

        public static string ModelToJSON<T>(T t)
        {
            StringBuilder sb = new StringBuilder();
            string json = "";
            if (t != null)
            {
                sb.Append("{");
                PropertyInfo[] properties  = t.GetType().GetProperties();
                foreach (PropertyInfo pi in properties)
                {
                    sb.Append("\"" + pi.Name.ToString().ToLower() + "\"");
                    sb.Append(":");
                    sb.Append("\"" + pi.GetValue(t, null).ToString().Replace("\"", "“").Replace("'", "‘").Replace("\r", "\\r").Replace("\n", "\\n").Replace("<", "＜").Replace(">", "＞") + "\"");
                    sb.Append(",");
                }

                json = sb.ToString().TrimEnd(',');
                json += "}";
            }

            return json;
        }
    }
}
