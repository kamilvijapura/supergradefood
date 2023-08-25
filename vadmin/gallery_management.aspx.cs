using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gallery_management : System.Web.UI.Page
{
    public int userId()
    {
        EncDec enc = new EncDec();
        return Convert.ToInt32(enc.Decrypt(Request.Cookies["viecomid"].Values["viecomval"].ToString()));

    }
    void fill_gallery_details_for_edit()
    {
        gallery_masterBAL gmBAL = new gallery_masterBAL();
        gmBAL.gm_id = Convert.ToInt32(Request.QueryString["gmid"].ToString());
        gallery_masterDAL gmDAL = new gallery_masterDAL();
        DataSet ds = gmDAL.get_gallery_details_for_edit(gmBAL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            rf_fu_gallerys_img.Visible = false;
            img_gallery_img.Visible = true;
            img_gallery_img.ImageUrl = ds.Tables[0].Rows[0]["gm_img"].ToString();
            if (ds.Tables[0].Rows[0]["gm_status"].ToString() == "1")
            {
                chkbxStatus.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["gm_status"].ToString() == "0")
            {
                chkbxStatus.Checked = false;
            }
            if (ds.Tables[0].Rows[0]["gm_home"].ToString() == "1")
            {
                CheckBox1.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["gm_home"].ToString() == "0")
            {
                CheckBox1.Checked = false;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["gmid"] != null && Request.QueryString["gmid"].ToString() != "")
                {
                    fill_gallery_details_for_edit();
                }
            }
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        gallery_masterBAL gmBAL = new gallery_masterBAL();

        if (Request.QueryString["gmid"] != null && Request.QueryString["gmid"].ToString() != "")
        {
            gmBAL.gm_id = Convert.ToInt32(Request.QueryString["gmid"].ToString());
        }
        else
        {
            gmBAL.gm_id = 0;
        }
        if (chkbxStatus.Checked == true)
        {
            gmBAL.gm_status = 1;
        }
        else
        {
            gmBAL.gm_status = 0;
        }
        gmBAL.gm_insip = Request.UserHostAddress;
        gmBAL.gm_insrid = userId();
        gmBAL.gm_insdt = System.DateTime.Now;
        gmBAL.gm_logip = Request.UserHostAddress;
        gmBAL.gm_logrid = userId();
        gmBAL.gm_logdt = System.DateTime.Now;

        if (CheckBox1.Checked == true)
        {
            gmBAL.gm_home = 1;
        }
        else
        {
            gmBAL.gm_home = 0;
        }
        int rval;
        if (fu_gallerys_img.HasFile)
        {
            foreach (var file in fu_gallerys_img.PostedFiles)
            {

                Guid b = Guid.NewGuid();
                hf_gallerys_ext.Value = System.IO.Path.GetExtension(file.FileName);
                hf_gallerys_name.Value = b.ToString() + hf_gallerys_ext.Value;
                file.SaveAs(Server.MapPath("~/image/gallery/" + hf_gallerys_name.Value));
                gmBAL.gm_img = "~/image/gallery/" + hf_gallerys_name.Value;

                gallery_masterDAL gmDAL = new gallery_masterDAL();
                rval = gmDAL.insert_update_gallery_master(gmBAL);
                if (rval == 2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                    //Response.Write("<script>alert('Gallery Images Added Successfully.'); window.location.href='gallerymanagement.aspx';</script>");
                }
                else if (rval == 3)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert();", true);
                    //Response.Write("<script>alert('Gallery Images Updated Successfully.'); window.location.href='gallerylist.aspx';</script>");
                }
            }
        }
        else if (Request.QueryString["gmid"] != null && Request.QueryString["gmid"].ToString() != "" && img_gallery_img.ImageUrl != "")
        {
            gmBAL.gm_img = img_gallery_img.ImageUrl;
            gallery_masterDAL gmDAL = new gallery_masterDAL();
            rval = gmDAL.insert_update_gallery_master(gmBAL);
            if (rval == 2)
            {
                //Response.Write("<script>alert('Gallery Images Added Successfully.'); window.location.href='gallerymanagement.aspx';</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);

            }
            else if (rval == 3)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert();", true);

                //Response.Write("<script>alert('Gallery Images Updated Successfully.'); window.location.href='gallerylist.aspx';</script>");
            }
        }
        else
        {
            gmBAL.gm_img = "~/image/gallery/no_image_found.png";
            gallery_masterDAL gmDAL = new gallery_masterDAL();
            rval = gmDAL.insert_update_gallery_master(gmBAL);
            if (rval == 2)
            {
                //Response.Write("<script>alert('Gallery Images Added Successfully.'); window.location.href='gallerymanagement.aspx';</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);

            }
            else if (rval == 3)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert();", true);

                //Response.Write("<script>alert('Gallery Images Updated Successfully.'); window.location.href='gallerylist.aspx';</script>");
            }
        }

    }
}