using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel; //确保你已经安装了ClosedXML库
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;


namespace Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //让表显示数据
        private void Table()
        {
            string sql = "select *from Student";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while(dr.Read())
            {
                string a, b, c, d, e;
                a = dr["Id"].ToString();
                b = dr["Name"].ToString();
                c = dr["Class"].ToString();
                d = dr["Birthday"].ToString();
                e = dr["JG"].ToString();
                string[] str = { a, b, c, d, e };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f = new Form21();
            f.ShowDialog();
            dataGridView1.Rows.Clear();
            Table();
        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString() };
            Form21 f = new Form21(str);
            f.ShowDialog();
            dataGridView1.Rows.Clear();
            Table();
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            if(r==DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from Student where Id='" + id + "'and Name='" + name + "'";
                Dao dao = new Dao();
                dao.Excute(sql);
                dataGridView1.Rows.Clear();
                Table();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Table();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 方法实现
        }

        private void 导出学生信息至ExcelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT id,Name,Class,Birthday,JG FROM Student";
            Dao dao = new Dao();
            SqlDataReader dr = dao.read(sql);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Students");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Name";
                worksheet.Cell(1, 3).Value = "Class";
                worksheet.Cell(1, 4).Value = "Birthday";
                worksheet.Cell(1, 5).Value = "JG";

                int currentRow = 2;
                while (dr.Read())
                {
                    worksheet.Cell(currentRow, 1).Value = dr["id"].ToString();
                    worksheet.Cell(currentRow, 2).Value = dr["Name"].ToString();
                    worksheet.Cell(currentRow, 3).Value = dr["Class"].ToString();
                    worksheet.Cell(currentRow, 4).Value = dr["Birthday"].ToString();
                    worksheet.Cell(currentRow, 5).Value = dr["JG"].ToString();
                    currentRow++;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files|*.xlsx",
                    Title = "Save an Excel File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                }
            }
        }

        private void 导出学生信息至txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Id, Name, Class, Birthday, JG FROM Student";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files|*.txt",
                Title = "Save a Text File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    while (dr.Read())
                    {
                        string studentInfo = $"{dr["Id"]}, {dr["Name"]}, {dr["Class"]}, {dr["Birthday"]}, {dr["JG"]}";
                        sw.WriteLine(studentInfo);
                    }
                }
            }
        }

        private void 导出_Click(object sender, EventArgs e)
        {

        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            previewDialog.Document = printDoc;
            previewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // 获取所有学生的信息
            string studentInfo = GetAllStudentsInfo();

            // 设置打印内容
            e.Graphics.DrawString(studentInfo, new Font("Arial", 10), Brushes.Black, new RectangleF(100, 100, e.MarginBounds.Width, e.MarginBounds.Height));
        }

        private string GetAllStudentsInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // 排除新行
                {
                    sb.AppendLine($"列1: {row.Cells["Column1"].Value.ToString()}, 列2: {row.Cells["Column2"].Value.ToString()}, 列3: {row.Cells["Column3"].Value.ToString()}, 列4: {row.Cells["Column4"].Value.ToString()}, 列5: {row.Cells["Column5"].Value.ToString()}");
                }
            }
            return sb.ToString();
        }
    }
}

