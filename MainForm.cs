using ImageCommissioner;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ImageComissioner
{
    public partial class MainForm : Form
    {
        private static string allNoneText = "All/None";
        private static int thumbMargin = 70;
        private static string placeholderKey = "loading";
        private static ListViewItem loadingItem = new ListViewItem($"Image {placeholderKey}", placeholderKey);

        private bool ProjectOpen = false;
        private string ProjectSavePath = "";

        List<String> allTags = new List<String>();
        TaggedImage[] taggedImages = [];

        private ConcurrentDictionary<int, Image> _imageCache = [];
        private int _imageCacheLimit = 200;
        List<int> beingLoaded = [];

        TaggedImage? editedImage = null;
        int lastEditedImageIndex = 0;

        String sourcePath = "";
        String destinationPath = "";
        bool recurse = false;
        bool zipit = false;

        int previousThumbPanelWidth = 0;
        int thumbSquare = 0;

        public MainForm()
        {
            InitializeComponent();
            ResizeThumbnails();

#if DEBUG
            /*
            allTags.AddRange(["Woodcuts", "Weers", "Barnicles", "Buborek", "Younglings"]);

            RegenerateTagButtons();

            sourcePath = @"D:\Projects\ImageComissioner\debugImages\HD";
            recurse = true;

            RegenerateTaggedImagesArray();
            ResizeThumbnails();
            SetActiveImage(0);

            destinationPath = @"D:\Projects\ImageComissioner\debugImages\destination";
            */
#else

#endif
        }
        private void FlushCache()
        {
            int referenceIndex = 0;
            if (editedImage != null) referenceIndex = editedImage.Index;

            // Create a sorted list of indexes, ordered by descending distance to referenceIndex
            var keysToRemove = _imageCache.Keys
                .OrderByDescending(key => Math.Abs(key - referenceIndex)) // Sort by distance
                .Take(_imageCacheLimit / 2) // Select the first x farthest items
                .ToList();

            foreach (var key in keysToRemove)
            {
                _imageCache[key].Dispose();
                _imageCache.TryRemove(key, out _);
            }

            GC.Collect(); // Free memory after bulk removal
            Debug.WriteLine($"Removed {_imageCacheLimit / 2} farthest images from index {referenceIndex}. Cache size: {_imageCache.Count}");
        }

        private void CacheThumbnail(int index)
        {
            var thumb = ImageUtils.GetThumbnail(taggedImages[index].ImagePath, thumbSquare);
            if (_imageCache.Count >= _imageCacheLimit)
            {
                FlushCache();
            }
            _imageCache.TryAdd(index, thumb);
            Debug.WriteLine($"Image {index} added to cache");

            listViewThumb.Invoke(() =>
            {
                listViewThumb.Invalidate(listViewThumb.Items[index].Bounds);
            });
        }

        private void listViewThumb_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = loadingItem;

            // Thumbnail is already loaded
            if (_imageCache.TryGetValue(e.ItemIndex, out Image? value)) return;

            e.Item = new ListViewItem();

            //if (e.ItemIndex > taggedImages.Length) return;

            if (beingLoaded.Contains(e.ItemIndex)) return;
            beingLoaded.Add(e.ItemIndex);

            // Launch async task to load the real thumbnail
            Task.Run(() =>
            {
                CacheThumbnail(e.ItemIndex);
                beingLoaded.Remove(e.ItemIndex);
            });
        }

        private void listViewThumb_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;

            // Determine item index and key
            int index = e.ItemIndex;

            if (index == 4)
            {
                Debug.WriteLine($"Loading image");
            }

            // Select the image to draw
            Image? img = null;
            ;
            if (_imageCache.TryGetValue(index, out img))
            { }
            else
            {
                img = SystemIcons.Question.ToBitmap();
            }

            // Draw background
            if (e.Item.Selected)
            {
                g.FillRectangle(SystemBrushes.Highlight, bounds);
            }
            else
            {
                g.FillRectangle(SystemBrushes.Control, bounds);
            }

            // Draw image
            int imgX = bounds.X + (bounds.Width - img.Width) / 2;
            int imgY = bounds.Y + (bounds.Height - img.Height) / 2;
            g.DrawImage(img, new Rectangle(imgX, imgY, img.Width, img.Height));

            // Measure text size
            string label = $"Image {index + 1}";
            SizeF textSize = g.MeasureString(label, listViewThumb.Font);
            int textWidth = (int)textSize.Width;
            int textHeight = (int)textSize.Height;

            // Calculate text position
            int textX = bounds.X + (bounds.Width - textWidth) / 2;
            int textY = bounds.Bottom - textHeight;

            // Draw text background rectangle
            Rectangle textBackground = new Rectangle(textX, textY, textWidth, textHeight);
            g.FillRectangle(SystemBrushes.Control, textBackground); // Background color

            // Draw the text on top of the background
            TextRenderer.DrawText(g, label, listViewThumb.Font, new Point(textX, textY),
                SystemColors.WindowText);

        }

        private void ComissionImages()
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            // Ensure the tag folder exists
            foreach (string tag in allTags)
            {
                string tagFolder = Path.Combine(destinationPath, tag);

                if (!Directory.Exists(tagFolder))
                {
                    Directory.CreateDirectory(tagFolder);
                }
            }

            foreach (TaggedImage image in taggedImages)
            {
                foreach (string tag in image.Tags)
                {
                    string tagFolder = Path.Combine(destinationPath, tag);

                    // Prepare file name & handle clashes
                    string originalFileName = Path.GetFileNameWithoutExtension(image.ImagePath);
                    string extension = Path.GetExtension(image.ImagePath);
                    string destinationFile = Path.Combine(tagFolder, originalFileName + extension);

                    // Handle name clashes by adding a random suffix
                    Random random = new Random();
                    while (File.Exists(destinationFile))
                    {
                        int randomNumber = random.Next(10, 99); // Generate a random 2-digit number
                        destinationFile = Path.Combine(tagFolder, $"{originalFileName}_{randomNumber}{extension}");
                    }

                    try
                    {
                        File.Copy(image.ImagePath, destinationFile, false); // Overwrites if exists
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error copying {image.ImagePath}: {ex.Message}");
                    }
                }
            }
            if (zipit)
            {
                foreach (string tag in allTags)
                {
                    string tagFolder = Path.Combine(destinationPath, tag);
                    string zipFilePath = Path.Combine(destinationPath, $"{tag}.zip");
                    ZipFile.CreateFromDirectory(tagFolder, zipFilePath);
                    //Directory.Delete(tagFolder, true);
                }
            }
        }

        private void SetActiveImage(int index)
        {
            SaveTagsToEditedImage();

            if (index >= 0 && index < taggedImages.Length)
            {
                lastEditedImageIndex = index;
                editedImage = taggedImages[index];
                pictureBoxPreview.Image = Image.FromFile(editedImage.ImagePath);
                labelImageName.Text = Path.GetFileName(editedImage.ImagePath);
                labelImageName.Left = (pictureBoxPreview.Width - labelImageName.Width) / 2;

                labelProgress.Text = $"{lastEditedImageIndex + 1}/{taggedImages.Length}";
                labelProgress.Left = (pictureBoxPreview.Width - labelProgress.Width) - 5;

                LoadTagsFromEditedImage();
            }
        }

        private void SaveTagsToEditedImage()
        {
            if (editedImage == null) return; // Ensure there's an active image

            editedImage.Tags.Clear(); // Reset existing tags

            foreach (Control control in panelTag.Controls)
            {
                if (control is TagButton button)
                {
                    if (button.IsSelected && !button.IsAllTag)
                    {
                        editedImage.Tags.Add(button.Text.Trim()); // Add new tag
                    }
                }
            }
        }

        private void LoadTagsFromEditedImage()
        {
            int totalTags = panelTag.Controls.Count - 1; // Count all tag buttons except "All"
            int selectedTags = 0;
            TagButton? allTagButton = null;

            foreach (Control control in panelTag.Controls)
            {
                if (control is TagButton button)
                {
                    if (editedImage!.Tags.Contains(button.Text))
                    {
                        button.SelectTag();
                        selectedTags++;
                    }
                    else
                    {
                        button.DeselectTag();
                    }

                    // If this button is the "All" tag button, update its state
                    if (button.IsAllTag)
                    {
                        allTagButton = button;
                    }
                }
            }
            if (allTagButton != null && totalTags == selectedTags)
            {
                allTagButton.SelectTag();
            }
        }

        private void ResizeThumbnails()
        {
            int size = splitContainerThumbMain.Panel1.Width - thumbMargin;
            thumbSquare = Math.Max(Math.Min(256, size), 10);

            listViewThumb.LargeImageList = new ImageList
            {
                ImageSize = new Size(thumbSquare, thumbSquare)
            };
        }

        private void RegenerateTaggedImagesArray()
        {
            int index = 0; // Start the unique index counter

            string[] imagePaths = ImageUtils.GetImagePaths(sourcePath, recurse);
            taggedImages = imagePaths.Select(path => new TaggedImage(path, [], index++)).ToArray();
            listViewThumb.Enabled = true;
            listViewThumb.VirtualListSize = taggedImages.Length;
        }

        private void ToggleAllTags()
        {
            TagButton allNoneButton = (TagButton)panelTag.Controls[0];
            bool selection = allNoneButton.IsSelected;
            foreach (Control control in panelTag.Controls)
            {
                if (control is TagButton tagButton && tagButton != allNoneButton)
                {
                    if (selection)
                    {
                        tagButton.SelectTag();
                    }
                    else
                    {
                        tagButton.DeselectTag();
                    }
                }
            }
        }

        private void RegenerateTagButtons()
        {
            panelTag.Controls.Clear();
            panelTag.RowCount = (allTags.Count + 1) / panelTag.ColumnCount; // Adjust rows dynamically
            panelTag.RowStyles.Clear();

            for (int i = 0; i < panelTag.RowCount; i++)
            {
                panelTag.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / panelTag.RowCount));
            }

            TagButton allNoneButton = new TagButton(allNoneText, true);
            allNoneButton.Click += (s, e) => ToggleAllTags();
            panelTag.Controls.Add(allNoneButton);

            foreach (string tag in allTags)
            {
                panelTag.Controls.Add(new TagButton(tag));
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void splitContainerThumbMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (sender is SplitContainer splitContainer)
            {
                if (splitContainer.Panel1.Width != previousThumbPanelWidth)
                {
                    ResizeThumbnails();
                }
            }
        }

        private void editTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTagsToEditedImage();

            using (EditTagsDialog dialog = new(allTags))
            {
                List<string> oldtags = new(allTags); // Correctly clones the list

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    allTags = dialog.GetUpdatedTags(); // Update list after closing the dialog

                    // Loop through each tag in the old list, checking for missing ones
                    foreach (string oldTag in oldtags)
                    {
                        if (!allTags.Contains(oldTag)) // If a tag was removed
                        {
                            foreach (TaggedImage image in taggedImages) // Remove the missing tag from all images
                            {
                                image.Tags.Remove(oldTag);
                            }
                        }
                    }

                    RegenerateTagButtons();
                }
            }
        }

        private void comissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTagsToEditedImage();
            ComissionImages();
        }

        private void NewProject()
        {
            DialogResult result = MessageBox.Show(
            "Warning: This will override all unsaved data. Proceed?",
            "Confirm New Project",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result == DialogResult.No) return; // Cancel if user says "No"

            ShowNewProjectDialog();
        }

        private void ShowNewProjectDialog()
        {
            using (NewProjectDialog dialog = new(allNoneText))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ProjectOpen = true;
                    ProjectSavePath = "";

                    sourcePath = dialog.Source;
                    destinationPath = dialog.Destination;

                    recurse = dialog.Recurse;
                    zipit = dialog.Zipit;

                    allTags = dialog.Tags;

                    RegenerateTagButtons();
                    RegenerateTaggedImagesArray();
                    ResizeThumbnails();
                }
            }
        }

        private void OpenProject()
        {
            DialogResult result = MessageBox.Show(
                "Warning: Opening a project will override all unsaved data. Proceed?",
                "Confirm Open Project",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No) return; // Cancel if user says "No"

            ShowOpenProjectDialog();
        }

        private void ShowOpenProjectDialog()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Project Files (*.proj)|*.proj|All Files (*.*)|*.*";
                fileDialog.Title = "Select a Project File";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProjectOpen = true;
                    ProjectSavePath = fileDialog.FileName;
                    LoadProject();
                }
            }
        }

        private void ShowSaveProjectDialog()
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "Project Files (*.proj)|*.proj|All Files (*.*)|*.*";
                fileDialog.Title = "Save Project File";
                fileDialog.DefaultExt = "proj";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProjectSavePath = fileDialog.FileName;
                    SaveProject(); // Implement project saving logic
                }
            }
        }

        private void SaveProject()
        {
            ProjectData projectData = new()
            {
                SourcePath = sourcePath,
                DestinationPath = destinationPath,
                Recurse = recurse,
                Zipit = zipit,
                Tags = allTags,
                TaggedImages = taggedImages,
                LastEditedImage = lastEditedImageIndex
            };

            string json = JsonSerializer.Serialize(projectData);

            using FileStream fileStream = new FileStream(ProjectSavePath, FileMode.Create);
            using GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Compress);
            using StreamWriter writer = new StreamWriter(gzipStream);
            writer.Write(json);
        }

        private void LoadProject()
        {
            if (!File.Exists(ProjectSavePath)) return;

            using FileStream fileStream = new FileStream(ProjectSavePath, FileMode.Open);
            using GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress);
            using StreamReader reader = new StreamReader(gzipStream);
            string json = reader.ReadToEnd();
            var projectData = JsonSerializer.Deserialize<ProjectData>(json);

            if (projectData != null)
            {
                sourcePath = projectData.SourcePath;
                destinationPath = projectData.DestinationPath;
                recurse = projectData.Recurse;
                zipit = projectData.Zipit;
                allTags = projectData.Tags;
                taggedImages = projectData.TaggedImages;
                lastEditedImageIndex = projectData.LastEditedImage;

                listViewThumb.VirtualListSize = taggedImages.Length;

                RegenerateTagButtons();
                ResizeThumbnails();
                SetActiveImage(lastEditedImageIndex);
                SelectListViewItem();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProjectOpen) NewProject();
            else ShowNewProjectDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProjectOpen) OpenProject();
            else ShowOpenProjectDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTagsToEditedImage();
            if (ProjectSavePath == "") ShowSaveProjectDialog();
            else SaveProject();
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTagsToEditedImage();
            ShowSaveProjectDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ProjectOpen) saveToolStripMenuItem_Click(sender, e);
        }

        private void listViewThumb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewThumb.SelectedIndices.Count > 0)
            {
                int selectedIndex = listViewThumb.SelectedIndices[0];
                SetActiveImage(selectedIndex);
            }
        }

        private void SelectListViewItem()
        {
            listViewThumb.SelectedIndices.Clear();
            listViewThumb.Items[lastEditedImageIndex].Selected = true;
            listViewThumb.Items[lastEditedImageIndex].Focused = true;
            listViewThumb.EnsureVisible(lastEditedImageIndex);
        }

        private void listViewThumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left /*|| e.KeyCode == Keys.Up*/)
            {
                SetActiveImage(lastEditedImageIndex - 1);
                SelectListViewItem();
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevent beep sound!
            }
            else if (e.KeyCode == Keys.Right /*|| e.KeyCode == Keys.Down*/)
            {
                SetActiveImage(lastEditedImageIndex + 1);
                SelectListViewItem();
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevent beep sound!
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            int numberPressed = -1; // Default invalid number

            // Check if the key is a number (top row or numpad)
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                numberPressed = e.KeyCode - Keys.D0; // Convert top row key to int
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                numberPressed = e.KeyCode - Keys.NumPad0; // Convert numpad key to int
            }

            // If a valid number key was pressed, call the function
            if (numberPressed >= 0)
            {
                HandleNumberInput(numberPressed);
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevent beep sound!
            }
        }

        private void HandleNumberInput(int number)
        {
            if(panelTag.Controls.Count > number)
            {
                Debug.WriteLine($"Number pressed: {number}");
                ((TagButton)panelTag.Controls[number]).ToggleTag();
                if (number == 0) ToggleAllTags();
            }
        }
    }
}
