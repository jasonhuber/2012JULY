using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class week5_checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OrderId"] != null && Session["OrderId"].ToString().Length > 0)
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
            sql = "select huber_products.productid, quantity, image, price, description from huber_products inner join huber_orderlines on huber_products.productid = huber_orderlines.productid where orderid = @orderid";

            comm.Parameters.AddWithValue("@orderid", Session["orderid"].ToString());

            comm.CommandText = sql;
            System.Data.DataSet ds = new System.Data.DataSet();

            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();

            da.SelectCommand = comm;
            da.Fill(ds);

            rptLineItems.DataSource = ds.Tables[0];
            rptLineItems.DataBind();
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }
    protected void btncheckout_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection conn =
                           new System.Data.SqlClient.SqlConnection();
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["GoDaddySQL"];
        conn.ConnectionString = conString.ConnectionString;

        conn.Open();
        System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
        comm.Connection = conn;

        string sql = "";
        //create the transaction
        System.Data.SqlClient.SqlTransaction trans = conn.BeginTransaction();

        comm.Transaction = trans;

        sql = "update huber_orders set ordercomplete = 'true' where orderid = @orderid";
        var result = "";
        comm.CommandText = sql;
        comm.Parameters.AddWithValue("@orderid", Session["OrderId"]);

        try
        {
            comm.ExecuteNonQuery();
            //we are pretending that a cc starting with 1 is a bad CC# and the CC transaction fails
            if (cc.Text.IndexOf("1") == 0)
            {
                trans.Rollback();
                lblError.Text = "Your transaction failed!";
            }
            else
            {
                lblError.Text = "Your transaction succeeded!";
                trans.Commit();
                sql = "";
                //it is a post back. This means they clicked the search button.
                //                              0           1       2       3       4
                sql = "select huber_products.productid, quantity, image, price, description from huber_products inner join huber_orderlines on huber_products.productid = huber_orderlines.productid where orderid = @orderid";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@orderid", Session["orderid"].ToString());

                comm.CommandText = sql;
                System.Data.SqlClient.SqlDataReader dr;
                dr = comm.ExecuteReader();
                string messagebody = "";
                while (dr.Read())
                {
                    messagebody += dr.GetValue(1).ToString() + " " + dr.GetValue(3).ToString() + " " + dr.GetValue(4).ToString() + "<br />";
                }

                DeVry.Huber.Mail.HuberMessage message = new DeVry.Huber.Mail.HuberMessage();
                message.Send(messagebody, "website@shawnstealscode.com", "customeremailhere@something.com", "Your order details");
            
            }
        }
        catch (Exception ex)
        {
            trans.Rollback();
        }

        
    }
}