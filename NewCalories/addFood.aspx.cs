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
    public partial class addFood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Convert.ToBoolean(Session["loggedIn"])) == true)
                Response.Redirect("login.aspx");
        }

        protected void submitB_Click(object sender, EventArgs e)
        {   
            int users_id = Convert.ToInt32(Session["users_id"]);
            int food_id = Convert.ToInt32(selectFoodDDL.SelectedItem.Value);
            int quantity = Convert.ToInt32(quantityTB.Text);
            String date = getDateFormat();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "InsertRecord";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@users_id", users_id);
            cmd.Parameters.AddWithValue("@food_id", food_id);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@recordDate", date);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            infoMessage.Text = "Successfully added food to the database";
            infoMessage.ForeColor = Color.Green;
            quantityTB.Text = "1";
        }

        protected void returnUserOptionsB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/userOptions.aspx");
        }

        protected String getDateFormat()
        {
            String retDate = "";
            retDate += foodCalendar.SelectedDate.Year + "-";
            if ((int)foodCalendar.SelectedDate.Month < 10)
                retDate += "0" + foodCalendar.SelectedDate.Month;
            else
                retDate += foodCalendar.SelectedDate.Month;
            retDate += "-";
            if ((int)foodCalendar.SelectedDate.Day < 10)
                retDate += "0" + foodCalendar.SelectedDate.Day;
            else
                retDate += foodCalendar.SelectedDate.Day;
            return retDate;
        }
    }
}