using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    devoloperkit dk = new devoloperkit();
   
    void FillBestSeller()
    {
        product_masterDAL pmDAL = new product_masterDAL();
        DataSet ds = pmDAL.get_product_on_home_page();
        dk.fillRepeter(ds, rptBestSeller);
    }
    void FillTestimonial()
    {
        DataSet ds = dk.getActiveData("testimonial_master", "tm_status");
        dk.fillRepeter(ds, rptTestimonial);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FillCategoy();
            FillBestSeller();
            FillTestimonial();
        }
    }

}