namespace HHFirstDraft
{
    partial class FrmAddWorkoutLog
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.cmbWorkoutCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWorkoutHours = new System.Windows.Forms.TextBox();
            this.lblWorkoutCategoryTest = new System.Windows.Forms.Label();
            this.cmbWorkout = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbActivityLevel = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.BackColor = System.Drawing.Color.LightGray;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(407, 297);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 50);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(285, 297);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 50);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 58;
            this.label1.Text = "運動類型";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 56);
            this.panel1.TabIndex = 72;
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(297, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(187, 39);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "新增運紀錄";
            // 
            // cmbWorkoutCategory
            // 
            this.cmbWorkoutCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbWorkoutCategory.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbWorkoutCategory.FormattingEnabled = true;
            this.cmbWorkoutCategory.Location = new System.Drawing.Point(304, 70);
            this.cmbWorkoutCategory.Name = "cmbWorkoutCategory";
            this.cmbWorkoutCategory.Size = new System.Drawing.Size(200, 28);
            this.cmbWorkoutCategory.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 58;
            this.label2.Text = "運動時間";
            // 
            // txtWorkoutHours
            // 
            this.txtWorkoutHours.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWorkoutHours.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtWorkoutHours.Location = new System.Drawing.Point(304, 211);
            this.txtWorkoutHours.Name = "txtWorkoutHours";
            this.txtWorkoutHours.Size = new System.Drawing.Size(200, 31);
            this.txtWorkoutHours.TabIndex = 73;
            // 
            // lblWorkoutCategoryTest
            // 
            this.lblWorkoutCategoryTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWorkoutCategoryTest.AutoSize = true;
            this.lblWorkoutCategoryTest.ForeColor = System.Drawing.Color.Red;
            this.lblWorkoutCategoryTest.Location = new System.Drawing.Point(302, 259);
            this.lblWorkoutCategoryTest.Name = "lblWorkoutCategoryTest";
            this.lblWorkoutCategoryTest.Size = new System.Drawing.Size(41, 15);
            this.lblWorkoutCategoryTest.TabIndex = 74;
            this.lblWorkoutCategoryTest.Text = "label3";
            // 
            // cmbWorkout
            // 
            this.cmbWorkout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbWorkout.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbWorkout.FormattingEnabled = true;
            this.cmbWorkout.Location = new System.Drawing.Point(304, 164);
            this.cmbWorkout.Name = "cmbWorkout";
            this.cmbWorkout.Size = new System.Drawing.Size(200, 28);
            this.cmbWorkout.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 76;
            this.label3.Text = "運動名稱";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(206, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 58;
            this.label4.Text = "運動強度";
            // 
            // cmbActivityLevel
            // 
            this.cmbActivityLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbActivityLevel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbActivityLevel.FormattingEnabled = true;
            this.cmbActivityLevel.Location = new System.Drawing.Point(304, 117);
            this.cmbActivityLevel.Name = "cmbActivityLevel";
            this.cmbActivityLevel.Size = new System.Drawing.Size(200, 28);
            this.cmbActivityLevel.TabIndex = 7;
            // 
            // FrmFrontendAddWorkoutLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 374);
            this.Controls.Add(this.cmbWorkout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWorkoutCategoryTest);
            this.Controls.Add(this.txtWorkoutHours);
            this.Controls.Add(this.cmbActivityLevel);
            this.Controls.Add(this.cmbWorkoutCategory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmFrontendAddWorkoutLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddWorkout";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddWorkout_FormClosed);
            this.Load += new System.EventHandler(this.FrmAddWorkoutLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ComboBox cmbWorkoutCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWorkoutHours;
        private System.Windows.Forms.Label lblWorkoutCategoryTest;
        private System.Windows.Forms.ComboBox cmbWorkout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbActivityLevel;
    }
}