using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace ORG.UILib.Controls
{
    public partial class ListViewEx : ListView
    {
        public ListViewEx()
        {
            InitializeComponent();
        }

        public ListViewEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
