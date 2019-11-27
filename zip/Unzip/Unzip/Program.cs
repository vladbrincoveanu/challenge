using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Unzip
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipFilePath = Directory.GetFiles(@"..\..\..\..\ConsoleApp1\ConsoleApp1\bin\Debug\", "*.zip")[0];
            if (File.Exists(zipFilePath))
            {
                var fileDeleted = Directory.GetFiles(@"ExtractedHere");
                foreach (var file in fileDeleted)
                {
                    File.Delete(file);
                }
                System.Threading.Thread.Sleep(20);
                ZipFile.ExtractToDirectory(zipFilePath, @"ExtractedHere");
            }
            else
            {
                ZipFile.ExtractToDirectory(zipFilePath, @"ExtractedHere");
            }

            const string path = @"ExtractedHere\text.meta";
            if (!File.Exists(path)) return;
            using (var sr = new StreamReader(path))
            {
                string line;
                var i = 0;
                byte[] tempId = { };
                while ((line = sr.ReadLine()) != null || sr.EndOfStream)
                {
                    i++;
                    if (i < 2) continue;
                    var values = line?.Split('|');
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ironmountainEntities"]
                        .ConnectionString))
                    {
                        using (var cmd = new SqlCommand("[InsertImage]", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            var id = Encoding.UTF8.GetBytes(values[0]);
                            if (tempId == id) return;
                            if (i < 3) tempId = id;
                            var date = values[1];
                            var pathImage = values[2];
                            cmd.Parameters.Add("@Id", SqlDbType.VarBinary,int.MaxValue).Value = id;
                            cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = date;
                            cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = pathImage;

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }

            }

        }
    }
}
