using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class product_details : System.Web.UI.Page
{
    devoloperkit dk = new devoloperkit();
    void FillBestSeller()
    {
        product_masterDAL pmDAL = new product_masterDAL();
        DataSet ds = pmDAL.get_product_on_home_page();
        dk.fillRepeter(ds, rptBestSeller);
    }
    void FillProductDetails()
    {
        product_masterBAL pmBAL = new product_masterBAL();
        pmBAL.prd_id = Convert.ToInt32(Request.QueryString["prd"].ToString());
        product_masterDAL pmDAL = new product_masterDAL();
        DataSet ds = pmDAL.get_product_details_for_edit(pmBAL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptPrdImages.DataSource = ds;
            rptPrdImages.DataBind();
            lblDes.Text = ds.Tables[0].Rows[0]["prd_des"].ToString();
            lbltitle.Text = ds.Tables[0].Rows[0]["prd_title"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["prd_name"].ToString();
            //lblCategory.Text = ds.Tables[0].Rows[0]["cat_name"].ToString();
            lblPrice.Text = ds.Tables[0].Rows[0]["prd_price"].ToString();
            lbldealer.Text = ds.Tables[0].Rows[0]["prd_selling_price"].ToString();



        }
        else
        {
            rptPrdImages.DataSource = null;
            rptPrdImages.DataBind();
        }
    }

    void Feature()
    {
        int prd_id = Convert.ToInt32(Request.QueryString["prd"].ToString());
        devoloperkit dk = new devoloperkit();
        DataSet ds2 = dk.getDataForEdit("product_feature", prd_id, "pf_prd_id");
        rptFeature.DataSource = ds2;
        rptFeature.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["prd"] != null && Request.QueryString["prd"].ToString() != "")
        {
            FillProductDetails();
            Feature();
            FillBestSeller();

        }
        else
        {
            Response.Redirect("shop.aspx");
        }
    }

}