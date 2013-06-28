using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Compression;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Common
{
    public class StringHelper
    {
        public static Boolean IsEmpty(string str)
        {
            if (str == null || str.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 删除HTML标记
        /// <summary>
        /// 删除HTML标记
        /// </summary>
        /// <param name="htmlString">带有样式的字符串</param>
        /// <returns></returns>
        public static string RemoveHtmlFormat(string htmlString)
        {
            return Regex.Replace(htmlString, "<[^>]+>", "");
        }
        #endregion

        #region 截断字符串
        /// <summary>
        /// 截断字符串
        /// </summary>
        /// <param name="str">要截断的字符串</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string CutString(string str, int length)
        {
            int i = 0, j = 0;
            foreach (char chr in str)
            {
                i += 2;
                if (i > length)
                {
                    str = str.Substring(0, j - 1) + "...";
                    break;
                }
                j++;
            }
            return str;
        }
        #endregion

        #region 生成唯一ID 由数字组成

        /// <summary>
        /// 生成唯一ID
        /// </summary>
        /// <returns></returns>
        public static string CreateIDCode()
        {
            DateTime Time1 = DateTime.Now.ToUniversalTime();
            DateTime Time2 = Convert.ToDateTime("1970-01-01");
            TimeSpan span = Time1 - Time2;   //span就是两个日期之间的差额   
            string t = span.TotalMilliseconds.ToString("0");

            return t;
        }
        #endregion

        #region 压缩与解压字符串

        #region 压缩字符串
        /// <summary>
        /// 压缩字符串
        /// </summary>
        /// <param name="unCompressedString">要压缩的字符串</param>
        /// <returns></returns>
        public static string ZipString(string unCompressedString)
        {

            byte[] bytData = System.Text.Encoding.UTF8.GetBytes(unCompressedString);
            MemoryStream ms = new MemoryStream();
            Stream s = new GZipStream(ms, CompressionMode.Compress);
            s.Write(bytData, 0, bytData.Length);
            s.Close();
            byte[] compressedData = (byte[])ms.ToArray();
            return System.Convert.ToBase64String(compressedData, 0, compressedData.Length);
        }

        #endregion

        #region 解压字符串
        /// <summary>
        ///  解压字符串
        /// </summary>
        /// <param name="unCompressedString">要解压的字符串</param>
        /// <returns></returns>
        public static string UnzipString(string unCompressedString)
        {
            System.Text.StringBuilder uncompressedString = new System.Text.StringBuilder();
            byte[] writeData = new byte[4096];

            byte[] bytData = System.Convert.FromBase64String(unCompressedString);
            int totalLength = 0;
            int size = 0;

            Stream s = new GZipStream(new MemoryStream(bytData), CompressionMode.Decompress);
            while (true)
            {
                size = s.Read(writeData, 0, writeData.Length);
                if (size > 0)
                {
                    totalLength += size;
                    uncompressedString.Append(System.Text.Encoding.UTF8.GetString(writeData, 0, size));
                }
                else
                {
                    break;
                }
            }
            s.Close();
            return uncompressedString.ToString();
        }

        #endregion

        #endregion

        #region 转全角的函数(SBC case)
        /// 
        /// 转全角的函数(SBC case)
        /// 
        /// 任意字符串
        /// 全角字符串
        ///
        ///全角空格为12288，半角空格为32///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///        
        public string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        #endregion

        #region 转半角的函数(DBC case)
        /// 
        /// 转半角的函数(DBC case)
        /// 
        /// 任意字符串
        /// 半角字符串
        ///
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///
        public string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        #region Html 编码

        /// <summary>
        /// 对文本框中的字符进行HTML编码
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns></returns>
        public static string HtmlEncode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        }

        /// <summary>
        /// 对字符串进行HTML解码,解析为可为页面识别的代码
        /// </summary>
        /// <param name="str">要解码的字符串</param>
        /// <returns></returns>
        public static string HtmlDecode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }

        #endregion

        #region  用户名过滤
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool Filter(string userName)
        {
            if (IsExist(userName,"!")) return false;
            if (IsExist(userName, "！")) return false;
            if (IsExist(userName, "#")) return false;
            if (IsExist(userName, "&")) return false;
            if (IsExist(userName, "$")) return false;
            if (IsExist(userName, "*")) return false;
            if (IsExist(userName, ".")) return false;
            if (IsExist(userName, ",")) return false;
            if (IsExist(userName, ";")) return false;
            if (IsExist(userName, "'")) return false;
            if (IsExist(userName, "<")) return false;
            if (IsExist(userName, ">")) return false;
            return true;
        }

        public static bool IsExist(string userName, string filterStr)
        {
            if (userName.IndexOf(filterStr) > -1)
                return true;
            return false;
        }
        #endregion

        #region SQL注入过滤
        /// <summary>
        ///SQL注入过滤
        /// </summary>
        /// <param name="InText">要进行过滤的字符串</param>
        /// <returns>如果参数存在不安全字符,则返回true</returns>
        public static bool SqlFilter2(string InText)
        {
            string word = "exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join";
            if (InText == null)
                return false;
            foreach (string i in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 将指定的str串执行sql关键字过滤并返回
        /// </summary>
        /// <param name="str">要过滤的字符串</param>
        /// <returns></returns>
        public static string SqlFilter(string str)
        {
            return str.Replace("'", "").Replace("&#39;", "").Replace("--", "").Replace("&","").Replace("/*","").Replace(";","").Replace("%","");
        }

        /// <summary>
        /// 将指定的串列表执行sql关键字过滤并以[,]号分隔返回
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string SqlFilters(params string[] strs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in strs)
            {
                sb.Append(SqlFilter(str) + ",");
            }
            if (sb.Length > 0)
                return sb.ToString().TrimEnd(',');
            return "";
        }

        public static bool ProcessSqlStr(string Str)
        {
            bool ReturnValue = false;
            try
            {
                if (Str != "")
                {
                    string SqlStr = "insert|select*|and'|or'|insertinto|deletefrom|altertable|update|createtable|createview|dropview|createindex|dropindex|createprocedure|dropprocedure|createtrigger|droptrigger|createschema|dropschema|createdomain|alterdomain|dropdomain|);|select@|declare@|print@|char(|select";
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.IndexOf(ss) >= 0)
                        {
                            ReturnValue = true;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = true;
            }

            return ReturnValue;
        }
        #endregion

        #region 获取CheckBoxList控件中选中的项
        /// <summary>
        /// 获取CheckBoxList控件中选中的项的value，字符串由,分隔
        /// </summary>
        /// <param name="chk">CheckBoxList 控件ID</param>
        /// <returns></returns>
        public static string GetCheckedItemValue(CheckBoxList chk)
        {
            string s = "";
            foreach (ListItem li in chk.Items)
            {
                if (li.Selected)
                    s += li.Value + ",";
            }
            return s.TrimEnd(',');
        }
        /// <summary>
        /// 获取CheckBoxList控件中选中的项的Text，字符串由,分隔
        /// </summary>
        /// <param name="chk">CheckBoxList 控件ID</param>
        /// <returns></returns>
        public static string GetCheckedItemText(CheckBoxList chk)
        {
            string s = "";
            foreach (ListItem li in chk.Items)
            {
                if (li.Selected)
                    s += li.Text + ",";
            }
            return s.TrimEnd(',');
        }
        #endregion

        #region 根据提供的Id字符串，将列表中的项选中
        /// <summary>
        /// 根据提供的Id字符串，将列表中的项选中
        /// </summary>
        /// <param name="itemid">Id字符串，由,分隔</param>
        /// <param name="checkboxlist">CheckBoxList控件</param>
        public static void CheckItem(string itemid, CheckBoxList checkboxlist)
        {
            foreach (ListItem li in checkboxlist.Items)
            {
                if (itemid.IndexOf(li.Value) != -1)
                    li.Selected = true;
            }
        }

        #endregion

        #region 加密字符串 MD5
        #region 利用 MD5 加密算法加密字符串
        /// <summary>
        /// 利用 MD5 加密算法加密字符串
        /// </summary>
        /// <param name="src">字符串源串</param>
        /// <returns>返加MD5 加密后的字符串</returns>
        public static string ComputeMD5(string src)
        {
            //将密码字符串转化成字节数组
            byte[] byteArray = GetByteArray(src);

            //计算 MD5 密码
            byteArray = (new MD5CryptoServiceProvider().ComputeHash(byteArray));

            //将字节码转化成字符串并返回
            return BitConverter.ToString(byteArray);
        }

        /// <summary>
        /// 将指定串加密为不包含中杠的MD5值
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <param name="isupper">返回值的大小写(true大写,false小写)</param>
        /// <returns></returns>
        public static string ComputeMD5(string str, bool isupper)
        {
            string md5str = ComputeMD5(str);
            if (isupper)
                return md5str.ToUpper().Replace("-", "");
            return md5str.ToLower().Replace("-", "");
        }
        #endregion

        #region 将字符串翻译成字节数组
        /// <summary>
        /// 将字符串翻译成字节数组
        /// </summary>
        /// <param name="src">字符串源串</param>
        /// <returns>字节数组</returns>
        private static byte[] GetByteArray(string src)
        {
            byte[] byteArray = new byte[src.Length];

            for (int i = 0; i < src.Length; i++)
            {
                byteArray[i] = Convert.ToByte(src[i]);
            }

            return byteArray;
        }
        #endregion

        #region MD5string

        public static string MD5string(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        public static string MD5string(string str,bool isupper)
        {
            string md5string = MD5string(str);
            if (isupper)
                return md5string.ToUpper();
            else
                return md5string.ToLower();
        }

        #endregion
        #endregion

        #region DES加密字符串
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString,string key)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key);
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
        #endregion

        #region DES解密字符串
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="key">解密密钥，要求8位</param>
        /// <returns></returns>
        public static string DecryptDES(string decryptString,string key)
        {
            try
            {
                //默认密钥向量
                byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] rgbKey = Encoding.UTF8.GetBytes(key);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        #endregion

        #region 转换为中文星期
        /// <summary>
        /// 转换为中文星期
        /// </summary>
        /// <param name="dayfweek">英文星期</param>
        /// <returns></returns>
        public static string ConvertWeekDayToCn(DayOfWeek dayfweek)
        {
            switch (dayfweek)
            {
                case DayOfWeek.Sunday:
                    return "星期日";
                case DayOfWeek.Monday:
                    return "星期一";
                case DayOfWeek.Tuesday:
                    return "星期二";
                case DayOfWeek.Wednesday:
                    return "星期三";
                case DayOfWeek.Thursday:
                    return "星期四";
                case DayOfWeek.Friday:
                    return "星期五";
                case DayOfWeek.Saturday:
                    return "星期六";
                default:
                    return "";
            }
        }

        #endregion

        #region 执行CMD 命令
        /// <summary>
        /// 执行CMD 命令
        /// </summary>
        /// <param name="strCommand">命令串</param>
        /// <returns></returns>
        public static string RunCommand(string strCommand)
        {
            Process process = new Process();
            process.StartInfo.FileName = "CMD.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.StandardInput.WriteLine(strCommand);
            process.StandardInput.WriteLine("exit");
            string str = process.StandardOutput.ReadToEnd();
            process.Close();
            return str;
        }
        #endregion

        public static string ToUbb(string str)
        {
            str = HtmlEncode(str);
            str = new Regex("(javascript)", RegexOptions.IgnoreCase).Replace(str, "&#106avascript");
            str = new Regex("(jscript:)", RegexOptions.IgnoreCase).Replace(str, "&#106script:");
            str = new Regex("(js:)", RegexOptions.IgnoreCase).Replace(str, "&#106s:");
            str = new Regex("(value)", RegexOptions.IgnoreCase).Replace(str, "&#118alue");
            str = new Regex("(about:)", RegexOptions.IgnoreCase).Replace(str, "about&#58");
            str = new Regex("(file:)", RegexOptions.IgnoreCase).Replace(str, "file&#58");
            str = new Regex("(document.cookie)", RegexOptions.IgnoreCase).Replace(str, "documents&#46cookie");
            str = new Regex("(vbscript:)", RegexOptions.IgnoreCase).Replace(str, "&#118bscript:");
            str = new Regex("(vbs:)", RegexOptions.IgnoreCase).Replace(str, "&#118bs:");
            str = new Regex("(on(mouse|exit|error|click|key))", RegexOptions.IgnoreCase).Replace(str, "&#111n$2");
            str = new Regex(@"(\[IMG\])(.[^\[]*)(\[\/IMG\])", RegexOptions.IgnoreCase).Replace(str, "<a   href=\"$2\"   target=_blank><IMG   SRC=\"$2\"   border=0   alt=按此在新窗口浏览图片   onload=\"javascript:if(this.width>screen.width-333)this.width=screen.width-333\"></a>");
            str = new Regex(@"\[DIR=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/DIR]", RegexOptions.IgnoreCase).Replace(str, "<embed src=$3 width=$1 height=$2 autoplay=true loop=false controller=true playeveryframe=false cache=false scale=TOFIT bgcolor=#000000 kioskmode=false targetcache=false pluginspage=http://www.apple.com/quicktime/>");
            str = new Regex(@"\[QT=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/QT]", RegexOptions.IgnoreCase).Replace(str, "<object align=middle classid=CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95 class=OBJECT id=MediaPlayer width=$1 height=$2 ><param name=ShowStatusBar value=-1><param name=Filename value=$3><embed type=application/x-oleobject codebase=http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701 flename=mp src=$3 width=$1 height=$2></embed></object>");
            str = new Regex(@"\[RM=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/RM]", RegexOptions.IgnoreCase).Replace(str, "<OBJECT classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width=$1 height=$2><PARAM NAME=SRC VALUE=$3><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=-1></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=60 id=video2 width=$1><PARAM NAME=SRC VALUE=$3><PARAM NAME=_ExtentX VALUE=10054><PARAM NAME=_ExtentY VALUE=1588><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS value=ControlPanel,StatusBar><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>");
            str = new Regex(@"(\[FLASH\])(.[^\[]*)(\[\/FLASH\])", RegexOptions.IgnoreCase).Replace(str, "<IMG SRC=Images/File/swf.gif border=0><A TARGET=_blank HREF=$2>[全屏欣赏该FLASH]</A>");
            str = new Regex(@"(\[FLASH\])(.[^\[]*)(\[\/FLASH\])", RegexOptions.IgnoreCase).Replace(str, "<IMG SRC=Images/File/swf.gif border=0><a href=$4 TARGET=_blank>[全屏欣赏FLASH]</a><br><OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=4,0,2,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000><PARAM NAME=movie VALUE=$2><PARAM NAME=quality VALUE=high><embed src=$2 quality=high pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash'>$2</embed></OBJECT>");
            str = new Regex(@"(\[FLASH=*([0-9]*),*([0-9]*)\])(.[^\[]*)(\[\/FLASH\])", RegexOptions.IgnoreCase).Replace(str, "<IMG SRC=Images/File/swf.gif border=0><a href=$4 TARGET=_blank>[全屏欣赏FLASH]</a><br><OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=4,0,2,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 width=$2 height=$3><PARAM NAME=movie VALUE=$4><PARAM NAME=quality VALUE=high><embed src=$4 quality=high pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width=$2 height=$3>$4</embed></OBJECT>");
            str = new Regex(@"(\[SOUND\])(.[^\[]*)(\[\/SOUND\])", RegexOptions.IgnoreCase).Replace(str, "<IMG SRC=Images/File/mid.gif border=0><a href=$2 target=_blank>[附背景音乐]</a><bgsound src=$2 loop='-1'>");
            str = new Regex(@"(\[ZIP\])(.[^\[]*)(\[\/ZIP\])", RegexOptions.IgnoreCase).Replace(str, "<br><IMG   SRC=pic/zip.gif   border=0>   <a   href=\"$2\">点击下载该文件</a>");
            str = new Regex(@"(\[RAR\])(.[^\[]*)(\[\/RAR\])", RegexOptions.IgnoreCase).Replace(str, "<br><IMG   SRC=pic/rar.gif   border=0>   <a   href=\"$2\">点击下载该文件</a>");
            str = new Regex(@"(\[UPLOAD=(.[^\[]*)\])(.[^\[]*)   (\[\/UPLOAD\])", RegexOptions.IgnoreCase).Replace(str, "<br><IMG   SRC=\"pic/$2.gif\"   border=0>此主题相关图片如下：<br><A     HREF=\"$3\"   TARGET=_blank><IMG   SRC=\"$3\"   border=0   alt=按此在新窗口浏览图片  onload=\"javascript:if(this.width>screen.width-333)this.width=screen.width-333\"></A>");
            str = new Regex(@"(\[URL\])(http:\/\/.[^\[]*)(\[\/URL\])", RegexOptions.IgnoreCase).Replace(str, "<A   HREF=\"$2\"   TARGET=_blank>$2</A>");
            str = new Regex(@"(\[URL\])(.[^\[]*)(\[\/URL\])", RegexOptions.IgnoreCase).Replace(str, "<A   HREF=\"http://$2\"   TARGET=_blank>$2</A>");
            str = new Regex(@"(\[URL=(http:\/\/.[^\[]*)\])(.[^\[]*)    (\[\/URL\])", RegexOptions.IgnoreCase).Replace(str, "<A   HREF=\"$2\"   TARGET=_blank>$3</A>");
            str = new Regex(@"(\[URL=(.[^\[]*)\])(.[^\[]*)(\[\/URL\])", RegexOptions.IgnoreCase).Replace(str, "<A   HREF=\"http://$2\"   TARGET=_blank>$3</A>");
            str = new Regex(@"(\[EMAIL\])(\S+\@.[^\[]*)(\[\/EMAIL\])", RegexOptions.IgnoreCase).Replace(str, "<A HREF=mailto:$2>$2</A>");
            str = new Regex(@"(\[EMAIL=(\S+\@.[^\[]*)\])(.[^\[]*)(\[\/EMAIL\])", RegexOptions.IgnoreCase).Replace(str, "<A target=_blank HREF=mailto:$2>$3</A>");
            str = new Regex(@"^(HTTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex(@"(HTTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)$", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex("[^>=\"](HTTP://[A-Za-z0-9\\./=\\?%\\-&_~`@':+!]   +)", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex(@"^(FTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex(@"(FTP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)$", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex("[^>=\"](FTP://[A-Za-z0-9\\.\\/=\\?%\\-&_~`@':+!]  +)", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex(@"^(RTSP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex(@"(RTSP://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)$", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex("[^>=\"](RTSP://[A-Za-z0-9\\.\\/=\\?%\\-&_~`@':+!]+)", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex(@"^(MMS://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex(@"(MMS://[A-Za-z0-9\./=\?%\-&_~`@':+!]+)$", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex("[^>=\"](MMS://[A-Za-z0-9\\.\\/=\\?%\\-&_~`@':+!]+)", RegexOptions.IgnoreCase).Replace(str, "<a   target=_blank   href=$1>$1</a>");
            str = new Regex(@"(\[HTML\])(.[^\[]*)(\[\/HTML\])", RegexOptions.IgnoreCase).Replace(str, "<table   width='100%'   border='0'   cellspacing='0'   cellpadding='6' bgcolor=''><td><b>以下内容为程序代码:</b><br>$2</td></table>");
            str = new Regex(@"(\[CODE\])(.[^\[]*)(\[\/CODE\])", RegexOptions.IgnoreCase).Replace(str, "<table   width='100%'   border='0'   cellspacing='0'   cellpadding='6' bgcolor=''><td><b>以下内容为程序代码:</b><br>$2</td></table>");
            str = new Regex(@"(\[COLOR=(.[^\[]*)\])(.[^\[]*)(\[\/COLOR\])", RegexOptions.IgnoreCase).Replace(str, "<font   COLOR=$2>$3</font>");
            str = new Regex(@"(\[face=(.[^\[]*)\])(.[^\[]*)(\[\/face\])", RegexOptions.IgnoreCase).Replace(str, "<font   FACE=$2>$3</font>");
            str = new Regex(@"(\[ALIGN=(.[^\[]*)\])(.*)(\[\/ALIGN\])", RegexOptions.IgnoreCase).Replace(str, "<div   ALIGN=$2>$3</div>");
            str = new Regex(@"(\[QUOTE\])(.*)(\[\/QUOTE\])", RegexOptions.IgnoreCase).Replace(str, "引用:<br><table   width=100%   border=0   cellspacing=1   cellpadding=1   class=tableborder3><tr><td   bgcolor=#F3F3F3><table   width=100%   border=0   cellspacing=2   cellpadding=2><tr><td>$2</td></tr></table></td></tr></table>");
            str = new Regex(@"(\[MOVE\])(.*)(\[\/MOVE\])", RegexOptions.IgnoreCase).Replace(str, "<MARQUEE   scrollamount=3>$2</marquee>");
            str = new Regex(@"\[GLOW=*([0-9]*),*(#*[a-z0-9]*),*([0-9]*)\](.[^\[]*)\[\/GLOW]", RegexOptions.IgnoreCase).Replace(str, "<table   width=$1   style=\"filter:glow(color=$2,strength=$3)\">$4</table>");
            str = new Regex(@"\[SHADOW=*([0-9]*),*(#*[a-z0-9]*),*([0-9]*)\](.[^\[]*)\[\/SHADOW]", RegexOptions.IgnoreCase).Replace(str, "<table   width=$1   style=\"filter:shadow(color=$2,strength=$3)\">$4</table>");
            str = new Regex(@"(\[I\])(.[^\[]*)(\[\/I\])", RegexOptions.IgnoreCase).Replace(str, "<i>$2</i>");
            str = new Regex(@"(\[U\])(.[^\[]*)(\[\/U\])", RegexOptions.IgnoreCase).Replace(str, "<u>$2</u>");
            str = new Regex(@"(\[B\])(.[^\[]*)(\[\/B\])", RegexOptions.IgnoreCase).Replace(str, "<b>$2</b>");
            str = new Regex(@"(\[FLY\])(.[^\[]*)(\[\/FLY\])", RegexOptions.IgnoreCase).Replace(str, "<marquee>$2</marquee>");
            str = new Regex(@"(\[SIZE=1\])(.[^\[]*)(\[\/SIZE\])", RegexOptions.IgnoreCase).Replace(str, "<font   size=1>$2</font>");
            str = new Regex(@"(\[SIZE=2\])(.[^\[]*)(\[\/SIZE\])", RegexOptions.IgnoreCase).Replace(str, "<font   size=2>$2</font>");
            str = new Regex(@"(\[SIZE=3\])(.[^\[]*)(\[\/SIZE\])", RegexOptions.IgnoreCase).Replace(str, "<font   size=3>$2</font>");
            str = new Regex(@"(\[SIZE=4\])(.[^\[]*)(\[\/SIZE\])", RegexOptions.IgnoreCase).Replace(str, "<font   size=4>$2</font>");
            str = new Regex(@"(\[CENTER\])(.[^\[]*)(\[\/CENTER\])", RegexOptions.IgnoreCase).Replace(str, "<center>$2</center>");
            str = new Regex(@"(\[em)(.[^\[]*)(\])", RegexOptions.IgnoreCase).Replace(str, "<img   src=img/emot/em$2.gif   border=0>");
            return str;
        }

        public static string UBBToHTML(string sDetail)
        {
            Match match;
            sDetail = sDetail.Replace(" ", "&nbsp;");
            sDetail = sDetail.Replace("<", "&lt;");
            sDetail = sDetail.Replace(">", "&gt;");
            Regex regex = new Regex(@"(\[b\])([ \S\t]*?)(\[\/b\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<B>" + match.Groups[2].ToString() + "</B>");
            }
            regex = new Regex(@"(\[i\])([ \S\t]*?)(\[\/i\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<I>" + match.Groups[2].ToString() + "</I>");
            }
            regex = new Regex(@"(\[U\])([ \S\t]*?)(\[\/U\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<U>" + match.Groups[2].ToString() + "</U>");
            }
            regex = new Regex(@"((\r\n)*\[p\])(.*?)((\r\n)*\[\/p\])", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<P class=\"pstyle\">" + match.Groups[3].ToString() + "</P>");
            }
            regex = new Regex(@"(\[sup\])([ \S\t]*?)(\[\/sup\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<SUP>" + match.Groups[2].ToString() + "</SUP>");
            }
            regex = new Regex(@"(\[sub\])([ \S\t]*?)(\[\/sub\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<SUB>" + match.Groups[2].ToString() + "</SUB>");
            }
            regex = new Regex(@"(\[url\])([ \S\t]*?)(\[\/url\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<A href=\"" + match.Groups[2].ToString() + "\" target=\"_blank\"><IMG border=0 src=\"images/url.gif\">" + match.Groups[2].ToString() + "</A>");
            }
            regex = new Regex(@"(\[url=([ \S\t]+)\])([ \S\t]*?)(\[\/url\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<A href=\"" + match.Groups[2].ToString() + "\" target=\"_blank\"><IMG border=0 src=\"images/url.gif\">" + match.Groups[3].ToString() + "</A>");
            }
            regex = new Regex(@"(\[email\])([ \S\t]*?)(\[\/email\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<A href=\"mailto:" + match.Groups[2].ToString() + "\" target=\"_blank\"><IMG border=0 src=\"images/email.gif\">" + match.Groups[2].ToString() + "</A>");
            }
            regex = new Regex(@"(\[email=([ \S\t]+)\])([ \S\t]*?)(\[\/email\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<A href=\"mailto:" + match.Groups[2].ToString() + "\" target=\"_blank\"><IMG border=0 src=\"images/email.gif\">" + match.Groups[3].ToString() + "</A>");
            }
            regex = new Regex(@"(\[size=([1-7])\])([ \S\t]*?)(\[\/size\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<FONT SIZE=" + match.Groups[2].ToString() + ">" + match.Groups[3].ToString() + "</FONT>");
            }
            regex = new Regex(@"(\[color=([\S]+)\])([ \S\t]*?)(\[\/color\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<FONT COLOR=" + match.Groups[2].ToString() + ">" + match.Groups[3].ToString() + "</FONT>");
            }
            regex = new Regex(@"(\[font=([\S]+)\])([ \S\t]*?)(\[\/font\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<FONT FACE=" + match.Groups[2].ToString() + ">" + match.Groups[3].ToString() + "</FONT>");
            }
            regex = new Regex(@"\[picture\](\d+?)\[\/picture\]", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<A href=\"ShowImage.aspx?Type=ALL&Action=forumImage&ImageID=" + match.Groups[1].ToString() + "\" target=\"_blank\"><IMG border=0 Title=\"点击打开新窗口查看\" src=\"ShowImage.aspx?Action=forumImage&ImageID=" + match.Groups[1].ToString() + "\"></A>");
            }
            regex = new Regex(@"(\[align=([\S]+)\])([ \S\t]*?)(\[\/align\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<P align=" + match.Groups[2].ToString() + ">" + match.Groups[3].ToString() + "</P>");
            }
            regex = new Regex(@"(\[H=([1-6])\])([ \S\t]*?)(\[\/H\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<H" + match.Groups[2].ToString() + ">" + match.Groups[3].ToString() + "</H" + match.Groups[2].ToString() + ">");
            }
            regex = new Regex(@"(\[list(=(A|a|I|i| ))?\]([ \S\t]*)\r\n)((\[\*\]([ \S\t]*\r\n))*?)(\[\/list\])", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                string input = match.Groups[5].ToString();
                Regex regex2 = new Regex(@"\[\*\]([ \S\t]*\r\n?)", RegexOptions.IgnoreCase);
                for (Match match2 = regex2.Match(input); match2.Success; match2 = match2.NextMatch())
                {
                    input = input.Replace(match2.Groups[0].ToString(), "<LI>" + match2.Groups[1]);
                }
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<UL TYPE=\"" + match.Groups[3].ToString() + "\"><B>" + match.Groups[4].ToString() + "</B>" + input + "</UL>");
            }
            regex = new Regex(@"(\r\n((&nbsp;)|　)+)(?<正文>\S+)", RegexOptions.IgnoreCase);
            for (match = regex.Match(sDetail); match.Success; match = match.NextMatch())
            {
                sDetail = sDetail.Replace(match.Groups[0].ToString(), "<BR>　　" + match.Groups["正文"].ToString());
            }
            sDetail = sDetail.Replace("\r\n", "<BR>");
            return sDetail;
        }

        public static string Escape(string s)
        {
            StringBuilder builder = new StringBuilder();
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            for (int i = 0; i < bytes.Length; i += 2)
            {
                builder.Append("%u");
                builder.Append(bytes[i + 1].ToString("X2"));
                builder.Append(bytes[i].ToString("X2"));
            }
            return builder.ToString();
        }

        public static string ReplaceHtml(string str)
        {
            if (str == null || str.Length==0)
                return "";
            str = str.Replace("<", "&lt");
            str = str.Replace(">", "&gt");
            str = str.Replace("\n", "");
            str = str.Replace("\r", "");
            return str; 
        }

        public static string ReplaceEnter(string str)
        {
            if (str == null || str.Length == 0)
                return "";
            
            str = str.Replace("\n", "");
            str = str.Replace("\r", "");
            return str;
        }

        /// <summary>
        /// 替换指定符串中的首个指定字符为新的字符
        /// </summary>
        /// <param name="sourcestr">要修改的字符串</param>
        /// <param name="oldstr">被替换的字符串</param>
        /// <param name="newstr">替换字符串 </param>
        /// <returns></returns>
        public static string ReplaceFirst(string sourcestr,string oldstr, string newstr)
        {
            Regex reg = new Regex(oldstr);
            if (reg.IsMatch(sourcestr))
            {
                sourcestr = reg.Replace(sourcestr, newstr, 1);
            }
            return sourcestr;
        }

        #region 生成随机字符串，格式：1q2w3e4r
        /// <summary>
        /// 生成随机字符串，格式：1q2w3e4r
        /// </summary>
        /// <returns></returns>
        public static string BuildPassword()
        {
            Random random = new Random();
            List<int> ints = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                ints.Add(random.Next(9));
            }

            List<string> strs = new List<string>();

            //string CodeSerial = "a,b,c,d,e,f,g,h,i,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
            string CodeSerial = "a,b,c,d,e,f,g,h,i,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z";

            string[] arr = CodeSerial.Split(',');

            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < 4; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);

                strs.Add(arr[randValue]);
            }

            string passwd = "";

            for (int k = 0; k < 4; k++)
            {
                passwd += ints[k].ToString() + strs[k];
            }

            return passwd;
        }
        #endregion
    }
}
