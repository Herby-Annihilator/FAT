using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileAllocationTable.Commands;
using FileAllocationTable.Commands.DirectoryCommands;
using FileAllocationTable.Commands.FileCommands;
using FileAllocationTable.FAT;
using FileAllocationTable;

namespace FileSystemFAT
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Ссылка на родителя
        /// </summary>
        public new StartWindow Parent { get; set; }
        /// <summary>
        /// Файловая система
        /// </summary>
        private FileSystem fileSystem;
        public MainWindow()
        {
            InitializeComponent();
            fileSystem = new FileSystem(Parent.ROMsize);
        }

        private void buttonCreateSubDirectory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Будем искать местов в FAT, выделим кластер и создадим там два файла '.' и '..' (если это не корневой каталог)";
        }

        private void buttonCreateSubDirectory_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }

        private void buttonNextSubdirectory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Указанная поддиректория будет открыта, а затем, ее содержимое будет прочитано";
        }

        private void buttonLeaveCurrentDirectory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Возьмем ссылку на стартовый кластер из файла '..', закроем эту дирекоторию, откроем новую и прочитаем ее";
        }

        private void buttonCreateFile_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Создадим каталожную запись в текущей директории, обратимся к FAT, выделим кластер";
        }

        private void buttonRewriteFile_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Откроем файл, выведем его содержимое, можно будет редактировать в секторе справа";
        }

        private void buttonRemoveFile_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Удалим каталожную запись этого файла из текущей директории, соотвествующие номера кластеров в FAT обнулим";
        }

        private void buttonAcceptChanges_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Содержимое поля справа будет записано в кластеры файла (будут выделены еще в случае необходимости)";
        }

        private void textBoxSubdirectories_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Тут просто будет отображаться содержимое выделенной директории";
        }

        private void textBoxRewriteFile_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Тут можно редактировать открытый файл";
        }

        private void statusStrip1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Зачем сюда наводишь?";
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parent.Close();
        }
        /// <summary>
        /// Создаем подкаталог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSubDirectory_Click(object sender, EventArgs e)
        {
            CreateDirectory createDirectory = new CreateDirectory(fileSystem);
            createDirectory.ShowDialog();
        }
    }
}
