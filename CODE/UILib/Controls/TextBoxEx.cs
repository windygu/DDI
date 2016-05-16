using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace ORG.UILib.Controls
{
    public partial class TextBoxEx : TextBox
    {
        
        public TextBoxEx()
        {
            InitializeComponent();
            
        }

        public TextBoxEx(IContainer container)
        {
            container.Add(this);

            this.BackColor = System.Drawing.Color.FromArgb(255, 235, 205);
            InitializeComponent();
            Init();
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

        private void Init()
        {
            this.EnabledChanged += new EventHandler(TextBoxEx_EnabledChanged);

        }

        internal void TextBoxEx_EnabledChanged(object sender, EventArgs e)
        {
            
            if (!this.Enabled)
            {
                this.BackColor = System.Drawing.Color.White;
            }
            else
            {
                //this.BackColor = System.Drawing.Color.FromArgb(255, 235, 205);
                this.BackColor = Color.White;

            }
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            if (!Enabled)
            {
                BackColor = Color.White;
            }
        }

    }  
}
