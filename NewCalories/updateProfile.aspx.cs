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
    public partial class updatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Convert.ToBoolean(Session["loggedIn"])) == true)
                Response.Redirect("login.aspx");
        }

        protected void changePasswordB_Click(object sender, EventArgs e)
        {
            if (changePasswordTB.Text == "")
            {
                infoMessage.Text = "You must type a new password first.";
                infoMessage.ForeColor = Color.Red;
            }
            else
            {
                int users_id = Convert.ToInt32(Session["users_id"]);
                String pass = changePasswordTB.Text;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "UpdatePassword";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@users_id", users_id);
                cmd.Parameters.AddWithValue("@pass", pass);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                infoMessage.Text += "Successfully changed your password.";
                infoMessage.ForeColor = Color.Green;
            }
        }
    
        protected void returnB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/userOptions.aspx");
        }

        protected void deleteAccountB_Click(object sender, EventArgs e)
        {
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;

            SqlCommand cmd2 = new SqlCommand();

            cmd2.CommandText = "DeleteUsersRecords";
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Connection = conn2;
            cmd2.Parameters.AddWithValue("@users_id", Convert.ToInt32(Session["users_id"]));

            conn2.Open();
            cmd2.ExecuteNonQuery();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "RemoveUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@users_id", Convert.ToInt32(Session["users_id"]));

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            conn2.Close();

            infoMessage.Text += "Successfully deleted your account.";
            infoMessage.ForeColor = Color.Green;

            Response.Redirect("login.aspx");
        }
    }
}