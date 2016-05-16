using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;


namespace ORG.UILib.Controls
{
    public partial class TableLayoutPanelEx : TableLayoutPanel
    {
        public TableLayoutPanelEx()
        {
            InitializeComponent();
        }

        public TableLayoutPanelEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
