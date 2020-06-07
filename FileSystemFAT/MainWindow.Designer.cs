namespace FileSystemFAT
{
    partial class MainWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDirictories = new System.Windows.Forms.GroupBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.textBoxNextSubdirectory = new System.Windows.Forms.TextBox();
            this.buttonLeaveCurrentDirectory = new System.Windows.Forms.Button();
            this.buttonNextSubdirectory = new System.Windows.Forms.Button();
            this.buttonCreateSubDirectory = new System.Windows.Forms.Button();
            this.groupBoxFiles = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxChangeAttributes = new System.Windows.Forms.TextBox();
            this.buttonChangeAttributes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRemoveFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRevriteFile = new System.Windows.Forms.TextBox();
            this.buttonAcceptChanges = new System.Windows.Forms.Button();
            this.buttonRemoveFile = new System.Windows.Forms.Button();
            this.buttonRewriteFile = new System.Windows.Forms.Button();
            this.buttonCreateFile = new System.Windows.Forms.Button();
            this.panelFileStatus = new System.Windows.Forms.Panel();
            this.textBoxRewriteFile = new System.Windows.Forms.TextBox();
            this.panelDirectoryStatus = new System.Windows.Forms.Panel();
            this.textBoxSubdirectories = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxDirictories.SuspendLayout();
            this.groupBoxFiles.SuspendLayout();
            this.panelFileStatus.SuspendLayout();
            this.panelDirectoryStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(967, 522);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(967, 20);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.statusStrip1.MouseHover += new System.EventHandler(this.statusStrip1_MouseHover);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 15);
            this.toolStripStatusLabel1.Text = "Будет выполнено: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 15);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxDirictories, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxFiles, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelFileStatus, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelDirectoryStatus, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(961, 496);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBoxDirictories
            // 
            this.groupBoxDirictories.Controls.Add(this.labelFileName);
            this.groupBoxDirictories.Controls.Add(this.textBoxNextSubdirectory);
            this.groupBoxDirictories.Controls.Add(this.buttonLeaveCurrentDirectory);
            this.groupBoxDirictories.Controls.Add(this.buttonNextSubdirectory);
            this.groupBoxDirictories.Controls.Add(this.buttonCreateSubDirectory);
            this.groupBoxDirictories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDirictories.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDirictories.Name = "groupBoxDirictories";
            this.groupBoxDirictories.Size = new System.Drawing.Size(378, 192);
            this.groupBoxDirictories.TabIndex = 0;
            this.groupBoxDirictories.TabStop = false;
            this.groupBoxDirictories.Text = "Управление каталогами";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(275, 67);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(91, 13);
            this.labelFileName.TabIndex = 4;
            this.labelFileName.Text = "Имя директории";
            // 
            // textBoxNextSubdirectory
            // 
            this.textBoxNextSubdirectory.Location = new System.Drawing.Point(145, 64);
            this.textBoxNextSubdirectory.MaxLength = 8;
            this.textBoxNextSubdirectory.Name = "textBoxNextSubdirectory";
            this.textBoxNextSubdirectory.Size = new System.Drawing.Size(124, 20);
            this.textBoxNextSubdirectory.TabIndex = 3;
            // 
            // buttonLeaveCurrentDirectory
            // 
            this.buttonLeaveCurrentDirectory.Location = new System.Drawing.Point(7, 92);
            this.buttonLeaveCurrentDirectory.Name = "buttonLeaveCurrentDirectory";
            this.buttonLeaveCurrentDirectory.Size = new System.Drawing.Size(132, 35);
            this.buttonLeaveCurrentDirectory.TabIndex = 2;
            this.buttonLeaveCurrentDirectory.Text = "Покинуть текущий каталог";
            this.buttonLeaveCurrentDirectory.UseVisualStyleBackColor = true;
            this.buttonLeaveCurrentDirectory.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.buttonLeaveCurrentDirectory.MouseHover += new System.EventHandler(this.buttonLeaveCurrentDirectory_MouseHover);
            // 
            // buttonNextSubdirectory
            // 
            this.buttonNextSubdirectory.Location = new System.Drawing.Point(7, 61);
            this.buttonNextSubdirectory.Name = "buttonNextSubdirectory";
            this.buttonNextSubdirectory.Size = new System.Drawing.Size(132, 24);
            this.buttonNextSubdirectory.TabIndex = 1;
            this.buttonNextSubdirectory.Text = "Перейти в подкаталог";
            this.buttonNextSubdirectory.UseVisualStyleBackColor = true;
            this.buttonNextSubdirectory.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.buttonNextSubdirectory.MouseHover += new System.EventHandler(this.buttonNextSubdirectory_MouseHover);
            // 
            // buttonCreateSubDirectory
            // 
            this.buttonCreateSubDirectory.Location = new System.Drawing.Point(6, 31);
            this.buttonCreateSubDirectory.Name = "buttonCreateSubDirectory";
            this.buttonCreateSubDirectory.Size = new System.Drawing.Size(133, 23);
            this.buttonCreateSubDirectory.TabIndex = 0;
            this.buttonCreateSubDirectory.Text = "Создать подкаталог";
            this.buttonCreateSubDirectory.UseVisualStyleBackColor = true;
            this.buttonCreateSubDirectory.Click += new System.EventHandler(this.buttonCreateSubDirectory_Click);
            this.buttonCreateSubDirectory.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.buttonCreateSubDirectory.MouseHover += new System.EventHandler(this.buttonCreateSubDirectory_MouseHover);
            // 
            // groupBoxFiles
            // 
            this.groupBoxFiles.Controls.Add(this.label3);
            this.groupBoxFiles.Controls.Add(this.textBoxChangeAttributes);
            this.groupBoxFiles.Controls.Add(this.buttonChangeAttributes);
            this.groupBoxFiles.Controls.Add(this.label2);
            this.groupBoxFiles.Controls.Add(this.textBoxRemoveFile);
            this.groupBoxFiles.Controls.Add(this.label1);
            this.groupBoxFiles.Controls.Add(this.textBoxRevriteFile);
            this.groupBoxFiles.Controls.Add(this.buttonAcceptChanges);
            this.groupBoxFiles.Controls.Add(this.buttonRemoveFile);
            this.groupBoxFiles.Controls.Add(this.buttonRewriteFile);
            this.groupBoxFiles.Controls.Add(this.buttonCreateFile);
            this.groupBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFiles.Location = new System.Drawing.Point(3, 201);
            this.groupBoxFiles.Name = "groupBoxFiles";
            this.groupBoxFiles.Size = new System.Drawing.Size(378, 292);
            this.groupBoxFiles.TabIndex = 2;
            this.groupBoxFiles.TabStop = false;
            this.groupBoxFiles.Text = "Управление файлами";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Имя файла";
            // 
            // textBoxChangeAttributes
            // 
            this.textBoxChangeAttributes.Location = new System.Drawing.Point(145, 130);
            this.textBoxChangeAttributes.MaxLength = 12;
            this.textBoxChangeAttributes.Name = "textBoxChangeAttributes";
            this.textBoxChangeAttributes.Size = new System.Drawing.Size(124, 20);
            this.textBoxChangeAttributes.TabIndex = 9;
            // 
            // buttonChangeAttributes
            // 
            this.buttonChangeAttributes.Location = new System.Drawing.Point(7, 128);
            this.buttonChangeAttributes.Name = "buttonChangeAttributes";
            this.buttonChangeAttributes.Size = new System.Drawing.Size(132, 23);
            this.buttonChangeAttributes.TabIndex = 8;
            this.buttonChangeAttributes.Text = "Изменить атрибуты";
            this.buttonChangeAttributes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Имя файла";
            // 
            // textBoxRemoveFile
            // 
            this.textBoxRemoveFile.Location = new System.Drawing.Point(145, 99);
            this.textBoxRemoveFile.MaxLength = 12;
            this.textBoxRemoveFile.Name = "textBoxRemoveFile";
            this.textBoxRemoveFile.Size = new System.Drawing.Size(124, 20);
            this.textBoxRemoveFile.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Имя файла";
            // 
            // textBoxRevriteFile
            // 
            this.textBoxRevriteFile.Location = new System.Drawing.Point(145, 70);
            this.textBoxRevriteFile.MaxLength = 12;
            this.textBoxRevriteFile.Name = "textBoxRevriteFile";
            this.textBoxRevriteFile.Size = new System.Drawing.Size(124, 20);
            this.textBoxRevriteFile.TabIndex = 4;
            // 
            // buttonAcceptChanges
            // 
            this.buttonAcceptChanges.Enabled = false;
            this.buttonAcceptChanges.Location = new System.Drawing.Point(240, 263);
            this.buttonAcceptChanges.Name = "buttonAcceptChanges";
            this.buttonAcceptChanges.Size = new System.Drawing.Size(132, 23);
            this.buttonAcceptChanges.TabIndex = 3;
            this.buttonAcceptChanges.Text = "Принять изменения";
            this.buttonAcceptChanges.UseVisualStyleBackColor = true;
            this.buttonAcceptChanges.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.buttonAcceptChanges.MouseHover += new System.EventHandler(this.buttonAcceptChanges_MouseHover);
            // 
            // buttonRemoveFile
            // 
            this.buttonRemoveFile.Location = new System.Drawing.Point(7, 97);
            this.buttonRemoveFile.Name = "buttonRemoveFile";
            this.buttonRemoveFile.Size = new System.Drawing.Size(132, 23);
            this.buttonRemoveFile.TabIndex = 2;
            this.buttonRemoveFile.Text = "Удалить файл";
            this.buttonRemoveFile.UseVisualStyleBackColor = true;
            this.buttonRemoveFile.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.buttonRemoveFile.MouseHover += new System.EventHandler(this.buttonRemoveFile_MouseHover);
            // 
            // buttonRewriteFile
            // 
            this.buttonRewriteFile.Location = new System.Drawing.Point(7, 67);
            this.buttonRewriteFile.Name = "buttonRewriteFile";
            this.buttonRewriteFile.Size = new System.Drawing.Size(132, 23);
            this.buttonRewriteFile.TabIndex = 1;
            this.buttonRewriteFile.Text = "Редактировать файл";
            this.buttonRewriteFile.UseVisualStyleBackColor = true;
            this.buttonRewriteFile.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.buttonRewriteFile.MouseHover += new System.EventHandler(this.buttonRewriteFile_MouseHover);
            // 
            // buttonCreateFile
            // 
            this.buttonCreateFile.Location = new System.Drawing.Point(7, 37);
            this.buttonCreateFile.Name = "buttonCreateFile";
            this.buttonCreateFile.Size = new System.Drawing.Size(132, 23);
            this.buttonCreateFile.TabIndex = 0;
            this.buttonCreateFile.Text = "Создать файл";
            this.buttonCreateFile.UseVisualStyleBackColor = true;
            this.buttonCreateFile.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.buttonCreateFile.MouseHover += new System.EventHandler(this.buttonCreateFile_MouseHover);
            // 
            // panelFileStatus
            // 
            this.panelFileStatus.Controls.Add(this.textBoxRewriteFile);
            this.panelFileStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileStatus.Location = new System.Drawing.Point(387, 201);
            this.panelFileStatus.Name = "panelFileStatus";
            this.panelFileStatus.Size = new System.Drawing.Size(571, 292);
            this.panelFileStatus.TabIndex = 3;
            // 
            // textBoxRewriteFile
            // 
            this.textBoxRewriteFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRewriteFile.Enabled = false;
            this.textBoxRewriteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRewriteFile.Location = new System.Drawing.Point(0, 0);
            this.textBoxRewriteFile.Multiline = true;
            this.textBoxRewriteFile.Name = "textBoxRewriteFile";
            this.textBoxRewriteFile.Size = new System.Drawing.Size(571, 292);
            this.textBoxRewriteFile.TabIndex = 0;
            this.textBoxRewriteFile.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.textBoxRewriteFile.MouseHover += new System.EventHandler(this.textBoxRewriteFile_MouseHover);
            // 
            // panelDirectoryStatus
            // 
            this.panelDirectoryStatus.Controls.Add(this.textBoxSubdirectories);
            this.panelDirectoryStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDirectoryStatus.Location = new System.Drawing.Point(387, 3);
            this.panelDirectoryStatus.Name = "panelDirectoryStatus";
            this.panelDirectoryStatus.Size = new System.Drawing.Size(571, 192);
            this.panelDirectoryStatus.TabIndex = 4;
            // 
            // textBoxSubdirectories
            // 
            this.textBoxSubdirectories.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSubdirectories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSubdirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSubdirectories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSubdirectories.Location = new System.Drawing.Point(0, 0);
            this.textBoxSubdirectories.Multiline = true;
            this.textBoxSubdirectories.Name = "textBoxSubdirectories";
            this.textBoxSubdirectories.ReadOnly = true;
            this.textBoxSubdirectories.Size = new System.Drawing.Size(571, 192);
            this.textBoxSubdirectories.TabIndex = 0;
            this.textBoxSubdirectories.MouseLeave += new System.EventHandler(this.buttonCreateSubDirectory_MouseLeave);
            this.textBoxSubdirectories.MouseHover += new System.EventHandler(this.textBoxSubdirectories_MouseHover);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 522);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxDirictories.ResumeLayout(false);
            this.groupBoxDirictories.PerformLayout();
            this.groupBoxFiles.ResumeLayout(false);
            this.groupBoxFiles.PerformLayout();
            this.panelFileStatus.ResumeLayout(false);
            this.panelFileStatus.PerformLayout();
            this.panelDirectoryStatus.ResumeLayout(false);
            this.panelDirectoryStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBoxDirictories;
        private System.Windows.Forms.GroupBox groupBoxFiles;
        private System.Windows.Forms.Panel panelFileStatus;
        private System.Windows.Forms.Panel panelDirectoryStatus;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox textBoxNextSubdirectory;
        private System.Windows.Forms.Button buttonLeaveCurrentDirectory;
        private System.Windows.Forms.Button buttonNextSubdirectory;
        private System.Windows.Forms.Button buttonCreateSubDirectory;
        private System.Windows.Forms.Button buttonAcceptChanges;
        private System.Windows.Forms.Button buttonRemoveFile;
        private System.Windows.Forms.Button buttonRewriteFile;
        private System.Windows.Forms.Button buttonCreateFile;
        private System.Windows.Forms.TextBox textBoxRewriteFile;
        private System.Windows.Forms.TextBox textBoxSubdirectories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRemoveFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRevriteFile;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxChangeAttributes;
        private System.Windows.Forms.Button buttonChangeAttributes;
    }
}