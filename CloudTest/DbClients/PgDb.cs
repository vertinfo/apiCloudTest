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

        
        private string connection = GlobalSettings.pgConn;
        public PgDb()
        {
            
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
                    string query = $"Insert Into baseloop (uId,lesson,lessonevent,devicename,feedback) values('{model.uId}','{model.lesson}','{model.lessonEvent}','{model.devicename}','{model.feedback}')";
                    NpgsqlCommand cmd = new NpgsqlCommand(query,conn);
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
