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

namespace FileSystemFAT
{
    public partial class ChangeAttributes : Form
    {
        public FileSystem FileSystem { get; private set; }
        public ChangeAttributes(FileSystem fileSystem, string fileName)
        {
            InitializeComponent();
            FileSystem = fileSystem;
            textBox1.Text = fileName;
            Attributes attributes = FileSystem.GetCurrentFileAttributes();
            checkedListBox1.SetItemChecked(0, attributes.ReadOnly);
            checkedListBox1.SetItemChecked(1, attributes.Hidden);
            checkedListBox1.SetItemChecked(2, attributes.System);
            checkedListBox1.SetItemChecked(3, attributes.Archival);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Attributes attributes = new Attributes(checkedListBox1.GetItemChecked(0), checkedListBox1.GetItemChecked(1),
                checkedListBox1.GetItemChecked(2), false, false, checkedListBox1.GetItemChecked(3));
            if (!FileSystem.SetFileAttributes(attributes))
            {
                MessageBox.Show("Не удалось обновить атрибуты", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            Close();
        }
    }
}
