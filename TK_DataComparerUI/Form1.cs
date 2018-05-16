using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FilesComparer;

namespace TK_DataComparerUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ComparableFolder leftFolder = new ComparableFolder("C:\\tmp");

            ComparableFolder rightFolder = new ComparableFolder("C:\\tmp - Copie");

            dataComparerUCtrl1.InitCompare(leftFolder, rightFolder);
        }
    }
}
