using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testimonial_list : System.Web.UI.Page
{
    date_time_conversion dtc = new date_time_conversion();
    void fill_testimonial_rpt()
    {
        testimonial_masterBAL tstBAL = new testimonial_masterBAL();
        tstBAL.tm_status = -1;
        testimonial_masterDAL tmDAL = new testimonial_masterDAL();
        DataSet ds = tmDAL.get_testimonial_details(tstBAL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            rpt_testimonial_list.DataSource = ds;
            rpt_testimonial_list.DataBind();
        }
        else
        {
            rpt_testimonial_list.DataSource = null;
            rpt_testimonial_list.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            if (!IsPostBack)
            {
                fill_testimonial_rpt();
            }
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
    }
}