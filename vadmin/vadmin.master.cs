using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vadmin : System.Web.UI.MasterPage
{
    devoloperkit fu = new devoloperkit();

    protected void Page_Load(object sender, EventArgs e)
    {
         
        if (!IsPostBack)
           

        {
            fu.FillListPageRepeter("user_master",rptuser);
            if (Session["admin_login"] != null)
                {
                //lblmobile.Visible = true;
                //lblmobile.Text = Convert.ToString(Session["mobile"]);
                //lblemail.Visible = true;
                //lblemail.Text = Convert.ToString(Session["email"]);
                Linklogout.Visible = true;
                

                }
                else
                {
                Linklogout.Visible = false;
                //lblmobile.Visible = false;
                //lblemail.Visible = false;
            }

            
            }
    }



    protected void Linklogout_Click(object sender, EventArgs e)
    {
        Session["admin_login"] = "";
        //Request.Cookies["viecomid"] = "";
      
        Linklogout.Visible = false;
        //lblmobile.Visible = false;
        //lblemail.Visible = false;

        Response.Redirect("admin_login.aspx");
    }
}
