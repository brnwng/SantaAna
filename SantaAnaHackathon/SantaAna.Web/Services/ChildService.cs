using SantaAna.Web.Models.Requests;
using SantaAna.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Services
{
    public class ChildService : BaseService
    {
        public int CreateChild(ChildAddRequest payload)
        {
            /*
             1. You need a connection
             2. You need a command (a function)
                a. Name
                b. Parameters
             3. You need to execute that command
                a. ExecuteNonQuery ==> public void C#
                b. ExeuteReader ==> public List<T> C#
             */
            int id = 0;

            // setting connection string to a variable
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.Child_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ChildName", payload.ChildName);
                    cmd.Parameters.AddWithValue("@ChildAgeYears", payload.ChildAgeYears);
                    cmd.Parameters.AddWithValue("@ChildAgeMonths", payload.ChildAgeMonths);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    // open SQL connection
                    sqlConn.Open();

                    // for insert or update statements
                    cmd.ExecuteNonQuery();// takes total number of rows that are affected

                    id = (int)cmd.Parameters["@ID"].Value;
                }
            }
            return id;
        } //CreateChild

        public List<Child> GetChilds()
        {
            List<Child> childList = new List<Child>();

            // setting connection string to a variable
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.Child_SelectAll", sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Child c = new Child();
                        int startingIndex = 0;

                        //reading data from db
                        c.Id = reader.GetInt32(startingIndex++);
                        c.ChildName = reader.GetString(startingIndex++);
                        c.ChildAgeYears = reader.GetInt32(startingIndex++);
                        c.ChildAgeMonths = reader.GetInt32(startingIndex++);

                        childList.Add(c);
                    }
                }
            }
            return childList;
        } //GetChilds

        public Child GetChildById(int id)
        {
            Child row = null;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.Child_GetById", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Child c = new Child();
                        int startingIndex = 0;

                        //reading data from db
                        c.Id = reader.GetInt32(startingIndex++);
                        c.ChildName = reader.GetString(startingIndex++);
                        c.ChildAgeYears = reader.GetInt32(startingIndex++);
                        c.ChildAgeMonths = reader.GetInt32(startingIndex++);

                        if (row == null)
                        {
                            row = c;
                        }
                    }
                }
            }
            return row;
        } //GetChildById

        public void DeleteChild(int id)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Child_Delete", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    sqlConn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        } //DeleteChild
    }
}