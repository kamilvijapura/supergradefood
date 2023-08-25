using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_login"] != null)
        {
            Session["admin_login"] = null;
            Session.Clear();
            Session.Abandon();


        }

        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            HttpCookie viecom = new HttpCookie("viecomid");
            viecom.Expires = System.DateTime.Now.AddDays(-1);
            Response.Cookies.Add(viecom);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["admin_login"] != null)
        {
            Session["admin_login"] = null;
            Session.Clear();
            Session.Abandon();
        }

        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            HttpCookie viecom = new HttpCookie("viecomid");
            viecom.Expires = System.DateTime.Now.AddDays(-1);
            Response.Cookies.Add(viecom);
        }

        user_masterBAL usrBAL = new user_masterBAL();
        usrBAL.usr_mobile_no = txt_ctn.Text;
        usrBAL.usr_password = txt_password.Text;
        //usrBAL.usr_mobile_no = Convert.ToString(Session["mobile"]);
        //usrBAL.usr_email = Convert.ToString(Session["email"]);

        user_masterDAL usrDAL = new user_masterDAL();
        
            string[] rval = usrDAL.user_login(usrBAL).ToString().Split('|');

        //password or mobile is wrong!
        if (rval[0].ToString() == "0" && rval[1].ToString() == "0")
        {
            //Response.Write("<script>alert('Mobile No or Password Wrong');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);
        }
        //account disabled
        else if (rval[0].ToString() == "1" && rval[1].ToString() == "0")
        {
            //Response.Write("<script>alert('Your account is disabled please contact super user of system');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "disablealert();", true);
        }
        //Admin With tax calculation
        else if (rval[0].ToString() == "2" && rval[1].ToString() == "1")
        {
            Session["admin_login"] = rval[1].ToString();
            Session.Timeout = 99999;
            //Generate Cookie For Login
            EncDec enc = new EncDec();
            HttpCookie viecom = new HttpCookie("viecomid");
            viecom.Values.Add("viecomval", enc.Encrypt(rval[1].ToString()));
            viecom.Expires = System.DateTime.Now.AddDays(365);
            Response.Cookies.Add(viecom);
            Response.Redirect("category_master.aspx");
        }
    }
}