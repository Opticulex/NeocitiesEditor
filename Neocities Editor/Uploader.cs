using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Neocities_Editor
{
    public partial class Uploader : Form
    {
        string workingdir = Directory.GetCurrentDirectory();
        string upfile = Editor.DataContainer.filenametouploader.ToString();
        string upfilefull = Editor.DataContainer.filenamefull.ToString();
        string sitename = Editor.DataContainer.uplsitename.ToString();
        string sitepass = Editor.DataContainer.uplsitepass.ToString();

        public Uploader()
        {
            InitializeComponent();
            up_file.Text = "./" + upfile;
            up_loc.Text = upfile.Replace(" ","_");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void upload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string upfull = upfilefull.Replace("\\","/");
            if (File.Exists(workingdir + "\\Data\\temp_node.js"))
            {
                File.Delete(workingdir + "\\Data\\temp_node.js");
            }
            File.AppendAllText(workingdir + "\\Data\\temp_node.js", @"var neocities = require('neocities')
var api = new neocities('" + sitename + @"', '" + sitepass + @"')

api.upload([
  {name: '" + up_loc.Text + @"', path: '" + upfull + @"'}
], function(resp) {
  console.log(resp)
})");
            if (File.Exists(workingdir + "\\Data\\temp_run.bat"))
            {
                File.Delete(workingdir + "\\Data\\temp_run.bat");
            }
            File.AppendAllText(workingdir + "\\Data\\temp_run.bat", @"node """ + workingdir + "\\Data\\temp_node.js\"" + @"
exit");
            if (File.Exists(workingdir + "\\Data\\temp_run.bat"))
            {
                Process.Start(workingdir + "\\Data\\temp_run.bat");
                Cursor.Current = Cursors.Default;
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("There was an error uploaing your file", "Neocities Editor Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
    }
}
