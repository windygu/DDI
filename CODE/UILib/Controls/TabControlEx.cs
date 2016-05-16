using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ORG.UILib.Controls
{
    /// <summary>
    /// 这个类支持的TabControl呈现正确使用bottom alignment时，style enabled。当它被禁用，则使用默认的渲染方法。
    /// </summary>
    public partial class TabControlEx : TabControl
    {
        private int imageclose = 15;

        private bool _showClose = true;

        /// <summary>
        /// 设置是否显示关闭按钮
        /// </summary>
        [Category("自定义"), Browsable(true), Description("设置是否显示关闭按钮")]
        public bool ShowClose
        {
            set { this._showClose = value; }
            get { return _showClose; }
        }
        /// <summary>
        /// 初始化一个新的实例 <see cref="T:VSControls.TabControlEx" /> 类.
        /// </summary>
        public TabControlEx()
        {
            
            this.Alignment = TabAlignment.Bottom;
            this.HotTrack = true;
            

            fUpDown = new NativeUpDown(this);

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(ExpTab_MouseDown);
            
        }

        



        private void ExpTab_MouseDown(object sender, MouseEventArgs e)
        {
            //判断该Tab页是否为添加按钮
            if (SelectedTab!=null && !String.IsNullOrEmpty(this.SelectedTab.Text))
            {
                if (e.Button == MouseButtons.Left)
                {
                    int x = e.X, y = e.Y;

                    //计算关闭区域      
                    Rectangle myTabRect = this.GetTabRect(this.SelectedIndex);

                    myTabRect.Offset(myTabRect.Width - (imageclose+3), (myTabRect.Height - imageclose)/2);
                    myTabRect.Width = imageclose;
                    myTabRect.Height = imageclose;

                    //如果鼠标在区域内就关闭选项卡      
                    bool isClose = x > myTabRect.X && x < myTabRect.Right
                     && y > myTabRect.Y && y < myTabRect.Bottom;

                    if (isClose == true)
                    {
                        this.TabPages.Remove(this.SelectedTab);
                    }
                }
            }

        }
        protected override void Dispose(bool disposing)
        {
            if (this.fSysFont != System.IntPtr.Zero)
            {
                NativeMethods.DeleteObject(this.fSysFont);
                this.fSysFont = System.IntPtr.Zero;
            }
            fUpDown.ReleaseHandle();
            base.Dispose(disposing);
        }

        #region Some overridden properties

        [Browsable(true), DefaultValue(TabAlignment.Bottom)]
        new public TabAlignment Alignment
        {
            get { return base.Alignment; }
            set { if (value <= TabAlignment.Bottom) base.Alignment = value; }
        }

        [Browsable(true), DefaultValue(true)]
        new public bool HotTrack
        {
            get { return base.HotTrack; }
            set { base.HotTrack = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        new public TabAppearance Appearance
        {
            get { return base.Appearance; }
            set { if (value == TabAppearance.Normal) base.Appearance = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        new public TabDrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { if (value == TabDrawMode.Normal) base.DrawMode = value; }
        }

        #endregion

        //此字段告诉我们是否开启自定义绘制。
        private bool fCustomDraw;

        /// <summary>
        /// 打开自定义绘制的开/关和设置本地字体控制（它所需的选项卡
        ///正确地调整它们的大小）。如果一个人没有手动安装本地字体，然后Windows会
        ///安装一个丑陋的控制系统字体。
        /// </summary>
        private void InitializeDrawMode()
        {
            this.fCustomDraw = Application.RenderWithVisualStyles && TabRenderer.IsSupported;

            this.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.DoubleBuffer|ControlStyles.ResizeRedraw|ControlStyles.SupportsTransparentBackColor, this.fCustomDraw);


            this.UpdateStyles();
            if (this.fCustomDraw) //将使用自定义绘制
            {
                if (this.fSysFont == IntPtr.Zero) this.fSysFont = this.Font.ToHfont();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.fSysFont, (IntPtr)1);
            }
            else //default drawing will be used
            {
                /* 请注意，在SendMessage调用下面我们无法删除HFONT传递给控制。如果我们这样做
                 *所以我们会看到一个丑陋的系统字体。我认为，在这种情况下，控制删除该字体本身
                 *当出售或确定。*/
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.Font.ToHfont(), (IntPtr)1);
                //但我们需要删除的字体（如果有的话）时创建的自定义绘制模式
                if (this.fSysFont != IntPtr.Zero)
                {
                    NativeMethods.DeleteObject(this.fSysFont);
                    this.fSysFont = IntPtr.Zero;
                }
            }
        }

        /* 用于自定义绘制的字体句柄。我们不使用这个原生的字体，但选项卡控件
         *调整大小的标签和标签滚动条的基础上，字体的大小。*/
        private IntPtr fSysFont = IntPtr.Zero;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            //已建立的控制之后，我们应该把自定义绘制的开/关等。
            InitializeDrawMode();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (this.fCustomDraw)
            {
                /* 控制自定义的绘制和管理的字体大小改变。我们应通知系统
                 *这样一个伟大的事件，它调整标签的大小。事实上，我们要创建一个新的
                 *本地字体管理1。*/
                if (this.fSysFont != IntPtr.Zero) NativeMethods.DeleteObject(this.fSysFont);
                this.fSysFont = this.Font.ToHfont();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.fSysFont, (IntPtr)1);
            }
        }

        protected override void WndProc(ref Message m)
        {
            /* 如果一个视觉主题的变化，我们必须重新初始化绘图模式，以防止被异常
             *切换时，抛出TabRenderer从视觉样式为“Windows经典”，反之亦然.*/
            if (m.Msg == NativeMethods.WM_THEMECHANGED) InitializeDrawMode();
            else if (m.Msg == NativeMethods.WM_PARENTNOTIFY && (m.WParam.ToInt32() & 0xffff) == NativeMethods.WM_CREATE)
            {
                /* 已创建标签滚动条（有太多的选项卡以显示和控制是不是多行），所以
                 *让我们的钩子。*/
                StringBuilder className = new StringBuilder(16);
                if (NativeMethods.RealGetWindowClass(m.LParam, className, 16) > 0 && className.ToString() == "msctls_updown32")
                {
                    fUpDown.ReleaseHandle();
                    fUpDown.AssignHandle(m.LParam);
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 绘制我们的选项卡控件。
        /// </summary>
        /// <param name="g">The <see cref="T:System.Drawing.Graphics"/> 用于绘制选项卡控制的对象.</param>
        /// <param name="clipRect">The <see cref="T:System.Drawing.Rectangle"/> the that specifies the clipping rectangle
        /// of the control.</param>
        private void DrawCustomTabControl(Graphics g, Rectangle clipRect)
        {
            
            /*在这个方法中，我们只绘制这些地区的控制相交的
             *剪辑矩形。这是某种形式的优化。*/
            if (!this.Visible) return;

            //所选的选项卡索引和矩形
            int iSel = this.SelectedIndex;
            Rectangle selRect = iSel != -1 ? this.GetTabRect(iSel) : Rectangle.Empty;

            Rectangle rcPage = this.ClientRectangle;
            //纠正页的矩形
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    {
                        int trunc = selRect.Height * this.RowCount + 2;
                        rcPage.Y += trunc; rcPage.Height -= trunc;
                    } break;
                case TabAlignment.Bottom: rcPage.Height -= selRect.Height * this.RowCount + 1;
                    break;
            }

            //显示页面本身
            if (rcPage.IntersectsWith(clipRect)) TabRenderer.DrawTabPage(g, rcPage);

            int tabCount = this.TabCount;
            if (tabCount == 0) return;

            //绘制未选中的标签
            this.lastHotIndex = HitTest();//hot tab
            VisualStyleRenderer tabRend = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
            for (int iTab = 0; iTab < tabCount; iTab++)
                if (iTab != iSel)
                {
                    Rectangle tabRect = this.GetTabRect(iTab);
                    if (tabRect.Right >= 3 && tabRect.IntersectsWith(clipRect))
                    {
                        TabItemState state = iTab == this.lastHotIndex ? TabItemState.Hot : TabItemState.Normal;
                        tabRend.SetParameters(tabRend.Class, tabRend.Part, (int)state);
                        DrawTabItem(g, iTab, tabRect, tabRend);
                    }
                }

            /*绘制一个选择的选项卡。我们也将增加选定的选项卡的矩形。它应该是一个小
             *大于其他选项卡。*/
            selRect.Inflate(2, 2);
            if (iSel != -1 && selRect.IntersectsWith(clipRect))
            {
                tabRend.SetParameters(tabRend.Class, tabRend.Part, (int)TabItemState.Selected);
                DrawTabItem(g, iSel, selRect, tabRend);
            }
        }

        /// <summary>
        /// 绘制一个选项卡。
        /// </summary>
        /// <param name="g">A <see cref="T:System.Drawing.Graphics"/> 对象，用于绘制标签控制。</param>
        /// <param name="index">正在制定的索引标签。</param>
        /// <param name="tabRect">A <see cref="T:System.Drawing.Rectangle"/> 对象指定标签的边界。</param>
        /// <param name="rend">A <see cref="T:System.Windows.Forms.VisualStyles.VisualStyleRenderer"/> 渲染“选项卡的对象。</param>
        private void DrawTabItem(Graphics g, int index, Rectangle tabRect, VisualStyleRenderer rend)
        {
            

            //如果滚动条是可见的，完全置于其下的“选项卡，我们不需要得出这样的标签
            if (fUpDown.X > 0 && tabRect.X >= fUpDown.X) return;

            bool tabSelected = rend.State == (int)TabItemState.Selected;
            // 我们将利用我们的选项卡上的位图，然后传输图像控制的图形上下文。
            using (GDIMemoryContext memGDI = new GDIMemoryContext(g, tabRect.Width, tabRect.Height))
            {
                Rectangle drawRect = new Rectangle(0, 0, tabRect.Width, tabRect.Height);
                rend.DrawBackground(memGDI.Graphics, drawRect);

                if (tabSelected && tabRect.X == 0)
                {
                    int corrY = memGDI.Height - 1;
                    memGDI.SetPixel(0, corrY, memGDI.GetPixel(0, corrY - 1));
                }
                /*一个重要的时刻。如果标签是底部对齐，我们应该翻转图像的显示选项卡
                 *正确*/
                if (this.Alignment == TabAlignment.Bottom) memGDI.FlipVertical();

                TabPage pg = this.TabPages[index];//标签页的选项卡，我们正在绘制
                //如果任何试图让一个标签图像
                Image pagePict = this.GetImageByIndexOrKey(pg.ImageIndex, pg.ImageKey);
                if (pagePict != null)
                {
                    //如果选项卡上的图像是值得我们借鉴。
                    Point imgLoc = new Point(tabSelected ? 8 : 6, 2);
                    int imgRight = imgLoc.X + pagePict.Width;

                    if (this.Alignment == TabAlignment.Bottom)
                        imgLoc.Y = drawRect.Bottom - pagePict.Height - (tabSelected ? 4 : 2);
                    if (RightToLeftLayout) imgLoc.X = drawRect.Right - imgRight;
                    memGDI.Graphics.DrawImageUnscaled(pagePict, imgLoc);
                    //修正矩形绘制文本。
                    drawRect.X += imgRight; 
                    drawRect.Width -= imgRight;
                }
                //绘制标签文本
                TextRenderer.DrawText(memGDI.Graphics, pg.Text, this.Font, drawRect, rend.GetColor(ColorProperty.TextColor),
                    TextFormatFlags.SingleLine | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                //如果该选项卡下滚动条的部分，我们不应该得出这样的部分。
                if (fUpDown.X > 0 && fUpDown.X >= tabRect.X && fUpDown.X < tabRect.Right)
                    tabRect.Width -= tabRect.Right - fUpDown.X;
                memGDI.DrawContextClipped(g, tabRect);

                if (ShowClose)
                {
                    DrawClose(g, index, tabRect);
                }
                else
                {
                    this.MouseDown -= new System.Windows.Forms.MouseEventHandler(ExpTab_MouseDown);
                }
            }
        }

        //画关闭按钮
        internal void DrawClose(Graphics g, int nIndex, Rectangle tabRect)
        {
            //获取当前Tab选项卡的绘图区域
            Rectangle myTabRect = tabRect;

            //判断该Tab页是否为添加按钮
            if (!String.IsNullOrEmpty(this.TabPages[nIndex].Text))
            {

                //再画一个矩形框   
                using (Pen p = new Pen(Color.Transparent))
                {
                    myTabRect.Offset(myTabRect.Width-(imageclose+3), (myTabRect.Height-imageclose)/2);
                    myTabRect.Width = imageclose;
                    myTabRect.Height = imageclose;
                    g.DrawRectangle(p, myTabRect);

                    

                }

                //画Tab选项卡右上方关闭按钮   
                using (Pen objpen = new Pen(Color.Red))
                {
                    //自己画X
                    //"\"线
                    //Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                    //Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                    //g.DrawLine(objpen, p1, p2);
                    ////"/"线
                    //Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                    //Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                    //g.DrawLine(objpen, p3, p4);

                    //获取绘图区域的开始坐标位置
                    Point p1 = new Point(myTabRect.X, myTabRect.Y);

                    //画关闭关闭按钮   
                    Bitmap bt = new Bitmap(Resources.closetab);
                    g.DrawImage(bt, p1);
                }
            }
        }

        /// <summary>
        /// 该函数尝试获得通过索引的第一个选项卡上的图像，或者，如果没有设置，然后按键。
        /// </summary>
        /// <param name="index">索引标签控制图像列表中的选项卡上的图像。</param>
        /// <param name="key">一个关键的选项卡控件选项卡上的图像在图像列表。</param>
        /// <returns><see cref="T:System.Drawing.Image"/> 表示图像的标签或空，如果没有设置。</returns>
        private Image GetImageByIndexOrKey(int index, string key)
        {
            if (this.ImageList == null) return null;
            else if (index > -1) return this.ImageList.Images[index];
            else if (key.Length > 0) return this.ImageList.Images[key];
            else return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            /*排序的一招：我们绘制在此控件的父控件的背景。要做到这一点的权利，
             我们要改变的“e”的父项的坐标系统后，我们就大功告成了，我们将重新回来。*/
            Point offsetPoint = this.Location;
            e.Graphics.TranslateTransform(-offsetPoint.X, -offsetPoint.Y);
            InvokePaintBackground(this.Parent, e);
            e.Graphics.TranslateTransform(offsetPoint.X, offsetPoint.Y);

            

            // 现在，我们要绘制选项卡控件本身。
            DrawCustomTabControl(e.Graphics, e.ClipRectangle);
        }

        /// <summary>
        /// 获取热Tab键索引。
        /// </summary>
        /// <returns>指数的标签，鼠标悬停或-1，如果鼠标没有在任何选项卡。</returns>
        private unsafe int HitTest()
        {
            NativeMethods.TCHITTESTINFO hti = new NativeMethods.TCHITTESTINFO();
            Point mousePos = this.PointToClient(TabControl.MousePosition);
            hti.pt.x = mousePos.X; hti.pt.y = mousePos.Y;
            return (int)NativeMethods.SendMessage(this.Handle, NativeMethods.TCM_HITTEST, IntPtr.Zero, (IntPtr)(&hti));
        }

        /* 我们一定要记住我们的原生UPDOWN钩的索引的最后热“选项卡，当鼠标移动到该选项卡正常透支。*/
        private int lastHotIndex = -1;

        //参考我们的钩子
        private NativeUpDown fUpDown;
    }
}