using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace NewCalories
{
    public partial class addNewCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Convert.ToBoolean(Session["loggedIn"])) == true)
                Response.Redirect("login.aspx");
        }

        protected void NewCategoryB_Click(object sender, EventArgs e)
        {
            if (addNewCategoryTB.Text == "")
            {
                infoMessage.Text = "Please fill out a category name before adding.";
                infoMessage.ForeColor = Color.Red;
            }
            else
            {
                String category_type = addNewCategoryTB.Text;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "InsertCategory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@type", category_type);

                conn.Open();

                if (Convert.ToInt32(cmd.ExecuteNonQuery()) == -1)
                {
                    infoMessage.Text = "Error:" + category_type + " is already in the database.";
                    infoMessage.ForeColor = Color.Red;
                }

                else
                {
                    infoMessage.Text = "Successfully added a new category to the database!";
                    infoMessage.ForeColor = Color.Green;
                }

                conn.Close();
                addNewCategoryTB.Text = "";
            }
        }

        protected void returnToPreviousPage_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/addANewFoodToDB.aspx");
        }
    }
}