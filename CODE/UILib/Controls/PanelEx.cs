using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ORG.UILib.Controls
{
    public partial class PanelEx : Panel
    {
        public PanelEx()
        {
            InitializeComponent();
        }

        public PanelEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
