using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
namespace ORG.UILib.Controls
{
    public partial class ListBoxEx : ListBox
    {
        public ListBoxEx()
        {
            InitializeComponent();

        }

        public ListBoxEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


    }
}
