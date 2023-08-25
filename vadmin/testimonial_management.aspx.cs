using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testimonial_management : System.Web.UI.Page
{
    date_time_conversion dtc = new date_time_conversion();
    public int userId()
    {
        EncDec enc = new EncDec();
        return Convert.ToInt32(enc.Decrypt(Request.Cookies["viecomid"].Values["viecomval"].ToString()));

    }
    void fill_testimonial_for_edit()
    {
        testimonial_masterBAL tmBAL = new testimonial_masterBAL();
        tmBAL.tm_id = Convert.ToInt32(Request.QueryString["tmid"].ToString());
        testimonial_masterDAL tmDAL = new testimonial_masterDAL();
        DataSet ds = tmDAL.get_testimonial_details_for_edit(tmBAL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //rf_fu_testimonials_img.Visible = false;
            txt_client_name.Text = ds.Tables[0].Rows[0]["tm_client_name"].ToString();
            txt_description.Text = ds.Tables[0].Rows[0]["tm_description"].ToString();
            txt_designation.Text = ds.Tables[0].Rows[0]["tm_designation"].ToString();
            img_testimonial_img.ImageUrl = ds.Tables[0].Rows[0]["tm_client_img"].ToString();

            if (ds.Tables[0].Rows[0]["tm_status"].ToString() == "1")
            {
                chkbxStatus.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["tm_status"].ToString() == "0")
            {
                chkbxStatus.Checked = false;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
           
            if (!Page.IsPostBack)
            {
                string ckEditorScript = "<script type='text/javascript'>CKEDITOR.replace('" + txt_description.ClientID + "');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CKEditorScript", ckEditorScript);

                if (Request.QueryString["tmid"] != null && Request.QueryString["tmid"].ToString() != "")
                {
                    fill_testimonial_for_edit();
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
        testimonial_masterBAL tmBAL = new testimonial_masterBAL();
        if (Request.QueryString["tmid"] != null && Request.QueryString["tmid"].ToString() != "")
        {
            tmBAL.tm_id = Convert.ToInt32(Request.QueryString["tmid"].ToString());
        }
        else
        {
            tmBAL.tm_id = 0;
        }
        tmBAL.tm_client_name = txt_client_name.Text;
        tmBAL.tm_designation = txt_designation.Text;

        if (fu_testimonials_img.HasFile)
        {
            Guid a = Guid.NewGuid();
            hf_testimonials_ext.Value = System.IO.Path.GetExtension(fu_testimonials_img.FileName);
            hf_testimonials_name.Value = a.ToString() + hf_testimonials_ext.Value;
            fu_testimonials_img.SaveAs(Server.MapPath("~/image/testimonial_image/" + hf_testimonials_name.Value));
            tmBAL.tm_client_img = "~/image/testimonial_image/" + hf_testimonials_name.Value;

            if (img_testimonial_img.ImageUrl != "" && img_testimonial_img.ImageUrl != "~/image/testimonial_image/no_image_found.png" && Request.QueryString["tmid"] != null && Request.QueryString["tmid"].ToString() != "" && fu_testimonials_img.HasFile)
            {
                String FileToDelete = Server.MapPath(img_testimonial_img.ImageUrl);
                File.Delete(FileToDelete);
            }
        }
        else if (Request.QueryString["tmid"] != null && Request.QueryString["tmid"].ToString() != "" && img_testimonial_img.ImageUrl != "")
        {
            tmBAL.tm_client_img = img_testimonial_img.ImageUrl;
        }
        else
        {
            tmBAL.tm_client_img = "~/image/testimonial_image/no_image_found.png";
        }
        tmBAL.tm_description = txt_description.Text;
        tmBAL.tm_insdt = System.DateTime.Now;
        tmBAL.tm_insip = "1";
        tmBAL.tm_insrid = userId();

        tmBAL.tm_logdt = System.DateTime.Now;
        tmBAL.tm_logip = "1";
        tmBAL.tm_logrid = userId();
        if (chkbxStatus.Checked == true)
        {
            tmBAL.tm_status = 1;
        }
        else 
        {
            tmBAL.tm_status = 0;
        }
        testimonial_masterDAL tmDAL = new testimonial_masterDAL();
        int val = tmDAL.insert_update_testimonial_master(tmBAL);
        if (val == 2)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            //Response.Write("<script>alert('Testimonial Added Successfully'); window.location.href='testimonial_list.aspx'; </script>");
        }
        else if (val == 3)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert();", true);
            // Response.Write("<script>alert('Testimonial Update Successfully'); window.location.href='testimonial_list.aspx'; </script>");
        }
        else
        {
            //Response.Write("<script>alert('Testimonial Already Added'); </script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);
        }
    }
}