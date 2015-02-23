using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LaunchVHDAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string appFolder = Application.StartupPath;
            //MessageBox.Show(appFolder);
            string vhd = null;
            foreach (string s in Directory.EnumerateFiles(appFolder))
            {
                if (s.ToUpper().EndsWith(".VHD") | s.ToUpper().EndsWith(".VHDX"))
                {
                    vhd = s;
                    //MessageBox.Show(s);
                }
            }

            string DPScript = "select vdisk file=\"" + vhd + "\"\nattach vdisk\nassign letter=v\nexit";
            File.WriteAllText(appFolder + "\\DPScript.txt", DPScript);

            RunCommand.run("cmd", "/c diskpart /s \"" + appFolder + "\\DPScript.txt\"", false, true);

            File.Delete(appFolder + "\\DPScript.txt");

            Application.Exit();
            Environment.Exit(0);

        }
    }
}
