using System;
using System.Data;
using Microsoft.Data.SqlClient; // လိုအပ်တဲ့ Namespace ကိုထည့်ထားပါတယ်

namespace GinnDotNetTrainingInPersonBatch0.ConsoleApp
{
    public class AdoDotNetService
    {
        // Database နဲ့ချိတ်ဆက်ဖို့ connection string ကိုသတ်မှတ်ပါတယ်
        string connectionString = "Data Source=.;Initial Catalog=GinnDotNetTrainingInPersonBatch0;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

        // ဒေတာတွေကိုဖတ်ဖို့ Read Method ကိုရေးပြပါမယ်
        public void Read()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT [StudentId], [StudentNo], [StudentName], [FatherName], [DateOfBirth], [Gender], [Address], [MobileNo], [DeleteFlag]
                                 FROM [dbo].[Tbl_Student]";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // ဒေတာတွေကိုပြသပါမယ်
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string no = dr["StudentNo"].ToString();
                    string name = dr["StudentName"].ToString();
                    Console.WriteLine($"{i + 1} {no} - {name}");
                }

                connection.Close();
            }
        }

        // ဒေတာအသစ်ထည့်သွင်းဖို့ Create Method ကိုရေးပြပါမယ်
        public void Create()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO [dbo].[Tbl_Student] ([StudentNo], [StudentName], [FatherName], [DateOfBirth], [Gender], [Address], [MobileNo], [DeleteFlag])
                                 VALUES ('S12345', 'John Doe', 'Richard Doe', '2000-01-01', 'M', '123 Main St', '555-1234', 0)";

                SqlCommand cmd = new SqlCommand(query, connection);
                int result = cmd.ExecuteNonQuery();

                connection.Close();

                string message = result > 0 ? "Saving Successful." : "Saving Failed.";
                Console.WriteLine(message);
            }
        }

        // ဒေတာပြင်ဆင်ဖို့ Update Method ကိုရေးပြပါမယ်
        public void Update()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE [dbo].[Tbl_Student]
                                 SET [StudentName] = 'Jane Doe'
                                 WHERE StudentId = 8";

                SqlCommand cmd = new SqlCommand(query, connection);
                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Updating Successful." : "Updating Failed.";

                connection.Close();

                Console.WriteLine(message);
            }
        }

        // ဒေတာဖျက်ဖို့ Delete Method ကိုရေးပြပါမယ်
        public void Delete()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE [dbo].[Tbl_Student]
                                 SET DeleteFlag = 1
                                 WHERE StudentId = 8";

                SqlCommand cmd = new SqlCommand(query, connection);
                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

                connection.Close();

                Console.WriteLine(message);
            }
        }

    }
}