using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication3
{
    public class Class1
    {
        
        SqlConnection sqlCon = new SqlConnection();
        public DataTable sqlDataTable = new DataTable();
  


        public Class1()
        {
            sqlCon.ConnectionString =
                ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
        }


        public void ReadData(string command)
        {
            try
            {
                sqlCon.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlCon);
                sqlDataAdapter.Fill(sqlDataTable);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<scritp>alert('"+ex.Message+"');</scritp>");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        

        public void InsertUpdateDelete(string command)
        {
            try
            {
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand(command, sqlCon);
                int row = sqlCommand.ExecuteNonQuery();
                if (row > 0)
                {
                    HttpContext.Current.Response.Write("<scritp>alert('det är klart');</scritp>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<scritp>alert('Något gick fel');</scritp>");
                }
            }
            catch(Exception ex)
            {
                HttpContext.Current.Response.Write("<scritp>alert('" + ex.Message + "');</scritp>");
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}