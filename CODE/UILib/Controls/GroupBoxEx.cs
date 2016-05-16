using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ORG.UILib.Controls
{
    public partial class GroupBoxEx : GroupBox
    {
        public GroupBoxEx()
        {
            InitializeComponent();
        }

        public GroupBoxEx(IContainer container)
        {
            container.Add(this);
            this.ForeColor = System.Drawing.Color.Black;

            InitializeComponent();
        }
    }
}
