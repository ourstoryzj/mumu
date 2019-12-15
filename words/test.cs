using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace words
{
    public partial class test : Form
    {
       
        private System.Windows.Forms.Label label1;
        private CodeProject.SystemHotkey.SystemHotkey systemHotkey1;
        //private System.ComponentModel.IContainer components;

        public test()
        {
            InitializeComponent();
            //this.components = new System.ComponentModel.Container();
            //this.systemHotkey1 = new CodeProject.SystemHotkey.SystemHotkey(this.components);
            // 
            // systemHotkey1
            // 
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.AltF6;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
        }
         

        private void systemHotkey1_Pressed(object sender, System.EventArgs e)
        {
            label1.Text = "Hotkey Pressed!";
            this.Activate();
            this.BringToFront();
        }

    }
}
