using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inquiry_list : System.Web.UI.Page
{
    void FillInquiryDetails()
    {
        inquiry_masterDAL inquiryDAL = new inquiry_masterDAL();
        DataSet ds = inquiryDAL.GetInquiryDetails();
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptInquiryDetails.DataSource = ds;
            rptInquiryDetails.DataBind();
        }
        else
        {
            rptInquiryDetails.DataSource = null;
            rptInquiryDetails.DataBind();
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
}