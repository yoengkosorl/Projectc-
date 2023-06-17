using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace pos
{
    internal class clsProductBrand
    {
        public int Id { get; set; }
        public string brand { get; set; }
        public string description { get; set; }


        public bool insert()
        {
            bool check = false;
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [tblbrands]
                                               ([brand]
                                               ,[description]
                                              
                                               )
                                         VALUES
                                               (@brand
                                               ,@description
                                               
                                              )",
                                              clsConection.con);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@description", description);
           
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
            SqlCommand cmd = new SqlCommand(@"delete from [tblbrands] 
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
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[tblbrands]
                                           SET [brand] = @brand
                                              ,[description] = @description
                                         WHERE id = @id"
            , clsConection.con);

            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@description", description);
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
            string sql = @"Select * From tblbrand 
                           Where (brand + lower(description))
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
