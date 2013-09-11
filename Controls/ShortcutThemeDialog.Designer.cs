namespace ShortcutThemes.Controls
{
    partial class ShortcutThemeDialog
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
            this.themesLabel = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.themes = new System.Windows.Forms.ListView();
            this.themesHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.apply = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // themesLabel
            // 
            this.themesLabel.AutoSize = true;
            this.themesLabel.Location = new System.Drawing.Point(12, 9);
            this.themesLabel.Name = "themesLabel";
            this.themesLabel.Size = new System.Drawing.Size(45, 13);
            this.themesLabel.TabIndex = 0;
            this.themesLabel.Text = "Themes";
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(197, 157);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 6;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // themes
            // 
            this.themes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.themes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.themesHeader});
            this.themes.FullRowSelect = true;
            this.themes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.themes.Location = new System.Drawing.Point(12, 25);
            this.themes.MultiSelect = false;
            this.themes.Name = "themes";
            this.themes.Size = new System.Drawing.Size(260, 126);
            this.themes.TabIndex = 7;
            this.themes.UseCompatibleStateImageBehavior = false;
            this.themes.View = System.Windows.Forms.View.Details;
            this.themes.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.themes_ItemSelectionChanged);
            this.themes.ClientSizeChanged += new System.EventHandler(this.themes_ClientSizeChanged);
            // 
            // apply
            // 
            this.apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.apply.Enabled = false;
            this.apply.Location = new System.Drawing.Point(12, 157);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 8;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.save.Location = new System.Drawing.Point(93, 157);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 9;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // openFile
            // 
            this.openFile.Filter = "Shortcut Keys (*.keys)|*.keys|All Files (*.*)|*.*";
            // 
            // saveFile
            // 
            this.saveFile.Filter = "Shortcut Keys (*.keys)|*.keys|All Files (*.*)|*.*";
            // 
            // ShortcutThemeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.save);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.themes);
            this.Controls.Add(this.close);
            this.Controls.Add(this.themesLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 230);
            this.Name = "ShortcutThemeDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shortcut Themes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label themesLabel;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.ListView themes;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.ColumnHeader themesHeader;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}