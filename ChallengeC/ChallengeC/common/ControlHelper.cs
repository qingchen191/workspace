using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using System.Net;

namespace Common
{
    public class ControlHelper
    {
        /// <summary>
        /// 设置指定的选中控件及未选中控件的样式
        /// </summary>
        /// <param name="control">选中的控件</param>
        /// <param name="controlList">未选中的控件</param>
        public static void SetControlStyle(Control control, params Control[] controlList)
        {
            if (control is LinkButton)
            {                
                ((LinkButton)control).CssClass = "selected";
                foreach (Control ctrl in controlList)
                    ((LinkButton)ctrl).CssClass = "";
            }            
        }

        public static void SetControlStyle(HtmlGenericControl control, params HtmlGenericControl[] controlList)
        {
            if (control.TagName == "li")
            {
                control.Attributes.Add("class","selected");
                foreach (HtmlGenericControl ctrl in controlList)
                    ctrl.Attributes.Remove("class");
            }
        }

        /// <summary>
        /// 设置指定控件(该控件必须是继承ListControl接口，如：DropDownList,CheckBoxList,RadioButtonList)的选定项为指定value值
        /// </summary>
        /// <param name="control">如：DropDownList,CheckBoxList,RadioButtonList</param>
        /// <param name="value">要设置为已选择的项的Value值</param>
        public static void SetSelectedItem(Control control, string value)
        {
            //ClearSelectedItem(control);
            ListItem item = null;
            if (control is DropDownList)
                item = ((DropDownList)control).Items.FindByValue(value);
            if (control is CheckBoxList)
                item = ((CheckBoxList)control).Items.FindByValue(value);
            if (control is RadioButtonList)
                item = ((RadioButtonList)control).Items.FindByValue(value);
            if (item != null)
                item.Selected = true;
        }

        /// <summary>
        /// 设置指定控件(该控件必须是继承ListControl接口，如：DropDownList,CheckBoxList,RadioButtonList)的选定项为指定value值
        /// </summary>
        /// <param name="control">如：DropDownList,CheckBoxList,RadioButtonList</param>
        /// <param name="value">要设置为已选择的项的Value值</param>
        public static void SetSelectedItem(Control control, DataTable dt, string DataValueField)
        {
            ListItem item = null;
            if (control is DropDownList)
            { 
                foreach(DataRow r in dt.Rows)
                {
                    item = ((DropDownList)control).Items.FindByValue(r[DataValueField].ToString());
                }                
                
            }
            if (control is CheckBoxList)
            {
                foreach (DataRow r in dt.Rows)
                {
                    item = ((CheckBoxList)control).Items.FindByValue(r[DataValueField].ToString());
                }
            }
            if (control is RadioButtonList)
            {
                foreach (DataRow r in dt.Rows)
                {
                    item = ((RadioButtonList)control).Items.FindByValue(r[DataValueField].ToString());
                }
            }
            item.Selected = true;
        }

        public static void ClearSelectedItem(Control control)
        {
            if (control is DropDownList)
                ((DropDownList)control).ClearSelection();
            if (control is CheckBoxList)
                ((CheckBoxList)control).ClearSelection();
            if (control is RadioButtonList)
                ((RadioButtonList)control).ClearSelection();
        }

        /// <summary>
        /// 将指定DropDownList或RadioButtonList或CheckBoxList控件绑定数据源为指定DataTable,并设置绑定值，当IsSelect为真时插入"请选择"样式
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dt"></param>
        /// <param name="DataTextField"></param>
        /// <param name="DataValueField"></param>
        /// <param name="IsSelect"></param>
        public static void BindItemControl(Control control, DataTable dt, string DataTextField, string DataValueField, bool IsSelect)
        {
            if(control is DropDownList)
            {
                DropDownList ddl = (DropDownList)control;
                ddl.ClearSelection();
                ddl.DataTextField = DataTextField;
                ddl.DataValueField = DataValueField;
                ddl.DataSource = dt;
                ddl.DataBind();
                if (IsSelect)
                    ddl.Items.Insert(0, new ListItem("请选择", ""));
                return;
            }
            if (control is RadioButtonList)
            {
                RadioButtonList rbl = (RadioButtonList)control;
                rbl.ClearSelection();
                rbl.DataTextField = DataTextField;
                rbl.DataValueField = DataValueField;
                rbl.DataSource = dt;
                rbl.DataBind();
                if (IsSelect)
                    rbl.Items.Insert(0, new ListItem("请选择", ""));
                return;
            }
            if (control is CheckBoxList)
            {
                CheckBoxList cbl = (CheckBoxList)control;
                cbl.ClearSelection();
                cbl.DataTextField = DataTextField;
                cbl.DataValueField = DataValueField;
                cbl.DataSource = dt;
                cbl.DataBind();
                if (IsSelect)
                    cbl.Items.Insert(0, new ListItem("请选择", ""));
                return;
            }            
        }

