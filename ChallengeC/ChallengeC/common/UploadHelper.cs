using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Drawing;
using System.IO;

namespace Common
{
    public class UploadHelper
    {

        /// <summary>
        /// 上传后生成的缩略图,宽度=高度
        /// </summary>
        ///<param name="postFile">要上传的图片</param>
        ///<param name="roomport">房间号</param>
        ///<param name="prefix">名称前缀</param>
        ///<param name="msg">返回信息</param>
        /// <returns>上传后的文件名</returns>
        public static void UploadImage(HttpPostedFile postFile, string uploadpath, string prefix, out string msg)
        {
            msg = "";
            if (postFile != null)
            {
                //获取上传文件的扩展名
                string _extension = Path.GetExtension(postFile.FileName).ToLower();
                //允许上传文件的格式
                string _canUploadExtension = ".jpg";
                //允许上传文件的大小，单位字节
                int fileSize = 163600; //150K



                if (!Directory.Exists(HttpContext.Current.Server.MapPath(uploadpath)))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(uploadpath));

                if (_canUploadExtension.ToLower().IndexOf(_extension) > -1)
                {

                    //获取上传文件的大小
                    int _upfileSize = postFile.ContentLength;
                    if (_upfileSize < fileSize)
                    {
                        //得到真实的路径
                        string _path = HttpContext.Current.Server.MapPath(uploadpath) + prefix + _extension;
                        //保存文件
                        postFile.SaveAs(_path);

                        msg = _path;
                    }
                    else
                    {
                        //上传文件太大
                        msg = "您上传的太大！请不要超过150k！";
                    }
                }
                else
                {
                    //文件格式不正确
                    msg = string.Format("不允许上传{0}格式的文件！\r\n只允许上传文件格式：{1}", _extension, _canUploadExtension);
                }
            }
            else
            {
                //没有选择上传的文件
                msg = "请选择要上传的文件！";
            }


        }

        public static string UploadImage(byte[] imgBuffer, string uploadpath, string ext)
        {
            try
            {
                System.IO.MemoryStream m = new MemoryStream(imgBuffer);

                if (!Directory.Exists(HttpContext.Current.Server.MapPath(uploadpath)))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(uploadpath));

                string imgname = StringHelper.CreateIDCode() + "." + ext;

                string _path = HttpContext.Current.Server.MapPath(uploadpath) + imgname;

                Image img = Image.FromStream(m);
                if (ext == "jpg")
                    img.Save(_path, System.Drawing.Imaging.ImageFormat.Jpeg);
                else
                    img.Save(_path, System.Drawing.Imaging.ImageFormat.Gif);
                m.Close();

                return uploadpath + imgname;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string UploadFile(byte[] fileBuffer, string uploadpath, string ext)
        {
            try
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(uploadpath)))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(uploadpath));

                string imgname = StringHelper.CreateIDCode() + "." + ext;

                string _path = HttpContext.Current.Server.MapPath(uploadpath) + imgname;

                FileStream fs = new FileStream(_path, FileMode.CreateNew);
                fs.Write(fileBuffer, 0, fileBuffer.Length);

                fs.Close();

                return uploadpath + imgname;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        /// <summary>
        /// 创建文本文件
        /// </summary>
        /// <param name="uploadpath">虚拟路径</param>
        /// <param name="content">内容</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static string CreateTxtFile(string uploadpath, string content, string filename)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath(uploadpath);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string _filepath = path + filename;

                if (!File.Exists(_filepath))
                    File.Create(_filepath).Close();

                StreamWriter sw = new StreamWriter(_filepath, false, Encoding.Default);
                sw.Write(content);
                sw.Close();

                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
