using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewCalories
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["loggedIn"] = false;
        }

        protected void LoginB_Click(object sender, EventArgs e)
        {
            String userName = usernameTB.Text;
            String pass = passwordTB.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Authenticate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@pass", pass);

            conn.Open();

            try
            {
                int user_id = (int)cmd.ExecuteScalar();
                if(user_id > 1)
                {
                    Session["loggedIn"] = true;
                    Session["users_id"] = user_id;

                    conn.Close();
                    Response.Redirect("userOptions.aspx");
                    //add another page with a redirect
                }
            }

            catch(NullReferenceException exception)
            {
                userwarninglabel.Visible = true;
                conn.Close();
            }

        }

        protected void registerB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/registrationPage.aspx");
        }
    }
}