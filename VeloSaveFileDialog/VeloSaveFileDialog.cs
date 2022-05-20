using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptPortal.Vegas;

namespace VeloSaveFileDialog
{
    public partial class VeloSaveFileDialog : Form
    {
        public Vegas myVegas;
        public VeloSaveFileDialog(Vegas vegas)
        {
            myVegas = vegas;
            InitializeComponent();
        }

    }

}