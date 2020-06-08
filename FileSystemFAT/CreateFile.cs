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
using FileAllocationTable.FAT;
using FileAllocationTable.Commands.DirectoryCommands;

namespace FileSystemFAT
{
    public partial class CreateFile : Form
    {
        private FileSystem fileSystem;
        public CreateFile(FileSystem fileSystem)
        {
            InitializeComponent();
            this.fileSystem = fileSystem;
        }
        /// <summary>
        /// Созадать файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFileName.Text) || BunnedSymbols.IsBunned(textBoxFileName.Text))
            {
                MessageBox.Show("Некорректное значение в поле имени файла!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFileName.Focus();
            }
            else if (string.IsNullOrEmpty(textBoxFileExt.Text) || BunnedSymbols.IsBunned(textBoxFileExt.Text))
            {
                MessageBox.Show("Некорректное значение в поле расширения файла!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFileExt.Focus();
            }
            else
            {
                Attributes attributes = new Attributes(checkedListBoxAttributes.GetItemChecked(0), checkedListBoxAttributes.GetItemChecked(1),
                    checkedListBoxAttributes.GetItemChecked(2), false, false, checkedListBoxAttributes.GetItemChecked(3));
                FileAllocationTable.Commands.FileCommands.CreateFile createFile = new FileAllocationTable.Commands.FileCommands.CreateFile(textBoxFileName.Text,
                    textBoxFileExt.Text, attributes.ReadOnly, attributes.System, attributes.Hidden, ref fileSystem);
                if (!fileSystem.ExecuteCommand(createFile))
                {
                    MessageBox.Show("Не удалось создать файл", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ReadDirectory readDirectory = new ReadDirectory(fileSystem);
                    if (!fileSystem.ExecuteCommand(readDirectory))
                    {
                        MessageBox.Show("Проверяй массив object-ов, похоже неверный апкаст", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    Close();
                }
            }
        }
    }
}
