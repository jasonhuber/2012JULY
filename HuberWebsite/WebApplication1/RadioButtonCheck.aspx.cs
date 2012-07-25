using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RadioButtonCheck : System.Web.UI.Page
{
    DateTime x;
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomValidator1.Validate();
       
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.RadioButton myradio = 
            (System.Web.UI.WebControls.RadioButton)sender;
        Response.Write(myradio.Text);
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBox1.Text = Calendar1.SelectedDate.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //this runs after the page load.
        if (CustomValidator1.IsValid)
        {
            //now I can run my update code.
            Response.Write(x.ToString());
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (TextBox1.Text.Length > 0)
        {
            CustomValidator1.IsValid = true;
        }
        else
        {
            CustomValidator1.IsValid = false;
        }
    }
}