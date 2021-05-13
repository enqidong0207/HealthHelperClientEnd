using HHFirstDraft.BLL;
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
    public partial class FrmMealHistory : Form
    {
        DietLogBLL dlBll = new DietLogBLL();
        public FrmMealHistory()
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = dlBll.GetDietLogHistory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.bindingSource1.DataSource = null;
            MonthCalendar mc = sender as MonthCalendar;
            bindingSource1.DataSource = dlBll.GetDaysRecord(mc.SelectionStart, mc.SelectionEnd);
        }
    }
}
