using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace ORG.UILib.Controls
{
    public partial class TreeViewEx : TreeView
    {
        public TreeViewEx()
        {
            InitializeComponent();
        }

        public TreeViewEx(IContainer container)
        {
            container.Add(this);
            this.BorderStyle = BorderStyle.None;
            InitializeComponent();
        }
    }
}
