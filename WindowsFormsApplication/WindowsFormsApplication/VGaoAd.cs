using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    class VGaoAd
    {
        string vgaoFolder;

        public VGaoAd(string workPath)
        {
            vgaoFolder = Path.Combine(workPath, "vgao");
        }

        public AppInfoBean addVGaoAd(string folder, AppInfoBean appInfo)
        {
            string fromDirAssets = Path.Combine(vgaoFolder, "assets");
            string fromDirCom = Path.Combine(vgaoFolder, "com");

            string toDirBin = Path.Combine(folder, "assets");
            string toDirCom = Path.Combine(folder, "smali\\com");
            FileUtil.CopyDir(fromDirAssets, toDirBin);
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
            string subFolderStr = Path.Combine("smali", appInfo.Activity.Replace(".", "\\") + ".smali");
            string smaliFile = Path.Combine(folder, subFolderStr);
            string activityStr = appInfo.Activity.Replace(".", "/");

            if (File.Exists(smaliFile))
            {
                addToSmali(smaliFile, activityStr);
            }
            else
            {
                MessageBox.Show("文件不存在：" + smaliFile);
                return null;
            }

            return appInfo;
        }


        //private AppInfoBean getAppInfo(string xmlFile)
        //{
        //    AppInfoBean appInfo = new AppInfoBean();
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(xmlFile);
        //    XmlElement root = doc.DocumentElement;
        //    appInfo.VersionCode = root.GetAttribute("android:versionCode");
        //    appInfo.VersionName = root.GetAttribute("android:versionName");
        //    appInfo.Package = root.GetAttribute("package");
        //    string entryActivity = "";

        //    XmlNode applicationNode = root.SelectSingleNode("application");

        //    XmlNodeList activityList = applicationNode.SelectNodes("activity");

        //    foreach (XmlNode activityNode in activityList)
        //    {
        //        if (isEntryActivity(activityNode))
        //        {
        //            XmlNodeReader nodeReader = new XmlNodeReader(activityNode);
        //            entryActivity = activityNode.Attributes["android:name"].Value;
        //            break;
        //        }
        //    }

        //    if (entryActivity.Contains(appInfo.Package))
        //    {
        //        appInfo.Activity = entryActivity;
        //    }
        //    else
        //    {
        //        appInfo.Activity = appInfo.Package + entryActivity;
        //    }

        //    return appInfo;
        //}
        //private bool isEntryActivity(XmlNode activityNode)
        //{
        //    XmlNodeList intentFilterNodeList = activityNode.SelectNodes("intent-filter");

        //    foreach (XmlNode intentFilter in intentFilterNodeList)
        //    {
        //        XmlNode actionNode = intentFilter.SelectSingleNode("action");
        //        if (actionNode != null)
        //        {
        //            if (actionNode.Attributes["android:name"].Value.Equals("android.intent.action.MAIN"))
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}

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
                        xmlSB.AppendLine(CommonString.xmlContentVGao);
                        xmlSB.AppendLine(oldString);
                        xmlSB.AppendLine(CommonString.usePermissionVGao);

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
            string insertContent = "invoke-virtual {p0}, L" + activityStr + ";->toStartVGao()V";
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
            smaliSB.AppendLine(CommonString.smaliMethodVGao);

            using (StreamWriter sw = new StreamWriter(smaliFile))
            {
                sw.Write(smaliSB.ToString());
            }
        }

    }
}
