
namespace XxxFitnessCLub
{
    partial class FrmWorkoutLogChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtTakeDays = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblTakeDays = new System.Windows.Forms.Label();
            this.btnShowChat = new System.Windows.Forms.Button();
            this.lblTakeDaysTest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "運動消耗熱量";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "運動時數";
            series6.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(1182, 449);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTakeDaysTest);
            this.splitContainer1.Panel1.Controls.Add(this.btnShowChat);
            this.splitContainer1.Panel1.Controls.Add(this.lblTakeDays);
            this.splitContainer1.Panel1.Controls.Add(this.lblStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.dtpStartDate);
            this.splitContainer1.Panel1.Controls.Add(this.txtTakeDays);
            this.splitContainer1.Panel1.Controls.Add(this.btnBack);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Size = new System.Drawing.Size(1182, 553);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.LightGray;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1072, 25);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 50);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtTakeDays
            // 
            this.txtTakeDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTakeDays.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTakeDays.Location = new System.Drawing.Point(834, 33);
            this.txtTakeDays.Name = "txtTakeDays";
            this.txtTakeDays.Size = new System.Drawing.Size(80, 31);
            this.txtTakeDays.TabIndex = 8;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.Location = new System.Drawing.Point(573, 39);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 25);
            this.dtpStartDate.TabIndex = 9;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStartDate.Location = new System.Drawing.Point(478, 42);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(89, 20);
            this.lblStartDate.TabIndex = 10;
            this.lblStartDate.Text = "開始日期";
            // 
            // lblTakeDays
            // 
            this.lblTakeDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTakeDays.AutoSize = true;
            this.lblTakeDays.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTakeDays.Location = new System.Drawing.Point(779, 42);
            this.lblTakeDays.Name = "lblTakeDays";
            this.lblTakeDays.Size = new System.Drawing.Size(49, 20);
            this.lblTakeDays.TabIndex = 10;
            this.lblTakeDays.Text = "天數";
            // 
            // btnShowChat
            // 
            this.btnShowChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowChat.BackColor = System.Drawing.Color.Khaki;
            this.btnShowChat.FlatAppearance.BorderSize = 0;
            this.btnShowChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowChat.Location = new System.Drawing.Point(946, 25);
            this.btnShowChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowChat.Name = "btnShowChat";
            this.btnShowChat.Size = new System.Drawing.Size(98, 51);
            this.btnShowChat.TabIndex = 12;
            this.btnShowChat.Text = "呈現";
            this.btnShowChat.UseVisualStyleBackColor = false;
            this.btnShowChat.Click += new System.EventHandler(this.btnShowChat_Click);
            // 
            // lblTakeDaysTest
            // 
            this.lblTakeDaysTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTakeDaysTest.AutoSize = true;
            this.lblTakeDaysTest.ForeColor = System.Drawing.Color.Red;
            this.lblTakeDaysTest.Location = new System.Drawing.Point(834, 71);
            this.lblTakeDaysTest.Name = "lblTakeDaysTest";
            this.lblTakeDaysTest.Size = new System.Drawing.Size(41, 15);
            this.lblTakeDaysTest.TabIndex = 13;
            this.lblTakeDaysTest.Text = "label1";
            // 
            // FrmWorkoutLogChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmWorkoutLogChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWorkoutLogChart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtTakeDays;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblTakeDays;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Button btnShowChat;
        private System.Windows.Forms.Label lblTakeDaysTest;
    }
}