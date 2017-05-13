using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Neocities_Editor
{
    public partial class Editor : Form
    {
        bool fileload = false;
        bool unsaved = false;
        bool savestatus = false;
        bool passshow = false;
        string file = "null";
        string text = "null";
        string uploadname = "null";
        string sitename = "null";
        string sitepass = "null";
        string workingdir = Directory.GetCurrentDirectory();

        public Editor()
        {
            InitializeComponent();
            string workingdir = Directory.GetCurrentDirectory();
            if (Directory.Exists(workingdir + "\\Data"))
            {

            }
            else
            {
                Directory.CreateDirectory(workingdir + "\\Data");
            }
            if (File.Exists(workingdir + "\\Data\\settings.txt"))
            {
                string[] settings = File.ReadAllLines(workingdir + "\\Data\\settings.txt");
                string sitename = settings[0];
                string sitepass = settings[1];
                sd_name.Text = sitename;
                sd_pass.Text = sitepass;
            }
            entry.Text = "";
            this.Text = "Neocities Editor - Untitled";
            fileload = true;
            unsaved = false;
            file = "Untitled";
        }

        private void ts_New_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void ts_Open_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void ts_Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void ts_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void ts_Undo_Click(object sender, EventArgs e)
        {
            entry.Undo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entry.Undo();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            entry.Undo();
        }

        private void ts_Redo_Click(object sender, EventArgs e)
        {
            entry.Redo();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            entry.Redo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entry.Redo();
        }

        private void ts_Cut_Click(object sender, EventArgs e)
        {
            if (entry.SelectedText != "")
            {
                Clipboard.SetText(entry.SelectedText);
                int remove = entry.SelectionLength;
                entry.Text = entry.Text.Remove(entry.SelectionStart, remove);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entry.SelectedText != "")
            {
                Clipboard.SetText(entry.SelectedText);
                int remove = entry.SelectionLength;
                entry.Text = entry.Text.Remove(entry.SelectionStart, remove);
            }
        }

        private void cm_Cut_Click(object sender, EventArgs e)
        {
            if (entry.SelectedText != "")
            {
                Clipboard.SetText(entry.SelectedText);
                int remove = entry.SelectionLength;
                entry.Text = entry.Text.Remove(entry.SelectionStart, remove);
            }
        }

        private void ts_Copy_Click(object sender, EventArgs e)
        {
            if (entry.SelectedText != "")
            {
                Clipboard.SetText(entry.SelectedText);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entry.SelectedText != "")
            {
                Clipboard.SetText(entry.SelectedText);
            }
        }

        private void cm_Copy_Click(object sender, EventArgs e)
        {
            if (entry.Text != "")
            {
                Clipboard.SetText(entry.Text);
            }
        }

        private void ts_Paste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                entry.Text = entry.Text + Clipboard.GetText(TextDataFormat.Text);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                entry.Text = entry.Text + Clipboard.GetText(TextDataFormat.Text);
            }
        }

        private void cm_Paste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                entry.Text = entry.Text + Clipboard.GetText(TextDataFormat.Text);
            }
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entry.Text != "")
            {
                Clipboard.SetText(entry.Text);
            }
        }

        private void cm_CopyAll_Click(object sender, EventArgs e)
        {
            if (entry.Text != "")
            {
                Clipboard.SetText(entry.Text);
            }
        }

        private void ts_ZoomIn_Click(object sender, EventArgs e)
        {
            if (entry.ZoomFactor < 8)
            {
                entry.ZoomFactor = entry.ZoomFactor + 0.15f;
            }
        }

        private void ts_ZoomOut_Click(object sender, EventArgs e)
        {
            if (entry.ZoomFactor > 0.165625)
            {
                entry.ZoomFactor = entry.ZoomFactor + -0.15f;
            }
        }

        public void NewFile()
        {
            if(fileload == true)
            {
                if (unsaved == true)
                {
                    var window = MessageBox.Show(
                    "You have unsaved changes to " + file + ". Do you want to save changes?",
                    "Neocites Editor",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (window == DialogResult.Yes)
                    {
                        SaveFile();
                        entry.Text = "";
                        this.Text = "Neocities Editor - Untitled";
                        fileload = true;
                        unsaved = false;
                        file = "Untitled";
                        savestatus = false;

                    }
                    if (window == DialogResult.No)
                    {
                        entry.Text = "";
                        this.Text = "Neocities Editor - Untitled";
                        fileload = true;
                        unsaved = false;
                        file = "Untitled";
                        savestatus = false;
                    }
                    if (window == DialogResult.No)
                    {
                        //cancelled
                    }
                }
                else
                {
                    entry.Text = "";
                    this.Text = "Neocities Editor - Untitled";
                    fileload = true;
                    unsaved = false;
                    savestatus = false;
                    file = "Untitled";
                }
            }
            else
            {
                entry.Text = "";
                this.Text = "Neocities Editor - Untitled";
                fileload = true;
                unsaved = false;
                file = "Untitled";
            }
        }

        public void OpenFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All supported file types|*.html;*.htm;*.md;*.markdown;*.js;*.json;*.geojson;*.css;*.txt;*.text;*.csv;*.tsv;*.xml|HTML files|*.html;*.htm|Markdown files|*.md;*.markdown|JavaScript scripts|*.js;*.json;*.geojson|CSS files|*.css|Text|*.txt;*.text;*.csv;*.tsv|XML documents|*.xml";
            openFileDialog1.Title = "Choose a file to edit";
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                Cursor.Current = Cursors.WaitCursor;
                file = openFileDialog1.FileName;
                text = File.ReadAllText(file);
                size = text.Length;
                //MessageBox.Show(file + " : " + size + " : " + result);
                entry.Text = text;
                fileload = true;
                unsaved = false;
                this.Text = "Neocities Editor - " + file;
                Cursor.Current = Cursors.Default;
            }
        }

        public void SaveFile()
        {
            if(fileload == true)
            {
                if(file != "null" || file != "Untitled")
                {
                    if(File.Exists(file))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        text = entry.Text;
                        File.Delete(file);
                        File.AppendAllText(file, text + Environment.NewLine);
                        this.Text = "Neocities Editor - " + file;
                        Cursor.Current = Cursors.Default;
                        savestatus = true;
                    }
                    else
                    {
                        SaveFileAs();
                    }
                }
                else
                {
                    SaveFileAs();
                }
            }
        }

        private void SaveFileAs()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter = "All supported file types|*.html;*.htm;*.md;*.markdown;*.js;*.json;*.geojson;*.css;*.txt;*.text;*.csv;*.tsv;*.xml|HTML files|*.html;*.htm|Markdown files|*.md;*.markdown|JavaScript scripts|*.js;*.json;*.geojson|CSS files|*.css|Text|*.txt;*.text;*.csv;*.tsv|XML documents|*.xml";
            saveFileDialog1.Title = "Save As";
            DialogResult result = saveFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = saveFileDialog1.FileName;
                if (File.Exists(file))
                {
                    savestatus = false;
                    Cursor.Current = Cursors.WaitCursor;
                    text = entry.Text;
                    File.Delete(file);
                    File.AppendAllText(file, text + Environment.NewLine);
                    fileload = true;
                    unsaved = false;
                    this.Text = "Neocities Editor - " + file;
                    Cursor.Current = Cursors.Default;
                    savestatus = true;
                }
                else
                {
                    savestatus = false;
                    Cursor.Current = Cursors.WaitCursor;
                    text = entry.Text;
                    File.AppendAllText(file, text + Environment.NewLine);
                    fileload = true;
                    unsaved = false;
                    this.Text = "Neocities Editor - " + file;
                    Cursor.Current = Cursors.Default;
                    savestatus = true;
                }

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.Show();
        }

        private void entry_TextChanged(object sender, EventArgs e)
        {
            if (fileload == true)
            {
                if (file != "null")
                {
                    this.Text = "Neocities Editor - " + file + "*";
                    unsaved = true;
                    savestatus = false;
                }
            }
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            sdSave();
            if (unsaved == true)
            {
                var window = MessageBox.Show(
                "You have unsaved changes to " + file + ". Do you want to save changes?",
                "Neocites Editor",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                e.Cancel = (window == DialogResult.Cancel);
                if(window == DialogResult.Yes)
                {
                    SaveFile();
                }
            }
        }

        private void entry_KeyDown(object sender, KeyEventArgs e)
        {
            // Trick to build undo stack word by word
            RichTextBox entry = (RichTextBox)sender;
            if (e.KeyCode == Keys.Space)
            {
                this.SuspendLayout();
                entry.Undo();
                entry.Redo();
                this.ResumeLayout();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entry.ZoomFactor < 8)
            {
                entry.ZoomFactor = entry.ZoomFactor + 0.15f;
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entry.ZoomFactor > 0.165625)
            {
                entry.ZoomFactor = entry.ZoomFactor + -0.15f;
            }
        }

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entry.ZoomFactor = 1;
        }

        private void ts_Upload_Click(object sender, EventArgs e)
        {
            sdSave();
            if (fileload == true)
            {
                if (file != "null")
                {
                    SaveFile();
                    if (savestatus == true)
                    {
                        unsaved = false;
                        uploadname = "null";
                        uploadname = Path.GetFileName(file);
                        shareuploaddata();
                        Uploader frm = new Uploader();
                        frm.Show();
                    }
                }
            }
        }

        public void shareuploaddata()
        {
            DataContainer.filenametouploader = uploadname;
            DataContainer.filenamefull = file;
            DataContainer.uplsitename = sitename;
            DataContainer.uplsitepass = sitepass;
        }

        public static class DataContainer
        {
            public static string filenametouploader;
            public static string filenamefull;
            public static string uplsitename;
            public static string uplsitepass;
        }

        public void sdSave()
        {
            if (File.Exists(workingdir + "\\Data\\settings.txt"))
            {
                File.Delete(workingdir + "\\Data\\settings.txt");
                File.AppendAllText(workingdir + "\\Data\\settings.txt", @"" + sd_name.Text + @"
" + sd_pass.Text);
                sitename = sd_name.Text;
                sitepass = sd_pass.Text;
            }
            else
            {
                File.AppendAllText(workingdir + "\\Data\\settings.txt", @"" + sd_name.Text + @"
" + sd_pass.Text);
                sitename = sd_name.Text;
                sitepass = sd_pass.Text;
            }
        }

        private void sd_pass_DoubleClick(object sender, EventArgs e)
        {
            if (passshow == true)
            {
                sd_pass.PasswordChar = '*';
                passshow = false;
            }
            else if (passshow == false)
            {
                sd_pass.PasswordChar = '\0';
                passshow = true;
            }
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void ts_Reload_Click(object sender, EventArgs e)
        {
            sdSave();
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sdSave();
            if (fileload == true)
            {
                if (file != "null")
                {
                    SaveFile();
                    if (savestatus == true)
                    {
                        unsaved = false;
                        uploadname = "null";
                        uploadname = Path.GetFileName(file);
                        shareuploaddata();
                        Uploader frm = new Uploader();
                        frm.Show();
                    }
                }
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://neocities.org/site_files/" + sitename + ".zip", workingdir + "\\Data\\" + sitename + ".zip");
                }
            }
            catch (Exception)
            {

            }
        }

        private void ts_Download_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://neocities.org/site_files/" + sitename + ".zip", workingdir + "\\Data\\" + sitename + ".zip");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}