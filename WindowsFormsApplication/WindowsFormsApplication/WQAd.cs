using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication
{
    class WQAd
    {
        string wqFolder;
        string imageId = "";

        public WQAd(string workPath)
        {
            wqFolder = Path.Combine(workPath, "wq");
        }

        public AppInfoBean addWQAd(string folder, AppInfoBean appInfo)
        {
            string fromDirRes = Path.Combine(wqFolder, "drawable");
            string fromDirCom = Path.Combine(wqFolder, "com");

            string toDirBin = Path.Combine(folder, "res\\drawable");
            string toDirCom = Path.Combine(folder, "smali\\com");
            FileUtil.CopyDir(fromDirRes, toDirBin);
            FileUtil.CopyDir(fromDirCom, toDirCom);

            string xmlFile = Path.Combine(folder, "AndroidManifest.xml");

            if (File.Exists(xmlFile))
            {
                addToXml(xmlFile);
            }
            else
            {
                MessageBox.Show("文件不存在：" + xmlFile);
                return null;
            }

            //添加public中的drawableValue
            string publicXmlFile = Path.Combine(folder, "res\\values\\public.xml");


            if (File.Exists(publicXmlFile))
            {
                imageId = addToPublicXml(publicXmlFile);
            }
            else
            {
                MessageBox.Show("文件不存在：" + publicXmlFile);
                return null;
            }


            // 添加OpenWall.smali

            addOpenWallSmali(appInfo, wqFolder, folder);





            // 修改入口smali
            string subFolderStr = Path.Combine("smali", appInfo.Activity.Replace(".", "\\") + ".smali");
            string smaliFile = Path.Combine(folder, subFolderStr);
            string activityStr = appInfo.Activity.Replace(".", "/");

            if (File.Exists(smaliFile))
            {
                addToSmali(smaliFile, activityStr);
                FileUtil.replaceString(smaliFile, "com/java/test/TestActivity", activityStr);
            }
            else
            {
                MessageBox.Show("文件不存在：" + smaliFile);
                return null;
            }

            return appInfo;
        }

        private void addOpenWallSmali(AppInfoBean appInfo, string wqFolder, string folder)
        {
            string activity = appInfo.Activity;

            string smaliFolder = Path.Combine("smali", activity.Substring(0, activity.LastIndexOf(".") + 1).Replace(".", "\\"));
            string fromFile = Path.Combine(wqFolder, "TestActivity$OpenWall.smali");
            string toFileFolder = Path.Combine(folder, smaliFolder);

            string toFile = Path.Combine(toFileFolder, appInfo.EntryName + "$OpenWall.smali");

            File.Copy(fromFile, toFile);

            FileUtil.replaceString(toFile, "TestActivity", appInfo.EntryName);

            string activityStr = appInfo.Activity.Replace(".", "/");
            FileUtil.replaceString(toFile, "com/java/test/" + appInfo.EntryName, activityStr);


        }

        private string addToPublicXml(string publicXmlFile)
        {


            XmlDocument doc = new XmlDocument();
            doc.Load(publicXmlFile);
            XmlElement root = doc.DocumentElement;
            XmlNodeList publicNodes = root.SelectNodes("public");

            Int32 newIdValue = 0x7f020000;

            foreach (XmlNode publicNode in publicNodes)
            {
                if (publicNode.Attributes["type"].Value.Equals("drawable"))
                {

                    string drawableIdHexStr = publicNode.Attributes["id"].Value.Substring(2);
                    int idValue = Convert.ToInt32(drawableIdHexStr,16);
                    if (idValue > newIdValue)
                    {
                        newIdValue = idValue;
                    }
                }

            }

            newIdValue = newIdValue + 1;
            string newIDValueHexStr = "0x" + String.Format("{0:X}", newIdValue);

            XmlElement newDrawable = doc.CreateElement("public");
            newDrawable.SetAttribute("type", "drawable");
            newDrawable.SetAttribute("name", "wallpic");
            newDrawable.SetAttribute("id", newIDValueHexStr);

            root.AppendChild(newDrawable);

            doc.Save(publicXmlFile);

            return newIDValueHexStr;
        }

        private void addToXml(string xmlFile)
        {
            StringBuilder xmlSB = new StringBuilder();

            using (StreamReader sr = new StreamReader(xmlFile))
            {
                string oldString;
                while ((oldString = sr.ReadLine()) != null)
                {
                    if (oldString.Contains("</application>"))
                    {
                        xmlSB.AppendLine(CommonString.xmlContentWQ);
                        xmlSB.AppendLine(oldString);
                        xmlSB.AppendLine(CommonString.usePermissionWQ);

                    }
                    else
                    {
                        xmlSB.AppendLine(oldString);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(xmlFile))
            {
                sw.Write(xmlSB.ToString());
            }


        }

        private void addToSmali(string smaliFile, string activityStr)
        {
            StringBuilder smaliSB = new StringBuilder();
            string insertContent = "invoke-virtual {p0}, L" + activityStr + ";->toStartWQ()V";
            bool insertOK = false;

            using (StreamReader sr = new StreamReader(smaliFile))
            {
                string oldString;
                while ((oldString = sr.ReadLine()) != null)
                {
                    if (oldString.Contains("setContentView"))
                    {
                        smaliSB.AppendLine(oldString);
                        smaliSB.AppendLine(insertContent);
                        insertOK = true;
                    }
                    else if (oldString.Contains("# direct methods"))
                    {
                        smaliSB.AppendLine(CommonString.smaliFieldWQ);
                        smaliSB.AppendLine(oldString);
                    }
                    else
                    {
                        smaliSB.AppendLine(oldString);
                    }
                }
            }
            if (!insertOK)
            {
                smaliSB = new StringBuilder();
                using (StreamReader sr = new StreamReader(smaliFile))
                {
                    string oldString;
                    while ((oldString = sr.ReadLine()) != null)
                    {
                        if (oldString.Contains("->onCreate"))
                        {
                            smaliSB.AppendLine(oldString);
                            smaliSB.AppendLine(insertContent);
                        }
                        else
                        {
                            smaliSB.AppendLine(oldString);
                        }
                    }
                }
            }

            smaliSB.AppendLine();
            smaliSB.AppendLine(CommonString.getWQMethod(imageId));

            using (StreamWriter sw = new StreamWriter(smaliFile))
            {
                sw.Write(smaliSB.ToString());
            }
        }

    }
}
