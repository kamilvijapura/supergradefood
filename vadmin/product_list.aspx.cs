using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class product_list : System.Web.UI.Page
{
    public int UserId()
    {
        EncDec enc = new EncDec();
        return Convert.ToInt32(enc.Decrypt(Request.Cookies["viecomid"].Values["viecomval"].ToString()));
    }
    void FillProductDetails()
    {
        product_masterBAL pmBAL = new product_masterBAL();
        pmBAL.prd_status = -1;
        product_masterDAL pmDAL = new product_masterDAL();
        DataSet ds = pmDAL.get_all_product_details(pmBAL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptProduct.DataSource = ds;
            rptProduct.DataBind();
        }
        else
        {
            rptProduct.DataSource = null;
            rptProduct.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            if (!IsPostBack)
            {
                FillProductDetails();
            }
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
    }

    protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnkbtnEdit")
        {
            Response.Redirect("product_management.aspx?prdid=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName == "lnkbtnDelete")
        {
            product_masterBAL gmBAL = new product_masterBAL();
            gmBAL.prd_id = Convert.ToInt32(e.CommandArgument.ToString());
            product_masterDAL gmDAL = new product_masterDAL();
            int val = gmDAL.delete_product(gmBAL);
            if (val == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);

            }
        }
    }
}