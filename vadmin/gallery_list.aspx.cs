using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gallery_list : System.Web.UI.Page
{
    public int userId()
    {
        EncDec enc = new EncDec();
        return Convert.ToInt32(enc.Decrypt(Request.Cookies["viecomid"].Values["viecomval"].ToString()));
    }
    void fill_gallery_rpt()
    {
        gallery_masterBAL gmBAL = new gallery_masterBAL();
        gmBAL.gm_status = -1;
        gallery_masterDAL gmDAL = new gallery_masterDAL();
        DataSet ds = gmDAL.get_galery_details(gmBAL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            rpt_gallery_list.DataSource = ds;
            rpt_gallery_list.DataBind();
        }
        else
        {
            rpt_gallery_list.DataSource = null;
            rpt_gallery_list.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            if (!IsPostBack)
            {

                fill_gallery_rpt();
            }
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
    }
    protected void rpt_gallery_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnkbtnDelete")
        {
            gallery_masterBAL gmBAL = new gallery_masterBAL();
            gmBAL.gm_id = Convert.ToInt32(e.CommandArgument.ToString());
            gallery_masterDAL gmDAL = new gallery_masterDAL();
            int val = gmDAL.delete_gallery_images(gmBAL);
            if (val == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);
                //Response.Write("<script>alert('Gallery Image Delete Successfully');window.location.href='gallerylist.aspx';</script>");
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
}