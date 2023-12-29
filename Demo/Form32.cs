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
    public partial class Form32 : Form
    {
        string SID;
        public Form32()
        {
            InitializeComponent();
        }

        public Form32(string sid)
        {
            InitializeComponent();
            SID = sid;
            string sql = "select* from Student where Id='" + SID + "'";
            Dao dao=new Dao();
            IDataReader dr = dao.read(sql);
            dr.Read();
            textBox1.Text = dr["Password"].ToString();
            dr.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Update Student set PassWord='" + textBox2.Text + "'where Id='" + SID + "'";
            Dao dao = new Dao();
            int i=dao.Excute(sql);
            if(i>0)
            {
                MessageBox.Show("修改成功");
            }
        }
    }
}
