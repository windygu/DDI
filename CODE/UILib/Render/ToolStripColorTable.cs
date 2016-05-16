using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ORG.UILib.Render
{


    public class ToolStripColorTable
    {
        private static readonly Color _base = Color.Transparent;
        private static readonly Color _border = Color.FromArgb(216, 216, 216);
        private static readonly Color _backNormal = Color.FromArgb(255, 255, 255);
        private static readonly Color _backHover = Color.FromArgb(193, 235, 153);
        private static readonly Color _backPressed = Color.FromArgb(193, 235, 153);
        private static readonly Color _fore = Color.FromArgb(0, 0, 0);
        private static readonly Color _dropDownImageBack = Color.FromArgb(233, 238, 238);
        private static readonly Color _dropDownImageSeparator = Color.FromArgb(197, 197, 197);

        public ToolStripColorTable() { }

        public virtual Color Base
        {
            get { return _base; }
        }

        public virtual Color Border
        {
            get { return _border; }
        }

        public virtual Color BackNormal
        {
            get { return _backNormal; }
        }

        public virtual Color BackHover
        {
            get { return _backHover; }
        }

        public virtual Color BackPressed
        {
            get { return _backPressed; }
        }

        public virtual Color Fore
        {
            get { return _fore; }
        }

        public virtual Color DropDownImageBack
        {
            get { return _dropDownImageBack; }
        }

        public virtual Color DropDownImageSeparator
        {
            get { return _dropDownImageSeparator; }
        }
    }
}
