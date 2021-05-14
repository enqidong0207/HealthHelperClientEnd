
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cBoxTimesOfDay = new System.Windows.Forms.ComboBox();
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.bS_MealHistory = new System.Windows.Forms.BindingSource(this.components);
            this.btnLike = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMealHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bS_MealHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVMealHistory
            // 
            this.DGVMealHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMealHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnLike,
            this.btnEdit,
            this.btnDelete});
            this.DGVMealHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVMealHistory.Location = new System.Drawing.Point(0, 0);
            this.DGVMealHistory.Margin = new System.Windows.Forms.Padding(2);
            this.DGVMealHistory.Name = "DGVMealHistory";
            this.DGVMealHistory.RowHeadersWidth = 82;
            this.DGVMealHistory.RowTemplate.Height = 33;
            this.DGVMealHistory.Size = new System.Drawing.Size(1102, 476);
            this.DGVMealHistory.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.cBoxTimesOfDay);
            this.splitContainer1.Panel1.Controls.Add(this.mCalendar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DGVMealHistory);
            this.splitContainer1.Size = new System.Drawing.Size(1102, 720);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(533, 161);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(77, 55);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cBoxTimesOfDay
            // 
            this.cBoxTimesOfDay.FormattingEnabled = true;
            this.cBoxTimesOfDay.Location = new System.Drawing.Point(389, 190);
            this.cBoxTimesOfDay.Name = "cBoxTimesOfDay";
            this.cBoxTimesOfDay.Size = new System.Drawing.Size(121, 26);
            this.cBoxTimesOfDay.TabIndex = 1;
            // 
            // mCalendar
            // 
            this.mCalendar.Location = new System.Drawing.Point(61, 0);
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 0;
            this.mCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar_DateChanged);
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
            // btnLike
            // 
            this.btnLike.HeaderText = "喜歡";
            this.btnLike.MinimumWidth = 8;
            this.btnLike.Name = "btnLike";
            this.btnLike.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnLike.Text = "喜歡";
            this.btnLike.UseColumnTextForButtonValue = true;
            this.btnLike.Width = 60;
            // 
            // btnEdit
            // 
            this.btnEdit.HeaderText = "修改";
            this.btnEdit.MinimumWidth = 8;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseColumnTextForButtonValue = true;
            this.btnEdit.Width = 60;
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "刪除";
            this.btnDelete.MinimumWidth = 8;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 60;
            // 
            // FrmMealHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 720);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "FrmMealHistory";
            this.Text = "FrmHistoryAndFuture";
            ((System.ComponentModel.ISupportInitialize)(this.DGVMealHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewButtonColumn btnLike;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
    }
}