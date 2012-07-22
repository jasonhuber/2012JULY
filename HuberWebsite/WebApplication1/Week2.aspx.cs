using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Week2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFname.Text = "Jason";
        }
    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        //if (txtFname.Text != "Jason")
        //{
        //    Response.Write("Oh no!");
        //}

        System.Web.UI.WebControls.Label lblFName = new Label();
        lblFName.ID = "lblFName";
        lblFName.Text = txtFname.Text;

        System.Web.UI.WebControls.Label lblEmail = new Label();
        lblEmail.ID = "lblEmail";
        lblEmail.Text = txtEmail.Text;

        System.Web.UI.WebControls.Literal lit1 = new Literal();
        lit1.Text = "<br />";

        System.Web.UI.WebControls.Literal lit2 = new Literal();
        lit2.Text = "<br />";


        PlaceHolder1.Controls.Add(lit1);
        PlaceHolder1.Controls.Add(lblEmail);
        PlaceHolder1.Controls.Add(lit2);
        PlaceHolder1.Controls.Add(lblFName);

        lblhidden.Text = Request.Form["ctl00$MainContent$txtFname"];
        lblhidden.Visible = true;

    }
}