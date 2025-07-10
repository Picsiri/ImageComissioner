using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComissioner
{
    public class ProgressForm : Form
    {
        public ProgressBar progressBar;
        public Label statusLabel;

        public ProgressForm(Form parent, int max)
        {
            this.Text = "Processing Images";
            this.Size = new Size(400, 100);
            this.StartPosition = FormStartPosition.Manual;

            // Center over parent
            if (parent != null)
            {
                this.Location = new Point(
                    parent.Location.X + (parent.Width - this.Width) / 2,
                    parent.Location.Y + (parent.Height - this.Height) / 2
                );
            }

            progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = max,
                Value = 0,
                Dock = DockStyle.Top,
                Height = 30
            };

            statusLabel = new Label
            {
                Text = "Starting...",
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(progressBar);
            Controls.Add(statusLabel);
        }

        public void UpdateProgress(int value, string text)
        {
            progressBar.Value = value;
            statusLabel.Text = text;
            Application.DoEvents(); // crude but enough for this basic UI
        }
    }

}
