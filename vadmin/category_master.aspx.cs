using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class category_master : System.Web.UI.Page
{
    date_time_conversion dtc = new date_time_conversion();
    void FillCategoryRepeter()
    {
        category_masterDAL catDAL = new category_masterDAL();
        DataSet ds = catDAL.get_category_details();
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptCategory.DataSource = ds;
            rptCategory.DataBind();
        }
        else
        {
            rptCategory.DataSource = null;
            rptCategory.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            if (!IsPostBack)
            {
                EncDec enc = new EncDec();
                Session["admin_login"] = Convert.ToInt32(enc.Decrypt(Request.Cookies["viecomid"].Values["viecomval"].ToString()));
                FillCategoryRepeter();
                //if (hfCatId.Value != null && hfCatId.Value.ToString() != "")
                //{
                //    fill_category_for_edit();
                //}
            }
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
    }



    protected void btnSave_Click1(object sender, EventArgs e)
    {
        category_masterBAL catBAL = new category_masterBAL();
        if (hfCatId.Value != null && hfCatId.Value.ToString() != "")
        {
            catBAL.cat_id = Convert.ToInt32(hfCatId.Value);
        }
        else
        {
            catBAL.cat_id = 0;
        }
        catBAL.cat_name = txtCategory.Text;

        if (chkbxStatus.Checked == true)
        {
            catBAL.cat_status = 1;
        }
        else
        {
            catBAL.cat_status = 0;
        }

        if (fu_img.HasFile)
        {

            Guid a = Guid.NewGuid();
            hf_ext.Value = System.IO.Path.GetExtension(fu_img.FileName);
            hf_name.Value = a.ToString() + hf_ext.Value;
            fu_img.SaveAs(Server.MapPath("~/image/category/" + hf_name.Value));
            catBAL.cat_image = "~/image/category/" + hf_name.Value;
            if (img_img.ImageUrl != "" && hfCatId.Value != null && hfCatId.Value.ToString() != "" && fu_img.HasFile)
            {
                String FileToDelete = Server.MapPath(img_img.ImageUrl);




            }
            else if (hfCatId.Value != null && hfCatId.Value.ToString() != "" && img_img.ImageUrl != "")
            {
                catBAL.cat_image = img_img.ImageUrl;
            }
            else
            {
                catBAL.cat_image = "~/image/category/no_image_found.png";
            }
        }
        catBAL.cat_insdt = dtc.GetIndianDateTime();
        catBAL.cat_insip = Request.UserHostAddress;
        catBAL.cat_insrid = Convert.ToInt32(Session["admin_login"].ToString());

        catBAL.cat_logdt = dtc.GetIndianDateTime();
        catBAL.cat_logip = Request.UserHostAddress;
        catBAL.cat_logrid = Convert.ToInt32(Session["admin_login"].ToString());

        category_masterDAL cmDAL = new category_masterDAL();
        int val = cmDAL.insert_update_category_master(catBAL);

        if (val == 2)
        {
            //Response.Write("<script>alert('Category Create Successfully'); window.location.href='category_master.aspx';</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
        }

        else if (val == 3)
        {
            //Response.Write("<script>alert('Category Update Successfully'); window.location.href='category_master.aspx';</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert();", true);
        }
        else
        {
            //Response.Write("<script>alert('Category Already Exists'); </script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);
        }
    }

    protected void rptCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnkbtnEdit")
        {
            category_masterBAL catBAL = new category_masterBAL();
            catBAL.cat_id = Convert.ToInt32(e.CommandArgument.ToString());
            category_masterDAL catDAL = new category_masterDAL();
            DataSet ds = catDAL.get_category_details_for_edit(catBAL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCategory.Text = ds.Tables[0].Rows[0]["cat_name"].ToString();
                
                img_img.ImageUrl = ds.Tables[0].Rows[0]["cat_image"].ToString();
                rf_fu_img.Visible = false;
                if (ds.Tables[0].Rows[0]["cat_status"].ToString() == "1")
                {
                    chkbxStatus.Checked = true;
                    chkbxStatus.BackColor = System.Drawing.Color.Green;
                    
                }
                else if (ds.Tables[0].Rows[0]["cat_status"].ToString() == "0")
                {
                    chkbxStatus.Checked = false;
                    chkbxStatus.BackColor = System.Drawing.Color.Red;
                }
                hfCatId.Value = ds.Tables[0].Rows[0]["cat_id"].ToString();

               
            }
        }
       
    }
}