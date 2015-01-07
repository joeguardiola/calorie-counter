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
    public partial class registrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addNewUserB_Click(object sender, EventArgs e)
        {
            if (firstNameTB.Text == "" || lastNameTB.Text == "" || CalorieLimitTB.Text == "" || userNameTB.Text == "" || passwordTB.Text == "")
            {
                infoMessage.Text = "Please fill out all information before adding your new user.";
                infoMessage.ForeColor = Color.Red;
            }
            else
            {
                String firstName = firstNameTB.Text;
                String lastName = lastNameTB.Text;
                int calLim = Convert.ToInt32(CalorieLimitTB.Text);
                String userName = userNameTB.Text;
                String password = passwordTB.Text;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "InsertUsers";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@calLim", calLim);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@pass", password);

                conn.Open();

                if (Convert.ToInt32(cmd.ExecuteNonQuery()) == -1)
                {
                    infoMessage.Text = "Error:" + userName + " is already in the database.";
                    infoMessage.ForeColor = Color.Red;
                }

                else
                {
                    infoMessage.Text = "Successfully added a new user to the database!";
                    infoMessage.ForeColor = Color.Green;
                }

                conn.Close();

                firstNameTB.Text = "";
                lastNameTB.Text = "";
                userNameTB.Text = "";
                passwordTB.Text = "";
                CalorieLimitTB.Text = "";

            }
        }

        protected void returnToLoginB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}