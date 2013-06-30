using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication
{
    class FileUtil
    {
        public static void CopyDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
                return;

            if (!Directory.Exists(toDir))
            {
                Directory.CreateDirectory(toDir);
            }

            string[] files = Directory.GetFiles(fromDir);
            foreach (string formFileName in files)
            {
                string fileName = Path.GetFileName(formFileName);
                string toFileName = Path.Combine(toDir, fileName);
                File.Copy(formFileName, toFileName);
            }
            string[] fromDirs = Directory.GetDirectories(fromDir);
            foreach (string fromDirName in fromDirs)
            {
                string dirName = Path.GetFileName(fromDirName);
                string toDirName = Path.Combine(toDir, dirName);
                CopyDir(fromDirName, toDirName);
            }
        }

        public static void MoveDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
                return;

            CopyDir(fromDir, toDir);
            Directory.Delete(fromDir, true);
        }



        public static void replacePackageString(string fileFullName, string originalString, string targetString)
        {
            try
            {
                string oldString = "";
                string newString = "";
                string orgStrSlash = originalString.Replace('.', '/');
                string targStrSlash = targetString.Replace('.', '/');

                using (StreamReader sr = new StreamReader(fileFullName))
                {
                    oldString = sr.ReadToEnd();
                }

                if (oldString.Contains(originalString) || oldString.Contains(orgStrSlash))
                {
                    newString = oldString.Replace(originalString, targetString).Replace(orgStrSlash, targStrSlash);

                }
                
                if (!newString.Equals(""))
                {
                    Console.WriteLine("替换文件：" + fileFullName);
                    using (StreamWriter sw = new StreamWriter(fileFullName))
                    {
                        sw.Write(newString);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }


        public static bool isASCII(string extension)
        {
            if (".xml".Equals(extension) || ".smali".Equals(extension)
                || ".java".Equals(extension) || ".txt".Equals(extension)
                || ".html".Equals(extension) || ".htm".Equals(extension)
                || ".js".Equals(extension) || ".sql".Equals(extension)
                || ".c".Equals(extension) || ".cpp".Equals(extension))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void replaceString(string fileFullName, string originalString, string targetString)
        {
            try
            {
                string oldString = "";
                string newString = "";

                using (StreamReader sr = new StreamReader(fileFullName))
                {
                    oldString = sr.ReadToEnd();
                }

                if (oldString.Contains(originalString))
                {
                    newString = oldString.Replace(originalString, targetString);

                }

                if (!newString.Equals(""))
                {
                    Console.WriteLine("替换文件：" + fileFullName);
                    using (StreamWriter sw = new StreamWriter(fileFullName))
                    {
                        sw.Write(newString);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
