using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    class KuGuoAd
    {
        string vgaoFolder;

        public KuGuoAd(string workPath)
        {
            vgaoFolder = Path.Combine(workPath, "kuguo");
        }

        public AppInfoBean addKuGuoAd(string folder, AppInfoBean appInfo)
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
                        xmlSB.AppendLine(CommonString.xmlContentKuGuo);
                        xmlSB.AppendLine(oldString);
                        xmlSB.AppendLine(CommonString.usePermissionKuGuo);

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
            string insertContent = "invoke-virtual {p0}, L" + activityStr + ";->toStartKuGuo()V";
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
            smaliSB.AppendLine(CommonString.smaliMethodKuGuo);

            using (StreamWriter sw = new StreamWriter(smaliFile))
            {
                sw.Write(smaliSB.ToString());
            }
        }
    }
}
