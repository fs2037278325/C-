namespace Demo
{
    partial class Form31
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导出 = new System.Windows.Forms.ToolStripMenuItem();
            this.导出选课信息至ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出选课信息至txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.取消这门课ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.取消这门课ToolStripMenuItem,
            this.导出,
            this.打印ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导出
            // 
            this.导出.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出选课信息至ExcelToolStripMenuItem,
            this.导出选课信息至txtToolStripMenuItem});
            this.导出.Name = "导出";
            this.导出.Size = new System.Drawing.Size(53, 24);
            this.导出.Text = "导出";
            this.导出.Click += new System.EventHandler(this.导出_Click);
            // 
            // 导出选课信息至ExcelToolStripMenuItem
            // 
            this.导出选课信息至ExcelToolStripMenuItem.Name = "导出选课信息至ExcelToolStripMenuItem";
            this.导出选课信息至ExcelToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.导出选课信息至ExcelToolStripMenuItem.Text = "导出选课信息至Excel";
            this.导出选课信息至ExcelToolStripMenuItem.Click += new System.EventHandler(this.导出选课信息至ExcelToolStripMenuItem_Click);
            // 
            // 导出选课信息至txtToolStripMenuItem
            // 
            this.导出选课信息至txtToolStripMenuItem.Name = "导出选课信息至txtToolStripMenuItem";
            this.导出选课信息至txtToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.导出选课信息至txtToolStripMenuItem.Text = "导出选课信息至txt";
            this.导出选课信息至txtToolStripMenuItem.Click += new System.EventHandler(this.导出选课信息至txtToolStripMenuItem_Click);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印预览ToolStripMenuItem});
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.打印ToolStripMenuItem.Text = "打印";
            // 
            // 打印预览ToolStripMenuItem
            // 
            this.打印预览ToolStripMenuItem.Name = "打印预览ToolStripMenuItem";
            this.打印预览ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.打印预览ToolStripMenuItem.Text = "打印预览";
            this.打印预览ToolStripMenuItem.Click += new System.EventHandler(this.打印预览ToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(800, 422);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "课程编号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "课程名称";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "授课老师";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "课程学分";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // 取消这门课ToolStripMenuItem
            // 
            this.取消这门课ToolStripMenuItem.Image = global::Demo.Properties.Resources.删除;
            this.取消这门课ToolStripMenuItem.Name = "取消这门课ToolStripMenuItem";
            this.取消这门课ToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.取消这门课ToolStripMenuItem.Text = "取消这门课";
            this.取消这门课ToolStripMenuItem.Click += new System.EventHandler(this.取消这门课ToolStripMenuItem_Click);
            // 
            // Form31
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form31";
            this.Text = "我的选课";
            this.Load += new System.EventHandler(this.Form31_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 取消这门课ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem 导出;
        private System.Windows.Forms.ToolStripMenuItem 导出选课信息至ExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出选课信息至txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印预览ToolStripMenuItem;
    }
}