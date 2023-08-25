using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
    date_time_conversion dtc = new date_time_conversion();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        inquiry_masterBAL inquiryBAL = new inquiry_masterBAL();
        inquiryBAL.inquiry_id = 0;
        inquiryBAL.inquiry_first_name = txtFirstName.Text;
        //inquiryBAL.inquiry_last_name = txtLastName.Text;
        inquiryBAL.inquiry_email = txtEmail.Text.Trim();
        inquiryBAL.inquiry_ctn = txtCtn.Text.Trim();
        inquiryBAL.inquiry_msg = txtMsg.Text;
        inquiryBAL.inquiry_status = 1;
        inquiryBAL.inquiry_insip = Request.UserHostAddress;
        inquiryBAL.inquiry_insrid = 1;
        inquiryBAL.inquiry_insdt = dtc.GetIndianDateTime();
        inquiryBAL.inquiry_logip = Request.UserHostAddress;
        inquiryBAL.inquiry_logrid = 1;
        inquiryBAL.inquiry_logdt = dtc.GetIndianDateTime();
        inquiry_masterDAL inquiryDAL = new inquiry_masterDAL();
        int val = inquiryDAL.insert_update_inquiry_master(inquiryBAL);
        //if (val == 1)
        //{
        //    Response.Write("<script>alert('This Email or Contact No Already Exists Please Enter Another Email or Contact No.')</script>");
        //}
        if (val == 2)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
        }
        //else if (val == 3)
        //{
        //    Response.Write("<script>alert('Inquiry Updated Successfully.'); window.location.href='contact.aspx';</script>");
        //}

    }
}