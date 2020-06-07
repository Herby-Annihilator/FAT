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
        public MainWindow(StartWindow startWindow)
        {
            InitializeComponent();
            Parent = startWindow;
            fileSystem = new FileSystem(Parent.ROMsize);
            for (int i = 0; i < fileSystem.FilesAndDirectoriesInDirectory.Count; i++)
            {
                textBoxSubdirectories.Text += "\"" + fileSystem.FilesAndDirectoriesInDirectory[i] + "\"" + " ";
            }            
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
            textBoxSubdirectories.Text = "";
            for (int i = 0; i < fileSystem.FilesAndDirectoriesInDirectory.Count; i++)
            {
                textBoxSubdirectories.Text += "\"" + fileSystem.FilesAndDirectoriesInDirectory[i] + "\"" + " ";
            }           
        }
        /// <summary>
        /// Переход в подкаталог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNextSubdirectory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNextSubdirectory.Text) || BunnedSymbols.IsBunned(textBoxNextSubdirectory.Text))
            {
                MessageBox.Show("Проверьте правильность имени открываемой директории, возможно, поле пустое!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNextSubdirectory.Focus();
                textBoxNextSubdirectory.ForeColor = Color.Red;
            }
            else
            {
                OpenDirectory openDirectory = new OpenDirectory(textBoxNextSubdirectory.Text, ref fileSystem);
                if (!fileSystem.ExecuteCommand(openDirectory))
                {
                    MessageBox.Show("Возможно, открываемая директория не является директорией", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ReadDirectory readDirectory = new ReadDirectory(fileSystem);
                    if (!fileSystem.ExecuteCommand(readDirectory))
                    {
                        MessageBox.Show("Проверяй массив object-ов, похоже неверный апкаст", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    for (int i = 0; i < fileSystem.FilesAndDirectoriesInDirectory.Count; i++)
                    {
                        textBoxSubdirectories.Text += "\"" + fileSystem.FilesAndDirectoriesInDirectory[i] + "\"" + " ";
                    }
                }
            }
            textBoxNextSubdirectory.Clear();
        }
        /// <summary>
        /// Покинуть текущий каталог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLeaveCurrentDirectory_Click(object sender, EventArgs e)
        {
            CloseDirectory closeDirectory = new CloseDirectory(fileSystem);
            if (!fileSystem.ExecuteCommand(closeDirectory))
            {
                MessageBox.Show("Возможно, вы находимтесь в корневом каталоге. Его закрыть нельзя", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ReadDirectory readDirectory = new ReadDirectory(fileSystem);
                if (!fileSystem.ExecuteCommand(readDirectory))
                {
                    MessageBox.Show("Проверяй массив object-ов, похоже неверный апкаст", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Создать файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            CreateFile createFile = new CreateFile(fileSystem);
            createFile.ShowDialog();
            textBoxSubdirectories.Text = "";
            for (int i = 0; i < fileSystem.FilesAndDirectoriesInDirectory.Count; i++)
            {
                textBoxSubdirectories.Text += "\"" + fileSystem.FilesAndDirectoriesInDirectory[i] + "\"" + " ";
            }
        }
        /// <summary>
        /// Редактируем файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRewriteFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxRewriteFileName.Text))
            {
                MessageBox.Show("Поле имени файла пустое!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string[] nameAndExt = textBoxRewriteFileName.Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                string name = nameAndExt[0];
                string ext = "";
                if (nameAndExt.Length == 2)
                {
                    ext = nameAndExt[1];
                }
                OpenFile openFile = new OpenFile(name, ext, fileSystem);
                if (!fileSystem.ExecuteCommand(openFile))
                {
                    MessageBox.Show("Не могу обновить ссылки", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ReadFile readFile = new ReadFile(fileSystem);
                    if (fileSystem.ExecuteCommand(readFile))
                    {
                        buttonAcceptChanges.Enabled = true;
                        buttonRewriteFile.Enabled = false;
                        textBoxRewriteFile.Text = "";
                        for (int i = 0; i < fileSystem.FileContent.Count; i++)
                        {
                            textBoxRewriteFile.Text += fileSystem.FileContent[i];
                        }
                        textBoxRewriteFileName.Clear();
                        toolStripStatusLabel2.Text = "Можно редактировать файл в большом белом разделе справа!!!";
                        textBoxRewriteFile.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Смотри массив object-ов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }
        /// <summary>
        /// Принять изменения (сохранить)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAcceptChanges_Click(object sender, EventArgs e)
        {
            fileSystem.FileContent.Clear();
            //
            // Считываем и правильно подготавливаем данные 
            //
            string content = textBoxRewriteFile.Text;
            int substringNumber;
            if (content.Length % fileSystem.ClusterSize == 0)
            {
                substringNumber = content.Length / fileSystem.ClusterSize;
            }
            else
            {
                substringNumber = content.Length / fileSystem.ClusterSize + 1;
            }
            for (int i = 0; i < substringNumber; i++)
            {
                fileSystem.FileContent.Add(content.Substring(i * fileSystem.ClusterSize, fileSystem.ClusterSize));
            }
            //
            // Создаем команду
            //
            WriteToFile writeToFile = new WriteToFile(fileSystem);
            if (!fileSystem.ExecuteCommand(writeToFile))
            {
                MessageBox.Show("Памяти не хватило", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                toolStripStatusLabel2.Text = "Редактирование завершено. Файл сохранен";
                textBoxRewriteFile.Enabled = false;
            }
            buttonAcceptChanges.Enabled = false;
            buttonRewriteFile.Enabled = true;
            textBoxRewriteFile.Clear();           
        }
        /// <summary>
        /// Изменяем атрибуты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChangeAttributes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxChangeAttributes.Text))
            {
                MessageBox.Show("Поле имени файла пустое!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string[] nameAndExt = textBoxChangeAttributes.Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                string name = nameAndExt[0];
                string ext = "";
                if (nameAndExt.Length == 2)
                {
                    ext = nameAndExt[1];
                }
                OpenFile openFile = new OpenFile(name, ext, fileSystem);
                if (!fileSystem.ExecuteCommand(openFile))
                {
                    MessageBox.Show("Не могу обновить ссылки", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ReadFile readFile = new ReadFile(fileSystem);
                    if (!fileSystem.ExecuteCommand(readFile))
                    {
                        MessageBox.Show("Смотри массив object-ов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        Attributes attributes = fileSystem.GetCurrentFileAttributes();
                        if (attributes == null)
                        {
                            MessageBox.Show("Файл не открыт", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            ChangeAttributes changeAttributes = new ChangeAttributes(fileSystem, textBoxChangeAttributes.Text);
                            changeAttributes.ShowDialog();
                            //
                            // Читаем заново текущую директорию и обновляем данные
                            //
                            ReadDirectory readDirectory = new ReadDirectory(fileSystem);
                            if (!fileSystem.ExecuteCommand(readDirectory))
                            {
                                MessageBox.Show("Смотри массив object-ов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                            else
                            {
                                textBoxSubdirectories.Clear();
                                for (int i = 0; i < fileSystem.FilesAndDirectoriesInDirectory.Count; i++)
                                {
                                    textBoxSubdirectories.Text += "\"" + fileSystem.FilesAndDirectoriesInDirectory[i] + "\"" + " ";
                                }
                            }
                        }
                    }
                }
            }
            textBoxChangeAttributes.Clear();
        }
        /// <summary>
        /// Удаляем файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxRemoveFile.Text))
            {
                MessageBox.Show("Поле имени файла пустое!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string[] nameAndExt = textBoxRemoveFile.Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                string name = nameAndExt[0];
                string ext = "";
                if (nameAndExt.Length == 2)
                {
                    ext = nameAndExt[1];
                }
                RemoveFile removeFile = new RemoveFile(fileSystem, name, ext);
                if (!fileSystem.ExecuteCommand(removeFile))
                {
                    MessageBox.Show("Не удалось удалить файл", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ReadDirectory readDirectory = new ReadDirectory(fileSystem);
                    if (!fileSystem.ExecuteCommand(readDirectory))
                    {
                        MessageBox.Show("Смотри массив object-ов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        textBoxSubdirectories.Clear();
                        for (int i = 0; i < fileSystem.FilesAndDirectoriesInDirectory.Count; i++)
                        {
                            textBoxSubdirectories.Text += "\"" + fileSystem.FilesAndDirectoriesInDirectory[i] + "\"" + " ";
                        }
                    }
                }
            }
            textBoxRemoveFile.Clear();
        }
    }
}
