using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ORG.UILib.Controls
{
    public partial class ComboBoxEx : ComboBox
    {
        public ComboBoxEx()
        {
            InitializeComponent();
        }

        public ComboBoxEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.ForeColor = System.Drawing.Color.Black;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        }
    }
}
