using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vadmin_review_list : System.Web.UI.Page
{
    void FillInquiryDetails()
    {
        replyDAL inquiryDAL = new replyDAL();
        DataSet ds = inquiryDAL.GetReplyDetails();

        if (ds.Tables[0].Rows.Count > 0)
        {
            repdealer.DataSource = ds;
            repdealer.DataBind();
        }
        else
        {
            repdealer.DataSource = null;
            repdealer.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            if (!IsPostBack)
            {
                FillInquiryDetails();
            }
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
    }
    protected void repdealer_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnkbtnDelete")
        {
            replyBAL gmBAL = new replyBAL();
            gmBAL.r_id = Convert.ToInt32(e.CommandArgument.ToString());
           replyDAL gmDAL = new replyDAL();
            int val = gmDAL.delete_reply(gmBAL);
            if (val == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);
                //Response.Write("<script>alert('Gallery Image Delete Successfully');window.location.href='gallerylist.aspx';</script>");
            }
        }
    }
}
