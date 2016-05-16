using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ORG.UILib.Controls
{
    partial class TabControlEx
    {
        /// <summary>
        /// 这个类表示UpDown控件用于滚动标签的低级别挂钩。我们需要知道的
        /// 位置的滚轮和正常时，画热“选项卡，从该选项卡中的鼠标移动到滚动条。
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        private class NativeUpDown : NativeWindow
        {
            public NativeUpDown(TabControlEx ctrl) { parentControl = ctrl; }

            private int x;

            private TabControlEx parentControl;

            /// <summary>
            /// 报告关于当前位置的标签滚动。
            /// </summary>
            public int X { get { return x; } }

            protected override void WndProc(ref Message m)
            {
                //如果本地UPDOWN被破坏，我们需要释放我们的钩子
                if (m.Msg == NativeMethods.WM_DESTROY || m.Msg == NativeMethods.WM_NCDESTROY)
                    this.ReleaseHandle();
                else if (m.Msg == NativeMethods.WM_WINDOWPOSCHANGING)
                {
                    //当滚动条位置发生变化时，我们应该记住，新的位置。
                    NativeMethods.WINDOWPOS wp = (NativeMethods.WINDOWPOS)m.GetLParam(typeof(NativeMethods.WINDOWPOS));
                    this.x = wp.x;
                }
                else if (m.Msg == NativeMethods.WM_MOUSEMOVE && parentControl.lastHotIndex > 0 &&
                    parentControl.lastHotIndex != parentControl.SelectedIndex)
                {
                    //作为正常的重绘前热片
                    using (Graphics context = Graphics.FromHwnd(parentControl.Handle))
                    {
                        VisualStyleRenderer rend = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
                        parentControl.DrawTabItem(context, parentControl.lastHotIndex, parentControl.GetTabRect(parentControl.lastHotIndex), rend);
                        if (parentControl.lastHotIndex - parentControl.SelectedIndex == 1)
                        {
                            Rectangle selRect = parentControl.GetTabRect(parentControl.SelectedIndex);
                            selRect.Inflate(2, 2);
                            rend.SetParameters(rend.Class, rend.Part, (int)TabItemState.Selected);
                            parentControl.DrawTabItem(context, parentControl.SelectedIndex, selRect, rend);
                        }
                    }
                }
                else if (m.Msg == NativeMethods.WM_LBUTTONDOWN)
                {
                    Rectangle invalidRect = parentControl.GetTabRect(parentControl.SelectedIndex);
                    invalidRect.X = 0; invalidRect.Width = 2;
                    invalidRect.Inflate(0, 2);
                    parentControl.Invalidate(invalidRect);
                }
                base.WndProc(ref m);
            }
        }
    }
}