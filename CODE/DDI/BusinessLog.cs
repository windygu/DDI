using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace DDIV2.UI
{
    public partial class BusinessLog : Form
    {
        public BusinessLog()
        {
            InitializeComponent();
        }

        private void btnSearchTime_Click(object sender, EventArgs e)
        {
           string texts= DDI.Common.BusinessLog.ReadBusinessLog(Convert.ToDateTime(dtpXQTime.Text));
           if (texts == "")
               txtLog.Text = "当前日期不存在业务日志！";
           else
               txtLog.Text = texts;
        }


        private static System.Timers.Timer Timerlog;
        public void TimerlogTick()
        {
            Timerlog = new System.Timers.Timer(10000);
            Timerlog.Elapsed += new ElapsedEventHandler(OnTimedEventLog);
            Timerlog.Interval = 10000;
            Timerlog.Enabled = true;
            Timerlog.Start();
        }

        private void OnTimedEventLog(object source, ElapsedEventArgs e)
        {

            string texts = DDI.Common.BusinessLog.ReadBusinessLog(Convert.ToDateTime(dtpXQTime.Text));
            if (texts == "")
                txtLog.Text = "当前日期不存在业务日志！";
            else
                txtLog.Text = texts;
        }

        private void BusinessLog_Load(object sender, EventArgs e)
        {
            dtpXQTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
