using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VExport
{
    internal class VeloSaveFileDialog
    {
        public static string ShowSaveFileDialog(string filter, string title, string defaultFilename)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (null == filter)
            {
                filter = "All Files (*.*)|*.*";
            }
            saveFileDialog.Filter = filter;
            if (null != title)
                saveFileDialog.Title = title;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.AddExtension = true;
            if (null != defaultFilename)
            {
                string initialDir = Path.GetDirectoryName(defaultFilename);
                if (Directory.Exists(initialDir))
                {
                    saveFileDialog.InitialDirectory = initialDir;
                }
                saveFileDialog.DefaultExt = Path.GetExtension(defaultFilename);
                saveFileDialog.FileName = Path.GetFileName(defaultFilename);
            }
            if (DialogResult.OK == saveFileDialog.ShowDialog())
                return Path.GetFullPath(saveFileDialog.FileName);
            else
                return null;
        }
    }
}
