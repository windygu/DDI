using System;
using System.Collections;
using System.IO;
using System.Text;

namespace DDI.Common
{
    public class BusinessLog
    {

        private static readonly object writeFile = new object();
        private static StreamWriter streamWriter; //写文件  
        /// <summary>
        /// 在本地写入日志
        /// </summary>
        /// <param name="exception">日志信息</param>
        /// <param name="subName">方法名称，或者自定义错误标识</param>
        public static void WriteException(Exception exception, string subName)
        {
            WriteLog(exception, subName);
        }
        
        /// <summary>
        /// 在本地写入日志
        /// </summary>
        /// <param name="exception">日志信息param>
        /// <param name="subName">业务名称及操作方法</param>
        public static void WriteBusinessLog(string message, string subName)
        {
            lock (writeFile)
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    string directPath = string.Format(@"{0}\Business_Log",
                                                      AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
                    //记录错误日志文件的路径
                    if (!Directory.Exists(directPath))
                    {
                        Directory.CreateDirectory(directPath);
                    }
                    directPath += string.Format(@"\{0}.log", dt.ToString("yyyy-MM-dd"));
                    if (streamWriter == null)
                    {
                        InitLog(directPath);
                    }
                    streamWriter.WriteLine("***********************************************************************");
                    streamWriter.WriteLine("业务操作时间："+dt.ToString("HH:mm:ss"));
                    if (!string.IsNullOrEmpty(subName))
                    {
                        streamWriter.WriteLine("业务名称及操作方法：" + subName);
                    }
                    if (message != null)
                    {
                        streamWriter.WriteLine("日志信息：\r\n" + message);
                    }
                }
                finally
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Flush();
                        streamWriter.Dispose();
                        streamWriter = null;
                    }
                }
            }
        }
        /// <summary>
        /// 在本地写入日志
        /// </summary>
        /// <param name="exception">错误信息</param>
        /// <param name="subName">方法名称</param>
        public static void WriteLog(Exception exception, string subName)
        {
            lock (writeFile)
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    string directPath = string.Format(@"{0}\Business_Log",
                                                      AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
                    //记录错误日志文件的路径
                    if (!Directory.Exists(directPath))
                    {
                        Directory.CreateDirectory(directPath);
                    }
                    directPath += string.Format(@"\{0}.log", dt.ToString("yyyy-MM-dd"));
                    if (streamWriter == null)
                    {
                        InitLog(directPath);
                    }
                    streamWriter.WriteLine("***********************************************************************");
                    streamWriter.WriteLine(dt.ToString("HH:mm:ss"));
                    streamWriter.WriteLine("输出信息：错误信息");
                    if (!string.IsNullOrEmpty(subName))
                    {
                        streamWriter.WriteLine("调用方法：" + subName);
                    }
                    if (exception != null)
                    {
                        streamWriter.WriteLine("异常信息：\r\n" + exception.Message);
                    }
                }
                finally
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Flush();
                        streamWriter.Dispose();
                        streamWriter = null;
                    }
                }
            }
        }
        private static void InitLog(string filPath)
        {
            streamWriter = !File.Exists(filPath) ? File.CreateText(filPath) : File.AppendText(filPath);
        }


        public static string ReadBusinessLog(DateTime date)
        {

            string res = ""; 
            try
            {
                string directPath = string.Format(@"{0}\Business_Log", AppDomain.CurrentDomain.SetupInformation.ApplicationBase);

                directPath += string.Format(@"\{0}.log", date.ToString("yyyy-MM-dd"));
                //记录错误日志文件的路径
                //UnicodeEncoding.GetEncoding("GB2312")准备读取中文            
                StreamReader objReader = new StreamReader(directPath, UnicodeEncoding.GetEncoding("utf-8"));
                string sLine = "";
                ArrayList arrText = new ArrayList();
                //创建一个动态数组            
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    arrText.Add(sLine);
                }
                objReader.Close();
                foreach (string sOutput in arrText)
                {
                    res += sOutput + "\r\n";
                }
            }
            catch (Exception)
            {

                res = "";
            }
            

            return res;
        }
    }
}
