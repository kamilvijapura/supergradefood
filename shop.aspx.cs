using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shop : System.Web.UI.Page
{
    devoloperkit dk = new devoloperkit();
    void FillCategoy()
    {
        //DataSet ds = dk.getActiveData("category_master", "cat_status", 4);
        //dk.fillRepeter(ds, rptCategory);
    }

    void FillProductDetails()
    {
        product_masterBAL pmBAL = new product_masterBAL();
        pmBAL.prd_status = 1;
        product_masterDAL pmDAL = new product_masterDAL();
        DataSet ds = pmDAL.get_all_product_details(pmBAL);
        lblProductCount.Text = ds.Tables[0].Rows.Count.ToString();
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
    void FillProductByCategory()
    {
        product_masterBAL pmBAL = new product_masterBAL();
        pmBAL.prd_cat_id = Convert.ToString(Request.QueryString["cat"].ToString());
        product_masterDAL pmDAL = new product_masterDAL();
        DataSet ds = pmDAL.get_product_by_category(pmBAL);
        lblProductCount.Text = ds.Tables[0].Rows.Count.ToString();

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
        if (!IsPostBack)
        {
            FillCategoy();
          
            if (Request.QueryString["cat"] != null && Request.QueryString["cat"] != "")
            {
                FillProductByCategory();
            }
            else
            {
                FillProductDetails();
            }

        }
    }
}