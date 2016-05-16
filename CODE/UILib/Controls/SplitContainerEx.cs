using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ORG.UILib.Controls
{
    public partial class SplitContainerEx : SplitContainer
    {
        public SplitContainerEx()
        {
            InitializeComponent();
        }

        public SplitContainerEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
