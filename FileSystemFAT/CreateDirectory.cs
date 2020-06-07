using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileAllocationTable;
using FileAllocationTable.Commands.DirectoryCommands;

namespace FileSystemFAT
{
    public partial class CreateDirectory : Form
    {
        public FileSystem FileSystem { get; set; }
        public CreateDirectory(FileSystem fileSystem)
        {
            InitializeComponent();
            FileSystem = fileSystem;
        }
        /// <summary>
        /// Кнопка создания директории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateDirectory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDirectoryName.Text))
            {
                label2.Text = "Введите имя директории";
            }
            else if (BunnedSymbols.IsBunned(textBoxDirectoryName.Text))
            {
                label2.Text = "В имени есть запрещенные символы";
            }
            else
            {
                FileAllocationTable.Commands.DirectoryCommands.CreateDirectory createDirectory =
                    new FileAllocationTable.Commands.DirectoryCommands.CreateDirectory(textBoxDirectoryName.Text, false, true, FileSystem);
                
                if (!FileSystem.ExecuteCommand(createDirectory))
                {
                    MessageBox.Show("Не удалось создать директорию", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
