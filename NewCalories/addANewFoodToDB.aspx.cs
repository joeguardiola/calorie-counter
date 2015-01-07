using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace NewCalories
{
    public partial class addANewFoodToDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addNewFoodB_Click(object sender, EventArgs e)
        {
            if (foodNameTB.Text == "" && caloriesTB.Text == "")
            {
                infoMessage.Text = "Please fill out all information before adding your new food.";
                infoMessage.ForeColor = Color.Red;
            }
            else
            {
                String food_name = foodNameTB.Text;
                int category_id = Convert.ToInt32(categoryDDL.SelectedItem.Value);
                int calories = Convert.ToInt32(caloriesTB.Text);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "InsertFood";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@foodName", food_name);
                cmd.Parameters.AddWithValue("@categoryId", category_id);
                cmd.Parameters.AddWithValue("@calorie", calories);

                conn.Open();

                if(Convert.ToInt32(cmd.ExecuteNonQuery()) == -1)
                {
                    infoMessage.Text = "Error:" + food_name + " is already in the database.";
                    infoMessage.ForeColor = Color.Red;
                }
                    
                else
                {
                    infoMessage.Text = "Successfully added a new food to the database!";
                    infoMessage.ForeColor = Color.Green;
                }

                conn.Close();

                foodNameTB.Text = "";
                caloriesTB.Text = "";
            }
        }

        protected void returnToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/addFood.aspx");
        }
    }
}