        /// <summary>
        /// 将指定DropDownList或RadioButtonList或CheckBoxList控件绑定数据源为指定DataTable,并设置绑定值，当IsSelect为真时插入"请选择"样式
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dt"></param>
        /// <param name="DataTextField"></param>
        /// <param name="DataValueField"></param>
        /// <param name="IsItemSelect"></param>
        /// <param name="IsSelect"></param>
        public static void BindItemControl(Control control, DataTable dt, string DataTextField, string DataValueField,bool IsItemSelect,bool IsSelect)
        {
            if (control is DropDownList)
            {
                DropDownList ddl = (DropDownList)control;
                foreach (DataRow r in dt.Rows)
                {
                    ddl.ClearSelection();
                    ListItem item = new ListItem(r[DataTextField].ToString(), r[DataValueField].ToString());
                    item.Selected = IsItemSelect;
                    ddl.Items.Add(item);
                }
                if (IsSelect)
                    ddl.Items.Insert(0, new ListItem("请选择", ""));
                ddl.DataBind();
                return;
            }
            if (control is RadioButtonList)
            {
                RadioButtonList rbl = (RadioButtonList)control;
                foreach (DataRow r in dt.Rows)
                {
                    rbl.ClearSelection();
                    ListItem item = new ListItem(r[DataTextField].ToString(), r[DataValueField].ToString());
                    item.Selected = IsItemSelect;
                    rbl.Items.Add(item);
                }
                if (IsSelect)
                    rbl.Items.Insert(0, new ListItem("请选择", ""));
                rbl.DataBind();
                return;
            }
            if (control is CheckBoxList)
            {
                CheckBoxList cbl = (CheckBoxList)control;
                foreach (DataRow r in dt.Rows)
                {
                    cbl.ClearSelection();
                    ListItem item = new ListItem(r[DataTextField].ToString(), r[DataValueField].ToString());
                    item.Selected = IsItemSelect;
                    cbl.Items.Add(item);
                }
                cbl.DataBind();
                if (IsSelect)
                    cbl.Items.Insert(0, new ListItem("请选择", ""));
                return;
            }
        }

        /// <summary>
        /// 将指定DropDownList或RadioButtonList或CheckBoxList控件绑定数据源为指定字符串数组，当IsSelect为真时插入"请选择"样式
        /// </summary>
        /// <param name="control"></param>
        /// <param name="items"></param>
        /// <param name="IsSelect"></param>
        public static void BindItemControl(Control control, string[] items, bool IsSelect)
        {
            if (control is DropDownList)
            {
                DropDownList ddl = (DropDownList)control;
                ddl.ClearSelection();
                for (int i = 0; i < items.Length; i++)
                {
                    ddl.Items.Add(new ListItem(items[i], i.ToString()));
                }               
                if (IsSelect)
                    ddl.Items.Insert(0, new ListItem("请选择", ""));
                return;
            }
            if (control is RadioButtonList)
            {
                RadioButtonList rbl = (RadioButtonList)control;
                rbl.ClearSelection();
                for (int i = 0; i < items.Length; i++)
                {
                    rbl.Items.Add(new ListItem(items[i], i.ToString()));
                }
                if (IsSelect)
                    rbl.Items.Insert(0, new ListItem("请选择", ""));
                return;
            }
            if (control is CheckBoxList)
            {
                CheckBoxList cbl = (CheckBoxList)control;
                cbl.ClearSelection();
                for (int i = 0; i < items.Length; i++)
                {
                    cbl.Items.Add(new ListItem(items[i], i.ToString()));
                }
                if (IsSelect)
                    cbl.Items.Insert(0, new ListItem("请选择", ""));
                return;
            }

        }

