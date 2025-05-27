using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageComissioner
{
    public partial class NewProjectDialog : Form
    {
        private string AllNoneText;
        public string Source { get; private set; }
        public string Destination { get; private set; }
        public bool Recurse { get; private set; }
        public bool Zipit { get; private set; }
        public List<string> Tags { get; private set; } = [];

        public NewProjectDialog(string allnonetext)
        {
            InitializeComponent();

            AllNoneText = allnonetext;

            Source = "";
            Destination = "";
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxSource.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void buttonDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestination.Text = folderDialog.SelectedPath;
                }
            }
        }

        private static readonly char[] separator = ['\n', '\r'];

        private bool TagsAreCorrect()
        {
            var tagSet = new HashSet<string>(); // Ensures uniqueness
            foreach (string line in textBoxTags.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                string tag = line.Trim();
                if (string.IsNullOrEmpty(tag) || tag.Equals(AllNoneText))
                {
                    return false; // Invalid tag detected
                }
                if (Regex.IsMatch(tag, @"[^a-zA-Z0-9 ]"))
                {
                    return false; // Reject tags with special characters
                }
                if (!tagSet.Add(tag)) // If already exists in HashSet, it's duplicate
                {
                    return false;
                }
            }
            Tags = [.. tagSet];

            return true; // All tags are valid
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Source = textBoxSource.Text.Trim();
            Destination = textBoxDestination.Text.Trim();

            if (string.IsNullOrEmpty(Source) || string.IsNullOrEmpty(Destination))
            {
                MessageBox.Show("Please select both source and destination folders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Source == Destination)
            {
                MessageBox.Show("Please select different source and destination folders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TagsAreCorrect())
            {
                MessageBox.Show("Please check tags for correct input. No repeats, no empty lines, no special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Recurse = checkBoxRecurse.Checked;
            Zipit = checkBoxZip.Checked;

            DialogResult = DialogResult.OK; // Close dialog with success
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Close without applying changes
            Close();
        }

        private void textBoxTags_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Stops the event from reaching the default button
                ((TextBox)sender).AppendText(Environment.NewLine);
            }
        }
    }

}
