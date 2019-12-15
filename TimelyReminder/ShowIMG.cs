using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimelyReminder
{
    public partial class ShowIMG : Form
    {
        public ShowIMG()
        {
            InitializeComponent();

            bind();
        }

        void bind()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
