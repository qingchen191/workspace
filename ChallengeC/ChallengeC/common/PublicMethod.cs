using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Common;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace Common
{
    public class PublicMethod
    {
        #region 分页获取

        /// <summary>
        /// 分页获取数据列表 适用于SQL2000
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="key">主键</param>
        /// <param name="where">查询条件</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="orderfield">排序字段</param>
        /// <param name="ordertype">排序方式 0=ASC 1=DESC</param>
        /// <param name="fieldlist">查找的字段</param>
        /// <param name="recordcount">总记录数</param>
        /// <returns></returns>
        //public static DataTable GetDataByPager2000(string fieldlist, string tablename, string where, string orderfield, string key, int pageindex, int pagesize, int ordertype, int recordcount)
        //{
        //    string cmd = "ProcCustomPage";
        //    SqlParameter[] para = new SqlParameter[9];
        //    para[0] = new SqlParameter("@Table_Name", tablename);
        //    para[1] = new SqlParameter("@Sign_Record", key);
        //    para[2] = new SqlParameter("@Filter_Condition", where);
        //    para[3] = new SqlParameter("@Page_Size", pagesize);
        //    para[4] = new SqlParameter("@Page_Index", pageindex);
        //    para[5] = new SqlParameter("@TaxisField", orderfield);
        //    para[6] = new SqlParameter("@Taxis_Sign", ordertype);
        //    para[7] = new SqlParameter("@Find_RecordList", fieldlist);
        //    para[8] = new SqlParameter("@Record_Count", recordcount);

        //    return SqlHelper.ExecuteDataset(SqlEasy.connString, CommandType.StoredProcedure, cmd, para).Tables[0];

        //}

        //public static DataTable GetDataByPager2000(string connString, string fieldlist, string tablename, string where, string orderfield, string key, int pageindex, int pagesize, int ordertype, int recordcount)
        //{
        //    string cmd = "ProcCustomPage";
        //    SqlParameter[] para = new SqlParameter[9];
        //    para[0] = new SqlParameter("@Table_Name", tablename);
        //    para[1] = new SqlParameter("@Sign_Record", key);
        //    para[2] = new SqlParameter("@Filter_Condition", where);
        //    para[3] = new SqlParameter("@Page_Size", pagesize);
        //    para[4] = new SqlParameter("@Page_Index", pageindex);
        //    para[5] = new SqlParameter("@TaxisField", orderfield);
        //    para[6] = new SqlParameter("@Taxis_Sign", ordertype);
        //    para[7] = new SqlParameter("@Find_RecordList", fieldlist);
        //    para[8] = new SqlParameter("@Record_Count", recordcount);

        //    return SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, cmd, para).Tables[0];

        //}


        /// <summary>
        /// 分页获取数据列表 适用于SQL2005
        /// </summary>
        /// <param name="SelectList">选取字段列表</param>
        /// <param name="tablename">数据源名称表名或视图名称</param>
        /// <param name="where">筛选条件</param>
        /// <param name="OrderExpression">排序 必须指定一个排序字段</param>
        /// <param name="pageindex">页索引 从0开始</param>
        /// <param name="pagesize">每页记录数</param>
        /// <returns></returns>
        //public static DataTable GetDataByPager2005(string SelectList, string tablename, string where, string OrderExpression, int pageindex, int pagesize)
        //{
        //    string cmd = "GetRecordFromPage";
        //    SqlParameter[] para = new SqlParameter[6];
        //    para[0] = new SqlParameter("@SelectList", SelectList);
        //    para[1] = new SqlParameter("@TableSource", tablename);
        //    para[2] = new SqlParameter("@SearchCondition", where);
        //    para[3] = new SqlParameter("@OrderExpression", OrderExpression);
        //    para[4] = new SqlParameter("@pageindex", pageindex);
        //    para[5] = new SqlParameter("@pagesize", pagesize);

        //    return SqlHelper.ExecuteDataset(SqlEasy.connString, cmd, para).Tables[0];
        //}
        #endregion

        #region 获取某表中的总记录数

        /// <summary>
        /// 获取某表中的总记录数
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        //public static int GetRecordCount(string tablename)
        //{
        //    string s = "select count(*) from {0}";
        //    s = string.Format(s, tablename);
        //    return Convert.ToInt32(SqlEasy.ExecuteScalar(s));
        //}

        //public static int GetRecordCount(string tablename, string where)
        //{
        //    string s = "select count(*) from {0} ";
        //    s = string.Format(s, tablename);
        //    if (!string.IsNullOrEmpty(where))
        //        s += " where " + where;
        //    return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlEasy.connString, CommandType.Text, s));
        //}

        //public static int GetRecordCount(string connString,string tablename, string where)
        //{
        //    string s = "select count(*) from {0} ";
        //    s = string.Format(s, tablename);
        //    if (!string.IsNullOrEmpty(where))
        //        s += " where " + where;
        //    return Convert.ToInt32(SqlHelper.ExecuteScalar(connString, CommandType.Text, s));
        //}


        #endregion

        #region 根据条件获取指定表中的数据

        /// <summary>
        /// 根据条件获取指定表中的数据
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        //public static DataTable GetDataTable(string tablename, string where)
        //{
        //    string s = "select * from " + tablename;
        //    if (where != "")
        //        s += " where " + where;

        //    return SqlHelper.ExecuteDataset(SqlEasy.connString, CommandType.Text, s).Tables[0];
        //}


        #endregion

        //#region 根据ID 获取一行数据

        ///// <summary>
        ///// 根据主键Id,获取一行数据
        ///// </summary>
        ///// <param name="tableName">表名</param>
        ///// <param name="keyName">主键名称</param>
        ///// <param name="value">值</param>
        ///// <param name="msg">返回信息</param>
        ///// <returns></returns>
        //public static DataRow GetADataRow(string tableName, string keyName, string value, out string msg)
        //{
        //    try
        //    {
        //        string s = "select * from @table where @keyname=@value";
        //        SqlParameter[] sp ={new SqlParameter("@table",tableName),
        //            new SqlParameter("@keyname",keyName),
        //            new SqlParameter("@value",value)
        //        };

        //        DataTable dt =SqlEasy.ExecuteDataTable(s,sp);

        //        if (dt.Rows.Count > 0)
        //        {
        //            msg = "OK";
        //            return dt.Rows[0];
        //        }
        //        else
        //        {
        //            msg = "";
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //        return null;
        //    }
        //}
        //#endregion

        #region 由Object取值
        /// <summary>
        /// 取得Int值,如果为Null 则返回０
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt(object obj)
        {
            if (obj != null)
            {
                int i;
                int.TryParse(obj.ToString(), out i);
                return i;
            }
            else
                return 0;
        }

        /// <summary>
        /// 取得Int值,如果不成功则返回指定exceptionvalue值
        /// </summary>
        /// <param name="obj">要计算的值</param>
        /// <param name="exceptionvalue">异常时的返回值</param>
        /// <returns></returns>
        public static int GetInt(object obj, int exceptionvalue)
        {            
            if (obj == null)
                return exceptionvalue;
            if (string.IsNullOrEmpty(obj.ToString()))
                return exceptionvalue;
            int i=exceptionvalue;
            try{i = Convert.ToInt32(obj);}
            catch{i = exceptionvalue;}
            return i;
        }

        /// <summary>
        /// 取得Decima值,如果不成功则返回指定exceptionvalue值
        /// </summary>
        /// <param name="obj">要计算的值</param>
        /// <param name="exceptionvalue">异常时的返回值</param>
        /// <returns></returns>
        public static decimal GetDecimal(object obj, int exceptionvalue)
        {
            if (obj == null)
                return exceptionvalue;
            if (string.IsNullOrEmpty(obj.ToString()))
                return exceptionvalue;
            decimal i = exceptionvalue;
            try { i = Convert.ToDecimal(obj); }
            catch { i = exceptionvalue; }
            return i;
        }

        /// <summary>
        /// 取得byte值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte Getbyte(object obj)
        {
            if (obj.ToString() != "")
                return byte.Parse(obj.ToString());
            else
                return 0;
        }

        /// <summary>
        /// 获得Long值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long GetLong(object obj)
        {
            if (obj.ToString() != "")
                return long.Parse(obj.ToString());
            else
                return 0;
        }

        /// <summary>
        /// 取得Long值,如果不成功则返回指定exceptionvalue值
        /// </summary>
        /// <param name="obj">要计算的值</param>
        /// <param name="exceptionvalue">异常时的返回值</param>
        /// <returns></returns>
        public static long GetLong(object obj, long exceptionvalue)
        {
            if (obj == null)
                return exceptionvalue;
            if (string.IsNullOrEmpty(obj.ToString()))
                return exceptionvalue;
            long i = exceptionvalue;
            try { i = Convert.ToInt64(obj); }
            catch { i = exceptionvalue; }
            return i;
        }

        /// <summary>
        /// 取得Decimal值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal GetDecimal(object obj)
        {
            if (obj.ToString() != "")
                return decimal.Parse(obj.ToString());
            else
                return 0;
        }

        /// <summary>
        /// 取得Guid值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid GetGuid(object obj)
        {
            if (obj.ToString() != "")
                return new Guid(obj.ToString());
            else
                return Guid.Empty;
        }

        /// <summary>
        /// 取得DateTime值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(object obj)
        {
            if (obj.ToString() != "")
                return DateTime.Parse(obj.ToString());
            else
                return DateTime.MinValue;
        }

        /// <summary>
        /// 取得bool值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetBool(object obj)
        {
            if (obj != null)
            {
                bool flag;
                bool.TryParse(obj.ToString(), out flag);
                return flag;
            }
            else
                return false;
        }

        /// <summary>
        /// 取得byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Byte[] GetByte(object obj)
        {
            if (obj.ToString() != "")
            {
                return (Byte[])obj;
            }
            else
                return null;
        }

        /// <summary>
        /// 取得string值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(object obj)
        {
            if (obj != null && obj != DBNull.Value)
                return obj.ToString();
            else
                return "";
        }
        #endregion

        #region  增加Sql参数
        /// <summary>
        /// 增加sql参数并返回
        /// </summary>
        /// <param name="arguments">参数列表(格式:@name,@sex,@email......)</param>
        /// <param name="param">参数对应值</param>
        /// <returns></returns>
        public static SqlParameter[] AddSqlParameters(string arguments,params object[] param)
        {
            string[] args = arguments.Split(',');
            if (args.Length == 0)
                throw new ArgumentNullException("arguments","参数个数为空!");
            if(args.Length!=param.Length)
                throw new ArgumentNullException("arguments", "参数个数与赋值参数个数不相等!");
            SqlParameter[] para = new SqlParameter[args.Length];
            for (int i = 0; i < para.Length; i++)
            {
                para[i] = new SqlParameter(args[i],param[i]);
            }
            return para;
        }

        /// <summary>
        /// 增加赋值sql参数并返回
        /// </summary>
        /// <param name="sqls">sql赋值可变对象</param>
        /// <param name="arguments">参数列表(格式:@name,@sex,@email......)</param>
        /// <param name="param">参数对应值</param>
        /// <returns></returns>
        public static List<SqlParameter> AddSqlParameters(ref StringBuilder sqls,string arguments, params object[] param)
        {
            string[] args = arguments.Split(',');
            if (args.Length == 0)
                throw new ArgumentNullException("arguments", "参数个数为空!");
            if (args.Length != param.Length)
                throw new ArgumentNullException("arguments", "参数个数与赋值参数个数不相等!");
            List<SqlParameter> para = new List<SqlParameter>();
            for (int i = 0; i < args.Length; i++)
            {
                if (param[i] == null)
                    continue;
                if (param[i] is int && GetInt(param[i], -1) == -1)
                    continue;
                if (param[i] is string && string.IsNullOrEmpty(param[i].ToString()))
                    continue;
                if (param[i] is DateTime && GetDateTime(param[i]).Date == DateTime.MinValue.Date)
                    continue;
                sqls.Append(string.Format("[{0}]={1},", args[i].TrimStart('@'),args[i]));
                para.Add(new SqlParameter(args[i], param[i]));
            }
            return para;
        }

        /// <summary>
        /// 赋值时给指定泛型及可变串追加指定字段及指定Int值
        /// </summary>
        /// <param name="para">sql参数泛型</param>
        /// <param name="sqls">sql可变字段</param>
        /// <param name="field">字段名称</param>
        /// <param name="fieldvalue">字段值</param>
        public static void AddSetIntSqlParameter(List<SqlParameter> para, StringBuilder sqls, string field, int fieldvalue)
        {
            if (PublicMethod.GetInt(fieldvalue, -1) > -1)
            {
                sqls.Append(string.Format("[{0}]=@{0},",field));
                para.Add(new SqlParameter(string.Format("@{0}",field), fieldvalue));
            }
        }

        /// <summary>
        /// 赋值时给指定泛型及可变串追加指定字段及指定String值
        /// </summary>
        /// <param name="para">sql参数泛型</param>
        /// <param name="sqls">sql可变字段</param>
        /// <param name="field">字段名称</param>
        /// <param name="fieldvalue">字段值</param>
        public static void AddSetStringSqlParameter(List<SqlParameter> para, StringBuilder sqls, string field, string fieldvalue)
        {
            if (!string.IsNullOrEmpty(fieldvalue))
            {
                sqls.Append(string.Format("[{0}]=@{0},", field));
                para.Add(new SqlParameter(string.Format("@{0}", field), fieldvalue));
            }
        }

        /// <summary>
        /// 赋值时给指定泛型及可变串追加指定字段及指定日期String值
        /// </summary>
        /// <param name="para">sql参数泛型</param>
        /// <param name="sqls">sql可变字段</param>
        /// <param name="field">字段名称</param>
        /// <param name="fieldvalue">字段值</param>
        public static void AddSetDateSqlParameter(List<SqlParameter> para, StringBuilder sqls, string field, DateTime fieldvalue)
        {
            if (!string.IsNullOrEmpty(fieldvalue.ToString()))
            {
                if (PublicMethod.GetDateTime(fieldvalue) != DateTime.MinValue)
                {
                    sqls.Append(string.Format("[{0}]=@{0},", field));
                    para.Add(new SqlParameter(string.Format("@{0}", field), fieldvalue));
                }
            }
        }

        /// <summary>
        /// 指定条件时给指定泛型及可变串追加指定字段及指定Int值
        /// </summary>
        /// <param name="para">sql参数泛型</param>
        /// <param name="sqls">sql可变字段</param>
        /// <param name="field">字段名称</param>
        /// <param name="fieldvalue">字段值</param>
        public static void AddWhereIntSqlParameter(List<SqlParameter> para, StringBuilder sqls, string field, int fieldvalue)
        {
            if (PublicMethod.GetInt(fieldvalue, -1) > -1)
            {
                sqls.Append(string.Format("[{0}]=@{0} and ", field));
                para.Add(new SqlParameter(string.Format("@{0}", field), fieldvalue));
            }
        }

        /// <summary>
        /// 指定条件时给指定泛型及可变串追加指定字段及指定String值
        /// </summary>
        /// <param name="para">sql参数泛型</param>
        /// <param name="sqls">sql可变字段</param>
        /// <param name="field">字段名称</param>
        /// <param name="fieldvalue">字段值</param>
        public static void AddWhereStringSqlParameter(List<SqlParameter> para, StringBuilder sqls, string field, string fieldvalue)
        {
            if (!string.IsNullOrEmpty(fieldvalue))
            {
                sqls.Append(string.Format("[{0}]=@{0} and ", field));
                para.Add(new SqlParameter(string.Format("@{0}", field), fieldvalue));
            }
        }
        #endregion

        #region 分页存储过程

        #region  sql 2000 分页存储过程
        /*
     * 
     * CREATE  PROCEDURE [dbo].[ProcCustomPage]
		(
		    @Table_Name               varchar(5000),      	    --表名
		    @Sign_Record              varchar(50),       		--主键
		    @Filter_Condition         varchar(1000),     	    --筛选条件,不带where
		    @Page_Size                int,               		--页大小
		    @Page_Index               int,          			--页索引     			
	        @TaxisField               varchar(1000),            --排序字段
		    @Taxis_Sign               int,               		--排序方式 1为 DESC, 0为 ASC
            @Find_RecordList          varchar(1000),        	--查找的字段
		    @Record_Count             int                		--总记录数
		 )
		 AS
			BEGIN 
			DECLARE  @Start_Number          int
			DECLARE  @End_Number            int
			DECLARE  @TopN_Number           int
		 DECLARE  @sSQL                  varchar(8000)
                 if(@Find_RecordList='')
                 BEGIN
                      SELECT @Find_RecordList='*'
                 END
		 SELECT @Start_Number =(@Page_Index-1) * @Page_Size
			IF @Start_Number<=0
		 SElECT @Start_Number=0
			SELECT @End_Number=@Start_Number+@Page_Size
			IF @End_Number>@Record_Count
		 SELECT @End_Number=@Record_Count
		 SELECT @TopN_Number=@End_Number-@Start_Number
		 IF @TopN_Number<=0
		 SELECT @TopN_Number=0
			print @TopN_Number
		 print @Start_Number
		 print @End_Number
		 print @Record_Count
                 IF @TaxisField=''
                 begin
                    select  @TaxisField=@Sign_Record
                 end
		 IF @Taxis_Sign=0
		  	BEGIN
		 		IF @Filter_Condition=''
				 BEGIN
		 			SELECT @sSQL='SELECT '+@Find_RecordList+' FROM '+@Table_Name+' 
		     			WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@TopN_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		    			 WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@End_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		    		 ORDER BY '+@TaxisField+') order by '+@TaxisField+' DESC)order by '+@TaxisField
		 		END
				ELSE
				BEGIN
				SELECT @sSQL='SELECT '+@Find_RecordList+' FROM '+@Table_Name+' 
		     WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@TopN_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		     WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@End_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		     WHERE '+@Filter_Condition+' ORDER BY '+@TaxisField+') and '+@Filter_Condition+' order by '+@TaxisField+' DESC) and '+@Filter_Condition+' order by '+@TaxisField
				 END
			END
		ELSE
			BEGIN
			IF @Filter_Condition=''
				BEGIN
					SELECT @sSQL='SELECT '+@Find_RecordList+' FROM '+@Table_Name+' 
		         WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@TopN_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		         WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@End_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		         ORDER BY '+@TaxisField+' DESC) order by '+@TaxisField+')order by '+@TaxisField+' DESC'
		     END
			ELSE
			BEGIN
				SELECT @sSQL='SELECT '+@Find_RecordList+' FROM '+@Table_Name+' 
		     WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@TopN_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		     WHERE '+@Sign_Record+' in (SELECT TOP '+CAST(@End_Number AS VARCHAR(10))+' '+@Sign_Record+' FROM '+@Table_Name+' 
		     WHERE '+@Filter_Condition+' ORDER BY '+@TaxisField+' DESC) and '+@Filter_Condition+' order by '+@TaxisField+') and '+@Filter_Condition+' order by '+@TaxisField+' DESC'
		 END
			END
			EXEC (@sSQL)
			IF @@ERROR<>0
			RETURN -3              
		 RETURN 0
		 END
		 
		 PRINT  @sSQL
        GO

     * */


        #endregion

        #region SQL2005 分页存储过程
        /*
     * 
   CREATE PROCEDURE [dbo].[GetRecordFromPage] 
    @SelectList            VARCHAR(2000),    --欲选择字段列表
    @TableSource        VARCHAR(100),    --表名或视图表 
    @SearchCondition    VARCHAR(2000),    --查询条件
    @OrderExpression    VARCHAR(1000),    --排序表达式
    @PageIndex            INT = 1,        --页号,从0开始
    @PageSize            INT = 10        --页尺寸
AS 
BEGIN
    IF @SelectList IS NULL OR LTRIM(RTRIM(@SelectList)) = ''
    BEGIN
        SET @SelectList = '*'
    END
    PRINT @SelectList
    
    SET @SearchCondition = ISNULL(@SearchCondition,'')
    SET @SearchCondition = LTRIM(RTRIM(@SearchCondition))
    IF @SearchCondition <> ''
    BEGIN
        IF UPPER(SUBSTRING(@SearchCondition,1,5)) <> 'WHERE'
        BEGIN
            SET @SearchCondition = 'WHERE ' + @SearchCondition
        END
    END
    PRINT @SearchCondition

    SET @OrderExpression = ISNULL(@OrderExpression,'')
    SET @OrderExpression = LTRIM(RTRIM(@OrderExpression))
    IF @OrderExpression <> ''
    BEGIN
        IF UPPER(SUBSTRING(@OrderExpression,1,5)) <> 'WHERE'
        BEGIN
            SET @OrderExpression = 'ORDER BY ' + @OrderExpression
        END
    END
    PRINT @OrderExpression

    IF @PageIndex IS NULL OR @PageIndex < 1
    BEGIN
        SET @PageIndex = 1
    END
    PRINT @PageIndex
    IF @PageSize IS NULL OR @PageSize < 1
    BEGIN
        SET @PageSize = 10
    END
    PRINT  @PageSize

    DECLARE @SqlQuery VARCHAR(4000)

    SET @SqlQuery='SELECT '+@SelectList+',RowNumber 
    FROM 
        (SELECT ' + @SelectList + ',ROW_NUMBER() OVER( '+ @OrderExpression +') AS RowNumber 
          FROM '+@TableSource+' '+ @SearchCondition +') AS RowNumberTableSource 
    WHERE RowNumber BETWEEN ' + CAST(((@PageIndex - 1)* @PageSize+1) AS VARCHAR) 
    + ' AND ' + 
    CAST((@PageIndex * @PageSize) AS VARCHAR) 
--    ORDER BY ' + @OrderExpression
    PRINT @SqlQuery
    SET NOCOUNT ON
    EXECUTE(@SqlQuery)
    SET NOCOUNT OFF
 
    RETURN @@RowCount
END
     **/

        #endregion

        #endregion

        #region 获取指定表中指定字段的最大值
        /// <summary>
        /// 获取指定表中指定字段的最大值
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="field">字段</param>
        /// <returns>Return Type:Int</returns>
        //public static int GetMaxID(string tableName, string field)
        //{
        //    string s = "select Max(@field) from @tablename";
        //    SqlParameter[] para = { new SqlParameter("@field",field),new SqlParameter("@tablename",tableName)};
        //    object obj = SqlHelper.ExecuteScalar(SqlEasy.connString, CommandType.Text, s,para);
        //    int i = Convert.ToInt32(obj == DBNull.Value ? "0" : obj);
        //    return i;
        //}
        #endregion

        #region 获取客户端IP地址

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }


            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }

        #endregion

        #region 获取页中 列表选中的项
        /// <summary>
        /// 获取页中 列表选中的项
        /// </summary>
        /// <param name="chklist">CheckBoxList ID</param>
        /// <returns></returns>
        public static List<string> GetCheckedItemList(CheckBoxList chklist)
        {
            List<string> list = new List<string>();
            foreach (ListItem li in chklist.Items)
            {
                if (li.Selected)
                    list.Add(li.Value);
            }
            return list;
        }


        #endregion

        #region 根据IP地址在纯直IP库中查询地址
        /// <summary>
        /// 根据IP地址在纯直IP库中查询地址
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns></returns>
        //public static string GetIPaddr(string ip,string ipdbpath)
        //{
        //    IpLocation ipl = IpLocator.GetIpLocation(ipdbpath, ip);
        //    string geography = ipl.Country + " " + ipl.City; //地理位置
        //    return geography;
        //}

        #endregion

        #region DataTable To List

        ///// <summary>
        ///// DataTable To List
        ///// </summary>
        ///// <typeparam name="TType">object type</typeparam>
        ///// <param name="dt">DataTable</param>
        ///// <returns></returns>
        //public static List<TType> DataTableToObjectList<TType>(DataTable dt) where TType : new()
        //{
        //    System.Data.DataColumnCollection columns = dt.Columns;
        //    int iColumnCount = columns.Count;
        //    int i;
        //    int j;
        //    TType ttype = new TType();
        //    Type elementType;
        //    elementType = ttype.GetType();
        //    System.Reflection.PropertyInfo[] publicProperties = elementType.GetProperties();
        //    List<TType> result = new List<TType>();
        //    //if (publicProperties.Length == iColumnCount)
        //    //{
        //        foreach (DataRow currentRow in dt.Rows)
        //        {
        //            for (i = 0; i < iColumnCount; i++)
        //            {
        //                for (j = 0; j < publicProperties.Length; j++)
        //                {
        //                    if (columns[i].ColumnName.ToLower() == publicProperties[j].Name.ToLower())
        //                    {
        //                        object obj = currentRow[i];
        //                        if (string.IsNullOrEmpty(obj.ToString()))
        //                        {
        //                            if (publicProperties[j].PropertyType == typeof(int))
        //                                obj = -1;
        //                            obj = "";
        //                        }
        //                        publicProperties[j].SetValue(ttype, obj, null);
        //                    }
        //                }
        //            }
        //            result.Add(ttype);
        //            ttype = new TType();
        //        }
        //    //}
        //    //else
        //    //{
        //    //    result = null;
        //    //}
        //    return result;
        //}

        /// <summary>
        /// DataTable To List
        /// </summary>
        /// <typeparam name="TType">object type</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<T> DataTableToObjectList<T>(DataTable dt) where T : new()
        {
            DataColumnCollection columns = dt.Columns;
            int columncount = columns.Count;            
            List<T> result = new List<T>();    //声明一个要返回的对象泛型
            Type type = typeof(T);
            PropertyInfo[] propertys = type.GetProperties(BindingFlags.IgnoreCase|BindingFlags.Instance|BindingFlags.Public|BindingFlags.SetProperty);   //获取参数对象属性集合
            foreach (DataRow r in dt.Rows)
            {
                T t = new T();
                for (int i = 0; i < propertys.Length; i++)
                {
                    DataColumn column = columns[propertys[i].Name];
                    if (column != null && r[column] != null)
                    {
                        if (propertys[i].PropertyType == typeof(int))
                            propertys[i].SetValue(t, PublicMethod.GetInt(r[column]), null);
                        if (propertys[i].PropertyType == typeof(string))
                            propertys[i].SetValue(t, r[column].ToString(), null);
                        if (propertys[i].PropertyType == typeof(DateTime))
                            propertys[i].SetValue(t, PublicMethod.GetDateTime(r[column]), null);
                    }
                }
                result.Add(t);                
            }            
            return result;
        }
        #endregion

        /// <summary>
        /// 获取指定字符串中的指定字符的个数
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="value">要查找的字符串</param>
        /// <returns></returns>
        public static int GetCharLength(string source,string value)
        {            
            Regex reg = new Regex(value);
            return reg.Matches(source).Count;
        }

        /// <summary>
        /// 给指定字符串前面增加指定值
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="value">要增加的字符串</param>
        /// <returns></returns>
        public static string CharBeforeAppend(string source, string value)
        {
            return source.Insert(0, value);
        }

        /// <summary>
        /// 给指定字符串前面增加指定个数的指定值
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="value">要增加的字符串</param>
        /// <param name="length">要增加的个数</param>
        /// <returns></returns>
        public static string CharBeforeAppend(string source, string value, int length)
        {
            for (int i = 0; i < length; i++)
            {
                source = source.Insert(0, value);
            }
            return source;
        }

        /// <summary>
        /// 合并指定表并返回
        /// </summary>
        /// <param name="dt">原始表</param>
        /// <param name="DataTables">可变表参</param>
        /// <returns></returns>
        public static DataTable MergeDataTable(DataTable dt,params DataTable[] DataTables)
        {
            if (DataTables.Length == 0)
                return dt;            
            foreach (DataTable table in DataTables)
                dt.Merge(table);
            return dt;
        }
    }
}
