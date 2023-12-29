using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Demo
{
    internal class Dao
    {

        public SqlConnection connection()
        {
            string str = "Data Source=LAPTOP-V1HUQMV6;Initial Catalog=Demo;Integrated Security=True";
            SqlConnection sc = new SqlConnection(str);
            sc.Open();//打开数据库链接
            return sc;
        }
        public SqlCommand command(string sql)
        {
            
            SqlCommand sc = new SqlCommand(sql, connection());
            return sc;
        }

        //用于dalete update insert,返回受影响的行数
        public int Excute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }

        //用于select，返回SqlDataReader对象，包含select到的数据
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
    }
}
