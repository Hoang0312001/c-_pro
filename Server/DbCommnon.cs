using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Server
{

    public class DbCommnon
    {

        public static string GetConnectString()
        {
            var configBuilder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
                       .AddJsonFile("./obj/appconfig.json");                    // nạp config định dạng JSON
            var configurationroot = configBuilder.Build();                // Tạo configurationroot
            return configurationroot["csdl:ketnoi2"];

        }
        public static SqlDataReader Query(string query, params Object[] objects)
        {
            // List<T> list = new List<T>();
            using var connection = new SqlConnection(GetConnectString());

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            List<SqlParameter> list = new List<SqlParameter>();

            if (query.Contains("@"))
            {
                List<String> paramers = GetParams(query);
                for (int i = 0; i < paramers.Count; i++)
                {
                    list.Add(new SqlParameter(paramers[i], objects[i]));
                    Console.WriteLine($"{paramers[i]}  {objects[i]}");
                }

            }
            command.Parameters.AddRange(list.ToArray<SqlParameter>());
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            connection.Close();
            // dataReader.Close();
            return dataReader;
        }

        public static void ModifyQueryString(string query, params Object[] objects)
        {

            using var connection = new SqlConnection(GetConnectString());
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            List<SqlParameter> list = new List<SqlParameter>();


            List<String> paramers = GetParams(query);
            for (int i = 0; i < paramers.Count; i++)
            {
                list.Add(new SqlParameter(paramers[i], objects[i]));
                // command.Parameters.AddWithValue(paramers[i], objects[i]);
                Console.WriteLine($"{paramers[i]}  {objects[i]}");
            }

            command.Parameters.AddRange(list.ToArray<SqlParameter>());

            command.ExecuteNonQuery();
            connection.Close();
            // dataReader.Close();

        }

        public static List<String> GetParams(String query)
        {
            List<String> paramers = new List<string>();
            string[] arrPamams = query.Split(" ");
            foreach (String param in arrPamams)
            {
                if (param.Contains("@"))
                {
                    paramers.Add(param);
                }
            }
            return paramers;
        }
    }
}