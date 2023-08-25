using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Globalization;
/// <summary>
/// Summary description for information
/// </summary>
///
public class devoloperkit : connection
{
    //Fix Variable of the Project//
    string loginpage = "admin_login.aspx";
    string loginCookie = "viecomid";
    string loginCookieVal = "viecomval";
    ///////////////////////////////


    public void SweetAlert(Page currentPage, bool success = false, string actionpage = "", int action = 0)
    {
        if (success)
        {
            if (action == 1) //insert
            {
                currentPage.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done!', '" + actionpage + " Insert Successfully', 'success'); ", true);
            }
            if (action == 2) //update
            {
                currentPage.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done!', '" + actionpage + " Update Successfully', 'success'); ", true);
            }
        }
        else
        {
            currentPage.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Sorry!', '" + actionpage + " Already Exist', 'error'); ", true);
        }

    }
    public void SweetAlertMessage(Page currentPage, string msg, bool success = true)
    {
        if (success)
        {
            currentPage.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Done!', '" + msg + "', 'success'); ", true);
        }
        else
        {
            currentPage.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Sorry!', '" + msg + "', 'error'); ", true);

        }
    }

    public string ipAddress()
    {
        return HttpContext.Current.Request.UserHostAddress;
    }
    public int userId()
    {
        EncDec enc = new EncDec();
        if (HttpContext.Current.Request.Cookies[loginCookie] != null && HttpContext.Current.Request.Cookies[loginCookie].ToString() != "")
        {
            return Convert.ToInt32(enc.Decrypt(HttpContext.Current.Request.Cookies[loginCookie].Values[loginCookieVal].ToString()));
        }
        else
        {
            return 0;
        }
    }
    public int userRole()
    {
        if (HttpContext.Current.Request.Cookies[loginCookie] != null && HttpContext.Current.Request.Cookies[loginCookie].ToString() != "")
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    public void LoginRequire()
    {
        if (HttpContext.Current.Request.Cookies[loginCookie] != null && HttpContext.Current.Request.Cookies[loginCookie].ToString() != "")
        {

        }
        else
        {
            HttpContext.Current.Response.Redirect(loginpage);
        }
    }
    public void alertRedirection(int val, string page)
    {
        if (val == 2)
        {
            HttpContext.Current.Response.Redirect("" + page + "?msgval=2");
        }
        if (val == 3)
        {
            HttpContext.Current.Response.Redirect("" + page + "?msgval=3");
        }
    }
    public void fillRepeter(DataSet ds, Repeater rpt, Panel pnl = null)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpt.DataSource = ds;
            rpt.DataBind();

            if (pnl != null)
            {
                pnl.Visible = true;
            }
        }
        else
        {
            rpt.DataSource = null;
            rpt.DataBind();
            if (pnl != null)
            {
                pnl.Visible = false;
            }
        }
    }
    public void fillRepeterFromDataView(DataView dv, Repeater rpt)
    {

        rpt.DataSource = dv;
        rpt.DataBind();



    }
    public void fillRepeterFromDataTable(DataTable dt, Repeater rpt)
    {
        if (dt.Rows.Count > 0)
        {
            rpt.DataSource = dt;
            rpt.DataBind();

        }
        else
        {
            rpt.DataSource = null;
            rpt.DataBind();
        }

    }
    public DataSet FillListPageRepeter(string table_name, Repeater rpt = null)
    {
        DataSet ds = getAllData(table_name);
        if (rpt != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt.DataSource = ds;
                rpt.DataBind();
            }
            else
            {
                rpt.DataSource = null;
                rpt.DataBind();
            }
        }

        return ds;
    }
    public void FillDropdown(DataSet ds, DropDownList dr, string val, string txt, string title)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            dr.DataSource = ds;
            dr.DataTextField = txt;
            dr.DataValueField = val;
            dr.DataBind();
            dr.Items.Insert(0, "--- Select " + title + "---");
            dr.Items[0].Value = "0";
        }
        else
        {
            dr.Items.Clear();
            dr.Items.Insert(0, "--- Select " + title + "---");
            dr.Items[0].Value = "0";
        }

    }
    public void FillDropdownOnlyFromDataSet(DataSet ds, DropDownList dr, string val, string txt)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            dr.DataSource = ds;
            dr.DataTextField = txt;
            dr.DataValueField = val;
            dr.DataBind();
           
        }
        else
        {
            dr.Items.Clear();           
        }

    }

    public void FillRadiobuttonList(DataSet ds, RadioButtonList dr, string val, string txt)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            dr.DataSource = ds;
            dr.DataTextField = txt;
            dr.DataValueField = val;
            dr.DataBind();

        }
        else
        {
            dr.Items.Clear();

        }

    }
    public void FillListBox(DataSet ds, ListBox lstbox, string val, string txt, string title)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            lstbox.DataSource = ds;
            lstbox.DataTextField = txt;
            lstbox.DataValueField = val;
            lstbox.DataBind();


        }
        else
        {
            lstbox.Items.Clear();

        }

    }
    public void FillCheckbox(DataSet ds, CheckBoxList chkbx, string val, string txt)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            chkbx.DataSource = ds;
            chkbx.DataTextField = txt;
            chkbx.DataValueField = val;
            chkbx.DataBind();

        }
        else
        {
            chkbx.Items.Clear();

        }

    }
    public void FillListbox(DataSet ds, ListBox lstbx, string val, string txt)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            lstbx.DataSource = ds;
            lstbx.DataTextField = txt;
            lstbx.DataValueField = val;
            lstbx.DataBind();

        }
        else
        {
            lstbx.Items.Clear();

        }

    }
    public void fillTextboxData(DataSet ds, TextBox txt, string s, int row = 0, int tableno = 0)
    {
        txt.Text = ds.Tables[tableno].Rows[row][s].ToString();
    }
    public void fillDateTextboxData(DataSet ds, TextBox txt, string s, int row = 0, int tableno = 0)
    {
        if (ds.Tables[tableno].Rows[row][s].ToString() != "")
        {
            txt.Text = (Convert.ToDateTime(ds.Tables[tableno].Rows[row][s].ToString(), CultureInfo.CurrentCulture).ToString("yyyy/MM/dd hh:MM:ss")).ToString().Split(null)[0].Replace('/', '-');
        }
    }
    public void fillTimeTextboxData(DataSet ds, TextBox txt, string s, int row = 0, int tableno = 0)
    {
        txt.Text = ds.Tables[tableno].Rows[row][s].ToString().Split(null)[1];
    }
    public void fillDropdownData(DataSet ds, DropDownList dr, string s, int row = 0, int tableno = 0)
    {
        dr.Text = ds.Tables[tableno].Rows[row][s].ToString();
    }
    public void fillRadioButtonData(DataSet ds, RadioButtonList rdo, string s, int row = 0, int tableno = 0)
    {
        rdo.Text = ds.Tables[tableno].Rows[row][s].ToString();

    }
    public void fillImageData(DataSet ds, Image img, string s, int row = 0, int tableno = 0)
    {
        img.ImageUrl = ds.Tables[tableno].Rows[row][s].ToString();
    }
    public void fillHyperlinkData(DataSet ds, HyperLink hl, string s, int row = 0, int tableno = 0)
    {
        hl.NavigateUrl = ds.Tables[tableno].Rows[row][s].ToString();
    }
    public void fillHiddenfieldData(DataSet ds, HiddenField hf, string s, int row = 0, int tableno = 0)
    {
        hf.Value = ds.Tables[tableno].Rows[row][s].ToString();
    }
    public void fillLabelData(DataSet ds, Label lbl, string s, int row = 0, int tableno = 0)
    {
        lbl.Text = ds.Tables[tableno].Rows[row][s].ToString();
    }
    public void fillTimeLabelData(DataSet ds, Label lbl, string s, int row = 0, int tableno = 0)
    {
        lbl.Text = ds.Tables[tableno].Rows[row][s].ToString().Split(null)[1];
    }
    public void fillstatusRadiobutton(DataSet ds, RadioButton rdoActive, RadioButton rdoDeactive, string s, int row = 0, int tableno = 0)
    {
        if (ds.Tables[tableno].Rows[row][s].ToString() == "1")
        {
            rdoActive.Checked = true;
        }
        else
        {
            rdoDeactive.Checked = true;
        }
    }
    public void fillstatusCheckbox(DataSet ds, CheckBox chk, string s, int row = 0, int tableno = 0)
    {
        if (ds.Tables[tableno].Rows[row][s].ToString() == "1")
        {
            chk.Checked = true;
        }
        else
        {
            chk.Checked = false;
        }
    }
    public void fillCheckboxlistData(DataSet ds, CheckBoxList chkbxlst, string tablecolumn, int tableno = 0)
    {
        for (int i = 0; i < ds.Tables[tableno].Rows.Count; i++)
        {

            foreach (ListItem item in chkbxlst.Items)
            {
                if (ds.Tables[tableno].Rows[i][tablecolumn].ToString() == item.Value)
                {
                    item.Selected = true;
                }
            }
        }
    }
    public int InsertStatus(RadioButton rdoActive)
    {
        if (rdoActive.Checked == true)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    public int InsertStatusCheckBox(CheckBox chk)
    {
        if (chk.Checked == true)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    public int InsertPrimarikey(HiddenField hf)
    {
        if (hf.Value != null && hf.Value.ToString() != "")
        {
            return Convert.ToInt32(hf.Value);
        }
        else
        {
            return 0;
        }
    }

    public string imageUpload(FileUpload fu, Image img, HiddenField hfid, string folder_path)
    {
        string extention;
        string filename;
        if (fu.HasFile)
        {
            Guid gid = Guid.NewGuid();
            extention = System.IO.Path.GetExtension(fu.FileName);
            filename = gid.ToString() + extention;

            string subdir = HttpContext.Current.Server.MapPath("~/image/" + folder_path);
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            fu.SaveAs(HttpContext.Current.Server.MapPath("~/image/" + folder_path + "/" + filename));

            if (img.ImageUrl != "" && hfid.Value != null && hfid.Value != "")
            {
                string deleteFilePath = HttpContext.Current.Server.MapPath(img.ImageUrl);
                File.Delete(deleteFilePath);
            }
            return "~/image/" + folder_path + "/" + filename;

        }
        else if (img.ImageUrl != null && img.ImageUrl.ToString() != "" && hfid.Value != null && hfid.Value != "")
        {
            return img.ImageUrl;
        }
        else
        {
            return "~/image/no_images_found.png";
        }
    }


    public void DeleteImageFromFolder(HiddenField hfPath)
    {
        if (hfPath.Value != null && hfPath.Value != "")
        {
            string deleteFilePath = HttpContext.Current.Server.MapPath(hfPath.Value);
            File.Delete(deleteFilePath);
        }
    }
    //public string[] multipleimageUpload(FileUpload fu, string folder_path)
    //{
    //    string filename;
    //    string path = "";

    //    Guid gid = Guid.NewGuid();
    //    if (fu.HasFile)
    //    {
    //        foreach (var file in fu.PostedFile)
    //        {
    //            filename = gid.ToString() + System.IO.Path.GetExtension(file.FileName);
    //            file.SaveAs(HttpContext.Current.Server.MapPath("~/admin/admin_data/" + folder_path + "/" + filename));
    //            path += "~/admin/admin_data/" + folder_path + "/" + filename + ",";

    //        }

    //        path = path.Remove(path.Length - 1, 1);

    //        return path.Split(',');
    //    }
    //    return null;
    //}
    public string documentUpload(FileUpload fu, HyperLink hl, HiddenField hfid, string folder_path)
    {
        string extention;
        string filename;
        if (fu.HasFile)
        {
            Guid gid = Guid.NewGuid();
            extention = System.IO.Path.GetExtension(fu.FileName);
            filename = gid.ToString() + extention;
            fu.SaveAs(HttpContext.Current.Server.MapPath("~/admin/admin_data/" + folder_path + "/" + filename));

            if (hl.NavigateUrl != "" && hfid.Value != null && hfid.Value != "")
            {
                string deleteFilePath = HttpContext.Current.Server.MapPath(hl.NavigateUrl);
                File.Delete(deleteFilePath);
            }
            return "~/admin/admin_data/" + folder_path + "/" + filename;

        }
        else if (hl.NavigateUrl != null && hl.NavigateUrl.ToString() != "" && hfid.Value != null && hfid.Value != "")
        {

            return hl.NavigateUrl;
        }
        else
        {
            return "~/admin/admin_data/no_images_found.png";
        }
    }
    public DataSet getAllData(string table_name)
    {

        mycon();
        try
        {
            cmd = new MySqlCommand("select * from " + table_name + "", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet getActiveData(string table_name, string status,int limit = 0)
    {

        mycon();
        try
        {
            if (limit != 0)
            {
                cmd = new MySqlCommand("select * from " + table_name + " where " + status + "=1 limit "+ limit +"", con);

            }
            else
            {
                cmd = new MySqlCommand("select * from " + table_name + " where " + status + "=1", con);

            }
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet getDataForEdit(string table_name, int pk, string parameter, string orderby = "", string ascdesc = "")
    {

        mycon();
        try
        {
            if (orderby != "" && ascdesc != "")
            {
                cmd = new MySqlCommand("select * from " + table_name + " where " + parameter + "=@" + parameter + " order by " + orderby + " " + ascdesc + " ", con);

            }
            else
            {
                cmd = new MySqlCommand("select * from " + table_name + " where " + parameter + "=@" + parameter + "", con);

            }
            cmd.Parameters.AddWithValue("@" + parameter + "", pk);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }



    public DataSet getInsertedYear(string table_name, string parameter)
    {

        mycon();
        try
        {
            cmd = new MySqlCommand("select year("+ parameter + ") as years from " + table_name + " group by year(" + parameter + ") order by year(" + parameter + ") desc", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }


    public DataSet getDataUsingIn(string table_name, string inparameter, string parameter)
    {

        mycon();
        try
        {
            cmd = new MySqlCommand("select * from " + table_name + " where " + parameter + " in (" + inparameter + ")", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public DataSet getTodayData(string table_name, string parameter, string filter1param = "", int filter1val = 0)
    {

        mycon();
        try
        {
            if (filter1param != "")
            {
                cmd = new MySqlCommand("select * from " + table_name + " where " + parameter + "=curdate() and " + filter1param + " = " + filter1val + "", con);
            }
            else
            {
                cmd = new MySqlCommand("select * from " + table_name + " where " + parameter + "=curdate()", con);

            }
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public DataSet getTodayDatawithTwoParameter(string table_name, string parameter, string filter1param, int filter1val, string filter2param, int filter2val)
    {

        mycon();
        try
        {

            cmd = new MySqlCommand("select * from " + table_name + " where " + parameter + "=curdate() and " + filter1param + " = " + filter1val + " and " + filter2param + " = " + filter2val + "", con);

            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int getMaxid(string table_name, string id)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select if(max(" + id + ") is null,0,max(" + id + ")) as indid from " + table_name + "", con);

            int maxid = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            con.Dispose();
            return maxid;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public int getSum(string table_name, string id, string filterId = null, int Filtervalue = 0)
    {
        mycon();
        try
        {
            if (filterId != null)
            {
                cmd = new MySqlCommand("select if(max(" + id + ") is null,0,sum(" + id + ")) as sum from " + table_name + " where " + filterId + "=" + Filtervalue + "", con);
            }
            else
            {
                cmd = new MySqlCommand("select if(max(" + id + ") is null,0,sum(" + id + ")) as sum from " + table_name + "", con);
            }

            int sum = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            con.Dispose();
            return sum;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public int getCount(string table_name, string id, string filterId = null, int Filtervalue = 0)
    {
        mycon();
        try
        {
            if (filterId != null)
            {
                cmd = new MySqlCommand("select if(max(" + id + ") is null,0,count(" + id + ")) as sum from " + table_name + " where " + filterId + "=" + Filtervalue + "", con);
            }
            else
            {
                cmd = new MySqlCommand("select if(max(" + id + ") is null,0,count(" + id + ")) as sum from " + table_name + "", con);
            }

            int sum = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            con.Dispose();
            return sum;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public string getLastInsertedcode(string table_name, string code)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select if(max(" + code + ") is null,0,max(" + code + ")) as code from " + table_name + "", con);

            string getcode = cmd.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
            return getcode;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public bool checkDuplicate(string table_name, string parameterpk, string parameter, int pkval, string parameterval)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT " + parameterpk + " FROM " + table_name + " WHERE " + parameter + " = '" + parameterval + "' and " + parameterpk + "!= " + pkval + "", con);

            bool dup = Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();
            con.Dispose();
            return dup;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public bool checkDuplicateTwoParameter(string table_name, string parameterpk, string parameter, string parameter2, int pkval, string parameterval, string parameterval2)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT " + parameterpk + " FROM " + table_name + " WHERE " + parameter + " = '" + parameterval + " and" + parameter2 + " = '" + parameterval2 + "' and " + parameterpk + "!= " + pkval + "", con);

            bool dup = Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();
            con.Dispose();
            return dup;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public bool updateOneColumn(string table_name, int pk, string val, string parameterpk, string parameter)
    {

        mycon();
        try
        {
            mycon();
            cmd = new MySqlCommand("update " + table_name + " set " + parameter + "=@" + parameter + " where " + parameterpk + "=@" + parameterpk + ";", con);
            cmd.Parameters.AddWithValue("@" + parameterpk + "", pk);
            cmd.Parameters.AddWithValue("@" + parameter + "", val);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return true;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public void updateIntOneDetail(string tablename, int pkval, int paramval, string pk, string param)
    {
        mycon(); try
        {
            cmd = new MySqlCommand("update " + tablename + " set " + param + "=" + paramval + " where " + pk + "=" + pkval + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public void deleteTableRow(string table_name, int pk, string parameterpk)
    {

        mycon();
        try
        {
            mycon();
            cmd = new MySqlCommand("delete from " + table_name + " where " + parameterpk + " = @" + parameterpk + ";", con);
            cmd.Parameters.AddWithValue("@" + parameterpk + "", pk);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataSet getDatawithTwoParameterFilter(string table_name, int dec1, int dec2, string parameter1, string parameter2, int limit = 0, string group_by = "")
    {

        mycon();
        try
        {
            if (limit != 0)
            {
                if (group_by != "")
                {
                    cmd = new MySqlCommand("select * from " + table_name + " where " + parameter1 + "=@" + parameter1 + " and " + parameter2 + "=@" + parameter2 + " group by " + group_by + "" + " limit " + limit + "", con);

                }
                else
                {
                    cmd = new MySqlCommand("select * from " + table_name + " where " + parameter1 + "=@" + parameter1 + " and " + parameter2 + "=@" + parameter2 + " limit " + limit + "", con);

                }

            }
            else
            {
                if (group_by != "")
                {
                    cmd = new MySqlCommand("select * from " + table_name + " where " + parameter1 + "=@" + parameter1 + " and " + parameter2 + "=@" + parameter2 + " group by " + group_by + "", con);

                }
                else
                {
                    cmd = new MySqlCommand("select * from " + table_name + " where " + parameter1 + "=@" + parameter1 + " and " + parameter2 + "=@" + parameter2 + "", con);
                }
            }
            cmd.Parameters.AddWithValue("@" + parameter1 + "", dec1);
            cmd.Parameters.AddWithValue("@" + parameter2 + "", dec2);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public DataSet getDatawithThreeParameterFilter(string table_name, int dec1, int dec2, int dec3, string parameter1, string parameter2, string parameter3, int limit = 0, string group_by = "")
    {

        mycon();
        try
        {
            if (limit != 0)
            {
                if (group_by != "")
                {
                    cmd = new MySqlCommand("select * from " + table_name + " where " + parameter1 + "=@" + parameter1 + " and " + parameter2 + "=@" + parameter2 + " and " + parameter3 + "=@" + parameter3 + "  group by " + group_by + "" + " limit " + limit + "", con);

                }
                else
                {
                    cmd = new MySqlCommand("select * from " + table_name + " where " + parameter1 + "=@" + parameter1 + " and " + parameter2 + "=@" + parameter2 + " and " + parameter3 + "=@" + parameter3 + " limit " + limit + "", con);

                }

            }
            else
            {
                if (group_by != "")
                {
                    cmd = new MySqlCommand("select * from " + table_name + " where " + parameter1 + "=@" + parameter1 + " and " + parameter2 + "=@" + parameter2 + " and " + parameter3 + "=@" + parameter3 + " group by " + group_by + "", con);

                }
                else
                {
                    cmd = new MySqlCommand("select * from " + table_name + " where " + parameter1 + "=@" + parameter1 + " and " + parameter2 + "=@" + parameter2 + " and " + parameter3 + "=@" + parameter3 + "", con);
                }
            }
            cmd.Parameters.AddWithValue("@" + parameter1 + "", dec1);
            cmd.Parameters.AddWithValue("@" + parameter2 + "", dec2);
            cmd.Parameters.AddWithValue("@" + parameter3 + "", dec3);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public void RedirectionQuerystring(string querystring, string pagename)
    {
        if (HttpContext.Current.Request.QueryString[querystring] != null && HttpContext.Current.Request.QueryString[querystring].ToString() != "")
        {

        }
        else
        {
            HttpContext.Current.Response.Redirect(pagename);
        }
    }
    public bool QueryStringExistorNot(string querystring)
    {
        if (HttpContext.Current.Request.QueryString[querystring] != null && HttpContext.Current.Request.QueryString[querystring].ToString() != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

  

    public DataTable FillDataTableColumns(DataTable dt, string[] columns, Repeater rpt = null, GridView gv = null)
    {
        dt.TableName = "Data Table";
        foreach (string str in columns)
        {
            dt.Columns.Add(new DataColumn(str, typeof(string)));
        }
        DataRow dr;
        dr = dt.NewRow();
        dt.Rows.Add(dr);
        return dt;
    }

    public void fillRepeter(DataSet ds, object rptGallery)
    {
        throw new NotImplementedException();
    }
}


