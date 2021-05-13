using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.Model.DAL.DTO;

namespace XxxFitnessCLub
{
    public partial class FrmAllNutrientOfDay : Form
    {
        public FrmAllNutrientOfDay()
        {
            InitializeComponent();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            int memberID = 3;
            DateTime EditTime =new DateTime(2020,5,3);
            TimesOfDayDTO tdto = new TimesOfDayDTO();
            DietDetailsDTO dd_dto = new DietDetailsDTO();
            DietLogDTO dldto = new DietLogDTO();
            NutrientDTO ndto = new NutrientDTO();


            if (dldto.MemberID == 3)
            {
                if (dldto.EditTime.Year == 2020 && dldto.EditTime.Month == 5 && dldto.EditTime.Day == 3)
                {
                    this.lblFat.Text = ndto.Fat.ToString();
                }
            }
            


            // EditTime.Year =>value is int
        }
    }
}
