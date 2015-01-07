using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewCalories
{
    public partial class userOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Convert.ToBoolean(Session["loggedIn"])) == true)
                Response.Redirect("login.aspx");

            resultsLabel.Text = "";

            if(Convert.ToInt32(choiceRBL.SelectedItem.Value)==1)
            {
                firstDateLabel.Text = "Select a date:";
                startDateCalendar.Visible = true;
                endDateLabel.Visible = false;
                endDateCalendar.Visible = false;
                foodsDDL.Visible = false;
            }
            else if (Convert.ToInt32(choiceRBL.SelectedItem.Value) == 2)
            {
                firstDateLabel.Text = "Select a Start Date:";
                startDateCalendar.Visible = true;
                endDateLabel.Visible = true;
                endDateCalendar.Visible = true;
                foodsDDL.Visible = false;
            }
            else
            {
                firstDateLabel.Text = "Select a food you have eaten:";
                startDateCalendar.Visible = false;
                endDateLabel.Visible = false;
                endDateCalendar.Visible = false;
                foodsDDL.Visible = true;
            }
        }

        protected void submitB_Click(object sender, EventArgs e)
        {
            resultsLabel.Text = "";
            int users_id = Convert.ToInt32(Session["users_id"]);
            String startDate = getStartDate();

            if (Convert.ToInt32(choiceRBL.SelectedItem.Value) == 1)
            {
                if(printTotalCalories(users_id, startDate, startDate))
                {
                    resultsLabel.Text += "<u>Food eaten and calorie count by category</u><br></br>";
                    PrintCategoryCalorieTotals(users_id, startDate, startDate);
                }
            }
            else if (Convert.ToInt32(choiceRBL.SelectedItem.Value) == 2)
            {
                String endDate = getEndDate();
                if (printTotalCalories(users_id, startDate, endDate))
                {
                    resultsLabel.Text += "<u>Food eaten and calorie count by category</u><br></br>";
                    PrintCategoryCalorieTotals(users_id, startDate, endDate);
                }
            }
            else
            {
                String food_name = Convert.ToString(foodsDDL.SelectedItem.Value);
                resultsLabel.Text += "<br><b><u> The following is what was eaten on the same days as you ate " + food_name + ".</b></u><br>";
                PrintFoodsEatenOnDayWithUserChosenFood(users_id, food_name);
            }
        }

        protected void addFoodB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/addFood.aspx");
        }
        protected String getStartDate()
        {
            String retDate = "";
            retDate += startDateCalendar.SelectedDate.Year + "-";
            if ((int)startDateCalendar.SelectedDate.Month < 10)
                retDate += "0" + startDateCalendar.SelectedDate.Month;
            else
                retDate += startDateCalendar.SelectedDate.Month;
            retDate += "-";
            if ((int)startDateCalendar.SelectedDate.Day < 10)
                retDate += "0" + startDateCalendar.SelectedDate.Day;
            else
                retDate += startDateCalendar.SelectedDate.Day;
            return retDate;
        }

        protected String getEndDate()
        {
            String retDate = "";
            retDate += endDateCalendar.SelectedDate.Year + "-";
            if ((int)endDateCalendar.SelectedDate.Month < 10)
                retDate += "0" + endDateCalendar.SelectedDate.Month;
            else
                retDate += endDateCalendar.SelectedDate.Month;
            retDate += "-";
            if ((int)endDateCalendar.SelectedDate.Day < 10)
                retDate += "0" + endDateCalendar.SelectedDate.Day;
            else
                retDate += endDateCalendar.SelectedDate.Day;
            return retDate;
        }

        protected Boolean printTotalCalories(int users_id, String startDate, String endDate)
        {
            Boolean retVal = true;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "PrintTotalCalories";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@userId", users_id);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            conn.Open();

            if(Convert.ToString(cmd.ExecuteScalar())=="")
            {
                if (startDate == endDate)
                    resultsLabel.Text += "<b>You did not eat anything on " + startDate + "</b>";
                else
                    resultsLabel.Text += "<b>You did not eat anything between " + startDate + "and " + endDate + "</b>";
                retVal = false;
            }
            else
            {
                if (startDate == endDate)
                    resultsLabel.Text += "<b>You ate " + cmd.ExecuteScalar() + " calories on " + startDate + ".</b><br>";
                else
                    resultsLabel.Text += "<b>You ate " + cmd.ExecuteScalar() + " calories between " + startDate + " and " + endDate + ".</b><br>";
            }
            conn.Close();
            return retVal;
        }

        protected void PrintCategoryCalorieTotals(int users_id, String startDate, String endDate)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "PrintCategoryCalorieTotals";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@users_id", users_id);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                resultsLabel.Text += reader["categoryType"] + "- " + reader["calories"] + " calories<br>";

                if(startDate.Equals(endDate))
                {
                    SqlConnection conn2 = new SqlConnection();
                    conn2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
                    SqlCommand cmd2 = new SqlCommand();

                    cmd2.CommandText = "PrintFoodsEatenInCategory";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Connection = conn2;

                    cmd2.Parameters.AddWithValue("@categoryType", Convert.ToString(reader["categoryType"]));
                    cmd2.Parameters.AddWithValue("@users_id", users_id);
                    cmd2.Parameters.AddWithValue("@recordDate", startDate);

                    conn2.Open();

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while(reader2.Read())
                    {
                        resultsLabel.Text += "&nbsp&nbsp&nbsp&nbsp" + reader2["food_name"] + " x" + reader2["quantity"]+ "<br>";
                    }
                    conn2.Close();
                }
            }
            conn.Close();
        }

        protected void PrintFoodsEatenOnDayWithUserChosenFood(int users_id, String food_name)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CCDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "PrintFoodsEatenOnDayWithUserChosenFood";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@users_id", users_id);
            cmd.Parameters.AddWithValue("@food_name", food_name);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                String date = Convert.ToString(reader["recordDate"]);

                resultsLabel.Text += "<br><b> The following was eaten on " + date + " when you also ate a "+ food_name + ".</b><br><br>";
                printTotalCalories(users_id, date, date);
                PrintCategoryCalorieTotals(users_id, date, date);
            }
        }
    }
}