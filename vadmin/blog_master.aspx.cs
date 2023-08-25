using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog_master : System.Web.UI.Page
{
    devoloperkit fu = new devoloperkit();
    void GetBlogDetails()
    {
        DataSet ds = fu.getDataForEdit("blog_master", Convert.ToInt32(Request.QueryString["blog"].ToString()), "blog_id");
        if (ds.Tables[0].Rows.Count > 0)
        {
            fu.fillHiddenfieldData(ds, hfblogId, "blog_id");
            fu.fillTextboxData(ds, txtCategory, "blog_title");
            fu.fillTextboxData(ds, txtDescription, "blog_content");
            fu.fillTextboxData(ds, txt_author, "blog_author");
            fu.fillTextboxData(ds, txt_date, "blog_date");
            fu.fillImageData(ds, img_img, "blog_image");
            fu.fillstatusCheckbox(ds, chkbxStatus, "blog_status");

        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string ckEditorScript = "<script type='text/javascript'>CKEDITOR.replace('" + txtDescription.ClientID + "');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CKEditorScript", ckEditorScript);
            fu.LoginRequire();

            bool qschecker = fu.QueryStringExistorNot("blog");
            if (qschecker)
            {
                GetBlogDetails();
            }

        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        blog_masterBAL blogBAL = new blog_masterBAL();
        blogBAL.blog_id = fu.InsertPrimarikey(hfblogId);
        blogBAL.blog_title = txtCategory.Text;
        blogBAL.blog_content = txtDescription.Text;
        blogBAL.blog_author = txt_author.Text;
        blogBAL.blog_date = txt_date.Text;
        //blogBAL.blog_image = fu.imageUpload(fu_img, img_img, hfblogId, "blog");
        //blogBAL.blog_status = fu.InsertStatusCheckBox(chkbxStatus);
        if (chkbxStatus.Checked == true)
        {
            blogBAL.blog_status = 1;
        }
        else
        {
            blogBAL.blog_status = 0;
        }

        if (fu_img.HasFile)
        {

            Guid a = Guid.NewGuid();
            hf_ext.Value = System.IO.Path.GetExtension(fu_img.FileName);
            hf_name.Value = a.ToString() + hf_ext.Value;
            fu_img.SaveAs(Server.MapPath("~/image/blog/" + hf_name.Value));
            blogBAL.blog_image = "~/image/blog/" + hf_name.Value;
            if (img_img.ImageUrl != "" && hfblogId.Value != null && hfblogId.Value.ToString() != "" && fu_img.HasFile)
            {
                String FileToDelete = Server.MapPath(img_img.ImageUrl);
                File.Delete(FileToDelete);
            }



        }
        else if (hfblogId.Value != null && hfblogId.Value.ToString() != "" && img_img.ImageUrl != "")
        {
            blogBAL.blog_image = img_img.ImageUrl;
        }
        else
        {
            blogBAL.blog_image = "~/image/blog/no_image_found.png";
        }
        blogBAL.blog_insdt = blogBAL.blog_logdt = System.DateTime.Now;
        blogBAL.blog_insip = blogBAL.blog_logip = Request.UserHostAddress;
        blogBAL.blog_insrid = blogBAL.blog_logrid = fu.userId();
        blog_masterDAL blogDAL = new blog_masterDAL();
        int val = blogDAL.insert_update_blog_master(blogBAL);
        if (val == 1)
        {
            //Response.Write("<script>alert('This Blog Already Exist'); window.location.href='blog_master.aspx';</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);

        }
        if (val == 2)
        {
            //Response.Write("<script>alert('Blog Added Successfully'); window.location.href='blog_master.aspx';</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);

        }
        if (val == 3)
        {
            // Response.Write("<script>alert('Blog Update Successfully'); window.location.href='blog_master.aspx';</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert();", true);

        }
    }
}