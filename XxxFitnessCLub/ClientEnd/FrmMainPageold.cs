using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessCLub.ClientEnd
{
    public partial class FrmMainPageold : Form
    {
        public FrmMainPageold()
        {
            InitializeComponent();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //FrmOrderHistory f = new FrmOrderHistory();
            //f.ShowDialog();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmProgress f = new FrmProgress();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FrmToGos f = new FrmToGos();
            //f.ShowDialog();
        }
    }
}
