using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //if (System.Web.Security.FormsAuthentication.Authenticate(txtUsername.Text, txtPassword.Text))
        //{
        //    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, false);
        //}
        //else
        //{
        //    lblError.Text = "Your username or password was incorrect.";
        //}

        System.Data.SqlClient.SqlConnection conn =
                           new System.Data.SqlClient.SqlConnection();
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["GoDaddySQL"];
        conn.ConnectionString = conString.ConnectionString;

        conn.Open();
        System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
        comm.Connection = conn;

        string sql = "";

        sql = "select customerlogon from huber_customers where customerlogon = @customerlogon and customerpass = @customerpass";

        System.Data.SqlClient.SqlDataReader dr;
        comm.CommandText = sql;
        comm.Parameters.AddWithValue("@customerlogon", txtUsername.Text);
        comm.Parameters.AddWithValue("@customerpass", txtPassword.Text);

        dr = comm.ExecuteReader();

        if (dr.HasRows)
        {
            System.Web.Security.FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
            Response.Redirect("default.aspx");
        }
        else
        {
            lblError.Text = "Your username or password was invalid.";
        }
    }
}