namespace FileSystemFAT
{
    partial class CreateDirectory
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxAttributes = new System.Windows.Forms.CheckedListBox();
            this.buttonCreateDirectory = new System.Windows.Forms.Button();
            this.textBoxDirectoryName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Атрибуты каталога (отмеченное - значит true)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Имя каталога";
            // 
            // checkedListBoxAttributes
            // 
            this.checkedListBoxAttributes.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxAttributes.FormattingEnabled = true;
            this.checkedListBoxAttributes.Items.AddRange(new object[] {
            "Скрытый"});
            this.checkedListBoxAttributes.Location = new System.Drawing.Point(15, 82);
            this.checkedListBoxAttributes.Name = "checkedListBoxAttributes";
            this.checkedListBoxAttributes.Size = new System.Drawing.Size(161, 64);
            this.checkedListBoxAttributes.TabIndex = 10;
            // 
            // buttonCreateDirectory
            // 
            this.buttonCreateDirectory.Location = new System.Drawing.Point(243, 123);
            this.buttonCreateDirectory.Name = "buttonCreateDirectory";
            this.buttonCreateDirectory.Size = new System.Drawing.Size(89, 23);
            this.buttonCreateDirectory.TabIndex = 9;
            this.buttonCreateDirectory.Text = "Создать";
            this.buttonCreateDirectory.UseVisualStyleBackColor = true;
            // 
            // textBoxDirectoryName
            // 
            this.textBoxDirectoryName.Location = new System.Drawing.Point(96, 15);
            this.textBoxDirectoryName.MaxLength = 8;
            this.textBoxDirectoryName.Name = "textBoxDirectoryName";
            this.textBoxDirectoryName.Size = new System.Drawing.Size(100, 20);
            this.textBoxDirectoryName.TabIndex = 7;
            // 
            // CreateDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 169);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxAttributes);
            this.Controls.Add(this.buttonCreateDirectory);
            this.Controls.Add(this.textBoxDirectoryName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateDirectory";
            this.Text = "CreateDirectory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxAttributes;
        private System.Windows.Forms.Button buttonCreateDirectory;
        private System.Windows.Forms.TextBox textBoxDirectoryName;
    }
}