using ImageCommissioner;

namespace ImageComissioner
{
    public partial class MainForm : Form
    {
        List<String> allTags = new List<String>();
        TaggedImage[] taggedImages;

        TaggedImage editedImage;

        String sourcePath;
        bool recurse;
        String destinationPath;

        String previewPath;

        int previousThumbWidth = 0;
        int activeIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            previousThumbWidth = splitContainerThumbMain.Panel1.Width;

#if DEBUG
            allTags.AddRange(["Woodcuts", "Weers", "Barnicles", "Buborek", "Younglings"]);

            RegenerateTagButtons();

            sourcePath = @"D:\Projects\ImageComissioner\debugImages\HD";
            recurse = true;

            RegenerateTaggedImagesArray();
            RegenerateThumbnails();
            SetActiveImage(0);


            destinationPath = @"D:\Projects\ImageComissioner\debugImages\destination";

            //ComissionImages();

#endif
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
        }

        private void SetActiveImage(int index)
        {
            SaveTagsToEditedImage();

            activeIndex = index;
            editedImage = taggedImages[index];
            pictureBoxPreview.Image = Image.FromFile(editedImage.ImagePath);
            labelImageName.Text = Path.GetFileName(editedImage.ImagePath);
            labelImageName.Left = (pictureBoxPreview.Width - labelImageName.Width) / 2;

            LoadTagsFromEditedImage();
        }

        private void SaveTagsToEditedImage()
        {
            if (editedImage == null) return; // Ensure there's an active image

            editedImage.Tags.Clear(); // Reset existing tags

            foreach (Control control in panelTag.Controls)
            {
                if (control is TagButton button)
                {
                    if (button.IsSelected)
                    {
                        editedImage.Tags.Add(button.Text.Trim()); // Add new tag
                    }
                }
            }
        }
        private void LoadTagsFromEditedImage()
        {
            if (editedImage == null) return; // Ensure there's an active image

            foreach (Control control in panelTag.Controls)
            {
                if (control is TagButton button)
                {
                    if (editedImage.Tags.Contains(button.Text))
                    {
                        button.SelectTag();
                    }
                    else
                    {
                        button.DeselectTag();
                    }
                }
            }
        }



        private void RegenerateThumbnails()
        {
            panelThumb.Controls.Clear(); // Clear existing thumbnails before adding new ones

            foreach (var taggedImages in taggedImages)
            {
                PictureBox thumbnail = new PictureBox
                {
                    Image = Image.FromFile(taggedImages.ImagePath),
                    SizeMode = PictureBoxSizeMode.Zoom, // Keeps aspect ratio
                    Cursor = Cursors.Hand // Indicates interactivity
                };

                thumbnail.BorderStyle = BorderStyle.FixedSingle; // Add a visible border

                // When clicked, display the main image
                thumbnail.Click += (s, e) => SetActiveImage(taggedImages.Index);

                panelThumb.Controls.Add(thumbnail);
            }

            resizeThumbnails(panelThumb.Width);
        }


        private void RegenerateTaggedImagesArray()
        {
            int index = 0; // Start the unique index counter

            string[] imagePaths = ImageUtils.GetImagePaths(sourcePath, recurse);
            taggedImages = imagePaths.Select(path => new TaggedImage(path, index++)).ToArray();

        }

        private void RegenerateTagButtons()
        {
            panelTag.Controls.Clear();
            panelTag.RowCount = allTags.Count / panelTag.ColumnCount; // Adjust rows dynamically
            panelTag.RowStyles.Clear();

            for (int i = 0; i < panelTag.RowCount; i++)
            {
                panelTag.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / panelTag.RowCount));
            }

            foreach (string tag in allTags)
            {
                panelTag.Controls.Add(new TagButton(tag));
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void resizeThumbnails(int size)
        {
            foreach (PictureBox thumb in panelThumb.Controls)
            {
                thumb.Width = size - SystemInformation.VerticalScrollBarWidth; // Fit width
                thumb.Height = thumb.Image.Width > thumb.Image.Height
                    ? (int)(thumb.Width * 0.6)  // Landscape: 0.75x width
                    : (int)(thumb.Width * 1.5);  // Portrait: 1.5x width
            }

            previousThumbWidth = size;
        }

        private void splitContainerThumbMain_SizeChanged(object sender, EventArgs e)
        {
            if (sender is SplitContainer splitContainer)
            {
                if (splitContainer.Panel1.Width != previousThumbWidth)
                {
                    resizeThumbnails(splitContainer.Panel1.Width);
                }
            }
        }

        private void splitContainerThumbMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (sender is SplitContainer splitContainer)
            {
                if (splitContainer.Panel1.Width != previousThumbWidth)
                {
                    resizeThumbnails(splitContainer.Panel1.Width);
                }
            }
        }

        private void editTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditTagsDialog dialog = new(allTags))
            {
                List<string> oldtags = new(allTags); // Correctly clones the list

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    allTags = dialog.GetUpdatedTags(); // Update list after closing the dialog
                }

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
            }
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                if (activeIndex > 0) // Ensure index doesn't go below zero
                    SetActiveImage(activeIndex - 1);
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                if (activeIndex < taggedImages.Count() - 1) // Prevent going out of bounds
                    SetActiveImage(activeIndex + 1);
            }
        }

        private void comissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTagsToEditedImage();
            ComissionImages();
        }
    }
}
