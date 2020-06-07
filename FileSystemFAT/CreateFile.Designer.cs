namespace FileSystemFAT
{
    partial class CreateFile
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
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.textBoxFileExt = new System.Windows.Forms.TextBox();
            this.buttonCreateFile = new System.Windows.Forms.Button();
            this.checkedListBoxAttributes = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(76, 12);
            this.textBoxFileName.MaxLength = 8;
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFileName.TabIndex = 0;
            // 
            // textBoxFileExt
            // 
            this.textBoxFileExt.Location = new System.Drawing.Point(314, 12);
            this.textBoxFileExt.MaxLength = 3;
            this.textBoxFileExt.Name = "textBoxFileExt";
            this.textBoxFileExt.Size = new System.Drawing.Size(100, 20);
            this.textBoxFileExt.TabIndex = 1;
            // 
            // buttonCreateFile
            // 
            this.buttonCreateFile.Location = new System.Drawing.Point(325, 120);
            this.buttonCreateFile.Name = "buttonCreateFile";
            this.buttonCreateFile.Size = new System.Drawing.Size(89, 23);
            this.buttonCreateFile.TabIndex = 2;
            this.buttonCreateFile.Text = "Создать";
            this.buttonCreateFile.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxAttributes
            // 
            this.checkedListBoxAttributes.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxAttributes.FormattingEnabled = true;
            this.checkedListBoxAttributes.Items.AddRange(new object[] {
            "Только для чтения",
            "Скрытый",
            "Системный",
            "Архивный"});
            this.checkedListBoxAttributes.Location = new System.Drawing.Point(9, 79);
            this.checkedListBoxAttributes.Name = "checkedListBoxAttributes";
            this.checkedListBoxAttributes.Size = new System.Drawing.Size(161, 64);
            this.checkedListBoxAttributes.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя файла";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Расширение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Атрибуты файла (отмеченное - значит true)";
            // 
            // CreateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 161);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxAttributes);
            this.Controls.Add(this.buttonCreateFile);
            this.Controls.Add(this.textBoxFileExt);
            this.Controls.Add(this.textBoxFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateFile";
            this.Text = "CreateFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.TextBox textBoxFileExt;
        private System.Windows.Forms.Button buttonCreateFile;
        private System.Windows.Forms.CheckedListBox checkedListBoxAttributes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}