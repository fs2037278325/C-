using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace Demo
{
    public partial class Form31 : Form
    {
        string SID;
        public Form31(string sID)
        {
            SID = sID;
            InitializeComponent();
            Table();
        }
        private void Table()
        {
            string sql = "select *from CourseRecord where sId='"+SID+"'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string cID = dr["cId"].ToString();
                string sql2="select *from Course where Id='"+cID+"'";
                IDataReader dr2 = dao.read(sql2);
                dr2.Read();
                string a, b, c, d;
                a = dr2["Id"].ToString();
                b = dr2["Name"].ToString();
                c = dr2["Teacher"].ToString();
                d = dr2["Credit"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();//关闭连接
        }

        private void Form31_Load(object sender, EventArgs e)
        {

        }

        private void 取消这门课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cID = dataGridView1.SelectedCells[0].Value.ToString();
            string sql = "delete CourseRecord where sId='" + SID + "'and cId='" + cID + "'";
            Dao dao = new Dao();
            dao.Excute(sql);
            dataGridView1.Rows.Clear();
            Table();
        }



        private void 导出_Click(object sender, EventArgs e)
        {

        }

        private void 导出选课信息至ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportCourseInfoToExcel();
        }

        private void 导出选课信息至txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportCourseInfoToText();
        }

        private void ExportCourseInfoToExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Courses");
                worksheet.Cell(1, 1).Value = "课程ID";
                worksheet.Cell(1, 2).Value = "课程名称";
                worksheet.Cell(1, 3).Value = "授课教师";
                worksheet.Cell(1, 4).Value = "学分";

                int currentRow = 2;
                string sql = "SELECT Id, Name, Teacher, Credit FROM Course";

                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                while (dr.Read())
                {
                    worksheet.Cell(currentRow, 1).Value = dr["Id"].ToString();
                    worksheet.Cell(currentRow, 2).Value = dr["Name"].ToString();
                    worksheet.Cell(currentRow, 3).Value = dr["Teacher"].ToString();
                    worksheet.Cell(currentRow, 4).Value = dr["Credit"].ToString();
                    currentRow++;
                }
                dr.Close();

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Save an Excel File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                }
            }
        }

        private void ExportCourseInfoToText()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Save a Text File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    string sql = "SELECT Id, Name, Teacher, Credit FROM Course";

                    Dao dao = new Dao();
                    IDataReader dr = dao.read(sql);
                    while (dr.Read())
                    {
                        sw.WriteLine($"{dr["Id"]}, {dr["Name"]}, {dr["Teacher"]}, {dr["Credit"]}");
                    }
                    dr.Close();
                }
            }
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
            // 获取所有课程的信息
            string coursesInfo = GetAllCoursesInfo();

            // 设置打印内容
            e.Graphics.DrawString(coursesInfo, new Font("Arial", 10), Brushes.Black, new RectangleF(100, 100, e.MarginBounds.Width, e.MarginBounds.Height));
        }

        private string GetAllCoursesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // 排除新行
                {
                    sb.AppendLine($"课程编号: {row.Cells["Column1"].Value.ToString()}, 课程名称: {row.Cells["Column2"].Value.ToString()}, 授课老师: {row.Cells["Column3"].Value.ToString()}, 课程学分: {row.Cells["Column4"].Value.ToString()}");
                }
            }
            return sb.ToString();
        }


    }
}
