namespace ImageComissioner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainerThumbMain = new SplitContainer();
            listViewThumb = new ListView();
            splitContainerPreviewTags = new SplitContainer();
            labelImageName = new Label();
            pictureBoxPreview = new PictureBox();
            panelTag = new TableLayoutPanel();
            menuStrip = new MenuStrip();
            fiToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveProjectAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            editTagsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            comissionToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainerThumbMain).BeginInit();
            splitContainerThumbMain.Panel1.SuspendLayout();
            splitContainerThumbMain.Panel2.SuspendLayout();
            splitContainerThumbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerPreviewTags).BeginInit();
            splitContainerPreviewTags.Panel1.SuspendLayout();
            splitContainerPreviewTags.Panel2.SuspendLayout();
            splitContainerPreviewTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerThumbMain
            // 
            splitContainerThumbMain.BackColor = SystemColors.ActiveBorder;
            splitContainerThumbMain.Dock = DockStyle.Fill;
            splitContainerThumbMain.FixedPanel = FixedPanel.Panel1;
            splitContainerThumbMain.Location = new Point(0, 24);
            splitContainerThumbMain.Name = "splitContainerThumbMain";
            // 
            // splitContainerThumbMain.Panel1
            // 
            splitContainerThumbMain.Panel1.Controls.Add(listViewThumb);
            // 
            // splitContainerThumbMain.Panel2
            // 
            splitContainerThumbMain.Panel2.Controls.Add(splitContainerPreviewTags);
            splitContainerThumbMain.Size = new Size(1300, 536);
            splitContainerThumbMain.SplitterDistance = 256;
            splitContainerThumbMain.SplitterWidth = 5;
            splitContainerThumbMain.TabIndex = 0;
            splitContainerThumbMain.TabStop = false;
            splitContainerThumbMain.SplitterMoved += splitContainerThumbMain_SplitterMoved;
            splitContainerThumbMain.SizeChanged += settingsToolStripMenuItem_Click;
            // 
            // listViewThumb
            // 
            listViewThumb.Dock = DockStyle.Fill;
            listViewThumb.Location = new Point(0, 0);
            listViewThumb.MultiSelect = false;
            listViewThumb.Name = "listViewThumb";
            listViewThumb.OwnerDraw = true;
            listViewThumb.ShowGroups = false;
            listViewThumb.Size = new Size(256, 536);
            listViewThumb.TabIndex = 0;
            listViewThumb.UseCompatibleStateImageBehavior = false;
            listViewThumb.VirtualMode = true;
            listViewThumb.DrawItem += listViewThumb_DrawItem;
            listViewThumb.RetrieveVirtualItem += listViewThumb_RetrieveVirtualItem;
            listViewThumb.SelectedIndexChanged += listViewThumb_SelectedIndexChanged;
            // 
            // splitContainerPreviewTags
            // 
            splitContainerPreviewTags.Dock = DockStyle.Fill;
            splitContainerPreviewTags.FixedPanel = FixedPanel.Panel2;
            splitContainerPreviewTags.Location = new Point(0, 0);
            splitContainerPreviewTags.Name = "splitContainerPreviewTags";
            // 
            // splitContainerPreviewTags.Panel1
            // 
            splitContainerPreviewTags.Panel1.Controls.Add(labelImageName);
            splitContainerPreviewTags.Panel1.Controls.Add(pictureBoxPreview);
            // 
            // splitContainerPreviewTags.Panel2
            // 
            splitContainerPreviewTags.Panel2.Controls.Add(panelTag);
            splitContainerPreviewTags.Size = new Size(1039, 536);
            splitContainerPreviewTags.SplitterDistance = 750;
            splitContainerPreviewTags.SplitterWidth = 5;
            splitContainerPreviewTags.TabIndex = 0;
            splitContainerPreviewTags.TabStop = false;
            // 
            // labelImageName
            // 
            labelImageName.Anchor = AnchorStyles.Top;
            labelImageName.AutoSize = true;
            labelImageName.BackColor = SystemColors.Control;
            labelImageName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelImageName.Location = new Point(335, 8);
            labelImageName.Name = "labelImageName";
            labelImageName.Size = new Size(142, 21);
            labelImageName.TabIndex = 1;
            labelImageName.Text = "labelImageName";
            labelImageName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BackColor = SystemColors.Control;
            pictureBoxPreview.Dock = DockStyle.Fill;
            pictureBoxPreview.Location = new Point(0, 0);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(750, 536);
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreview.TabIndex = 0;
            pictureBoxPreview.TabStop = false;
            // 
            // panelTag
            // 
            panelTag.BackColor = SystemColors.Control;
            panelTag.ColumnCount = 1;
            panelTag.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelTag.Dock = DockStyle.Fill;
            panelTag.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            panelTag.Location = new Point(0, 0);
            panelTag.Name = "panelTag";
            panelTag.RowCount = 1;
            panelTag.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelTag.Size = new Size(284, 536);
            panelTag.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fiToolStripMenuItem, settingsToolStripMenuItem, languageToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1300, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // fiToolStripMenuItem
            // 
            fiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveProjectAsToolStripMenuItem, toolStripSeparator1, editTagsToolStripMenuItem, toolStripSeparator2, comissionToolStripMenuItem });
            fiToolStripMenuItem.Name = "fiToolStripMenuItem";
            fiToolStripMenuItem.Size = new Size(37, 20);
            fiToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(161, 22);
            newToolStripMenuItem.Text = "New project";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(161, 22);
            openToolStripMenuItem.Text = "Open project";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(161, 22);
            saveToolStripMenuItem.Text = "Save project";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveProjectAsToolStripMenuItem
            // 
            saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            saveProjectAsToolStripMenuItem.Size = new Size(161, 22);
            saveProjectAsToolStripMenuItem.Text = "Save project as...";
            saveProjectAsToolStripMenuItem.Click += saveProjectAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(158, 6);
            // 
            // editTagsToolStripMenuItem
            // 
            editTagsToolStripMenuItem.Name = "editTagsToolStripMenuItem";
            editTagsToolStripMenuItem.Size = new Size(161, 22);
            editTagsToolStripMenuItem.Text = "Edit tags";
            editTagsToolStripMenuItem.Click += editTagsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(158, 6);
            // 
            // comissionToolStripMenuItem
            // 
            comissionToolStripMenuItem.Name = "comissionToolStripMenuItem";
            comissionToolStripMenuItem.Size = new Size(161, 22);
            comissionToolStripMenuItem.Text = "Comission";
            comissionToolStripMenuItem.Click += comissionToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new Size(71, 20);
            languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            englishToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.CheckState = CheckState.Checked;
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Size = new Size(112, 22);
            englishToolStripMenuItem.Text = "English";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 560);
            Controls.Add(splitContainerThumbMain);
            Controls.Add(menuStrip);
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "Image Comissioner";
            FormClosing += MainForm_FormClosing;
            PreviewKeyDown += MainForm_PreviewKeyDown;
            splitContainerThumbMain.Panel1.ResumeLayout(false);
            splitContainerThumbMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerThumbMain).EndInit();
            splitContainerThumbMain.ResumeLayout(false);
            splitContainerPreviewTags.Panel1.ResumeLayout(false);
            splitContainerPreviewTags.Panel1.PerformLayout();
            splitContainerPreviewTags.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerPreviewTags).EndInit();
            splitContainerPreviewTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainerThumbMain;
        private SplitContainer splitContainerPreviewTags;
        private PictureBox pictureBoxPreview;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fiToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private TableLayoutPanel panelTag;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem editTagsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem comissionToolStripMenuItem;
        private Label labelImageName;
        private ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private ListView listViewThumb;
    }
}
