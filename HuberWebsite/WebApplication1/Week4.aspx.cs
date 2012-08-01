using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Week4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        sql = "select productid, description, price, qoh, image from huber_products where 1=1";

       
        if (txtDescription.Text.Length > 0)
        {
            //concatenation is bad. use a stringbuilder instead. do not forget to tostring it.
            sql += " and description like @description";
            comm.Parameters.AddWithValue("@description", "%" + txtDescription.Text + "%");
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