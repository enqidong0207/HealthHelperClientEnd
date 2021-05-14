
namespace XxxFitnessCLub.ClientEnd
{
    partial class FrmMealLog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxTimesOfDay = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnProtionCheck = new System.Windows.Forms.Button();
            this.lblGainCal = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.tBoxPortion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LabelMealTitle = new System.Windows.Forms.Label();
            this.tBoxCal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pBoxMeal = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cBoxKeyWord = new System.Windows.Forms.ComboBox();
            this.DGVAddedMeals = new System.Windows.Forms.DataGridView();
            this.DeleteCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bS_AddedMeals = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnRefImg = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myCProParBedSn = new ViewModel.MyCircleProgress();
            this.myCProParSn = new ViewModel.MyCircleProgress();
            this.myCProParDn = new ViewModel.MyCircleProgress();
            this.myCProParLn = new ViewModel.MyCircleProgress();
            this.myCProParBf = new ViewModel.MyCircleProgress();
            this.pBarDailyGain = new System.Windows.Forms.ProgressBar();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClear = new System.Windows.Forms.Button();
            this.DGVRecordOfToday = new System.Windows.Forms.DataGridView();
            this.bS_RecordOfToday = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMeal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAddedMeals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bS_AddedMeals)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecordOfToday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bS_RecordOfToday)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1830, 68);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(810, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 46);
            this.label2.TabIndex = 6;
            this.label2.Text = "飲食Log";
            // 
            // cBoxTimesOfDay
            // 
            this.cBoxTimesOfDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cBoxTimesOfDay.FormattingEnabled = true;
            this.cBoxTimesOfDay.Location = new System.Drawing.Point(360, 106);
            this.cBoxTimesOfDay.Name = "cBoxTimesOfDay";
            this.cBoxTimesOfDay.Size = new System.Drawing.Size(264, 26);
            this.cBoxTimesOfDay.TabIndex = 16;
            this.cBoxTimesOfDay.Text = "請選擇時段";
            this.cBoxTimesOfDay.SelectedIndexChanged += new System.EventHandler(this.cBoxTimesOfDay_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmit.Location = new System.Drawing.Point(0, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(605, 34);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSendMealsToDB_Click);
            // 
            // btnProtionCheck
            // 
            this.btnProtionCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProtionCheck.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProtionCheck.Location = new System.Drawing.Point(549, 165);
            this.btnProtionCheck.Name = "btnProtionCheck";
            this.btnProtionCheck.Size = new System.Drawing.Size(75, 32);
            this.btnProtionCheck.TabIndex = 34;
            this.btnProtionCheck.Text = "確定";
            this.btnProtionCheck.UseVisualStyleBackColor = false;
            this.btnProtionCheck.Click += new System.EventHandler(this.btnProtionCheck_Click);
            // 
            // lblGainCal
            // 
            this.lblGainCal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGainCal.AutoSize = true;
            this.lblGainCal.ForeColor = System.Drawing.Color.Red;
            this.lblGainCal.Location = new System.Drawing.Point(492, 243);
            this.lblGainCal.Name = "lblGainCal";
            this.lblGainCal.Size = new System.Drawing.Size(50, 18);
            this.lblGainCal.TabIndex = 33;
            this.lblGainCal.Text = "label1";
            this.lblGainCal.Visible = false;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddToList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddToList.Location = new System.Drawing.Point(360, 264);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(122, 49);
            this.btnAddToList.TabIndex = 32;
            this.btnAddToList.Text = "確定";
            this.btnAddToList.UseVisualStyleBackColor = false;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToTempList_Click);
            // 
            // tBoxPortion
            // 
            this.tBoxPortion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBoxPortion.Location = new System.Drawing.Point(360, 165);
            this.tBoxPortion.Name = "tBoxPortion";
            this.tBoxPortion.Size = new System.Drawing.Size(182, 29);
            this.tBoxPortion.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 18);
            this.label9.TabIndex = 30;
            this.label9.Text = "份量:";
            // 
            // LabelMealTitle
            // 
            this.LabelMealTitle.AutoSize = true;
            this.LabelMealTitle.Font = new System.Drawing.Font("新細明體", 20F);
            this.LabelMealTitle.Location = new System.Drawing.Point(7, 27);
            this.LabelMealTitle.Name = "LabelMealTitle";
            this.LabelMealTitle.Size = new System.Drawing.Size(177, 40);
            this.LabelMealTitle.TabIndex = 27;
            this.LabelMealTitle.Text = "菜色名稱";
            // 
            // tBoxCal
            // 
            this.tBoxCal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBoxCal.Location = new System.Drawing.Point(360, 130);
            this.tBoxCal.Name = "tBoxCal";
            this.tBoxCal.Size = new System.Drawing.Size(182, 29);
            this.tBoxCal.TabIndex = 26;
            this.tBoxCal.TextChanged += new System.EventHandler(this.tBoxCal_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(303, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "餐點:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // pBoxMeal
            // 
            this.pBoxMeal.Location = new System.Drawing.Point(14, 85);
            this.pBoxMeal.Name = "pBoxMeal";
            this.pBoxMeal.Size = new System.Drawing.Size(230, 233);
            this.pBoxMeal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxMeal.TabIndex = 24;
            this.pBoxMeal.TabStop = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(285, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 18);
            this.label11.TabIndex = 23;
            this.label11.Text = "卡路里:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // cBoxKeyWord
            // 
            this.cBoxKeyWord.FormattingEnabled = true;
            this.cBoxKeyWord.Location = new System.Drawing.Point(358, 27);
            this.cBoxKeyWord.Name = "cBoxKeyWord";
            this.cBoxKeyWord.Size = new System.Drawing.Size(266, 26);
            this.cBoxKeyWord.TabIndex = 21;
            this.cBoxKeyWord.SelectedIndexChanged += new System.EventHandler(this.cBoxKeyWord_SelectedIndexChanged_1);
            // 
            // DGVAddedMeals
            // 
            this.DGVAddedMeals.BackgroundColor = System.Drawing.Color.White;
            this.DGVAddedMeals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAddedMeals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteCol});
            this.DGVAddedMeals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVAddedMeals.Location = new System.Drawing.Point(918, 376);
            this.DGVAddedMeals.Name = "DGVAddedMeals";
            this.DGVAddedMeals.RowHeadersVisible = false;
            this.DGVAddedMeals.RowHeadersWidth = 62;
            this.DGVAddedMeals.RowTemplate.Height = 31;
            this.DGVAddedMeals.Size = new System.Drawing.Size(909, 494);
            this.DGVAddedMeals.TabIndex = 34;
            // 
            // DeleteCol
            // 
            this.DeleteCol.DataPropertyName = "btnDelete";
            this.DeleteCol.HeaderText = "刪除紐";
            this.DeleteCol.MinimumWidth = 10;
            this.DeleteCol.Name = "DeleteCol";
            this.DeleteCol.Text = "刪除紐";
            this.DeleteCol.UseColumnTextForButtonValue = true;
            this.DeleteCol.Width = 200;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DGVAddedMeals, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DGVRecordOfToday, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1830, 873);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.pBoxMeal);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.LabelMealTitle);
            this.groupBox1.Controls.Add(this.tBoxCal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tBoxPortion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddToList);
            this.groupBox1.Controls.Add(this.BtnRefImg);
            this.groupBox1.Controls.Add(this.cBoxTimesOfDay);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.lblGainCal);
            this.groupBox1.Controls.Add(this.cBoxKeyWord);
            this.groupBox1.Controls.Add(this.btnProtionCheck);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(905, 323);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(630, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(270, 291);
            this.listBox1.TabIndex = 38;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(360, 208);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 29);
            this.textBox1.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 41;
            this.label6.Text = "獲取卡路里:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 18);
            this.label5.TabIndex = 40;
            this.label5.Text = "時段:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 39;
            this.label4.Text = "日期:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "/ 每100克";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // BtnRefImg
            // 
            this.BtnRefImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnRefImg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnRefImg.Location = new System.Drawing.Point(502, 266);
            this.BtnRefImg.Name = "BtnRefImg";
            this.BtnRefImg.Size = new System.Drawing.Size(122, 49);
            this.BtnRefImg.TabIndex = 36;
            this.BtnRefImg.Text = "分量參考";
            this.BtnRefImg.UseVisualStyleBackColor = false;
            this.BtnRefImg.Click += new System.EventHandler(this.BtnRefImg_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Location = new System.Drawing.Point(358, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(266, 29);
            this.dateTimePicker1.TabIndex = 35;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.IndianRed;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 336);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(909, 34);
            this.panel4.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(404, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "今日紀錄";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.myCProParBedSn);
            this.panel2.Controls.Add(this.myCProParSn);
            this.panel2.Controls.Add(this.myCProParDn);
            this.panel2.Controls.Add(this.myCProParLn);
            this.panel2.Controls.Add(this.myCProParBf);
            this.panel2.Controls.Add(this.pBarDailyGain);
            this.panel2.Controls.Add(this.lblGreeting);
            this.panel2.Location = new System.Drawing.Point(918, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 327);
            this.panel2.TabIndex = 35;
            // 
            // myCProParBedSn
            // 
            this.myCProParBedSn.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParBedSn.AnimationSpeed = 500;
            this.myCProParBedSn.BackColor = System.Drawing.Color.Transparent;
            this.myCProParBedSn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParBedSn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParBedSn.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myCProParBedSn.InnerMargin = 2;
            this.myCProParBedSn.InnerWidth = -1;
            this.myCProParBedSn.Location = new System.Drawing.Point(494, 64);
            this.myCProParBedSn.MarqueeAnimationSpeed = 2000;
            this.myCProParBedSn.Name = "myCProParBedSn";
            this.myCProParBedSn.OuterColor = System.Drawing.Color.Gray;
            this.myCProParBedSn.OuterMargin = -25;
            this.myCProParBedSn.OuterWidth = 26;
            this.myCProParBedSn.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.myCProParBedSn.ProgressWidth = 25;
            this.myCProParBedSn.SecondaryFont = new System.Drawing.Font("新細明體", 36F);
            this.myCProParBedSn.Size = new System.Drawing.Size(116, 112);
            this.myCProParBedSn.StartAngle = 270;
            this.myCProParBedSn.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParBedSn.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParBedSn.SubscriptText = ".23";
            this.myCProParBedSn.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParBedSn.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParBedSn.SuperscriptText = "°C";
            this.myCProParBedSn.TabIndex = 33;
            this.myCProParBedSn.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParBedSn.timeOfDayName = null;
            this.myCProParBedSn.Value = 68;
            // 
            // myCProParSn
            // 
            this.myCProParSn.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParSn.AnimationSpeed = 500;
            this.myCProParSn.BackColor = System.Drawing.Color.Transparent;
            this.myCProParSn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParSn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParSn.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myCProParSn.InnerMargin = 2;
            this.myCProParSn.InnerWidth = -1;
            this.myCProParSn.Location = new System.Drawing.Point(372, 66);
            this.myCProParSn.MarqueeAnimationSpeed = 2000;
            this.myCProParSn.Name = "myCProParSn";
            this.myCProParSn.OuterColor = System.Drawing.Color.Gray;
            this.myCProParSn.OuterMargin = -25;
            this.myCProParSn.OuterWidth = 26;
            this.myCProParSn.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.myCProParSn.ProgressWidth = 25;
            this.myCProParSn.SecondaryFont = new System.Drawing.Font("新細明體", 36F);
            this.myCProParSn.Size = new System.Drawing.Size(116, 112);
            this.myCProParSn.StartAngle = 270;
            this.myCProParSn.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParSn.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParSn.SubscriptText = ".23";
            this.myCProParSn.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParSn.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParSn.SuperscriptText = "°C";
            this.myCProParSn.TabIndex = 32;
            this.myCProParSn.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParSn.timeOfDayName = null;
            this.myCProParSn.Value = 68;
            // 
            // myCProParDn
            // 
            this.myCProParDn.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParDn.AnimationSpeed = 500;
            this.myCProParDn.BackColor = System.Drawing.Color.Transparent;
            this.myCProParDn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParDn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParDn.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myCProParDn.InnerMargin = 2;
            this.myCProParDn.InnerWidth = -1;
            this.myCProParDn.Location = new System.Drawing.Point(254, 66);
            this.myCProParDn.MarqueeAnimationSpeed = 2000;
            this.myCProParDn.Name = "myCProParDn";
            this.myCProParDn.OuterColor = System.Drawing.Color.Gray;
            this.myCProParDn.OuterMargin = -25;
            this.myCProParDn.OuterWidth = 26;
            this.myCProParDn.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.myCProParDn.ProgressWidth = 25;
            this.myCProParDn.SecondaryFont = new System.Drawing.Font("新細明體", 36F);
            this.myCProParDn.Size = new System.Drawing.Size(116, 112);
            this.myCProParDn.StartAngle = 270;
            this.myCProParDn.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParDn.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParDn.SubscriptText = ".23";
            this.myCProParDn.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParDn.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParDn.SuperscriptText = "°C";
            this.myCProParDn.TabIndex = 31;
            this.myCProParDn.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParDn.timeOfDayName = null;
            this.myCProParDn.Value = 68;
            // 
            // myCProParLn
            // 
            this.myCProParLn.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParLn.AnimationSpeed = 500;
            this.myCProParLn.BackColor = System.Drawing.Color.Transparent;
            this.myCProParLn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParLn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParLn.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myCProParLn.InnerMargin = 2;
            this.myCProParLn.InnerWidth = -1;
            this.myCProParLn.Location = new System.Drawing.Point(134, 66);
            this.myCProParLn.MarqueeAnimationSpeed = 2000;
            this.myCProParLn.Name = "myCProParLn";
            this.myCProParLn.OuterColor = System.Drawing.Color.Gray;
            this.myCProParLn.OuterMargin = -25;
            this.myCProParLn.OuterWidth = 26;
            this.myCProParLn.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.myCProParLn.ProgressWidth = 25;
            this.myCProParLn.SecondaryFont = new System.Drawing.Font("新細明體", 36F);
            this.myCProParLn.Size = new System.Drawing.Size(116, 112);
            this.myCProParLn.StartAngle = 270;
            this.myCProParLn.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParLn.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParLn.SubscriptText = ".23";
            this.myCProParLn.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParLn.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParLn.SuperscriptText = "°C";
            this.myCProParLn.TabIndex = 30;
            this.myCProParLn.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParLn.timeOfDayName = null;
            this.myCProParLn.Value = 68;
            // 
            // myCProParBf
            // 
            this.myCProParBf.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParBf.AnimationSpeed = 500;
            this.myCProParBf.BackColor = System.Drawing.Color.Transparent;
            this.myCProParBf.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParBf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParBf.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myCProParBf.InnerMargin = 2;
            this.myCProParBf.InnerWidth = -1;
            this.myCProParBf.Location = new System.Drawing.Point(12, 66);
            this.myCProParBf.MarqueeAnimationSpeed = 2000;
            this.myCProParBf.Name = "myCProParBf";
            this.myCProParBf.OuterColor = System.Drawing.Color.Gray;
            this.myCProParBf.OuterMargin = -25;
            this.myCProParBf.OuterWidth = 26;
            this.myCProParBf.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.myCProParBf.ProgressWidth = 25;
            this.myCProParBf.SecondaryFont = new System.Drawing.Font("新細明體", 36F);
            this.myCProParBf.Size = new System.Drawing.Size(116, 112);
            this.myCProParBf.StartAngle = 270;
            this.myCProParBf.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParBf.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParBf.SubscriptText = ".23";
            this.myCProParBf.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParBf.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParBf.SuperscriptText = "°C";
            this.myCProParBf.TabIndex = 29;
            this.myCProParBf.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParBf.timeOfDayName = null;
            this.myCProParBf.Value = 68;
            // 
            // pBarDailyGain
            // 
            this.pBarDailyGain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBarDailyGain.Location = new System.Drawing.Point(26, 282);
            this.pBarDailyGain.Name = "pBarDailyGain";
            this.pBarDailyGain.Size = new System.Drawing.Size(827, 33);
            this.pBarDailyGain.TabIndex = 22;
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Location = new System.Drawing.Point(9, 20);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(50, 18);
            this.lblGreeting.TabIndex = 21;
            this.lblGreeting.Text = "label1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(918, 336);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSubmit);
            this.splitContainer1.Size = new System.Drawing.Size(909, 34);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 37;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(300, 34);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // DGVRecordOfToday
            // 
            this.DGVRecordOfToday.BackgroundColor = System.Drawing.Color.White;
            this.DGVRecordOfToday.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVRecordOfToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRecordOfToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVRecordOfToday.Location = new System.Drawing.Point(3, 376);
            this.DGVRecordOfToday.Name = "DGVRecordOfToday";
            this.DGVRecordOfToday.RowHeadersVisible = false;
            this.DGVRecordOfToday.RowHeadersWidth = 62;
            this.DGVRecordOfToday.RowTemplate.Height = 31;
            this.DGVRecordOfToday.Size = new System.Drawing.Size(909, 494);
            this.DGVRecordOfToday.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(177, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 43;
            this.label7.Text = "YOOOO";
            this.label7.Visible = false;
            // 
            // FrmMealLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1830, 941);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMealLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMealLog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmMealLog_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMeal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAddedMeals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bS_AddedMeals)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecordOfToday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bS_RecordOfToday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxTimesOfDay;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cBoxKeyWord;
        private System.Windows.Forms.TextBox tBoxPortion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LabelMealTitle;
        private System.Windows.Forms.TextBox tBoxCal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pBoxMeal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label lblGainCal;
        private System.Windows.Forms.Button btnProtionCheck;
        private System.Windows.Forms.DataGridView DGVAddedMeals;
        private System.Windows.Forms.BindingSource bS_AddedMeals;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.ProgressBar pBarDailyGain;
        private System.Windows.Forms.Button btnClear;
        private ViewModel.MyCircleProgress myCProParBf;
        private ViewModel.MyCircleProgress myCProParBedSn;
        private ViewModel.MyCircleProgress myCProParSn;
        private ViewModel.MyCircleProgress myCProParDn;
        private ViewModel.MyCircleProgress myCProParLn;
        private System.Windows.Forms.Button BtnRefImg;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DGVRecordOfToday;
        private System.Windows.Forms.BindingSource bS_RecordOfToday;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}