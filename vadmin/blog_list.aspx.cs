using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog_list : System.Web.UI.Page
{
    devoloperkit fu = new devoloperkit();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fu.LoginRequire();
            fu.FillListPageRepeter("blog_master", rptProduct);
        }
    }
}