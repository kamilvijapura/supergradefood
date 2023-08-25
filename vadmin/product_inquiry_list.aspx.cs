using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vadmin_form_list : System.Web.UI.Page
{

    date_time_conversion dtc = new date_time_conversion();
    void fill_salesman_rpt()
    {
        product_inquiry_masterBAL tstBAL = new product_inquiry_masterBAL();
        tstBAL.prdinq_status = -1;
        product_inquiry_masterDAL slfDAL = new product_inquiry_masterDAL();
        DataSet ds = slfDAL.GetProductDetails();


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
                fill_salesman_rpt();
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
            product_inquiry_masterBAL gmBAL = new product_inquiry_masterBAL();
            gmBAL.prdinq_id = Convert.ToInt32(e.CommandArgument.ToString());
          product_inquiry_masterDAL gmDAL = new product_inquiry_masterDAL();
            int val = gmDAL.delete_product_inquiry(gmBAL);
            if (val == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);
                //Response.Write("<script>alert('Gallery Image Delete Successfully');window.location.href='gallerylist.aspx';</script>");
            }
        }
    }
}