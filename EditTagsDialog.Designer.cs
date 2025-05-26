namespace ImageComissioner
{
    partial class EditTagsDialog
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
            listBoxTags = new ListBox();
            buttonAdd = new Button();
            buttonRemove = new Button();
            buttonOK = new Button();
            buttonCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxNewTag = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxTags
            // 
            listBoxTags.Dock = DockStyle.Top;
            listBoxTags.FormattingEnabled = true;
            listBoxTags.ItemHeight = 15;
            listBoxTags.Location = new Point(0, 0);
            listBoxTags.Name = "listBoxTags";
            listBoxTags.Size = new Size(221, 214);
            listBoxTags.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Dock = DockStyle.Fill;
            buttonAdd.Location = new Point(3, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(104, 31);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Dock = DockStyle.Fill;
            buttonRemove.Location = new Point(113, 3);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(105, 31);
            buttonRemove.TabIndex = 1;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonOK
            // 
            buttonOK.Dock = DockStyle.Fill;
            buttonOK.Location = new Point(3, 40);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(104, 32);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Dock = DockStyle.Fill;
            buttonCancel.Location = new Point(113, 40);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(105, 32);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(buttonAdd, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonOK, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonCancel, 1, 1);
            tableLayoutPanel1.Controls.Add(buttonRemove, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 243);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(221, 75);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // textBoxNewTag
            // 
            textBoxNewTag.Dock = DockStyle.Fill;
            textBoxNewTag.Location = new Point(0, 214);
            textBoxNewTag.Name = "textBoxNewTag";
            textBoxNewTag.Size = new Size(221, 23);
            textBoxNewTag.TabIndex = 3;
            // 
            // EditTagsDialog
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(221, 318);
            Controls.Add(textBoxNewTag);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(listBoxTags);
            Name = "EditTagsDialog";
            Text = "Edit Tags";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxTags;
        private Button buttonAdd;
        private Button buttonRemove;
        private Button buttonOK;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxNewTag;
    }
}