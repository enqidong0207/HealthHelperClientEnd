
namespace HHFirstDraft
{
    partial class FrmMealHistory
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
            this.DGVMealHistory = new System.Windows.Forms.DataGridView();
            this.btnLike = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalGainedCalPer = new System.Windows.Forms.Label();
            this.myCProParBf = new XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress();
            this.myCProParBedSn = new XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress();
            this.pBarDailyGain = new System.Windows.Forms.ProgressBar();
            this.myCProParSn = new XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress();
            this.myCProParLn = new XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress();
            this.myCProParDn = new XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress();
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cBoxTimesOfDay = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.bS_MealHistory = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMealHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bS_MealHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVMealHistory
            // 
            this.DGVMealHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVMealHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMealHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnLike,
            this.btnEdit,
            this.btnDelete});
            this.DGVMealHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVMealHistory.Location = new System.Drawing.Point(0, 0);
            this.DGVMealHistory.Name = "DGVMealHistory";
            this.DGVMealHistory.RowHeadersVisible = false;
            this.DGVMealHistory.RowHeadersWidth = 82;
            this.DGVMealHistory.RowTemplate.Height = 33;
            this.DGVMealHistory.Size = new System.Drawing.Size(1954, 815);
            this.DGVMealHistory.TabIndex = 0;
            // 
            // btnLike
            // 
            this.btnLike.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.btnLike.FillWeight = 156.6647F;
            this.btnLike.HeaderText = "喜歡";
            this.btnLike.MinimumWidth = 8;
            this.btnLike.Name = "btnLike";
            this.btnLike.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnLike.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.btnLike.Text = "喜歡";
            this.btnLike.UseColumnTextForButtonValue = true;
            this.btnLike.Width = 33;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.btnEdit.FillWeight = 104.8737F;
            this.btnEdit.HeaderText = "修改";
            this.btnEdit.MinimumWidth = 8;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseColumnTextForButtonValue = true;
            this.btnEdit.Width = 33;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.btnDelete.FillWeight = 38.46154F;
            this.btnDelete.HeaderText = "刪除";
            this.btnDelete.MinimumWidth = 8;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 33;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.mCalendar);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DGVMealHistory);
            this.splitContainer1.Size = new System.Drawing.Size(1954, 1231);
            this.splitContainer1.SplitterDistance = 410;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalGainedCalPer);
            this.groupBox1.Controls.Add(this.myCProParBf);
            this.groupBox1.Controls.Add(this.myCProParBedSn);
            this.groupBox1.Controls.Add(this.pBarDailyGain);
            this.groupBox1.Controls.Add(this.myCProParSn);
            this.groupBox1.Controls.Add(this.myCProParLn);
            this.groupBox1.Controls.Add(this.myCProParDn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(681, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1243, 342);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // lblTotalGainedCalPer
            // 
            this.lblTotalGainedCalPer.AutoSize = true;
            this.lblTotalGainedCalPer.Location = new System.Drawing.Point(1043, 280);
            this.lblTotalGainedCalPer.Name = "lblTotalGainedCalPer";
            this.lblTotalGainedCalPer.Size = new System.Drawing.Size(0, 37);
            this.lblTotalGainedCalPer.TabIndex = 40;
            // 
            // myCProParBf
            // 
            this.myCProParBf.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParBf.AnimationSpeed = 500;
            this.myCProParBf.BackColor = System.Drawing.Color.Transparent;
            this.myCProParBf.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParBf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParBf.InnerColor = System.Drawing.SystemColors.Control;
            this.myCProParBf.InnerMargin = 0;
            this.myCProParBf.InnerWidth = -1;
            this.myCProParBf.Location = new System.Drawing.Point(7, 48);
            this.myCProParBf.Margin = new System.Windows.Forms.Padding(4);
            this.myCProParBf.MarqueeAnimationSpeed = 2000;
            this.myCProParBf.Name = "myCProParBf";
            this.myCProParBf.OuterColor = System.Drawing.Color.LightGray;
            this.myCProParBf.OuterMargin = -26;
            this.myCProParBf.OuterWidth = 26;
            this.myCProParBf.ProgressColor = System.Drawing.Color.Pink;
            this.myCProParBf.ProgressWidth = 25;
            this.myCProParBf.SecondaryFont = new System.Drawing.Font("PMingLiU", 36F);
            this.myCProParBf.Size = new System.Drawing.Size(222, 222);
            this.myCProParBf.StartAngle = 270;
            this.myCProParBf.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParBf.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParBf.SubscriptText = "";
            this.myCProParBf.SuperscriptColor = System.Drawing.Color.White;
            this.myCProParBf.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParBf.SuperscriptText = "";
            this.myCProParBf.TabIndex = 35;
            this.myCProParBf.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParBf.timeOfDayName = null;
            this.myCProParBf.Value = 68;
            // 
            // myCProParBedSn
            // 
            this.myCProParBedSn.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParBedSn.AnimationSpeed = 500;
            this.myCProParBedSn.BackColor = System.Drawing.Color.Transparent;
            this.myCProParBedSn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParBedSn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParBedSn.InnerColor = System.Drawing.SystemColors.Control;
            this.myCProParBedSn.InnerMargin = 3;
            this.myCProParBedSn.InnerWidth = 3;
            this.myCProParBedSn.Location = new System.Drawing.Point(927, 48);
            this.myCProParBedSn.Margin = new System.Windows.Forms.Padding(6);
            this.myCProParBedSn.MarqueeAnimationSpeed = 2000;
            this.myCProParBedSn.Name = "myCProParBedSn";
            this.myCProParBedSn.OuterColor = System.Drawing.Color.LightGray;
            this.myCProParBedSn.OuterMargin = -27;
            this.myCProParBedSn.OuterWidth = 26;
            this.myCProParBedSn.ProgressColor = System.Drawing.Color.Lavender;
            this.myCProParBedSn.ProgressWidth = 25;
            this.myCProParBedSn.SecondaryFont = new System.Drawing.Font("PMingLiU", 36F);
            this.myCProParBedSn.Size = new System.Drawing.Size(222, 222);
            this.myCProParBedSn.StartAngle = 270;
            this.myCProParBedSn.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParBedSn.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParBedSn.SubscriptText = "";
            this.myCProParBedSn.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParBedSn.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.myCProParBedSn.SuperscriptText = "";
            this.myCProParBedSn.TabIndex = 39;
            this.myCProParBedSn.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParBedSn.timeOfDayName = null;
            this.myCProParBedSn.Value = 68;
            // 
            // pBarDailyGain
            // 
            this.pBarDailyGain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBarDailyGain.Location = new System.Drawing.Point(28, 280);
            this.pBarDailyGain.Margin = new System.Windows.Forms.Padding(4);
            this.pBarDailyGain.Name = "pBarDailyGain";
            this.pBarDailyGain.Size = new System.Drawing.Size(983, 46);
            this.pBarDailyGain.TabIndex = 34;
            // 
            // myCProParSn
            // 
            this.myCProParSn.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParSn.AnimationSpeed = 500;
            this.myCProParSn.BackColor = System.Drawing.Color.Transparent;
            this.myCProParSn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParSn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParSn.InnerColor = System.Drawing.SystemColors.Control;
            this.myCProParSn.InnerMargin = 2;
            this.myCProParSn.InnerWidth = -1;
            this.myCProParSn.Location = new System.Drawing.Point(695, 48);
            this.myCProParSn.Margin = new System.Windows.Forms.Padding(4);
            this.myCProParSn.MarqueeAnimationSpeed = 2000;
            this.myCProParSn.Name = "myCProParSn";
            this.myCProParSn.OuterColor = System.Drawing.Color.LightGray;
            this.myCProParSn.OuterMargin = -26;
            this.myCProParSn.OuterWidth = 26;
            this.myCProParSn.ProgressColor = System.Drawing.Color.Azure;
            this.myCProParSn.ProgressWidth = 25;
            this.myCProParSn.SecondaryFont = new System.Drawing.Font("PMingLiU", 36F);
            this.myCProParSn.Size = new System.Drawing.Size(222, 222);
            this.myCProParSn.StartAngle = 270;
            this.myCProParSn.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParSn.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParSn.SubscriptText = "";
            this.myCProParSn.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParSn.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParSn.SuperscriptText = "";
            this.myCProParSn.TabIndex = 38;
            this.myCProParSn.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParSn.timeOfDayName = null;
            this.myCProParSn.Value = 68;
            // 
            // myCProParLn
            // 
            this.myCProParLn.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParLn.AnimationSpeed = 500;
            this.myCProParLn.BackColor = System.Drawing.Color.Transparent;
            this.myCProParLn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParLn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParLn.InnerColor = System.Drawing.SystemColors.Control;
            this.myCProParLn.InnerMargin = 2;
            this.myCProParLn.InnerWidth = -1;
            this.myCProParLn.Location = new System.Drawing.Point(237, 50);
            this.myCProParLn.Margin = new System.Windows.Forms.Padding(4);
            this.myCProParLn.MarqueeAnimationSpeed = 2000;
            this.myCProParLn.Name = "myCProParLn";
            this.myCProParLn.OuterColor = System.Drawing.Color.LightGray;
            this.myCProParLn.OuterMargin = -26;
            this.myCProParLn.OuterWidth = 26;
            this.myCProParLn.ProgressColor = System.Drawing.Color.PapayaWhip;
            this.myCProParLn.ProgressWidth = 25;
            this.myCProParLn.SecondaryFont = new System.Drawing.Font("PMingLiU", 36F);
            this.myCProParLn.Size = new System.Drawing.Size(222, 222);
            this.myCProParLn.StartAngle = 270;
            this.myCProParLn.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myCProParLn.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParLn.SubscriptText = "";
            this.myCProParLn.SuperscriptColor = System.Drawing.Color.White;
            this.myCProParLn.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParLn.SuperscriptText = "";
            this.myCProParLn.TabIndex = 36;
            this.myCProParLn.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParLn.timeOfDayName = null;
            this.myCProParLn.Value = 68;
            // 
            // myCProParDn
            // 
            this.myCProParDn.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.myCProParDn.AnimationSpeed = 500;
            this.myCProParDn.BackColor = System.Drawing.Color.Transparent;
            this.myCProParDn.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.myCProParDn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCProParDn.InnerColor = System.Drawing.SystemColors.Control;
            this.myCProParDn.InnerMargin = 2;
            this.myCProParDn.InnerWidth = -1;
            this.myCProParDn.Location = new System.Drawing.Point(467, 48);
            this.myCProParDn.Margin = new System.Windows.Forms.Padding(4);
            this.myCProParDn.MarqueeAnimationSpeed = 2000;
            this.myCProParDn.Name = "myCProParDn";
            this.myCProParDn.OuterColor = System.Drawing.Color.LightGray;
            this.myCProParDn.OuterMargin = -26;
            this.myCProParDn.OuterWidth = 26;
            this.myCProParDn.ProgressColor = System.Drawing.Color.Honeydew;
            this.myCProParDn.ProgressWidth = 25;
            this.myCProParDn.SecondaryFont = new System.Drawing.Font("PMingLiU", 36F);
            this.myCProParDn.Size = new System.Drawing.Size(222, 222);
            this.myCProParDn.StartAngle = 270;
            this.myCProParDn.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParDn.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.myCProParDn.SubscriptText = "";
            this.myCProParDn.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.myCProParDn.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.myCProParDn.SuperscriptText = "";
            this.myCProParDn.TabIndex = 37;
            this.myCProParDn.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.myCProParDn.timeOfDayName = null;
            this.myCProParDn.Value = 68;
            // 
            // mCalendar
            // 
            this.mCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.mCalendar.Location = new System.Drawing.Point(0, 0);
            this.mCalendar.Margin = new System.Windows.Forms.Padding(12);
            this.mCalendar.MaxSelectionCount = 31;
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 0;
            this.mCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar_DateChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cBoxTimesOfDay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(405, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 121);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // cBoxTimesOfDay
            // 
            this.cBoxTimesOfDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxTimesOfDay.FormattingEnabled = true;
            this.cBoxTimesOfDay.Location = new System.Drawing.Point(4, 4);
            this.cBoxTimesOfDay.Margin = new System.Windows.Forms.Padding(4);
            this.cBoxTimesOfDay.Name = "cBoxTimesOfDay";
            this.cBoxTimesOfDay.Size = new System.Drawing.Size(235, 33);
            this.cBoxTimesOfDay.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(4, 64);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(235, 53);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "喜歡";
            this.dataGridViewImageColumn1.Image = global::XxxFitnessCLub.Properties.Resources.like;
            this.dataGridViewImageColumn1.MinimumWidth = 8;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 60;
            // 
            // FrmMealHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1954, 1231);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.Name = "FrmMealHistory";
            this.Text = "FrmHistoryAndFuture";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DGVMealHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bS_MealHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVMealHistory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource bS_MealHistory;
        private System.Windows.Forms.MonthCalendar mCalendar;
        private System.Windows.Forms.ComboBox cBoxTimesOfDay;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress myCProParBedSn;
        private XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress myCProParSn;
        private XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress myCProParDn;
        private XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress myCProParLn;
        private XxxFitnessCLub.ClientEnd.ViewModel.MyCircleProgress myCProParBf;
        private System.Windows.Forms.ProgressBar pBarDailyGain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalGainedCalPer;
        private System.Windows.Forms.DataGridViewButtonColumn btnLike;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
    }
}