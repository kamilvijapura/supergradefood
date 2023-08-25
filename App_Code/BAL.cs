using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BAL
/// </summary>
/// 

public class loginBAL
{


    public int l_id { get; set; }
    public string l_rollno { get; set; }
    public string l_email { get; set; }
    public string l_password { get; set; }
    public string l_name{ get; set; }
    public string l_designation { get; set; }
    public string l_image { get; set; }
    public int l_status { get; set; }
    public DateTime l_insdt { get; set; }
    public string l_insip { get; set; }
    public int l_insrid { get; set; }
    public DateTime l_logdt { get; set; }
    public string l_logip { get; set; }
    public int l_logrid { get; set; }

    public string l_time { get; set; }
}

public class careerBAL
{


    public int c_id { get; set; }
    public string c_name { get; set; }
    public string c_email { get; set; }
    public string c_contact { get; set; }
    public string c_country { get; set; }
    public string c_add { get; set; }
   
    public string c_exp { get; set; }
 
    public string c_pdf { get; set; }
 
    public int c_status { get; set; }
    public DateTime c_insdt { get; set; }
    public string c_insip { get; set; }
    public int c_insrid { get; set; }
    public DateTime c_logdt { get; set; }
    public string c_logip { get; set; }
    public int c_logrid { get; set; }

  
}
public class replyBAL
{
    public int r_id { get; set; }

    public string r_name { get; set; }

    public string r_email { get; set; }
    // public string r_website { get; set; }
    public string r_comment { get; set; }

    public int r_status { get; set; }
    public DateTime r_insdt { get; set; }
    public string r_insip { get; set; }
    public int r_insrid { get; set; }
    public DateTime r_logdt { get; set; }
    public string r_logip { get; set; }
    public int r_logrid { get; set; }
    public string r_prd_name { get; set; }
}

public class user_masterBAL
{
    public int usr_id { get; set; }
    public string usr_name { get; set; }
    public int usr_gender { get; set; }
    public string usr_mobile_no { get; set; }
    public string usr_email { get; set; }
    public string usr_password { get; set; }
    public int usr_role { get; set; }
    public int usr_status { get; set; }
    public DateTime usr_insdt { get; set; }
    public string usr_insip { get; set; }
    public int usr_insrid { get; set; }
    public DateTime usr_logdt { get; set; }
    public string usr_logip { get; set; }
    public int usr_logrid { get; set; }
}

public class category_masterBAL
{
    public int cat_id { get; set; }
    public string cat_name { get; set; }
    public string cat_image { get; set; }
    public int cat_status { get; set; }
    public DateTime cat_insdt { get; set; }
    public string cat_insip { get; set; }
    public int cat_insrid { get; set; }
    public DateTime cat_logdt { get; set; }
    public string cat_logip { get; set; }
    public int cat_logrid { get; set; }
}
public class subcat_masterBAL
{
    public int subcat_id { get; set; }
    public int subcat_cat_id { get; set; }
    public string subcat_name { get; set; }
    public int subcat_status { get; set; }
    public DateTime subcat_insdt { get; set; }
    public string subcat_insip { get; set; }
    public int subcat_insrid { get; set; }
    public DateTime subcat_logdt { get; set; }
    public string subcat_logip { get; set; }
    public int subcat_logrid { get; set; }
}

public class thirdcat_masterBAL
{
    public int thirdcat_id { get; set; }
    public int thirdcat_subcat_id { get; set; }
    public string thirdcat_name { get; set; }
    public int thirdcat_status { get; set; }
    public DateTime thirdcat_insdt { get; set; }
    public string thirdcat_insip { get; set; }
    public int thirdcat_insrid { get; set; }
    public DateTime thirdcat_logdt { get; set; }
    public string thirdcat_logip { get; set; }
    public int thirdcat_logrid { get; set; }
}
public class type_masterBAL
{
    public int type_id { get; set; }
    public string type_name { get; set; }
    public int type_status { get; set; }
    public DateTime type_insdt { get; set; }
    public string type_insip { get; set; }
    public int type_insrid { get; set; }
    public DateTime type_logdt { get; set; }
    public string type_logip { get; set; }
    public int type_logrid { get; set; }
}

public class product_masterBAL
{
    public int prd_id { get; set; }
    public string prd_cat_id { get; set; }
    public int prd_subcat_id { get; set; }
    public int prd_type_id { get; set; }
    public string prd_name { get; set; }
    public string prd_des { get; set; }
    public int prd_price { get; set; }
    public int prd_selling_price { get; set; }
    public int prd_show_home_page { get; set; }
    public string prd_pdf { get; set; }
    public int prd_status { get; set; }
    public DateTime prd_insdt { get; set; }
    public string prd_insip { get; set; }
    public int prd_insrid { get; set; }
    public DateTime prd_logdt { get; set; }
    public string prd_logip { get; set; }
    public int prd_logrid { get; set; }
    public string prd_title { get; set; }

