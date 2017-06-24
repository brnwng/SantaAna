using SantaAna.Web.Models;
using SantaAna.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Services
{
    public class ParentService:BaseService
    {
       
        public int CreateParent(ParentAddRequest payload)
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
                using (SqlCommand cmd = new SqlCommand("dbo.Parent_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FamilySize", payload.FamilySize);
                    cmd.Parameters.AddWithValue("@NumberOfChildren", payload.NumberOfChildren);

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
        } //CreateParent

        public List<Parent> GetParents()
        {
            List<Parent> parentList = new List<Parent>();

            // setting connection string to a variable
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.Parent_Select", sqlConn))
                {
                    sqlConn.Open();
                   SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Parent p = new Parent();
                        int startingIndex = 0;

                        //reading data from db
                        p.ID = reader.GetInt32(startingIndex++);
                        p.FamilySize = reader.GetInt32(startingIndex++);
                        p.NumberOfChildren = reader.GetInt32(startingIndex++);
    

                        parentList.Add(p);
                    }
                }
            }
            return parentList;
        } //GetParent

        public Parent GetParentById(int id)
        {
            Parent row = null;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.Parent_SelectById", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Parent p = new Parent();
                        int startingIndex = 0;

                        //reading data from db
                        p.ID = reader.GetInt32(startingIndex++);
                        p.FamilySize = reader.GetInt32(startingIndex++);
                        p.NumberOfChildren = reader.GetInt32(startingIndex++);
                    

                        if (row == null)
                        {
                            row = p;
                        }
                    }
                }
            }
            return row;
        } //GetParentById

        public void DeleteParent(int id)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Parent_Delete", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    sqlConn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        } //DeleteParent
    }
}
    