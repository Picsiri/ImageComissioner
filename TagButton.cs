using System.Drawing;
using System.Windows.Forms;

namespace ImageCommissioner
{
    internal class TagButton : Button
    {
        private static readonly Color SelectedColor = Color.LightGreen;
        private static readonly Color DeselectedColor = SystemColors.Control;

        public bool IsSelected { get; private set; } = false; // Store selection state

        public TagButton(string tagName)
        {
            Text = tagName;
            Font = new Font("Arial", 12, FontStyle.Bold);
            Dock = DockStyle.Fill;
            FlatStyle = FlatStyle.Flat;
            BackColor = DeselectedColor;

            // Override hover behavior
            SetStyle(ControlStyles.Selectable, false);
            FlatAppearance.MouseOverBackColor = BackColor;
            FlatAppearance.MouseDownBackColor = BackColor;

            // Toggle selection on click
            Click += (s, e) => ToggleTag();
        }

        private void ToggleTag()
        {
            IsSelected = !IsSelected;
            BackColor = IsSelected ? SelectedColor : DeselectedColor;
        }
        public void SelectTag()
        {
            IsSelected = true;
            BackColor = SelectedColor;
        }

        public void DeselectTag()
        {
            IsSelected = false;
            BackColor = DeselectedColor;
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            // Do nothing (Prevents hover effect)
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            // Do nothing (Prevents hover effect)
        }
    }
}
