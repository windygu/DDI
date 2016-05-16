using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;


namespace ORG.UILib.Controls
{
    public partial class RadioButtonEx : RadioButton
    {
        public RadioButtonEx()
        {
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            InitializeComponent();
        }

        public RadioButtonEx(IContainer container)
        {
            container.Add(this);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            InitializeComponent();
        }
    }
}
