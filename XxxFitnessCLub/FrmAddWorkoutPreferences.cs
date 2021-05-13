using HHFirstDraft.BLL;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.DAL;

namespace XxxFitnessCLub
{
    //恩旗
    public partial class FrmAddWorkoutPreferences : Form
    {
        WorkoutPreferencesBLL wpBll = new WorkoutPreferencesBLL();
        WorkoutCategoryBLL wcBll = new WorkoutCategoryBLL();
        WorkoutBLL wBll = new WorkoutBLL();
        FrmAddMember frmAddMember = new FrmAddMember();

        public FrmAddWorkoutPreferences(FrmAddMember frmAddMember)
        {
            this.frmAddMember = frmAddMember;
            InitializeComponent();
        }

        private void FrmAddWorkoutPreferences_Load(object sender, EventArgs e)
        {
            LoadCheckedListBox();

            if (this.frmAddMember.isUpdate)
            {
                this.lbTitle.Text = "修改喜好運動類型";
            }
        }

        private void LoadCheckedListBox()
        {
            List<WorkoutPreference> wpList = wpBll.GetPreferences(this.frmAddMember.MemberID);

            foreach (var item in wcBll.GetWcItems())
            {
                if (wpList.Where(wp => wp.WorkoutCategoryID == item.wcID).SingleOrDefault() != null)
                {
                    this.clbWPreferences.Items.Add(item, true);
                }
                else
                {
                    this.clbWPreferences.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            List<WorkoutPreference> wpList = new List<WorkoutPreference>();
            foreach (ClbItem item in this.clbWPreferences.CheckedItems)
            {
                wpList.Add(new WorkoutPreference
                {
                    MemberID = this.frmAddMember.MemberID,
                    WorkoutCategoryID = item.wcID
                });
            }

            if (this.frmAddMember.isUpdate)
            {
                if (wpBll.EditPreferences(wpList))
                {
                    MessageBox.Show("喜好運動類型修改成功");
                }
            }
            else
            {
                if (wpBll.AddPreferences(wpList))
                {
                    MessageBox.Show("喜好運動類型新增成功");
                }
            }
            
            this.frmAddMember.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.frmAddMember.Close();
        }

        private void clbWPreferences_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            var clb = sender as CheckedListBox;
            var item = clb.SelectedItem as ClbItem;
            var wList = wBll.GetWorkoutByWCAL(item.wcID);

            foreach (var w in wList)
            {
                Label lblWorkout = new Label();
                lblWorkout.Text = w.Name;
                lblWorkout.Font = new Font(lblWorkout.Font.Name, 16f);
                lblWorkout.Height = (int)(lblWorkout.Font.Size * 2.5);
                lblWorkout.Margin = new Padding(5);
                lblWorkout.Paint += LblWorkout_Paint;
                this.flowLayoutPanel1.Controls.Add(lblWorkout);
            }
        }

        #region draw rounded corner label
        internal static void LblWorkout_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            SizeF s = e.Graphics.MeasureString(lbl.Text, lbl.Font);
            lbl.Width = (int)s.Width + (int)lbl.Font.Size;

            GraphicsPath gp = draw_rectangle(new Rectangle(0, 0, lbl.Width, lbl.Height), 10);

            LinearGradientBrush brush =
                new LinearGradientBrush(new Rectangle(0, 0, lbl.Width, lbl.Height), Color.MediumSeaGreen, Color.LimeGreen, 4f);


            e.Graphics.FillPath(brush, gp);
            e.Graphics.DrawString(lbl.Text, lbl.Font, new SolidBrush(Color.White), new PointF(lbl.Font.Size * 0.5f , lbl.Font.Size * 0.5f));
        }

        internal static GraphicsPath draw_rectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        #endregion
    }


}
