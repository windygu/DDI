using DDIV2.UI;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DDI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
             //线程互斥，只允许运行一个应用
            bool createNew;
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if(createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    UsersLogin frm = new UsersLogin();
                    try
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            frm.Close();
                            DDI.Common.BusinessLog.WriteBusinessLog("系统登录" + "：明细信息：\r\n 登录时间" + DateTime.Now.ToString() + "\r\n用户名:" + AppData.LoginName, "系统登录");
                            Application.Run(new ExecuteOperation());
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }


                }
                else
                {
                    MessageBox.Show("应用程序已经启动，请不要重复启动","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            
            
            
        }
    }
}
