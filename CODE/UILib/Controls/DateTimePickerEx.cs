using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ORG.UILib.Controls
{
    public partial class DateTimePickerEx : DateTimePicker
    {
        public DateTimePickerEx()
        {
            InitializeComponent();
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "yyyy-MM-dd";
        }

        public DateTimePickerEx(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            //统一格式
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "yyyy-MM-dd";

            this.KeyPress += new KeyPressEventHandler(DateTimePickerEx_KeyPress);
            this.MouseUp += new MouseEventHandler(DateTimePickerEx_MouseUp);

        }



        void DateTimePickerEx_MouseUp(object sender, MouseEventArgs e)
        {
            a = 0;
        }


        int a = 0;
        void DateTimePickerEx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                
                a++;
                if (a == 4)
                {
                    SendKeys.Send("{right}");
                }
                if (a == 6)
                {
                    SendKeys.Send("{right}");
                }
                if (a == 8)
                {
                    SendKeys.Send("{right}");
                    a = 0;
                }
            }
        }

        #region 属性
        private string _otherText;
        /// <summary>
        /// 获取设置其他自定义内容
        /// </summary>
        [Category("Custom"), Browsable(true), Description("获取设置其他自定义内容")]
        public string OtherText
        {
            get { return _otherText; }
            set { _otherText = value; }

        } 
        #endregion
    }
}
