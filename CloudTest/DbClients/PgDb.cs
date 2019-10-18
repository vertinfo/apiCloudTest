using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using CloudTest.Models;
using Npgsql;

namespace CloudTest.DbClients
{
    public class PgDb
    {

        public IConfiguration Configuration { get; }
        private string connection = "";
        public PgDb()
        {
            connection = Configuration["pgConn"];
        }

        public bool insertFeedback(LessonEventLoopModel model)
        {
            Console.WriteLine("In the db class");
            NpgsqlConnection conn = new NpgsqlConnection(connection);
            using (conn)
            {
                try
                {
                    conn.Open();
                    string query = $"Insert Into baseloop (user,lesson,lessonevent,device,feedback) values({model.UserId},{model.Lesson},{model.LessonEvent},{model.Device},{model.Feedback})";
                    NpgsqlCommand cmd = new NpgsqlCommand(query);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Row inserted");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception inserting in pg: " + ex.Message);
                    
                }
                finally
                {
                    conn.Close();
                }
                
            }
            
            return true;
        }
    }
}
