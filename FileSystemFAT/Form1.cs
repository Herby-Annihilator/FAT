﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemFAT
{
    public partial class StartWindow : Form
    {
        public int ROMsize { get; set; }
        public StartWindow()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                labelInfo.Text = "Выберите размер диска!";
            }
            else
            {
                ROMsize = Convert.ToInt32(comboBox1.Text) * 1024 * 1024;
            }
        }
    }
}
