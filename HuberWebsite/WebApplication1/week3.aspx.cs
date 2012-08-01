using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class week3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        if (!IsPostBack)
        {
            
            System.Data.SqlClient.SqlConnection conn =
                             new System.Data.SqlClient.SqlConnection();
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["GoDaddySQL"];
            conn.ConnectionString = conString.ConnectionString;

            conn.Open();
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;

            string sql = "";
            //Response.Write(conn.State.ToString());

            sql = "insert into huber_tracker (ip, useragent, referrer, destination, datetimewhen)" +
                " values (@ip, @useragent, @referrer, @destination, @datetimewhen)";

            System.Text.StringBuilder mysb = new System.Text.StringBuilder();

            mysb.Append("insert into huber_tracker (ip, useragent, referrer, destination,");
            mysb.Append("datetimewhen) values (@ip, @useragent, @referrer, @destination,");
            mysb.Append("@datetimewhen)");
            

            //comm.CommandText = sql;
            comm.CommandText = mysb.ToString();

            comm.Parameters.AddWithValue("@ip", Request.ServerVariables["REMOTE_ADDR"]);
            comm.Parameters.AddWithValue("@useragent", Request.ServerVariables["HTTP_USER_AGENT"]);
            if (Request.ServerVariables["HTTP_REFERER"] == null)
            {
                comm.Parameters.AddWithValue("@referrer", "");
            }
            else
            {
                comm.Parameters.AddWithValue("@referrer", Request.ServerVariables["HTTP_REFERER"]);

            }
            comm.Parameters.AddWithValue("@destination", Request.ServerVariables["URL"]);
            comm.Parameters.AddWithValue("@datetimewhen", DateTime.Now.ToString());

            comm.ExecuteNonQuery();

            lblTemp.Text = "You have been tracked!";

        }
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection conn =
                    new System.Data.SqlClient.SqlConnection();
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["GoDaddySQL"];
        conn.ConnectionString = conString.ConnectionString;

        conn.Open();
        System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
        comm.Connection = conn;

        string sql = "";
        //it is a post back. This means they clicked the search button.
        sql = "select ip, useragent, referrer, destination, datetimewhen from huber_tracker where 1=1";

        if (txtIP.Text.Length > 0 )
        {
            //concatenation is bad. use a stringbuilder instead. do not forget to tostring it.
            sql += " and ip = @ip";
            comm.Parameters.AddWithValue("@ip", txtIP.Text);
        }

        if (txtUserAgent.Text.Length > 0)
        {
            //concatenation is bad. use a stringbuilder instead. do not forget to tostring it.
            sql += " and useragent like @useragent";
            comm.Parameters.AddWithValue("@useragent", "%" + txtUserAgent.Text + "%");
        }
                
        comm.CommandText = sql;
        System.Data.DataSet ds = new System.Data.DataSet();

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();

        da.SelectCommand = comm;
        da.Fill(ds);

        rptData.DataSource = ds.Tables[0];
        rptData.DataBind();
    }
}