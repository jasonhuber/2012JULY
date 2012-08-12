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
            }
        }
        catch (Exception ex)
        {
            trans.Rollback();
        }

        
    }
}