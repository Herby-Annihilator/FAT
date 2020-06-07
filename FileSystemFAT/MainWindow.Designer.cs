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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDirictories = new System.Windows.Forms.GroupBox();
            this.groupBoxFiles = new System.Windows.Forms.GroupBox();
            this.panelFileStatus = new System.Windows.Forms.Panel();
            this.panelDirectoryStatus = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(967, 20);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
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
            this.groupBoxDirictories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDirictories.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDirictories.Name = "groupBoxDirictories";
            this.groupBoxDirictories.Size = new System.Drawing.Size(378, 192);
            this.groupBoxDirictories.TabIndex = 0;
            this.groupBoxDirictories.TabStop = false;
            this.groupBoxDirictories.Text = "Управление каталогами";
            // 
            // groupBoxFiles
            // 
            this.groupBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFiles.Location = new System.Drawing.Point(3, 201);
            this.groupBoxFiles.Name = "groupBoxFiles";
            this.groupBoxFiles.Size = new System.Drawing.Size(378, 292);
            this.groupBoxFiles.TabIndex = 2;
            this.groupBoxFiles.TabStop = false;
            this.groupBoxFiles.Text = "Управление файлами";
            // 
            // panelFileStatus
            // 
            this.panelFileStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileStatus.Location = new System.Drawing.Point(387, 201);
            this.panelFileStatus.Name = "panelFileStatus";
            this.panelFileStatus.Size = new System.Drawing.Size(571, 292);
            this.panelFileStatus.TabIndex = 3;
            // 
            // panelDirectoryStatus
            // 
            this.panelDirectoryStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDirectoryStatus.Location = new System.Drawing.Point(387, 3);
            this.panelDirectoryStatus.Name = "panelDirectoryStatus";
            this.panelDirectoryStatus.Size = new System.Drawing.Size(571, 192);
            this.panelDirectoryStatus.TabIndex = 4;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 15);
            this.toolStripStatusLabel1.Text = "Будет выполнено: ";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 522);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
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
    }
}