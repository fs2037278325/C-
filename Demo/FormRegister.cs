using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;           // 学生ID
            string name = textBox2.Text;         // 学生姓名
            string studentClass = textBox3.Text; // 班级
            string birthday = textBox4.Text;     // 生日
            string address = textBox5.Text;      // 家庭住址
            string password = textBox6.Text;     // 密码

            // 构建 SQL 插入语句
            string sql = $"INSERT INTO Student (Id, Name, Class, Birthday, JG, PassWord) VALUES ('{id}', '{name}', '{studentClass}', '{birthday}', '{address}', '{password}')";

            Dao dao = new Dao();
            if (dao.Excute(sql) > 0) // 注意使用 'Excute'（如果您还没有重命名方法的话）
            {
                MessageBox.Show("学生注册成功！");
            }
            else
            {
                MessageBox.Show("注册失败，请检查信息是否正确。");
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }
    }
}
