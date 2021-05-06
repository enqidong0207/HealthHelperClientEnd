using HHFirstDraft.BLL;
using HHFirstDraft.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessCLub
{
    public partial class FrmMealLog : Form
    {
        MealDAO dao = new MealDAO();
        MealBLL bll = new MealBLL();
        
        public FrmMealLog()
        {
            InitializeComponent();
            this.textBoxKeyWord.TextChanged += textBoxKeyWord_TextChanged;
        }
        private void textBoxKeyWord_TextChanged(object sender, EventArgs e)
        {
           
            string InputKeyword = (sender as TextBox).Text;
            bll.GetMeals(InputKeyword);
        }
    }
}