        /// <summary>
        /// 将指定DropDownList或RadioButtonList或CheckBoxList控件绑定数据源为指定DataTable内容项,并设置绑定值，当IsSelect为真时插入"请选择"样式
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dt"></param>
        /// <param name="DataTextField"></param>
        /// <param name="DataValueField"></param>
        /// <param name="IsItemSelect"></param>
        /// <param name="IsSelect"></param>
        public static void ControlAddItem(Control control, DataTable dt, string DataTextField, string DataValueField, bool IsItemSelect, bool IsSelect)
        {
            if (control is DropDownList)
            {
                DropDownList ddl = (DropDownList)control;
                foreach (DataRow r in dt.Rows)
                {
                    ListItem item = new ListItem(r[DataTextField].ToString(), r[DataValueField].ToString());
                    item.Selected = IsItemSelect;
                    ddl.Items.Add(item);
                }
                if (IsSelect)
                    ddl.Items.Insert(0, new ListItem("请选择", ""));
                ddl.DataBind();
                return;
            }
            if (control is RadioButtonList)
            {
                RadioButtonList rbl = (RadioButtonList)control;
                foreach (DataRow r in dt.Rows)
                {
                    ListItem item = new ListItem(r[DataTextField].ToString(), r[DataValueField].ToString());
                    item.Selected = IsItemSelect;
                    rbl.Items.Add(item);
                }
                if (IsSelect)
                    rbl.Items.Insert(0, new ListItem("请选择", ""));
                rbl.DataBind();
                return;
            }
            if (control is CheckBoxList)
            {
                CheckBoxList cbl = (CheckBoxList)control;
                foreach (DataRow r in dt.Rows)
                {
                    ListItem item = new ListItem(r[DataTextField].ToString(), r[DataValueField].ToString());
                    item.Selected = IsItemSelect;
                    cbl.Items.Add(item);
                }
                cbl.DataBind();
                if (IsSelect)
                    cbl.Items.Insert(0, new ListItem("请选择", ""));
                return;
            }
        }

        /// <summary>
        /// 清除页面的指定TextBox项的值
        /// </summary>
        /// <param name="textBox"></param>
        public static void ClearPageText(params TextBox[] textBox)
        {
            foreach (TextBox txt in textBox)
            {
                txt.Text = "";
            }
        }

        /// <summary>
        /// 使用FileUpload 控件上传文件,并返回文件名,
        /// </summary>
        /// <param name="fileupload">FileUpload 控件ID</param>
        /// <param name="upfilePath">要保存的物理路径</param>
        /// <param name="extension">允许上传文件的扩展名</param>
        /// <param name="filesize">允许上传文件的大小</param>
        /// <param name="customerImgname">是否允许自定义文件名</param>
        /// <returns>string 文件名</returns>
        public static string UploadFile(FileUpload fileupload, string upfilePath, string extension,string newImgName, int filesize, bool customerImgname,out string msg)
        {
            msg = "";
            if (fileupload.HasFile)
            {
                //获取上传文件的扩展名
                string _extension = Path.GetExtension(fileupload.FileName).ToLower();
                //允许上传文件的格式
                string _canUploadExtension = extension;
                //允许上传文件的大小，单位字节
                if (_canUploadExtension.ToLower().IndexOf(_extension) > -1)
                {
                    string imgName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + _extension;
                    if (customerImgname && newImgName != "")
                        imgName = newImgName +_extension;
                    else
                        imgName = fileupload.FileName;

                    //获取上传文件的大小
                    int _upfileSize = fileupload.PostedFile.ContentLength;
                    if (_upfileSize < filesize * 1024)
                    {
                        //得到真实的路径
                        if (!Directory.Exists(upfilePath))
                            Directory.CreateDirectory(upfilePath);
                        string _path = upfilePath +"/"+ imgName;
                        //保存文件
                        fileupload.SaveAs(_path);
                        msg = "OK";
                        return imgName;
                    }
                    else
                    {
                        //上传文件太大
                        msg = "您上传的太大！请不要超过" + filesize + "k字节！";
                        return "";
                    }
                }
                else
                {
                    //文件格式不正确
                    msg = string.Format("不允许上传{0}格式的文件！只允许上传文件格式：{1}", _extension, _canUploadExtension);
                    return "";
                }
            }
            return "";
        }
       
        /// <summary>
        /// 删除指定目录下的所有文件
        /// </summary>
        /// <param name="path"></param>
        public static void DelFile(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
            }
        }

        /// <summary>
        /// 获取指定解释串为指定代码的值
        /// </summary>
        /// <param name="str">解释串(如:1:张三;2:李四;3:王五)</param>
        /// <param name="value">指定代码值(如:2)</param>
        /// <returns></returns>
        public static string GetStrValue(string str, string value)
        {
            foreach (string s in str.Split(";".ToCharArray()))
            {
                string[] s1 = s.Split(":".ToCharArray());
                if (s1.Length > 0 && s1[0] == value)
                    return s1[1];
            }
            return "";            
        }

