
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Server;

namespace server
{
    class Program
    {
        // Lấy chuỗi kết nối từ file config định dạng json,
        // Điểm lưu: csl:ketnoi2

        public static void Main(string[] args)
        {


            // var DbStringBuilder = new SqlConnectionStringBuilder();
            // DbStringBuilder["Server"] = "localhost";
            // DbStringBuilder["Database"] = "NHANVIEN";
            // DbStringBuilder["User Id"] = "sa";
            // DbStringBuilder["Password"] = "1234";

            // string sqlConnectStr = DbStringBuilder.ToString();
            // int[] param = { 20, 30 };
            // using var connection = new SqlConnection(DbCommnon.GetConnectString());

            // connection.Open();
            // Console.WriteLine(connection.State);
            // SqlCommand command = new SqlCommand();
            // command.Connection = connection;
            // command.CommandText = query;
            // List<SqlParameter> list = new List<SqlParameter>();
            // list.Add(new SqlParameter("@HIGH_SALARY", 800));
            // list.Add(new SqlParameter("@GRADE", 1));

            // // command.Parameters.AddWithValue("@DEPT_ID", 20);
            // command.Parameters.AddRange(list.ToArray<SqlParameter>());

            // int row = command.ExecuteNonQuery();
            // while (dataReader.Read())
            // {
            //     Console.WriteLine($"{dataReader["EMP_NAME"]} \t {dataReader["DEPT_ID"]}");
            // }



            // string query = "select  TOP (5) * from EMPLOYEE where DEPT_ID = @DEPT_ID and SALARY > @SALARY";
            // SqlDataReader dataReader = DbCommnon.Query(query, new object[] { 20, 800 });

            // while (dataReader.Read())
            // {
            //     Console.WriteLine($"{dataReader["EMP_NAME"]} \t {dataReader["DEPT_ID"]}");
            // }
            String query = @"insert into SALARY_GRADE (GRADE,HIGH_SALARY,LOW_SALARY) values ( @GRADE , @HIGH_SALARY , @LOW_SALARY )";
            // String query = @"update SALARY_GRADE set HIGH_SALARY = @HIGH_SALARY where GRADE =  @GRADE ";

            DbCommnon.ModifyQueryString(query, new object[] { 3, 300, 200 });

        }
    }
}