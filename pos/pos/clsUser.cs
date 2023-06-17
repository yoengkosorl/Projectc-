using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos
{
    internal class clsUser
    {
        public int Id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }


        public bool insert()
        {
            bool check = false;
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [tblusers]
                                               ([fullname]
                                               ,[email]
                                               ,[phone]
                                               ,[password]
                                               )
                                         VALUES
                                               (@fullname
                                               ,@email
                                               ,@phone
                                               ,@password
                                              )",
                                              clsConection.con);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@password", password);
            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            return check;

        }

        public bool delete()
        {
            bool check = false;
            SqlCommand cmd = new SqlCommand(@"delete from tblusers 
                                               where id =@id",
                                              clsConection.con);
            cmd.Parameters.AddWithValue("@id", Id);

            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            return check;

        }

        public bool update()
        {
            bool check = false;
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[tblusers]
                                           SET [fullname] = @fullname
                                              ,[email] = @email
                                              ,[phone] = @phone
                                              ,[password] = @password
                                              
                                         WHERE id = @id", clsConection.con);

            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@id", Id);
            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
                throw;
            }
            return check;

        }

        public DataTable GetData(string q)
        {
            DataTable dt = new DataTable();
            string sql = @"Select * From tblusers 
                           Where (fullname + lower(email))
                           collate SQL_Latin1_General_CP850_BIN2 Like '%' + lower(@q) + '%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, clsConection.con);
            da.SelectCommand.Parameters.AddWithValue("@q", q);
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
    }
}
