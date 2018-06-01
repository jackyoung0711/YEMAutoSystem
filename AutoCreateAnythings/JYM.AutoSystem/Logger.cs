using System;
using System.IO;
using System.Windows.Forms;

namespace JYM.AutoSystem
{
    public static class Logger
    {
        public static readonly object objLock = new object();

        /// <summary>
        ///     记录数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        public static void LoadData(string fileName, string message)
        {
            string pathR = Path.Combine(Application.StartupPath, fileName);
            lock (objLock)
            {
                if (!File.Exists(pathR))
                {
                    //创建
                    if (!Directory.Exists(Path.GetDirectoryName(pathR)))
                    {
                        //创建
                        Directory.CreateDirectory(Path.GetDirectoryName(pathR));
                    }
                    using (FileStream fs = new FileStream(pathR, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(message);
                        }
                    }
                }
                else
                {
                    FileInfo file = new FileInfo(pathR);
                    using (StreamWriter sww = file.AppendText())
                    {
                        sww.WriteLine(message);
                    }
                }
            }
        }

        public static void LogRecord(string message, int type)
        {
            string typeName = type == 0 ? "RecordUser" : "RecordAssert";
            lock (objLock)
            {
                string pathR = Application.StartupPath + $"\\log{typeName}.txt";
                if (!File.Exists(pathR))
                {
                    //创建
                    using (FileStream fs = new FileStream(pathR, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(message);
                        }
                    }
                }
                else
                {
                    FileInfo file = new FileInfo(pathR);
                    using (StreamWriter sww = file.AppendText())
                    {
                        sww.WriteLine(message);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minNums"></param>
        /// <param name="maxNums"></param>
        /// <param name="ids"></param>
        public static void LogTableIds(int type, int minNums, int maxNums, string ids)
        {
            string typeName = @"RedisToTable\" + $"{minNums}_{maxNums}" + (type == 0 ? "userids" : "assetids");
            if (type == 2)
            {
                //Reload数据时报错的txt文档
                typeName = @"ReloadError\ReloadTableToDiskErrorAssetIds";
            }
            string pathR = Application.StartupPath + $"\\{typeName}.txt";
            if (File.Exists(pathR))
            {
                File.Delete(pathR);
            }
            else
            {
                //记录
                using (FileStream fs = new FileStream(pathR, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(ids);
                    }
                }
            }
        }

        public static void Logw(string message, int type)
        {
            lock (objLock)
            {
                string typeName = type == 0 ? "ErrorUser" : "ErrorAssert";
                if (type == 3)
                {
                    typeName = "ErrorRollback";
                }
                if (type == 4)
                {
                    typeName = "CheckAssetIdError";
                }
                string pathR = Application.StartupPath + $"\\log{typeName}.txt";
                if (!File.Exists(pathR))
                {
                    //创建
                    using (FileStream fs = new FileStream(pathR, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(message + "----------" + DateTime.Now);
                        }
                    }
                }
                else
                {
                    FileInfo file = new FileInfo(pathR);
                    using (StreamWriter sww = file.AppendText())
                    {
                        sww.WriteLine(message + "----------" + DateTime.Now);
                    }
                }
            }
        }
    }
}