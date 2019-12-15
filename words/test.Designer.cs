namespace words
{
    partial class test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.systemHotkey1 = new CodeProject.SystemHotkey.SystemHotkey(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // systemHotkey1
            // 
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.AltF6;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(77, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 104);
            this.label1.TabIndex = 0;
            this.label1.Text = "Waiting for events";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(701, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Use the SystemHotkey Component in Windows Forms designer to modify the Hotkey. Pr" +
                "ess ALT+F6 to fire the Hotkey event";
            // 
            // test
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(655, 452);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "test";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
    }
}