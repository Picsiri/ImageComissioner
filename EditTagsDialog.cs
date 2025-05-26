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
    public partial class EditTagsDialog : Form
    {
        private List<string> allTags;

        public EditTagsDialog(List<string> tags)
        {
            InitializeComponent();
            allTags = new List<string>(tags); // Create a copy of the list
            listBoxTags.DataSource = new BindingSource(allTags, null);
        }

        public List<string> GetUpdatedTags() => allTags;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string newTag = textBoxNewTag.Text.Trim();
            if (!string.IsNullOrEmpty(newTag) && !allTags.Contains(newTag))
            {
                allTags.Add(newTag);
                listBoxTags.DataSource = new BindingSource(allTags, null); // Refresh list
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxTags.SelectedItem != null)
            {
                string? selectedTag = listBoxTags.SelectedItem.ToString();

                if (selectedTag != null)
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to remove this tag? This will remove all '{selectedTag}' tags from the images in this session!",
                                                          "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        allTags.Remove(selectedTag);
                        listBoxTags.DataSource = new BindingSource(allTags, null); // Refresh list
                    }
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Marks dialog as "confirmed"
            this.Close(); // Closes the dialog
        }
    }
}
