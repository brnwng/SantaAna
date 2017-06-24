using SantaAna.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Services
{
    public class FoodService : BaseService
    {
        public List<Food> GetFood()
        {
            List<Food> foodList = new List<Food>();

            // setting connection string to a variable
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.Food_SelectAll", sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Food f = new Food();
                        int startingIndex = 0;

                        //reading data from db
                        f.Id = reader.GetInt32(startingIndex++);
                        f.Name = reader.GetString(startingIndex++);
                        f.Type = reader.GetString(startingIndex++);
                        f.Calories = reader.GetInt32(startingIndex++);
                        f.Fat = reader.GetInt32(startingIndex++);
                        f.Carbs = reader.GetInt32(startingIndex++);
                        f.Protein = reader.GetInt32(startingIndex++);

                        foodList.Add(f);
                    }
                }
            }
            return foodList;
        }

        public List<Food> GetFoodByType(string type)
        {
            List<Food> foodList = new List<Food>();

            // setting connection string to a variable
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.Food_SelectByType", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", type);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Food f = new Food();
                        int startingIndex = 0;

                        //reading data from db
                        f.Id = reader.GetInt32(startingIndex++);
                        f.Name = reader.GetString(startingIndex++);
                        f.Type = reader.GetString(startingIndex++);
                        f.Calories = reader.GetInt32(startingIndex++);
                        f.Fat = reader.GetInt32(startingIndex++);
                        f.Carbs = reader.GetInt32(startingIndex++);
                        f.Protein = reader.GetInt32(startingIndex++);

                        foodList.Add(f);
                    }
                }
            }
            return foodList;
        }
    }
}