using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neocities_Editor
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            textBoxDescription.Text = @"Neocties Editor v1.0.0

Program Development by Opticulex
Icon images (C) Microsoft VS2012 Image Library
Other images (C) Neocites.org

All copyrights belong to their respective owners.

Any content in here can be used to the extent the copyright holders allow. All code by Opticulex comes with no copyright and can be modified and manipulated freely.";
        }


        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
