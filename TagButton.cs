using System.Drawing;
using System.Windows.Forms;

namespace ImageCommissioner
{
    internal class TagButton : Button
    {
        private static readonly Color SelectedColor = Color.LightGreen;
        private static readonly Color DeselectedColor = SystemColors.Control;

        public bool IsSelected { get; private set; } = false; // Store selection state
        public bool IsAllTag { get; private set; } = false;
        public String TagName { get; private set; }
        private int BaseNumber;

        public TagButton(string tagName, bool isalltag = false)
        {
            Text = TagName = tagName;
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

            IsAllTag = isalltag;
        }

        public void ToggleTag()
        {
            if (IsSelected)
            {
                DeselectTag();
            }
            else
            {
                SelectTag();
            }
        }
        public void SelectTag()
        {
            IsSelected = true;
            BackColor = SelectedColor;
            UpdateText(1);
        }
        public void DeselectTag()
        {
            IsSelected = false;
            BackColor = DeselectedColor;
            UpdateText(0);
        }
        public void SetBaseNumber(int number)
        {
            BaseNumber = number;
        }
        private void UpdateText(int offset)
        {
            if (!IsAllTag)
            {
                Text = TagName + " (" + (BaseNumber + offset) + ")";
            }
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