    public int prd_dealer_price { get; set; }

}
public class product_featureBAL
{
    public int pf_id { get; set; }
    public int pf_prd_id { get; set; }
    public string pf_feature { get; set; }
    public string pf_des { get; set; }

}
public class product_imagesBAL
{
    public int pi_id { get; set; }
    public string pi_prd_id { get; set; }
    public string pi_images { get; set; }

}
public class product_cart_masterBAL
{
    public int pcm_id { get; set; }
    public int pcm_prd_id { get; set; }
    public int pcm_usr_id { get; set; }
    public string pcm_guid { get; set; }
    public int pcm_quantity { get; set; }    
    public int pcm_price { get; set; }    
    public int pcm_total { get; set; }    
    public DateTime pcm_insdt { get; set; }
    public string pcm_insip { get; set; }
    public int pcm_insrid { get; set; }
    public DateTime pcm_logdt { get; set; }
    public string pcm_logip { get; set; }
    public int pcm_logrid { get; set; }
}
public class promocode_masterBAL
{
    public int promo_id { get; set; }
    public string promo_code { get; set; }
    public int promo_discount { get; set; }
    public int promo_ispercentage { get; set; }
    public int promo_status { get; set; }
    public DateTime promo_insdt { get; set; }
    public string promo_insip { get; set; }
    public int promo_insrid { get; set; }
    public DateTime promo_logdt { get; set; }
    public string promo_logip { get; set; }
    public int promo_logrid { get; set; }
}

public class state_masterBAL
{
    public int state_id { get; set; }
    public string state_name { get; set; }
    public int state_status { get; set; }
    public DateTime state_insdt { get; set; }
    public string state_insip { get; set; }
    public int state_insrid { get; set; }
    public DateTime state_logdt { get; set; }
    public string state_logip { get; set; }
    public int state_logrid { get; set; }
}
public class customer_address_masterBAL
{
    public int cam_id { get; set; }
    public string cam_name { get; set; }
    public string cam_streetaddress_1 { get; set; }
    public string cam_streetaddress_2 { get; set; }
    public int cam_state_id { get; set; }
    public string cam_city { get; set; }
    public string cam_pincode { get; set; }
    public string cam_area { get; set; }
    public string cam_ctn { get; set; }
    public DateTime cam_insdt { get; set; }
    public string cam_insip { get; set; }
    public int cam_insrid { get; set; }
    public DateTime cam_logdt { get; set; }
    public string cam_logip { get; set; }
    public int cam_logrid { get; set; }
}
public class testimonial_masterBAL
{
    public int tm_id { get; set; }
    public string tm_client_name { get; set; }
    public string tm_designation { get; set; }
    public string tm_client_img { get; set; }
    public string tm_description { get; set; }
    public int tm_status { get; set; }
    public DateTime tm_insdt { get; set; }
    public string tm_insip { get; set; }
    public int tm_insrid { get; set; }
    public DateTime tm_logdt { get; set; }
    public string tm_logip { get; set; }
    public int tm_logrid { get; set; }
}

public class pdf_masterBAL
{
    public int pdf_id { get; set; }
    public string pdf_pdf { get; set; }
    public string pdf_thumbnail { get; set; }
    public int pdf_status { get; set; }
    public DateTime pdf_insdt { get; set; }
    public string pdf_insip { get; set; }
    public int pdf_insrid { get; set; }
    public DateTime pdf_logdt { get; set; }
    public string pdf_logip { get; set; }
    public int pdf_logrid { get; set; }
}

public class inquiry_masterBAL
{
    public int inquiry_id { get; set; }
    public string inquiry_first_name { get; set; }
    // public string inquiry_last_name { get; set; }
    public string inquiry_email { get; set; }
    public string inquiry_ctn { get; set; }
    public string inquiry_msg { get; set; }
    public int inquiry_status { get; set; }
    public DateTime inquiry_insdt { get; set; }
    public string inquiry_insip { get; set; }
    public int inquiry_insrid { get; set; }
    public DateTime inquiry_logdt { get; set; }
    public string inquiry_logip { get; set; }
    public int inquiry_logrid { get; set; }
}

public class gallery_masterBAL
{
    public int gm_id { get; set; }
    public string gm_img { get; set; }
    public int gm_status { get; set; }
    public DateTime gm_insdt { get; set; }
    public string gm_insip { get; set; }
    public int gm_insrid { get; set; }
    public DateTime gm_logdt { get; set; }
    public string gm_logip { get; set; }
    public int gm_logrid { get; set; }
    public int gm_home { get; set; }
}

public class product_inquiry_masterBAL
{
    public int prdinq_id { get; set; }
    public string prdinq_prd_id { get; set; }
    public string prdinq_name { get; set; }
    public string prdinq_contact_no { get; set; }
    public string prdinq_email { get; set; }
    public string prdinq_address { get; set; }
    public string prdinq_company_name { get; set; }
    public string prdinq_city { get; set; }
    public string prdinq_postcode { get; set; }