        /// <summary>
        /// 获取指定表中解释串为指定代码的值
        /// </summary>
        /// <param name="dt">要解释的DataTable表</param>
        /// <param name="DataTextField">文本值</param>
        /// <param name="DataValueField">键值</param>
        /// <param name="value">指定代码值(如:2)</param>
        /// <returns></returns>
        public static string GetStrValue(DataTable dt, string DataTextField, string DataValueField, string value)
        {
            StringBuilder strs = new StringBuilder();
            foreach (DataRow r in dt.Rows)
            {
                strs.AppendFormat("{0}:{1};", r[DataValueField].ToString(), r[DataTextField].ToString());
            }
            if (strs.Length > 0)
                return GetStrValue(strs.ToString().TrimEnd(';'), value);
            return "";
        }

        /// <summary>
        /// 清空指定TextBox控件序列的Text值
        /// </summary>
        /// <param name="textboxs"></param>
        public static void ClearTextBox(params TextBox[] textboxs)
        {
            foreach (TextBox txt in textboxs)
            {
                txt.Text = "";
            }
        }

        /// <summary>
        /// 清空或初始化TextBox控件序列的Text值
        /// </summary>
        /// <param name="isInit">是否初始化(true,值为0; false,值为空字符串)</param>
        /// <param name="textboxs">TextBox控件序列</param>
        public static void ClearTextBox(bool isInit, params TextBox[] textboxs)
        {
            if (isInit)
                InitTextBox(textboxs);
            else
                ClearTextBox(textboxs);
        }

        /// <summary>
        /// 初始化TextBox控件序列的Text值为0
        /// </summary>
        /// <param name="textboxs"></param>
        public static void InitTextBox(params TextBox[] textboxs)
        {
            foreach (TextBox txt in textboxs)
            {
                txt.Text = "0";
            }
        }

        /// <summary>
        /// 获取GRIDVIEW中CHECKBOX选中的项
        /// </summary>
        /// <param name="gv">gridview id</param>
        /// <param name="checkboxID">checkboxID</param>
        /// <returns></returns>
        public static List<object> GetGridViewChecked(GridView gv, string checkboxID)
        {
            List<object> list = new List<object>();
            CheckBox chk = null;
            foreach (GridViewRow gvr in gv.Rows)
            {
                chk = (CheckBox)gvr.FindControl(checkboxID);
                if (chk != null && chk.Checked)
                {
                    list.Add(gv.DataKeys[gvr.RowIndex].Values[0].ToString());
                }
            }

            return list;
        }

        /// <summary>
        /// 返回指定url是否存在
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool UrlExists(string url)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "HEAD";
                webRequest.Timeout = 100;
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                return webResponse.StatusCode == HttpStatusCode.OK;
            }
            catch (WebException we)
            {
                System.Diagnostics.Trace.Write(we.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取指定KEY值的配置串
        /// </summary>
        /// <param name="key">指定的配置KEY</param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        { 
            string str="";
            try
            {
                str = ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {
                return "";
            }
            return str;
        }

        /// <summary>
        /// 读取指定目录文本文件内容
        /// </summary>
        /// <param name="filename">文件名称(包括路径)</param>
        /// <returns></returns>
        public static string ReadTxt(string filename)
        {
            if (File.Exists(filename))
                return File.ReadAllText(filename);
            return "";
        }

        /// <summary>
        /// 将指定数组换为换DataTable
        /// </summary>
        /// <param name="items">数组</param>
        /// <returns></returns>
        public static DataTable ItemsToTable(string[] items)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("v"));
            dt.Columns.Add(new DataColumn("t"));
            for (int i = 0; i < items.Length; i++)
            {
                DataRow r = dt.NewRow();
                r[0] = i;
                r[1] = items[i];
                dt.Rows.Add(r);
            }
            return dt;
        }

        /// <summary>
        /// 将指定数组换为换DataTable
        /// </summary>
        /// <param name="items">数组</param>
        /// <param name="v">数组key值</param>
        /// <param name="t">数组值</param>
        /// <returns></returns>
        public static DataTable ItemsToTable(string[] items,string v,string t)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn(v));
            dt.Columns.Add(new DataColumn(t));
            for (int i = 0; i < items.Length; i++)
            {
                DataRow r = dt.NewRow();
                r[0] = i;
                r[1] = items[i];
                dt.Rows.Add(r);
            }
            return dt;
        }

        /// <summary>
        /// 将指定数组以指定分隔附输出字符串
        /// </summary>
        /// <param name="items">数组</param>
        /// <param name="c">分隔符</param>
        /// <returns></returns>
        public static string ItemsToString(string[] items,string c)
        {
            StringBuilder strs = new StringBuilder();
            foreach (string item in items)
            {
                strs.AppendFormat("'{0}'{1}", item, c);
            }
            if (strs.Length > 0)
                return strs.ToString().TrimEnd(c.ToCharArray());
            return "";
        }
    }
}
