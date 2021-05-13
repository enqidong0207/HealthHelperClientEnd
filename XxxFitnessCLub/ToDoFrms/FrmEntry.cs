using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHFirstDraft
{
    public partial class FrmEntry : Form
    {
        public FrmEntry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMainPage f = new FrmMainPage();
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("參考UBER EAT");
        }
    }
}
