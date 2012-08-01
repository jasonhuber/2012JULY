using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Week4_AddtoCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["ProductId"] != null && Request.Params["ProductId"].ToString().Length > 0)
        {
            //insert into the order lines. 
            //first I need to check to see if they have an order....
            //insert the order, and set the session variable.
            System.Data.SqlClient.SqlConnection conn =
                            new System.Data.SqlClient.SqlConnection();
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["GoDaddySQL"];
            conn.ConnectionString = conString.ConnectionString;

            conn.Open();
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;

            string sql = "";
            //Response.Write(conn.State.ToString());

            //now go and get that latest orderid
            sql = "select max(orderlinesid) + 1 from huber_orderlines";

            comm.Parameters.Clear();

            comm.CommandText = sql;
            object result;
            result = comm.ExecuteScalar();

            sql = "insert into Huber_OrderLines (Orderlinesid, OrderId, Productid, Quantity)" +
                " values (@OrderlinesId, @OrderId, @Productid, @Quantity)";

            comm.CommandText = sql;

            comm.Parameters.AddWithValue("@OrderlinesId", (int)result);
            comm.Parameters.AddWithValue("@OrderId", GetCustomerOrder(1));
            comm.Parameters.AddWithValue("@ProductId", Request.Params["ProductId"].ToString());
            comm.Parameters.AddWithValue("@Quantity", "1");
            
            comm.ExecuteNonQuery();

            lblDisplay.Text = "Your item was added to your cart!";

        }
    }

    private int GetCustomerOrder(int CustomerId)
    {
        if (Session["OrderId"] == null || Session["OrderId"].ToString().Length <= 0)
        {
             System.Data.SqlClient.SqlConnection conn =
                            new System.Data.SqlClient.SqlConnection();
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["GoDaddySQL"];
            conn.ConnectionString = conString.ConnectionString;

            conn.Open();
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;

            string sql = "";
             //now go and get that latest orderid
            sql = "select max(orderid) + 1 from huber_orders";
            
            comm.Parameters.Clear();

            comm.CommandText = sql;
            object result;
            result = comm.ExecuteScalar();

            if (result != null && result.ToString().Length > 0)
            {
                Session["OrderId"] = (int)result;
            }
            else
            {
                Session["OrderId"] = -1;
            }
           
            //insert the order, and set the session variable.
           
            //Response.Write(conn.State.ToString());

            sql = "insert into Huber_Orders (OrderId, OrderDate, CustomerId)" +
                " values (@OrderId, @OrderDate, @CustomerId)";

            //System.Text.StringBuilder mysb = new System.Text.StringBuilder();

            //mysb.Append("insert into huber_tracker (ip, useragent, referrer, destination,");
            //mysb.Append("datetimewhen) values (@ip, @useragent, @referrer, @destination,");
            //mysb.Append("@datetimewhen)");

            comm.CommandText = sql;
            //comm.CommandText = mysb.ToString();
            comm.Parameters.AddWithValue("@OrderId", Session["OrderId"].ToString());
            comm.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString());
            comm.Parameters.AddWithValue("@CustomerId", CustomerId);

            comm.ExecuteNonQuery();
            

        }
       
            return int.Parse(Session["OrderId"].ToString());
       

    }
}