    public int prdinq_status { get; set; }
    public DateTime prdinq_insdt { get; set; }
    public string prdinq_insip { get; set; }
    public int prdinq_insrid { get; set; }
    public DateTime prdinq_logdt { get; set; }
    public string prdinq_logip { get; set; }
    public int prdinq_logrid { get; set; }
}

public class newslatter_masterBAL
{
    public int nm_id { get; set; }
    public string nm_email { get; set; }
    public DateTime nm_insdt { get; set; }
    public string nm_insip { get; set; }
    public int nm_insrid { get; set; }
    public DateTime nm_logdt { get; set; }
    public string nm_logip { get; set; }
    public int nm_logrid { get; set; }
}
public class blog_masterBAL
{
    public int blog_id { get; set; }
    public string blog_title { get; set; }

    public string blog_content { get; set; }
    public string blog_author { get; set; }
    public string blog_date { get; set; }
    public string blog_image { get; set; }
    public int blog_status { get; set; }
    public DateTime blog_insdt { get; set; }
    public string blog_insip { get; set; }
    public int blog_insrid { get; set; }
    public DateTime blog_logdt { get; set; }
    public string blog_logip { get; set; }
    public int blog_logrid { get; set; }
}
public class reviewBAL
{
    public int ca_id { get; set; }
    public string ca_name { get; set; }

    public string ca_email { get; set; }
    public string ca_sub { get; set; }
    public string ca_mobile { get; set; }
    public string ca_date { get; set; }
    public string ca_time { get; set; }
    public string ca_msg { get; set; }
    public int ca_status { get; set; }
    public DateTime ca_insdt { get; set; }
    public string ca_insip { get; set; }
    public int ca_insrid { get; set; }
    public DateTime ca_logdt { get; set; }
    public string ca_logip { get; set; }
    public int ca_logrid { get; set; }
}
public class project_masterBAL
{
    public int prd_id { get; set; }
    public int prd_cat_id { get; set; }
    public int prd_subcat_id { get; set; }
    public int prd_type_id { get; set; }
    public string prd_name { get; set; }
    public string prd_des { get; set; }
    public int prd_price { get; set; }
    public int prd_selling_price { get; set; }
    public int prd_show_home_page { get; set; }
    public string prd_pdf { get; set; }
    public int prd_status { get; set; }
    public DateTime prd_insdt { get; set; }
    public string prd_insip { get; set; }
    public int prd_insrid { get; set; }
    public DateTime prd_logdt { get; set; }
    public string prd_logip { get; set; }
    public int prd_logrid { get; set; }
    

    public string prd_title_desc { get; set; }

    public string prd_ben_des { get; set; }
    public string prd_b1_image { get; set; }
    public string prd_b1_title { get; set; }

    public string prd_b1_des { get; set; }
    public string prd_b2_image { get; set; }
    public string prd_b2_title { get; set; }

    public string prd_b2_des { get; set; }

}
public class project_imagesBAL
{
    public int pi_id { get; set; }
    public int pi_prd_id { get; set; }
    public string pi_images { get; set; }

}
public class dealerBAL
{


    public int dlr_id { get; set; }
    public string dlr_email { get; set; }
    public string dlr_password { get; set; }

    public int dlr_status { get; set; }
    public DateTime dlr_insdt { get; set; }
    public string dlr_insip { get; set; }
    public int dlr_insrid { get; set; }
    public DateTime dlr_logdt { get; set; }
    public string dlr_logip { get; set; }
    public int dlr_logrid { get; set; }


}
public class salesmanBAL
{
    public int sm_id { get; set; }
    public string sm_email { get; set; }
    public string sm_password { get; set; }

    public int sm_status { get; set; }
    public DateTime sm_insdt { get; set; }
    public string sm_insip { get; set; }
    public int sm_insrid { get; set; }
    public DateTime sm_logdt { get; set; }
    public string sm_logip { get; set; }
    public int sm_logrid { get; set; }

}
public class salesman_formBAL
{
    public int slf_id { get; set; }
    //public string slf_sm_email { get; set; }
    public string slf_name { get; set; }
    public string slf_company_name { get; set; }
    public string slf_product { get; set; }
    public string slf_message { get; set; }
    public string slf_img { get; set; }

    public int slf_status { get; set; }
    public DateTime slf_insdt { get; set; }
    public string slf_insip { get; set; }
    public int slf_insrid { get; set; }
    public DateTime slf_logdt { get; set; }
    public string slf_logip { get; set; }
    public int slf_logrid { get; set; }
    public int slf_sm_id { get; set; }
    public string slf_sm_email { get; set; }
    public DateTime slf_sm_date { get; set; }
}
