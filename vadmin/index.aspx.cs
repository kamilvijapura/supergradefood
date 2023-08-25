using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
   void categorycount()
    {
        //category Start
        category_masterDAL catDAL = new category_masterDAL();
        DataSet ds = catDAL.get_category_details();
        Label1.Text = ds.Tables[0].Rows.Count.ToString();
        //Category End
    }
    void productcount()
    {
     
        product_masterDAL pmDAL = new product_masterDAL();
        DataSet ds = pmDAL.get_products_count();
        Label2.Text = ds.Tables[0].Rows.Count.ToString();
    }
    //void blogcount()
    //{
       
    //    blog_masterDAL pmDAL = new blog_masterDAL();
    //    DataSet ds = pmDAL.get_blog_count();
    //    Label3.Text = ds.Tables[0].Rows.Count.ToString();
    //}
    void testimonialcount()
    {
       
        testimonial_masterDAL pmDAL = new testimonial_masterDAL();
        DataSet ds = pmDAL.get_testimonial_count();
        Label4.Text = ds.Tables[0].Rows.Count.ToString();
    }
    void inquirycount()
    {
       inquiry_masterDAL pmDAL = new inquiry_masterDAL();
        DataSet ds = pmDAL.GetInquiryDetails();
        Label5.Text = ds.Tables[0].Rows.Count.ToString();
    }
    void imagescount()
    {
        gallery_masterDAL pmDAL = new gallery_masterDAL();
        DataSet ds = pmDAL.get_gallery_count();
        Label7.Text = ds.Tables[0].Rows.Count.ToString();
    }

    //void Review()
    //{
    //    replyDAL rdal = new replyDAL();
    //    DataSet ds = rdal.GetReplyDetails();
    //    Label6.Text = ds.Tables[0].Rows.Count.ToString();
    //}
    //void productinquirycount()
    //{
       
    //   product_inquiry_masterDAL pmDAL = new product_inquiry_masterDAL();
    //    DataSet ds = pmDAL.GetProductDetails();
    //    Label7.Text = ds.Tables[0].Rows.Count.ToString();
    //}
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["viecomid"] != null && Request.Cookies["viecomid"].ToString() != "")
        {
            if (!IsPostBack)
            {
                EncDec enc = new EncDec();
                Session["admin_login"] = Convert.ToInt32(enc.Decrypt(Request.Cookies["viecomid"].Values["viecomval"].ToString()));
                categorycount();
                productcount();
                //blogcount();
                testimonialcount();
                inquirycount();
                imagescount();
                //productinquirycount();
               
                //Review();
            }
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
    }

}
