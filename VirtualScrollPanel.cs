using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageComissioner
{
    public partial class VirtualScrollPanel : Control
    {
        private int scrollOffset = 0;
        private int itemHeight = 50;
        private int totalItems = 4000;

        VScrollBar vScrollBar = new VScrollBar
        {
            Dock = DockStyle.Left,
            Minimum = 0,
            Maximum = 4000,
            SmallChange = 1,
            LargeChange = 10
        };

        public VirtualScrollPanel()
        {
            this.DoubleBuffered = true; // Prevent flickering
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawVisibleItems(e.Graphics);
        }

        private void DrawVisibleItems(Graphics g)
        {
            int visibleCount = this.ClientSize.Height / itemHeight;

            for (int i = 0; i < visibleCount; i++)
            {
                int index = (scrollOffset / itemHeight) + i;
                if (index >= totalItems) break;

                Rectangle rect = new Rectangle(10, i * itemHeight, this.Width - 20, itemHeight);
                g.FillRectangle(Brushes.LightBlue, rect);
                g.DrawRectangle(Pens.Black, rect);
            }
        }

        protected void OnScroll(ScrollEventArgs e)
        {
            scrollOffset = e.NewValue * itemHeight;
            this.Invalidate();
        }
    }
}
