using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gallery : System.Web.UI.Page
{
    devoloperkit dk = new devoloperkit();
    void FillGallery()
    {
        DataSet ds = dk.getActiveData("gallery_master", "gm_status");
        dk.fillRepeter(ds, rptGallery);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGallery();
        }
    }
}