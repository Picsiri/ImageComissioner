namespace ImageComissioner
{
    partial class NewProjectDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxSource = new TextBox();
            buttonSource = new Button();
            labelSource = new Label();
            checkBoxRecurse = new CheckBox();
            buttonDestination = new Button();
            textBoxDestination = new TextBox();
            labelDestination = new Label();
            checkBoxZip = new CheckBox();
            buttonCancel = new Button();
            buttonCreate = new Button();
            textBoxTags = new TextBox();
            labelTags = new Label();
            SuspendLayout();
            // 
            // textBoxSource
            // 
            textBoxSource.Location = new Point(12, 27);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(489, 23);
            textBoxSource.TabIndex = 0;
            // 
            // buttonSource
            // 
            buttonSource.Location = new Point(507, 27);
            buttonSource.Name = "buttonSource";
            buttonSource.Size = new Size(75, 23);
            buttonSource.TabIndex = 1;
            buttonSource.Text = "Browse";
            buttonSource.UseVisualStyleBackColor = true;
            buttonSource.Click += buttonSource_Click;
            // 
            // labelSource
            // 
            labelSource.AutoSize = true;
            labelSource.Location = new Point(12, 9);
            labelSource.Name = "labelSource";
            labelSource.Size = new Size(117, 15);
            labelSource.TabIndex = 2;
            labelSource.Text = "Images source folder";
            // 
            // checkBoxRecurse
            // 
            checkBoxRecurse.AutoSize = true;
            checkBoxRecurse.Location = new Point(321, 8);
            checkBoxRecurse.Name = "checkBoxRecurse";
            checkBoxRecurse.Size = new Size(146, 19);
            checkBoxRecurse.TabIndex = 3;
            checkBoxRecurse.Text = "recurse into subfolders";
            checkBoxRecurse.UseVisualStyleBackColor = true;
            // 
            // buttonDestination
            // 
            buttonDestination.Location = new Point(507, 84);
            buttonDestination.Name = "buttonDestination";
            buttonDestination.Size = new Size(75, 23);
            buttonDestination.TabIndex = 5;
            buttonDestination.Text = "Browse";
            buttonDestination.UseVisualStyleBackColor = true;
            buttonDestination.Click += buttonDestination_Click;
            // 
            // textBoxDestination
            // 
            textBoxDestination.Location = new Point(12, 84);
            textBoxDestination.Name = "textBoxDestination";
            textBoxDestination.Size = new Size(489, 23);
            textBoxDestination.TabIndex = 4;
            // 
            // labelDestination
            // 
            labelDestination.AutoSize = true;
            labelDestination.Location = new Point(12, 66);
            labelDestination.Name = "labelDestination";
            labelDestination.Size = new Size(141, 15);
            labelDestination.TabIndex = 6;
            labelDestination.Text = "Images destination folder";
            // 
            // checkBoxZip
            // 
            checkBoxZip.AutoSize = true;
            checkBoxZip.Location = new Point(321, 65);
            checkBoxZip.Name = "checkBoxZip";
            checkBoxZip.Size = new Size(167, 19);
            checkBoxZip.TabIndex = 7;
            checkBoxZip.Text = "zip folders at comissioning";
            checkBoxZip.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(341, 141);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(241, 44);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(341, 215);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(241, 111);
            buttonCreate.TabIndex = 9;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // textBoxTags
            // 
            textBoxTags.AcceptsReturn = true;
            textBoxTags.Location = new Point(12, 141);
            textBoxTags.Multiline = true;
            textBoxTags.Name = "textBoxTags";
            textBoxTags.Size = new Size(295, 185);
            textBoxTags.TabIndex = 10;
            textBoxTags.KeyPress += textBoxTags_KeyPress;
            // 
            // labelTags
            // 
            labelTags.AutoSize = true;
            labelTags.Location = new Point(12, 123);
            labelTags.Name = "labelTags";
            labelTags.Size = new Size(154, 15);
            labelTags.TabIndex = 11;
            labelTags.Text = "Tags (each line will be a tag)";
            // 
            // NewProjectDialog
            // 
            AcceptButton = buttonCreate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            CancelButton = buttonCancel;
            ClientSize = new Size(601, 345);
            Controls.Add(labelTags);
            Controls.Add(textBoxTags);
            Controls.Add(buttonCreate);
            Controls.Add(buttonCancel);
            Controls.Add(checkBoxZip);
            Controls.Add(labelDestination);
            Controls.Add(buttonDestination);
            Controls.Add(textBoxDestination);
            Controls.Add(checkBoxRecurse);
            Controls.Add(labelSource);
            Controls.Add(buttonSource);
            Controls.Add(textBoxSource);
            MaximizeBox = false;
            Name = "NewProjectDialog";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "New Project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSource;
        private Button buttonSource;
        private Label labelSource;
        private CheckBox checkBoxRecurse;
        private Button buttonDestination;
        private TextBox textBoxDestination;
        private Label labelDestination;
        private CheckBox checkBoxZip;
        private Button buttonCancel;
        private Button buttonCreate;
        private TextBox textBoxTags;
        private Label labelTags;
    }
}