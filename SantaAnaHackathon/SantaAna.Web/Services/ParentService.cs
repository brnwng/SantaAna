using SantaAna.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Services
{
    public class ParentService
    {
        //Select by ParentID
        public List<Parent> GetParentByID()
        {
            List<Parent> parentList = new List<Parent>();

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Parent_SelectById", sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Parent p = new Parent();
                        p.ID = reader.GetInt32(0);
                        p.FamilySize = reader.GetInt32(1);
                        p.NumberOfChildren = reader.GetInt32(2);

                        parentList.Add(p);
                    }
                }
            }
            return parentList;
        }