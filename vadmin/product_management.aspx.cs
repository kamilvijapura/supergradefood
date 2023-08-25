using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class product_management : System.Web.UI.Page
{

    public int UserId()
    {
        EncDec enc = new EncDec();
        return Convert.ToInt32(enc.Decrypt(Request.Cookies["viecomid"].Values["viecomval"].ToString()));
    }
    void FillProductDetails()
    {
        product_masterBAL pmBAL = new product_masterBAL();
        pmBAL.prd_id = Convert.ToInt32(Request.QueryString["prdid"].ToString());
        product_masterDAL pmDAL = new product_masterDAL();
        DataSet ds = pmDAL.get_product_details_for_edit(pmBAL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            drCategory.Text = ds.Tables[0].Rows[0]["prd_cat_id"].ToString();
            //FillSubCategoryDropdown();
            //drSubCategory.Text = ds.Tables[0].Rows[0]["prd_subcat_id"].ToString();
            //FillThirdCategoryDropdown();
            //drType.Text = ds.Tables[0].Rows[0]["prd_type_id"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["prd_name"].ToString();
            hlPDF.NavigateUrl = ds.Tables[0].Rows[0]["prd_pdf"].ToString();

            //txtwebsite.Text = ds.Tables[0].Rows[0]["prd_link"].ToString();
            //txtclient.Text = ds.Tables[0].Rows[0]["prd_client"].ToString();
            //txttime.Text = ds.Tables[0].Rows[0]["prd_link"].ToString();
            //txtfeatures.Text = ds.Tables[0].Rows[0]["prd_feature"].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0]["prd_price"].ToString();
            txtSellingPrice.Text = ds.Tables[0].Rows[0]["prd_selling_price"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["prd_des"].ToString();
            txttitle.Text = ds.Tables[0].Rows[0]["prd_title"].ToString();
            //TextBox1.Text = ds.Tables[0].Rows[0]["prd_dealer_price"].ToString();
            if (ds.Tables[0].Rows[0]["prd_status"].ToString() == "1")
            {
                chkbxStatus.Checked = true;
            }
            else
            {
                chkbxStatus.Checked = false;
            }
            if (ds.Tables[0].Rows[0]["prd_show_home_page"].ToString() == "1")
            {
                CheckBox1.Checked = true;
            }
            else
            {
                CheckBox1.Checked = false;
            }


            devoloperkit dk = new devoloperkit();
            DataSet ds2 = dk.getDataForEdit("product_feature", pmBAL.prd_id, "pf_prd_id");
            pnlUpdate.Visible = true;
            repProductFeature.DataSource = ds2;
            repProductFeature.DataBind();


            product_imagesBAL piBAL = new product_imagesBAL();
            piBAL.pi_prd_id = Convert.ToString(Request.QueryString["prdid"].ToString());
            product_imagesDAL piDAL = new product_imagesDAL();
            DataSet dsimg = piDAL.get_product_images(piBAL);
            Session["imgCount"] = dsimg.Tables[0].Rows.Count;
            if (dsimg.Tables[0].Rows.Count > 0)
            {
                rptProductImages.DataSource = dsimg;
                rptProductImages.DataBind();
            }
            else
            {
                rptProductImages.DataSource = null;
                rptProductImages.DataBind();
            }

        }
    }
    private void AddNewRowToGrid()
    {
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                //add new row to DataTable   
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Store the current data to ViewState for future reference   
                ViewState["CurrentTable"] = dtCurrentTable;
                for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                {
                    TextBox txtFeature = (TextBox)grdview_area_of_painting.Rows[i].Cells[1].FindControl("txtFeature");
                    dtCurrentTable.Rows[i]["Column1"] = txtFeature.Text;
                    //extract the DropDownList Selected Items   
                    TextBox txtFeatureDes = (TextBox)grdview_area_of_painting.Rows[i].Cells[2].FindControl("txtFeatureDes");

                    dtCurrentTable.Rows[i]["Column2"] = txtFeatureDes.Text;
                    //extract the TextBox values   
                    //breadth 


                }

                //Rebind the Grid with the current data to reflect changes   
                grdview_area_of_painting.DataSource = dtCurrentTable;
                grdview_area_of_painting.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        //Set Previous Data on Postbacks   
        SetPreviousData();
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for DropDownList selected item   
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dt.Rows.Add(dr);
        //Store the DataTable in ViewState for future reference   
        ViewState["CurrentTable"] = dt;
        //Bind the Gridview   
        grdview_area_of_painting.DataSource = dt;
        grdview_area_of_painting.DataBind();
    }


    private void ResetRowID(DataTable dt)
    {
        int rowNumber = 1;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                row[0] = rowNumber;
                rowNumber++;
            }
        }
    }

    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtFeature = (TextBox)grdview_area_of_painting.Rows[i].Cells[1].FindControl("txtFeature");

                    TextBox txtFeatureDes = (TextBox)grdview_area_of_painting.Rows[i].Cells[2].FindControl("txtFeatureDes");
                    //Fill the DropDownList with Data   
                    if (i < dt.Rows.Count - 1)
                    {
                        //Set the Previous Selected Items on Each DropDownList  on Postbacks   
                        txtFeature.Text = dt.Rows[i]["Column1"].ToString();
                        txtFeatureDes.Text = dt.Rows[i]["Column2"].ToString();

                        //Assign the value from DataTable to the TextBox   

                    }
                    rowIndex++;
                }
            }
        }
    }
    void FillCategoryDropdown()
    {
        category_masterDAL catDAL = new category_masterDAL();
        DataSet ds = catDAL.get_category_for_dropdown();
        if (ds.Tables[0].Rows.Count > 0)
        {
            drCategory.DataSource = ds;
            drCategory.DataTextField = "cat_name";
            drCategory.DataValueField = "cat_name";
            drCategory.DataBind();
            drCategory.Items.Insert(0, "--- Select Category---");
            drCategory.Items[0].Value = "0";
        }
        else
        {
            drCategory.Items.Clear();
            drCategory.Items.Insert(0, "--- Select Category---");
            drCategory.Items[0].Value = "0";
        }
    }
    //void FillSubCategoryDropdown()
    //{
    //    subcat_masterBAL catBAL = new subcat_masterBAL();
    //    catBAL.subcat_cat_id = Convert.ToInt32(drCategory.SelectedItem.Value);
    //    subcat_masterDAL catDAL = new subcat_masterDAL();
    //    DataSet ds = catDAL.get_subcat_for_dropdown(catBAL);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        drSubCategory.DataSource = ds;
    //        drSubCategory.DataTextField = "subcat_name";
    //        drSubCategory.DataValueField = "subcat_id";
    //        drSubCategory.DataBind();
    //        drSubCategory.Items.Insert(0, "--- Select Sub Category---");
    //        drSubCategory.Items[0].Value = "0";
    //    }
    //    else
    //    {
    //        drSubCategory.Items.Clear();
    //        drSubCategory.Items.Insert(0, "--- Select Sub Category---");
    //        drSubCategory.Items[0].Value = "0";
    //    }
    //}

    //void FillThirdCategoryDropdown()
    //{
    //    thirdcat_masterDAL tcDAL = new thirdcat_masterDAL();
    //    DataSet ds = tcDAL.get_type_for_dropdown();
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        drType.DataSource = ds;
    //        drType.DataTextField = "type_name";
    //        drType.DataValueField = "type_id";
    //        drType.DataBind();
    //        drType.Items.Insert(0, "--- Select Type---");
    //        drType.Items[0].Value = "0";
    //    }
    //    else
    //    {
    //        drType.Items.Clear();
    //        drType.Items.Insert(0, "--- Select Type---");
    //        drType.Items[0].Value = "0";
    //    }
    //}

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                string ckEditorScript = "<script type='text/javascript'>CKEDITOR.replace('" + txtDescription.ClientID + "');</script>";
                      Page.ClientScript.RegisterStartupScript(this.GetType(), "CKEditorScript", ckEditorScript);
             
                 SetInitialRow();
                FillCategoryDropdown();
                //FillThirdCategoryDropdown();
                if (Request.QueryString["prdid"] != null && Request.QueryString["prdid"].ToString() != "")
                {
                    FillProductDetails();
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
          








        product_masterBAL pmBAL = new product_masterBAL();
        product_featureBAL pfBAL = new product_featureBAL();
        if (Request.QueryString["prdid"] != null && Request.QueryString["prdid"].ToString() != "")
        {
            pmBAL.prd_id = Convert.ToInt32(Request.QueryString["prdid"].ToString());


        }
        else
        {
            pmBAL.prd_id = 0;
        }
        pmBAL.prd_cat_id = Convert.ToString(drCategory.SelectedItem.Value);


        pmBAL.prd_name = txtName.Text;
        pmBAL.prd_des = txtDescription.Text;
        pmBAL.prd_selling_price = Convert.ToInt32(txtSellingPrice.Text);
        pmBAL.prd_price = Convert.ToInt32(txtPrice.Text);
       // pmBAL.prd_dealer_price = Convert.ToInt32(TextBox1.Text);

        if (chkbxStatus.Checked == true)
        {
            pmBAL.prd_status = 1;
        }
        else
        {
            pmBAL.prd_status = 0;
        }

        if (CheckBox1.Checked == true)
        {
            pmBAL.prd_show_home_page = 1;
        }
        else
        {
            pmBAL.prd_show_home_page = 0;
        }
      
        pmBAL.prd_insrid = UserId();
        pmBAL.prd_insdt = System.DateTime.Now;
        pmBAL.prd_insip = Request.UserHostAddress.ToString();
        pmBAL.prd_logrid = UserId();
        pmBAL.prd_logip = Request.UserHostAddress.ToString();
        pmBAL.prd_logdt = System.DateTime.Now;
        pmBAL.prd_title = txttitle.Text;
        if (fuImages.HasFile)
        {
            foreach (var file in fuPDF.PostedFiles)
            {


                Guid b = Guid.NewGuid();
                hfextension.Value = System.IO.Path.GetExtension(file.FileName);
                hffilenewname.Value = b.ToString() + hfextension.Value;
                file.SaveAs(Server.MapPath("~/image/product/" + hffilenewname.Value));
                pmBAL.prd_pdf = "~/image/product/" + hffilenewname.Value;


            }
        }
        else if (Request.QueryString["prdid"] != null && Request.QueryString["prdid"].ToString() != "" && hlPDF.NavigateUrl != "")
        {
            pmBAL.prd_pdf = hlPDF.NavigateUrl;
        }
        product_masterDAL pmDAL = new product_masterDAL();
        string[] val = pmDAL.insert_update_product_master(pmBAL).ToString().Split('|');


        product_imagesBAL piBAL = new product_imagesBAL();
        if (fuImages.HasFile)
        {
            foreach (var file in fuImages.PostedFiles)
            {
                if (Request.QueryString["prdid"] != null && Request.QueryString["prdid"].ToString() != "")
                {
                    piBAL.pi_prd_id = Convert.ToString(Request.QueryString["prdid"].ToString());
                }
                else
                {
                    piBAL.pi_prd_id = Convert.ToString(val[1].ToString());

                }
                Guid b = Guid.NewGuid();
                hfextension.Value = System.IO.Path.GetExtension(file.FileName);
                hffilenewname.Value = b.ToString() + hfextension.Value;
                file.SaveAs(Server.MapPath("~/image/product/" + hffilenewname.Value));
                piBAL.pi_images = "~/image/product/" + hffilenewname.Value;

                product_imagesDAL pimDAL = new product_imagesDAL();
                int rval = pimDAL.insert_update_product_images(piBAL);

            }
        }


        foreach (GridViewRow g1 in grdview_area_of_painting.Rows)
        {
            if (Request.QueryString["prdid"] != null && Request.QueryString["prdid"].ToString() != "")
            {
                pfBAL.pf_prd_id = Convert.ToInt32(Request.QueryString["prdid"].ToString());

            }
            else
            {
                pfBAL.pf_prd_id = Convert.ToInt32(val[1].ToString());
            }
            TextBox txtFeature = (TextBox)g1.FindControl("txtFeature");
            TextBox txtFeatureDes = (TextBox)g1.FindControl("txtFeatureDes");


            pfBAL.pf_feature = txtFeature.Text;
            pfBAL.pf_des = txtFeatureDes.Text;



            product_featureDAL pfDAL = new product_featureDAL();
            int bval = pfDAL.insert_update_product_feature(pfBAL);

        }



        if (val[0] == "1")
            {
            //Response.Write("Country Already Exist");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);

        }
        if (val[0] == "2")
        {
            //Response.Write("<script>alert('country Create Successfully'); window.location.href='country_management.aspx';</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);

        }

        else if (val[0] == "3")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert();", true);

            //Response.Write("<script>alert('Product Update Successfully'); window.location.href='country_management.aspx';</script>");
        }













    }

    protected void drCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  FillSubCategoryDropdown();
        }

    protected void rptProductImages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnkbtnDelete")
        {
            if (Convert.ToInt32(Session["imgCount"]) > 1)
            {
                product_imagesBAL piBAL = new product_imagesBAL();
                piBAL.pi_id = Convert.ToInt32(e.CommandArgument.ToString());
                product_imagesDAL piDAL = new product_imagesDAL();
                string val = piDAL.delete_product_image_master(piBAL);
                Response.Write("<script>alert('" + val + "');window.location.href='product_management.aspx?prdid=" + Request.QueryString["prdid"].ToString() + "' ;</script>");

            }
            else
            {
                Response.Write("<script>alert('you can not delete all images');window.location.href='product_management.aspx?prdid=" + Request.QueryString["prdid"].ToString() + "' ;</script>");

            }

        }
    }
    protected void grdview_area_of_painting_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            LinkButton lb = (LinkButton)e.Row.FindControl("btn_remove");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count + 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void btn_remove_Click(object sender, EventArgs e)
    {
        //LinkButton lnk_remove = (LinkButton)sender;
        //GridViewRow gvRow = lnk_remove.NamingContainer as GridViewRow;
        //int rowID = gvRow.RowIndex;
        ////int rowID = Convert.ToInt32(gvRow.lb[gvRow.RowIndex].Value.ToString());
        //if (ViewState["CurrentTable"] != null)
        //{
        //    DataTable dt = (DataTable)ViewState["CurrentTable"];
        //    if (dt.Rows.Count > 1)
        //    {
        //        if (gvRow.RowIndex <= dt.Rows.Count - 1)
        //        {
        //            //Remove the Selected Row data and reset row number  
        //            dt.Rows.Remove(dt.Rows[rowID - 1]);
        //            ResetRowID(dt);
        //        }
        //    }
        //    //Store the current data in ViewState for future reference  
        //    ViewState["CurrentTable"] = dt;
        //    //Re bind the GridView for the updated data  
        //    grdview_area_of_painting.DataSource = ViewState["CurrentTable"];
        //    grdview_area_of_painting.DataBind();
        //}
        ////Set Previous Data on Postbacks  
        //SetPreviousData();
        //product_featureBAL gmBAL = new product_featureBAL();
        //gmBAL.pf_id = Convert.ToInt32(pf);
        //gallery_masterDAL gmDAL = new gallery_masterDAL();
        //int val = gmDAL.delete_gallery_images(gmBAL);
        //if (val == 1)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "wrongalert();", true);
        //    //Response.Write("<script>alert('Gallery Image Delete Successfully');window.location.href='gallerylist.aspx';</script>");
        //}
    }
    protected void repProductFeature_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnk_delete")
        {
            //if (Convert.ToInt32(Session["featureCount"]) > 1)
            //{
                product_featureBAL pfBAL = new product_featureBAL();
                pfBAL.pf_id = Convert.ToInt32(e.CommandArgument.ToString());
                product_featureDAL pfDAL = new product_featureDAL();
                int val = pfDAL.delete_feature(pfBAL);
                    if (val == 1)
                    
                {
                Response.Write("<script>alert('Feature delete successfully');window.location.href='product_management.aspx?prdid=" + Request.QueryString["prdid"].ToString() + "' ;</script>");
                }
            //}
            //else
            //{
            //    Response.Write("<script>alert('you can not delete all features');window.location.href='product_management.aspx?prdid=" + Request.QueryString["prdid"].ToString() + "' ;</script>");
            //}


        }
    }
}
