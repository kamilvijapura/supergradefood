using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for DAL
/// </summary>
public class connection
{
    public MySqlCommand cmd;
    public MySqlConnection con;
    public MySqlDataAdapter da;
    public DataSet ds;
    public void mycon()
    {
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ToString());
        con.Open();
    }
}
public class date_time_conversion
{
    public DateTime GetIndianDateTime()
    {
        DateTime timeUtc = DateTime.UtcNow;
        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime istTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, istZone);
        return istTime;
    }
}



public class replyDAL : connection
{
    public DataSet GetReplyDetails()
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT * FROM reply", con);
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

    public int delete_reply(replyBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("delete from reply where r_id=@r_id", con);
            cmd.Parameters.AddWithValue("@r_id", rBAL.r_id);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();

            return 1;
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

    public int insert_update_reply(replyBAL rBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_reply", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_r_id", rBAL.r_id);
            cmd.Parameters.AddWithValue("@_r_name", rBAL.r_name);
            // cmd.Parameters.AddWithValue("@_inquiry_last_name", inquiryBAL.inquiry_last_name);
            cmd.Parameters.AddWithValue("@_r_email", rBAL.r_email);
            //cmd.Parameters.AddWithValue("@_r_website", rBAL.r_website);

            cmd.Parameters.AddWithValue("@_r_comment", rBAL.r_comment);

            cmd.Parameters.AddWithValue("@_r_status", rBAL.r_status);
            cmd.Parameters.AddWithValue("@_r_insdt", rBAL.r_insdt);
            cmd.Parameters.AddWithValue("@_r_insip", rBAL.r_insip);
            cmd.Parameters.AddWithValue("@_r_insrid", rBAL.r_insrid);
            cmd.Parameters.AddWithValue("@_r_logdt", rBAL.r_logdt);
            cmd.Parameters.AddWithValue("@_r_logip", rBAL.r_logip);
            cmd.Parameters.AddWithValue("@_r_logrid", rBAL.r_logrid);
            cmd.Parameters.AddWithValue("@_r_prd_name", rBAL.r_prd_name);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            Byte retval = Convert.ToByte(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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
}
public class careerDAL : connection
{
   
    public int insert_update_career(careerBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_career", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_c_id", cBAL.c_id);
            cmd.Parameters.AddWithValue("@_c_name", cBAL.c_name);
            cmd.Parameters.AddWithValue("@_c_email", cBAL.c_email);
            cmd.Parameters.AddWithValue("@_c_contact", cBAL.c_contact);
           
            cmd.Parameters.AddWithValue("@_c_country", cBAL.c_country);
          
            cmd.Parameters.AddWithValue("@_c_add", cBAL.c_add);
            cmd.Parameters.AddWithValue("@_c_exp", cBAL.c_exp);
            cmd.Parameters.AddWithValue("@_c_pdf", cBAL.c_pdf);
            cmd.Parameters.AddWithValue("@_c_status", cBAL.c_status);
            cmd.Parameters.AddWithValue("@_c_insdt", cBAL.c_insdt);
            cmd.Parameters.AddWithValue("@_c_insip", cBAL.c_insip);
            cmd.Parameters.AddWithValue("@_c_insrid", cBAL.c_insrid);
            cmd.Parameters.AddWithValue("@_c_logdt", cBAL.c_logdt);
            cmd.Parameters.AddWithValue("@_c_logip", cBAL.c_logip);
            cmd.Parameters.AddWithValue("@_c_logrid",cBAL.c_logrid);
          

            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;

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
    public DataSet get_career_details(careerBAL cBAL)
    {
        mycon();
        try
        {
            if (cBAL.c_status == -1)
            {
                cmd = new MySqlCommand("select * from career", con);
            }
            else
            {
                cmd = new MySqlCommand("select * from career where c_status=@_c_status", con);
                cmd.Parameters.AddWithValue("@_c_status", cBAL.c_status);
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
    public DataSet get_career_details_for_edit(careerBAL cBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from career  where  c_id=@_c_id", con);
            cmd.Parameters.AddWithValue("@_c_id", cBAL.c_id);
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
    
}

public class loginDAL : connection
{
   // public int login(loginBAL lBAL)
    public int login(loginBAL lBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("logins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_l_id", lBAL.l_id);
            cmd.Parameters.AddWithValue("@_l_rollno", lBAL.l_rollno);
            cmd.Parameters.AddWithValue("@_l_email", lBAL.l_email);
            cmd.Parameters.AddWithValue("@_l_password", lBAL.l_password);
            cmd.Parameters.AddWithValue("@_l_name", lBAL.l_name);
            cmd.Parameters.AddWithValue("@_l_designation", lBAL.l_designation);
            cmd.Parameters.AddWithValue("@_l_image", lBAL.l_image);
            cmd.Parameters.AddWithValue("@_l_status", lBAL.l_status);
            cmd.Parameters.AddWithValue("@_l_insdt", lBAL.l_insdt);
            cmd.Parameters.AddWithValue("@_l_insip", lBAL.l_insip);
            cmd.Parameters.AddWithValue("@_l_insrid", lBAL.l_insrid);
            cmd.Parameters.AddWithValue("@_l_logdt", lBAL.l_logdt);
            cmd.Parameters.AddWithValue("@_l_logip", lBAL.l_logip);
            cmd.Parameters.AddWithValue("@_l_logrid", lBAL.l_logrid);
            cmd.Parameters.AddWithValue("@_l_time", lBAL.l_time);

            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;

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
    public DataSet get_login_details(loginBAL lBAL)
    {
        mycon();
        try
        {
            if (lBAL.l_status == -1)
            {
                cmd = new MySqlCommand("select * from login", con);
            }
            else
            {
                cmd = new MySqlCommand("select * from login where l_status=@_l_status", con);
                cmd.Parameters.AddWithValue("@_l_status", lBAL.l_status);
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
    public DataSet get_login_details_for_edit(loginBAL lBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from login  where  l_id=@_l_id", con);
            cmd.Parameters.AddWithValue("@_l_id", lBAL.l_id);
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
    public DataSet getlogininfo(loginBAL lbal)
    {

        mycon();
        try
        {
            cmd = new MySqlCommand("select * from login where l_rollno=@_l_rollno and l_time=@_l_time", con);
            cmd.Parameters.AddWithValue("@_l_rollno", lbal.l_rollno);
            cmd.Parameters.AddWithValue("@_l_time", lbal.l_time);
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
}

public class user_masterDAL : connection
{
    public string user_login(user_masterBAL amBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("system_user_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_usr_mobile_no", amBAL.usr_mobile_no);
            cmd.Parameters.AddWithValue("@_usr_password", amBAL.usr_password);

            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            MySqlParameter return_uid = new MySqlParameter("@_user_id", SqlDbType.Int);
            return_uid.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(return_uid);
            cmd.Parameters.Add(returnval);

            cmd.ExecuteNonQuery();
            int returnvalue = (int)returnval.Value;
            int uid = (int)return_uid.Value;

            con.Close();
            con.Dispose();
            return returnvalue + "|" + uid;

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
    public int insert_update_user_master(user_masterBAL usrBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_user_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_usr_id", usrBAL.usr_id);
            cmd.Parameters.AddWithValue("@_usr_name", usrBAL.usr_name);
            cmd.Parameters.AddWithValue("@_usr_gender", usrBAL.usr_gender);
            cmd.Parameters.AddWithValue("@_usr_mobile_no", usrBAL.usr_mobile_no);
            cmd.Parameters.AddWithValue("@_usr_email", usrBAL.usr_email);
            cmd.Parameters.AddWithValue("@_usr_password", usrBAL.usr_password);
            cmd.Parameters.AddWithValue("@_usr_role", usrBAL.usr_role);
            cmd.Parameters.AddWithValue("@_usr_status", usrBAL.usr_status);
            cmd.Parameters.AddWithValue("@_usr_insdt", usrBAL.usr_insdt);
            cmd.Parameters.AddWithValue("@_usr_insip", usrBAL.usr_insip);
            cmd.Parameters.AddWithValue("@_usr_insrid", usrBAL.usr_insrid);
            cmd.Parameters.AddWithValue("@_usr_logdt", usrBAL.usr_logdt);
            cmd.Parameters.AddWithValue("@_usr_logrid", usrBAL.usr_logrid);
            cmd.Parameters.AddWithValue("@_usr_logip", usrBAL.usr_logip);
            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;
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
    public DataSet get_user_details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from user_master", con);
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

}
public class category_masterDAL : connection
{
    public int insert_update_category_master(category_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_category_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_cat_id", cmBAL.cat_id);
            cmd.Parameters.AddWithValue("@_cat_name", cmBAL.cat_name);
            cmd.Parameters.AddWithValue("@_cat_image", cmBAL.cat_image);
            cmd.Parameters.AddWithValue("@_cat_status", cmBAL.cat_status);
            cmd.Parameters.AddWithValue("@_cat_insdt", cmBAL.cat_insdt);
            cmd.Parameters.AddWithValue("@_cat_insip", cmBAL.cat_insip);
            cmd.Parameters.AddWithValue("@_cat_insrid", cmBAL.cat_insrid);
            cmd.Parameters.AddWithValue("@_cat_logdt", cmBAL.cat_logdt);
            cmd.Parameters.AddWithValue("@_cat_logrid", cmBAL.cat_logrid);
            cmd.Parameters.AddWithValue("@_cat_logip", cmBAL.cat_logip);
            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;
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

    public DataSet get_category_details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from category_master", con);
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


    public DataSet get_category_details_for_edit(category_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from category_master where cat_id=@cat_id", con);
            cmd.Parameters.AddWithValue("@cat_id", cmBAL.cat_id);
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

    public DataSet get_category_for_dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from category_master where cat_status=1", con);
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

}
public class type_masterDAL : connection
{
    public int insert_update_type_master(type_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_type_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_type_id", cmBAL.type_id);
            cmd.Parameters.AddWithValue("@_type_name", cmBAL.type_name);
            cmd.Parameters.AddWithValue("@_type_status", cmBAL.type_status);
            cmd.Parameters.AddWithValue("@_type_insdt", cmBAL.type_insdt);
            cmd.Parameters.AddWithValue("@_type_insip", cmBAL.type_insip);
            cmd.Parameters.AddWithValue("@_type_insrid", cmBAL.type_insrid);
            cmd.Parameters.AddWithValue("@_type_logdt", cmBAL.type_logdt);
            cmd.Parameters.AddWithValue("@_type_logrid", cmBAL.type_logrid);
            cmd.Parameters.AddWithValue("@_type_logip", cmBAL.type_logip);
            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;
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

    public DataSet get_type_details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from type_master", con);
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


    public DataSet get_type_details_for_edit(type_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from type_master where type_id=@type_id", con);
            cmd.Parameters.AddWithValue("@type_id", cmBAL.type_id);
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

    public DataSet get_type_for_dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from type_master where type_status=1", con);
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

}
public class subcat_masterDAL : connection
{
    public int insert_update_subcat_master(subcat_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_subcat_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_subcat_id", cmBAL.subcat_id);
            cmd.Parameters.AddWithValue("@_subcat_cat_id", cmBAL.subcat_cat_id);
            cmd.Parameters.AddWithValue("@_subcat_name", cmBAL.subcat_name);
            cmd.Parameters.AddWithValue("@_subcat_status", cmBAL.subcat_status);
            cmd.Parameters.AddWithValue("@_subcat_insdt", cmBAL.subcat_insdt);
            cmd.Parameters.AddWithValue("@_subcat_insip", cmBAL.subcat_insip);
            cmd.Parameters.AddWithValue("@_subcat_insrid", cmBAL.subcat_insrid);
            cmd.Parameters.AddWithValue("@_subcat_logdt", cmBAL.subcat_logdt);
            cmd.Parameters.AddWithValue("@_subcat_logrid", cmBAL.subcat_logrid);
            cmd.Parameters.AddWithValue("@_subcat_logip", cmBAL.subcat_logip);
            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;
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

    public DataSet get_subcat_details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from subcat_master left join category_master on subcat_cat_id=cat_id", con);
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


    public DataSet get_subcat_details_for_edit(subcat_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from subcat_master where subcat_id=@subcat_id", con);
            cmd.Parameters.AddWithValue("@subcat_id", cmBAL.subcat_id);
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

    public DataSet get_subcat_for_dropdown(subcat_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from subcat_master where subcat_status=1 and subcat_cat_id=@subcat_cat_id", con);
            cmd.Parameters.AddWithValue("@subcat_cat_id", cmBAL.subcat_cat_id);
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

}
public class thirdcat_masterDAL : connection
{
    public int insert_update_thirdcat_master(thirdcat_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_thirdcat_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_thirdcat_id", cmBAL.thirdcat_id);
            cmd.Parameters.AddWithValue("@_thirdcat_subcat_id", cmBAL.thirdcat_subcat_id);
            cmd.Parameters.AddWithValue("@_thirdcat_name", cmBAL.thirdcat_name);
            cmd.Parameters.AddWithValue("@_thirdcat_status", cmBAL.thirdcat_status);
            cmd.Parameters.AddWithValue("@_thirdcat_insdt", cmBAL.thirdcat_insdt);
            cmd.Parameters.AddWithValue("@_thirdcat_insip", cmBAL.thirdcat_insip);
            cmd.Parameters.AddWithValue("@_thirdcat_insrid", cmBAL.thirdcat_insrid);
            cmd.Parameters.AddWithValue("@_thirdcat_logdt", cmBAL.thirdcat_logdt);
            cmd.Parameters.AddWithValue("@_thirdcat_logrid", cmBAL.thirdcat_logrid);
            cmd.Parameters.AddWithValue("@_thirdcat_logip", cmBAL.thirdcat_logip);
            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;
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

    public DataSet get_thirdcat_details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from thirdcat_master left join subcat_master on thirdcat_subcat_id=subcat_id", con);
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


    public DataSet get_thirdcat_details_for_edit(thirdcat_masterBAL cmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from thirdcat_master left join subcat_master on thirdcat_subcat_id=subcat_id  where thirdcat_id=@thirdcat_id", con);
            cmd.Parameters.AddWithValue("@thirdcat_id", cmBAL.thirdcat_id);
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

    public DataSet get_thirdcat_for_dropdown(thirdcat_masterBAL tcBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from thirdcat_master where thirdcat_status=1 and thirdcat_subcat_id=@thirdcat_subcat_id", con);
            cmd.Parameters.AddWithValue("@thirdcat_subcat_id", tcBAL.thirdcat_subcat_id);
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

    public DataSet get_type_for_dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from type_master", con);
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
}


public class product_masterDAL : connection
{
    public string insert_update_product_master(product_masterBAL prdBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_product_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_prd_id", prdBAL.prd_id);
            cmd.Parameters.AddWithValue("@_prd_cat_id", prdBAL.prd_cat_id);
            cmd.Parameters.AddWithValue("@_prd_subcat_id", prdBAL.prd_subcat_id);
            cmd.Parameters.AddWithValue("@_prd_type_id", prdBAL.prd_type_id);
            cmd.Parameters.AddWithValue("@_prd_name", prdBAL.prd_name);
            cmd.Parameters.AddWithValue("@_prd_des", prdBAL.prd_des);
            cmd.Parameters.AddWithValue("@_prd_price", prdBAL.prd_price);
            cmd.Parameters.AddWithValue("@_prd_selling_price", prdBAL.prd_selling_price);
            cmd.Parameters.AddWithValue("@_prd_show_home_page", prdBAL.prd_show_home_page);
            cmd.Parameters.AddWithValue("@_prd_pdf", prdBAL.prd_pdf);
            cmd.Parameters.AddWithValue("@_prd_status", prdBAL.prd_status);
            cmd.Parameters.AddWithValue("@_prd_insdt", prdBAL.prd_insdt);
            cmd.Parameters.AddWithValue("@_prd_insip", prdBAL.prd_insip);
            cmd.Parameters.AddWithValue("@_prd_insrid", prdBAL.prd_insrid);
            cmd.Parameters.AddWithValue("@_prd_logdt", prdBAL.prd_logdt);
            cmd.Parameters.AddWithValue("@_prd_logip", prdBAL.prd_logip);
            cmd.Parameters.AddWithValue("@_prd_logrid", prdBAL.prd_logrid);
            cmd.Parameters.AddWithValue("@_prd_title", prdBAL.prd_title);
            cmd.Parameters.AddWithValue("@_prd_dealer_price", prdBAL.prd_dealer_price);

            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);

            MySqlParameter maxval = new MySqlParameter("_max_id", SqlDbType.TinyInt);
            maxval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(maxval);

            cmd.ExecuteNonQuery();
            string retval = cmd.Parameters["_ret"].Value.ToString();
            string max = cmd.Parameters["_max_id"].Value.ToString();
            con.Close();
            con.Dispose();
            return retval + "|" + max;
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

    public int delete_product(product_masterBAL prdBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("delete from  product_master where prd_id = @prd_id", con);
            cmd.Parameters.AddWithValue("@prd_id", prdBAL.prd_id);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();

            return 1;
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


    public DataSet get_all_product_details(product_masterBAL pmBAL)
    {
        mycon();
        try
        {
            if (pmBAL.prd_status == -1)
            {
                cmd = new MySqlCommand("SELECT * FROM product_master", con);

            }
           else if (pmBAL.prd_status == -2)
            {
                cmd = new MySqlCommand("SELECT * FROM product_master left join type_master on type_id = prd_type_id left join category_master on prd_cat_id=cat_id group by type_id", con);

            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM product_images left join product_master on pi_prd_id=prd_id where prd_status=@prd_status group by prd_id", con);
                cmd.Parameters.AddWithValue("@prd_status",pmBAL.prd_status);

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
    public DataSet get_products_count()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from product_master", con);
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

    //public DataSet get_all_product_details(product_masterBAL pmBAL)
    //{
    //    mycon();
    //    try
    //    {
    //        cmd = new MySqlCommand("select * from get_product_details where prd_id=@prd_id", con);
    //        cmd.Parameters.AddWithValue("@prd_id", pmBAL.prd_id);
    //        da = new MySqlDataAdapter(cmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //        con.Close();
    //        con.Dispose();
    //        return ds;
    //    }
    //    catch (Exception)
    //    {
    //        con.Close();
    //        con.Dispose();
    //        throw;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();
    //    }

    //}

    public DataSet get_product_details_for_edit(product_masterBAL prdBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM  product_master left join product_images on prd_id=pi_prd_id left join category_master on cat_id = prd_cat_id where prd_id=@prd_id", con);
            cmd.Parameters.AddWithValue("@prd_id", prdBAL.prd_id);
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

        //}
        //public DataSet get_product_list(product_masterBAL pmBAL)
        //{
        //    mycon();
        //    try
        //    {
        //        cmd = new MySqlCommand("select * from get_product_details where prd_status=1 group by prd_id", con);
        //        da = new MySqlDataAdapter(cmd);
        //        DataTable dtPrddetail = new DataTable();
        //        da.Fill(dtPrddetail);
        //        //prd_detail cat wise
        //        cmd = new MySqlCommand("select * from get_product_details where cat_id=@cmid and prd_status=1 group by prd_id", con);
        //        cmd.Parameters.AddWithValue("@cmid", pmBAL.cat_id);
        //        da = new MySqlDataAdapter(cmd);
        //        DataTable dtcat = new DataTable();
        //        da.Fill(dtcat);
        //        //Populate Datasets
        //        ds = new DataSet();
        //        ds.Tables.AddRange(new DataTable[] { dtPrddetail, dtcat });
        //        con.Close();
        //        con.Dispose();
        //        return ds;
        //    }
        //    catch (Exception)
        //    {
        //        con.Close();
        //        con.Dispose();
        //        throw;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }
        //}
    }

    public DataSet get_related_product(product_masterBAL pmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM product_images  left join  product_master on pi_prd_id=prd_id where prd_id != @prd_id group by prd_id", con);
            cmd.Parameters.AddWithValue("@prd_id", pmBAL.prd_id);
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

    public DataSet get_product_by_category(product_masterBAL pmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM  product_master left join product_images on pi_prd_id = prd_id where prd_cat_id = @prd_cat_id group by prd_id", con);
            cmd.Parameters.AddWithValue("@prd_cat_id", pmBAL.prd_cat_id);
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

    public DataSet get_product_on_home_page()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM  product_master left join product_images on pi_prd_id = prd_id where prd_show_home_page = 1 group by prd_id", con);
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

    public DataSet get_product_search(product_masterBAL pmBAL)
    {
        mycon();
        try
        {
                cmd = new MySqlCommand("SELECT * FROM product_images left join product_master on pi_prd_id=prd_id where prd_status=1 and prd_name=@prd_name group by prd_id", con);
                cmd.Parameters.AddWithValue("@prd_name", pmBAL.prd_name);

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

    public DataSet get_category_by_type(product_masterBAL pmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM product_master left join type_master on type_id = prd_type_id left join category_master on prd_cat_id=cat_id where prd_type_id = @prd_type_id group by type_id", con);
            cmd.Parameters.AddWithValue("@prd_type_id",pmBAL.prd_type_id);


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
}
public class product_imagesDAL : connection
{
    public int insert_update_product_images(product_imagesBAL pimBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_product_images", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_pi_id", pimBAL.pi_id);
            cmd.Parameters.AddWithValue("@_pi_prd_id", pimBAL.pi_prd_id);
            cmd.Parameters.AddWithValue("@_pi_images", pimBAL.pi_images);

            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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

    public string delete_product_image_master(product_imagesBAL pimBAL)
    {
        mycon();

        try
        {
            cmd = new MySqlCommand("delete from product_images where pi_id=@pi_id", con);
            cmd.Parameters.AddWithValue("@pi_id", pimBAL.pi_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return "Product Image Delete Successfully";
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

    public DataSet get_product_images(product_imagesBAL piBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM product_images where pi_prd_id=@pi_prd_id", con);
            cmd.Parameters.AddWithValue("@pi_prd_id", piBAL.pi_prd_id);
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
}
public class product_featureDAL : connection
{
    public int insert_update_product_feature(product_featureBAL pfBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_product_feature", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_pf_id", pfBAL.pf_id);
            cmd.Parameters.AddWithValue("@_pf_prd_id", pfBAL.pf_prd_id);
            cmd.Parameters.AddWithValue("@_pf_feature", pfBAL.pf_feature);
            cmd.Parameters.AddWithValue("@_pf_des", pfBAL.pf_des);

            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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

    public string delete_product_features(product_featureBAL pfBAL)
    {
        mycon();

        try
        {
            cmd = new MySqlCommand("delete from product_feature where pf_id=@pf_id", con);
            cmd.Parameters.AddWithValue("@pf_id", pfBAL.pf_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return "Product Feature Delete Successfully";
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
    public int delete_feature(product_featureBAL pfBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("delete from product_feature where pf_id=@pf_id", con);
            cmd.Parameters.AddWithValue("@pf_id", pfBAL.pf_id);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();

            return 1;
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
}

public class product_cart_masterDAL:connection
{
    public string delete_cart_product(product_cart_masterBAL pcmBAL)
    {
        mycon();

        try
        {
            cmd = new MySqlCommand("delete from product_cart_master where pcm_id=@pcm_id", con);
            cmd.Parameters.AddWithValue("@pcm_id", pcmBAL.pcm_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return "Product From Cart Removed Successfully";
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

    public DataSet GetCartDetailsFromGuid(product_cart_masterBAL pcmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM product_cart_master  left join  product_images on pcm_prd_id=pi_prd_id left join product_master on pcm_prd_id=prd_id  where pcm_guid = @pcm_guid  group by prd_id", con);
            cmd.Parameters.AddWithValue("@pcm_guid", pcmBAL.pcm_guid);
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
    public DataSet GetCartDetailsFromUserid(product_cart_masterBAL pcmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM product_cart_master  left join  product_images on pcm_prd_id=pi_prd_id left join product_master on pcm_prd_id=prd_id  where pcm_usr_id = @pcm_usr_id  group by prd_id", con);
            cmd.Parameters.AddWithValue("@pcm_usr_id", pcmBAL.pcm_usr_id);
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

    public int GetSubTotalFromUserId(product_cart_masterBAL pcmBAL)
    {
        mycon(); try
        {
            cmd = new MySqlCommand("select if(sum(pcm_total)is null,0,sum(pcm_total)) as  pcmTotal from product_cart_master where pcm_usr_id=@pcm_usr_id", con);
            cmd.Parameters.AddWithValue("@pcm_usr_id", pcmBAL.pcm_usr_id);
            int bbdmid = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            con.Dispose();
            return bbdmid;
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

    public int GetSubTotalFromguId(product_cart_masterBAL pcmBAL)
    {
        mycon(); try
        {
            cmd = new MySqlCommand("select if(sum(pcm_total)is null,0,sum(pcm_total)) as  pcmTotal from product_cart_master where pcm_guid=@pcm_guid", con);
            cmd.Parameters.AddWithValue("@pcm_guid", pcmBAL.pcm_guid);
            int bbdmid = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            con.Dispose();
            return bbdmid;
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

    public int insert_update_product_cart_master(product_cart_masterBAL pcmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_product_cart_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_pcm_id", pcmBAL.pcm_id);
            cmd.Parameters.AddWithValue("@_pcm_prd_id", pcmBAL.pcm_prd_id);
            cmd.Parameters.AddWithValue("@_pcm_usr_id", pcmBAL.pcm_usr_id);
            cmd.Parameters.AddWithValue("@_pcm_guid", pcmBAL.pcm_guid);
            cmd.Parameters.AddWithValue("@_pcm_quantity", pcmBAL.pcm_quantity);
            cmd.Parameters.AddWithValue("@_pcm_price", pcmBAL.pcm_price);
            cmd.Parameters.AddWithValue("@_pcm_total", pcmBAL.pcm_total);
            cmd.Parameters.AddWithValue("@_pcm_insdt", pcmBAL.pcm_insdt);
            cmd.Parameters.AddWithValue("@_pcm_insip", pcmBAL.pcm_insip);
            cmd.Parameters.AddWithValue("@_pcm_insrid", pcmBAL.pcm_insrid);
            cmd.Parameters.AddWithValue("@_pcm_logdt", pcmBAL.pcm_logdt);
            cmd.Parameters.AddWithValue("@_pcm_logip", pcmBAL.pcm_logip);
            cmd.Parameters.AddWithValue("@_pcm_logrid", pcmBAL.pcm_logrid);

            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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

    public string update_cart_quantity(product_cart_masterBAL pcmBAL)
    {
        mycon();

        try
        {
            cmd = new MySqlCommand("Update product_cart_master set pcm_quantity=@pcm_quantity,pcm_total=@pcm_total where pcm_id=@pcm_id", con);
            cmd.Parameters.AddWithValue("@pcm_quantity", pcmBAL.pcm_quantity);
            cmd.Parameters.AddWithValue("@pcm_total", pcmBAL.pcm_total);
            cmd.Parameters.AddWithValue("@pcm_id", pcmBAL.pcm_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return "Cart Details Updated";
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

    public int UpdateCartDetailsFromGuidToUserId(product_cart_masterBAL pcmBAL)
    {
        mycon();

        try
        {
            cmd = new MySqlCommand("Update product_cart_master set pcm_guid=@guid,pcm_usr_id=@pcm_usr_id where pcm_guid=@pcm_guid", con);
            cmd.Parameters.AddWithValue("@pcm_usr_id", pcmBAL.pcm_usr_id);
            cmd.Parameters.AddWithValue("@pcm_guid", pcmBAL.pcm_guid);
            cmd.Parameters.AddWithValue("@guid", "Move");
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
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
}
public class promocode_masterDAL : connection
{
    public DataSet GetPromocodeDetails(promocode_masterBAL promoBAL)
    {
        mycon();
        try
        {
            if (promoBAL.promo_status == -1)
            {
                cmd = new MySqlCommand("SELECT * FROM promocode_master", con);

            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM promocode_master where promo_status=@promo_status", con);
                cmd.Parameters.AddWithValue("@promo_status", promoBAL.promo_status);

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

    public DataSet GetPromocodeDetailsForEdit(promocode_masterBAL promoBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM promocode_master where promo_id = @promo_id", con);
            cmd.Parameters.AddWithValue("@promo_id", promoBAL.promo_id);
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

    public DataSet GetPromocodeDetailsFromPromocode(promocode_masterBAL promoBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM promocode_master where promo_code = @promo_code and promo_status=1", con);
            cmd.Parameters.AddWithValue("@promo_code", promoBAL.promo_code);
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

    public int insert_update_promocode_master(promocode_masterBAL promoBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_promocode_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_promo_id", promoBAL.promo_id);
            cmd.Parameters.AddWithValue("@_promo_code", promoBAL.promo_code);
            cmd.Parameters.AddWithValue("@_promo_discount", promoBAL.promo_discount);
            cmd.Parameters.AddWithValue("@_promo_ispercentage", promoBAL.promo_ispercentage);
            cmd.Parameters.AddWithValue("@_promo_status", promoBAL.promo_status);
            cmd.Parameters.AddWithValue("@_promo_insdt", promoBAL.promo_insdt);
            cmd.Parameters.AddWithValue("@_promo_insip", promoBAL.promo_insip);
            cmd.Parameters.AddWithValue("@_promo_insrid", promoBAL.promo_insrid);
            cmd.Parameters.AddWithValue("@_promo_logdt", promoBAL.promo_logdt);
            cmd.Parameters.AddWithValue("@_promo_logip", promoBAL.promo_logip);
            cmd.Parameters.AddWithValue("@_promo_logrid", promoBAL.promo_logrid);

            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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
}

public class state_masterDAL : connection
{
    public int insert_update_state_master(state_masterBAL stateBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_state_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_state_id", stateBAL.state_id);
            cmd.Parameters.AddWithValue("@_state_name", stateBAL.state_name);
            cmd.Parameters.AddWithValue("@_state_status", stateBAL.state_status);
            cmd.Parameters.AddWithValue("@_state_insdt", stateBAL.state_insdt);
            cmd.Parameters.AddWithValue("@_state_insip", stateBAL.state_insip);
            cmd.Parameters.AddWithValue("@_state_insrid", stateBAL.state_insrid);
            cmd.Parameters.AddWithValue("@_state_logdt", stateBAL.state_logdt);
            cmd.Parameters.AddWithValue("@_state_logip", stateBAL.state_logip);
            cmd.Parameters.AddWithValue("@_state_logrid", stateBAL.state_logrid);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            Byte retval = Convert.ToByte(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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

    public DataSet get_state_list(state_masterBAL stmBAL)
    {
        try
        {
            mycon();
            if (stmBAL.state_status == -1)
            {
                cmd = new MySqlCommand("select state_id,state_name,state_status from state_master", con);
            }
            else
            {
                cmd = new MySqlCommand("select state_id,state_name,state_status from state_master where state_status = @state_status order by state_name", con);
                cmd.Parameters.AddWithValue("@state_status", stmBAL.state_status);
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

    public DataSet get_state_for_edit(state_masterBAL stateBAL)
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("select state_id,state_name,state_status from state_master where state_id = @state_id", con);
            cmd.Parameters.AddWithValue("@state_id", stateBAL.state_id);
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
}

public class customer_address_masterDAL:connection
{
    public int insert_update_cam_master(customer_address_masterBAL camBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_cam_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_cam_id", camBAL.cam_id);
            cmd.Parameters.AddWithValue("@_cam_name", camBAL.cam_name);
            cmd.Parameters.AddWithValue("@_cam_streetaddress_1", camBAL.cam_streetaddress_1);
            cmd.Parameters.AddWithValue("@_cam_streetaddress_2", camBAL.cam_streetaddress_2);
            cmd.Parameters.AddWithValue("@_cam_state_id", camBAL.cam_state_id);
            cmd.Parameters.AddWithValue("@_cam_city", camBAL.cam_city);
            cmd.Parameters.AddWithValue("@_cam_pincode", camBAL.cam_pincode);
            cmd.Parameters.AddWithValue("@_cam_area", camBAL.cam_area);
            cmd.Parameters.AddWithValue("@_cam_ctn", camBAL.cam_ctn);
            cmd.Parameters.AddWithValue("@_cam_insdt", camBAL.cam_insdt);
            cmd.Parameters.AddWithValue("@_cam_insip", camBAL.cam_insip);
            cmd.Parameters.AddWithValue("@_cam_insrid", camBAL.cam_insrid);
            cmd.Parameters.AddWithValue("@_cam_logdt", camBAL.cam_logdt);
            cmd.Parameters.AddWithValue("@_cam_logip", camBAL.cam_logip);
            cmd.Parameters.AddWithValue("@_cam_logrid", camBAL.cam_logrid);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            Byte retval = Convert.ToByte(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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
}

public class testimonial_masterDAL : connection
{
    public int insert_update_testimonial_master(testimonial_masterBAL tmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_testimonial_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_tm_id", tmBAL.tm_id);
            cmd.Parameters.AddWithValue("@_tm_client_name", tmBAL.tm_client_name);
            cmd.Parameters.AddWithValue("@_tm_designation", tmBAL.tm_designation);
            cmd.Parameters.AddWithValue("@_tm_client_img", tmBAL.tm_client_img);
            cmd.Parameters.AddWithValue("@_tm_description", tmBAL.tm_description);
            cmd.Parameters.AddWithValue("@_tm_status", tmBAL.tm_status);
            cmd.Parameters.AddWithValue("@_tm_insdt", tmBAL.tm_insdt);
            cmd.Parameters.AddWithValue("@_tm_insip", tmBAL.tm_insip);
            cmd.Parameters.AddWithValue("@_tm_insrid", tmBAL.tm_insrid);
            cmd.Parameters.AddWithValue("@_tm_logdt", tmBAL.tm_logdt);
            cmd.Parameters.AddWithValue("@_tm_logip", tmBAL.tm_logip);
            cmd.Parameters.AddWithValue("@_tm_logrid", tmBAL.tm_logrid);
            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;
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

    public DataSet get_testimonial_details(testimonial_masterBAL tstBAL)
    {
        mycon();
        try
        {
            if (tstBAL.tm_status == -1)
            {
                cmd = new MySqlCommand("select * from testimonial_master", con);
            }
            else
            {
                cmd = new MySqlCommand("select * from testimonial_master where tm_status=@tm_status", con);
                cmd.Parameters.AddWithValue("@tm_status", tstBAL.tm_status);
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
    public DataSet get_testimonial_count()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from testimonial_master", con);
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
    public DataSet get_testimonial_details_for_edit(testimonial_masterBAL tmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from testimonial_master where tm_id=@tm_id", con);
            cmd.Parameters.AddWithValue("@tm_id", tmBAL.tm_id);
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
}

public class pdf_masterDAL : connection
{
    public int insert_update_pdf_master(pdf_masterBAL pdfBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_pdf_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_pdf_id", pdfBAL.pdf_id);
            cmd.Parameters.AddWithValue("@_pdf_pdf", pdfBAL.pdf_pdf);
            cmd.Parameters.AddWithValue("@_pdf_thumbnail", pdfBAL.pdf_thumbnail);
            cmd.Parameters.AddWithValue("@_pdf_status", pdfBAL.pdf_status);
            cmd.Parameters.AddWithValue("@_pdf_insdt", pdfBAL.pdf_insdt);
            cmd.Parameters.AddWithValue("@_pdf_insip", pdfBAL.pdf_insip);
            cmd.Parameters.AddWithValue("@_pdf_insrid", pdfBAL.pdf_insrid);
            cmd.Parameters.AddWithValue("@_pdf_logdt", pdfBAL.pdf_logdt);
            cmd.Parameters.AddWithValue("@_pdf_logip", pdfBAL.pdf_logip);
            cmd.Parameters.AddWithValue("@_pdf_logrid", pdfBAL.pdf_logrid);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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

    public DataSet get_galery_details(pdf_masterBAL pdfBAL)
    {
        mycon();
        try
        {
            if (pdfBAL.pdf_status == -1)
            {
                cmd = new MySqlCommand("select * from pdf_master", con);
            }
            else
            {
                cmd = new MySqlCommand("select * from pdf_master where pdf_status = @pdf_status", con);
                cmd.Parameters.AddWithValue("@pdf_status", pdfBAL.pdf_status);
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

    public DataSet get_pdf_details_for_edit(pdf_masterBAL pdfBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from pdf_master where pdf_id=@pdf_id", con);
            cmd.Parameters.AddWithValue("@pdf_id", pdfBAL.pdf_id);
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
}

public class inquiry_masterDAL : connection
{
    public DataSet GetInquiryDetails()
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT * FROM inquiry_master", con);
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

    public int insert_update_inquiry_master(inquiry_masterBAL inquiryBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_inquiry_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_inquiry_id", inquiryBAL.inquiry_id);
            cmd.Parameters.AddWithValue("@_inquiry_first_name", inquiryBAL.inquiry_first_name);
            // cmd.Parameters.AddWithValue("@_inquiry_last_name", inquiryBAL.inquiry_last_name);
            cmd.Parameters.AddWithValue("@_inquiry_email", inquiryBAL.inquiry_email);
            cmd.Parameters.AddWithValue("@_inquiry_ctn", inquiryBAL.inquiry_ctn);
            cmd.Parameters.AddWithValue("@_inquiry_msg", inquiryBAL.inquiry_msg);
            cmd.Parameters.AddWithValue("@_inquiry_status", inquiryBAL.inquiry_status);
            cmd.Parameters.AddWithValue("@_inquiry_insdt", inquiryBAL.inquiry_insdt);
            cmd.Parameters.AddWithValue("@_inquiry_insip", inquiryBAL.inquiry_insip);
            cmd.Parameters.AddWithValue("@_inquiry_insrid", inquiryBAL.inquiry_insrid);
            cmd.Parameters.AddWithValue("@_inquiry_logdt", inquiryBAL.inquiry_logdt);
            cmd.Parameters.AddWithValue("@_inquiry_logip", inquiryBAL.inquiry_logip);
            cmd.Parameters.AddWithValue("@_inquiry_logrid", inquiryBAL.inquiry_logrid);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            Byte retval = Convert.ToByte(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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
}

public class view_masterDAL:connection
{
    public int getCount()
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT count(*) FROM view_master", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            con.Dispose();
            return count;
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

    public void insert_view()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert into view_master values(null,'"+HttpContext.Current.Request.UserHostAddress+"','"+System.DateTime.Now+"')", con);
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
}

public class gallery_masterDAL : connection
{
    public int insert_update_gallery_master(gallery_masterBAL gmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_gallery_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_gm_id", gmBAL.gm_id);
            cmd.Parameters.AddWithValue("@_gm_img", gmBAL.gm_img);
            cmd.Parameters.AddWithValue("@_gm_status", gmBAL.gm_status);
            cmd.Parameters.AddWithValue("@_gm_insdt", gmBAL.gm_insdt);
            cmd.Parameters.AddWithValue("@_gm_insip", gmBAL.gm_insip);
            cmd.Parameters.AddWithValue("@_gm_insrid", gmBAL.gm_insrid);
            cmd.Parameters.AddWithValue("@_gm_logdt", gmBAL.gm_logdt);
            cmd.Parameters.AddWithValue("@_gm_logip", gmBAL.gm_logip);
            cmd.Parameters.AddWithValue("@_gm_logrid", gmBAL.gm_logrid);
            cmd.Parameters.AddWithValue("@_gm_home", gmBAL.gm_home);

            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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
    public DataSet get_gallery_count()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from gallery_master", con);
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
    public DataSet get_galery_details(gallery_masterBAL gmBAL)
    {
        mycon();
        try
        {
            if (gmBAL.gm_status == -1)
            {
                cmd = new MySqlCommand("select * from gallery_master", con);
            }
            else
            {
                cmd = new MySqlCommand("select * from gallery_master where gm_status = @gm_status", con);
                cmd.Parameters.AddWithValue("@gm_status", gmBAL.gm_status);
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

    public DataSet get_gallery_details_for_edit(gallery_masterBAL gmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from gallery_master where gm_id=@gm_id", con);
            cmd.Parameters.AddWithValue("@gm_id", gmBAL.gm_id);
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

    public int delete_gallery_images(gallery_masterBAL gmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("delete from gallery_master where gm_id = @gm_id", con);
            cmd.Parameters.AddWithValue("@gm_id", gmBAL.gm_id);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();

            return 1;
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
}

public class product_inquiry_masterDAL : connection
{
    public DataSet GetProductCartDetails()
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT * FROM product_master inner join product_inquiry_master on prd_id = prdinq_prd_id", con);
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
    public DataSet GetProductDetails()
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT * FROM  product_inquiry_master", con);
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
    public int insert_update_product_inquiry_master(product_inquiry_masterBAL pcmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_product_inquiry_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_prdinq_id", pcmBAL.prdinq_id);
            cmd.Parameters.AddWithValue("@_prdinq_prd_id", pcmBAL.prdinq_prd_id);
            cmd.Parameters.AddWithValue("@_prdinq_name", pcmBAL.prdinq_name);
            cmd.Parameters.AddWithValue("@_prdinq_contact_no", pcmBAL.prdinq_contact_no);
            cmd.Parameters.AddWithValue("@_prdinq_email", pcmBAL.prdinq_email);
            cmd.Parameters.AddWithValue("@_prdinq_address", pcmBAL.prdinq_address);
            cmd.Parameters.AddWithValue("@_prdinq_company_name", pcmBAL.prdinq_company_name);
            cmd.Parameters.AddWithValue("@_prdinq_city", pcmBAL.prdinq_city);
            cmd.Parameters.AddWithValue("@_prdinq_postcode", pcmBAL.prdinq_postcode);
            cmd.Parameters.AddWithValue("@_prdinq_status", pcmBAL.prdinq_status);
            cmd.Parameters.AddWithValue("@_prdinq_insdt", pcmBAL.prdinq_insdt);
            cmd.Parameters.AddWithValue("@_prdinq_insip", pcmBAL.prdinq_insip);
            cmd.Parameters.AddWithValue("@_prdinq_insrid", pcmBAL.prdinq_insrid);
            cmd.Parameters.AddWithValue("@_prdinq_logdt", pcmBAL.prdinq_logdt);
            cmd.Parameters.AddWithValue("@_prdinq_logip", pcmBAL.prdinq_logip);
            cmd.Parameters.AddWithValue("@_prdinq_logrid", pcmBAL.prdinq_logrid);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            Byte retval = Convert.ToByte(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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

    public int delete_product_inquiry(product_inquiry_masterBAL pcmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("delete from product_inquiry_master where prdinq_id = @prdinq_id", con);
            cmd.Parameters.AddWithValue("@prdinq_id", pcmBAL.prdinq_id);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();

            return 1;
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
    public int updateProductCartStatus(product_inquiry_masterBAL pcmBAL)
    {
        mycon(); try
        {
            cmd = new MySqlCommand("update product_inquiry_master set prdinq_status=@prdinq_status where prdinq_id=@prdinq_id", con);
            cmd.Parameters.AddWithValue("@prdinq_status", pcmBAL.prdinq_status);
            cmd.Parameters.AddWithValue("@prdinq_id", pcmBAL.prdinq_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return 1;
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
}

public class newslatter_masterDAL : connection
{
    public DataSet get_newsletter_list()
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT * from newslatter_master order by nm_id desc", con);
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

    public int insert_newslatter_master(newslatter_masterBAL nmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_newslatter_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_nm_id", nmBAL.nm_id);
            cmd.Parameters.AddWithValue("@_nm_email", nmBAL.nm_email);
            cmd.Parameters.AddWithValue("@_nm_insdt", nmBAL.nm_insdt);
            cmd.Parameters.AddWithValue("@_nm_insip", nmBAL.nm_insip);
            cmd.Parameters.AddWithValue("@_nm_insrid", nmBAL.nm_insrid);
            cmd.Parameters.AddWithValue("@_nm_logdt", nmBAL.nm_logdt);
            cmd.Parameters.AddWithValue("@_nm_logip", nmBAL.nm_logip);
            cmd.Parameters.AddWithValue("@_nm_logrid", nmBAL.nm_logrid);
            MySqlParameter returnval = new MySqlParameter("@_ret", MySqlDbType.VarChar, 50);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            int rval = Convert.ToInt32(returnval.Value);
            con.Close();
            con.Dispose();
            return rval;
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
}
public class reviewDAL : connection
{
    public DataSet GetReviewDetails()
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT * FROM review", con);
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
    public DataSet get_review_count()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from review", con);
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
    public int insert_update_review(reviewBAL caBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_review", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_ca_id", caBAL.ca_id);
            cmd.Parameters.AddWithValue("@_ca_name", caBAL.ca_name);
            // cmd.Parameters.AddWithValue("@_inquiry_last_name", inquiryBAL.inquiry_last_name);
            cmd.Parameters.AddWithValue("@_ca_email", caBAL.ca_email);
            cmd.Parameters.AddWithValue("@_ca_sub", caBAL.ca_sub);
            cmd.Parameters.AddWithValue("@_ca_mobile", caBAL.ca_mobile);
            cmd.Parameters.AddWithValue("@_ca_date", caBAL.ca_date);
            cmd.Parameters.AddWithValue("@_ca_time", caBAL.ca_time);
            cmd.Parameters.AddWithValue("@_ca_msg", caBAL.ca_msg);
            cmd.Parameters.AddWithValue("@_ca_status", caBAL.ca_status);
            cmd.Parameters.AddWithValue("@_ca_insdt", caBAL.ca_insdt);
            cmd.Parameters.AddWithValue("@_ca_insip", caBAL.ca_insip);
            cmd.Parameters.AddWithValue("@_ca_insrid", caBAL.ca_insrid);
            cmd.Parameters.AddWithValue("@_ca_logdt", caBAL.ca_logdt);
            cmd.Parameters.AddWithValue("@_ca_logip", caBAL.ca_logip);
            cmd.Parameters.AddWithValue("@_ca_logrid", caBAL.ca_logrid);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            Byte retval = Convert.ToByte(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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
}
public class blog_masterDAL : connection
{
    public DataSet get_single_blog(blog_masterBAL blogBAL)
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT *,DATE_FORMAT(blog_insdt, '%M %d,%Y') as insdt FROM blog_master;", con);
            cmd.Parameters.AddWithValue("@blog_id", blogBAL.blog_id);
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
    public DataSet get_blog_count()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from blog_master", con);
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
    public DataSet get_all_blog(blog_masterBAL blogBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM blog_master where blog_id=@_blog_id", con);
            cmd.Parameters.AddWithValue("@_blog_id", blogBAL.blog_id);
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

    public int insert_update_blog_master(blog_masterBAL blogBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_blog_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_blog_id", blogBAL.blog_id);
            cmd.Parameters.AddWithValue("@_blog_title", blogBAL.blog_title);
            cmd.Parameters.AddWithValue("@_blog_content", blogBAL.blog_content);
            cmd.Parameters.AddWithValue("@_blog_author", blogBAL.blog_author);
            cmd.Parameters.AddWithValue("@_blog_date", blogBAL.blog_date);
            cmd.Parameters.AddWithValue("@_blog_image", blogBAL.blog_image);
            cmd.Parameters.AddWithValue("@_blog_status", blogBAL.blog_status);
            cmd.Parameters.AddWithValue("@_blog_insdt", blogBAL.blog_insdt);
            cmd.Parameters.AddWithValue("@_blog_insip", blogBAL.blog_insip);
            cmd.Parameters.AddWithValue("@_blog_insrid", blogBAL.blog_insrid);
            cmd.Parameters.AddWithValue("@_blog_logdt", blogBAL.blog_logdt);
            cmd.Parameters.AddWithValue("@_blog_logip", blogBAL.blog_logip);
            cmd.Parameters.AddWithValue("@_blog_logrid", blogBAL.blog_logrid);

            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            Byte retval = Convert.ToByte(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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
}
public class project_masterDAL : connection
{
    public string insert_update_project_master(project_masterBAL prdBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_project_master", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_prd_id", prdBAL.prd_id);
            cmd.Parameters.AddWithValue("@_prd_cat_id", prdBAL.prd_cat_id);
            cmd.Parameters.AddWithValue("@_prd_subcat_id", prdBAL.prd_subcat_id);
            cmd.Parameters.AddWithValue("@_prd_type_id", prdBAL.prd_type_id);
            cmd.Parameters.AddWithValue("@_prd_name", prdBAL.prd_name);
            cmd.Parameters.AddWithValue("@_prd_des", prdBAL.prd_des);
            cmd.Parameters.AddWithValue("@_prd_price", prdBAL.prd_price);
            cmd.Parameters.AddWithValue("@_prd_selling_price", prdBAL.prd_selling_price);
            cmd.Parameters.AddWithValue("@_prd_show_home_page", prdBAL.prd_show_home_page);
            cmd.Parameters.AddWithValue("@_prd_pdf", prdBAL.prd_pdf);
            cmd.Parameters.AddWithValue("@_prd_status", prdBAL.prd_status);
            cmd.Parameters.AddWithValue("@_prd_insdt", prdBAL.prd_insdt);
            cmd.Parameters.AddWithValue("@_prd_insip", prdBAL.prd_insip);
            cmd.Parameters.AddWithValue("@_prd_insrid", prdBAL.prd_insrid);
            cmd.Parameters.AddWithValue("@_prd_logdt", prdBAL.prd_logdt);
            cmd.Parameters.AddWithValue("@_prd_logip", prdBAL.prd_logip);
            cmd.Parameters.AddWithValue("@_prd_logrid", prdBAL.prd_logrid);
            cmd.Parameters.AddWithValue("@_prd_title_desc", prdBAL.prd_title_desc);
            cmd.Parameters.AddWithValue("@_prd_ben_des", prdBAL.prd_ben_des);
            cmd.Parameters.AddWithValue("@_prd_b1_image", prdBAL.prd_b1_image);
            cmd.Parameters.AddWithValue("@_prd_b1_title", prdBAL.prd_b1_title);
            cmd.Parameters.AddWithValue("@_prd_b1_des", prdBAL.prd_b1_des);
          
            cmd.Parameters.AddWithValue("@_prd_b2_image", prdBAL.prd_b2_image);
            cmd.Parameters.AddWithValue("@_prd_b2_title", prdBAL.prd_b2_title);
            cmd.Parameters.AddWithValue("@_prd_b2_des", prdBAL.prd_b2_des);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);

            MySqlParameter maxval = new MySqlParameter("_max_id", SqlDbType.TinyInt);
            maxval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(maxval);

            cmd.ExecuteNonQuery();
            string retval = cmd.Parameters["_ret"].Value.ToString();
            string max = cmd.Parameters["_max_id"].Value.ToString();
            con.Close();
            con.Dispose();
            return retval + "|" + max;
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



    public DataSet get_all_project_details(project_masterBAL pmBAL)
    {
        mycon();
        try
        {
            if (pmBAL.prd_status == -1)
            {
                cmd = new MySqlCommand("SELECT * FROM project_master", con);

            }
            else if (pmBAL.prd_status == -2)
            {
                cmd = new MySqlCommand("SELECT * FROM projecct_master left join type_master on type_id = prd_type_id left join category_master on prd_cat_id=cat_id group by type_id", con);

            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM project_images left join project_master on pi_prd_id=prd_id where prd_status=@prd_status group by prd_id", con);
                cmd.Parameters.AddWithValue("@prd_status", pmBAL.prd_status);

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

    //public DataSet get_all_product_details(product_masterBAL pmBAL)
    //{
    //    mycon();
    //    try
    //    {
    //        cmd = new MySqlCommand("select * from get_product_details where prd_id=@prd_id", con);
    //        cmd.Parameters.AddWithValue("@prd_id", pmBAL.prd_id);
    //        da = new MySqlDataAdapter(cmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //        con.Close();
    //        con.Dispose();
    //        return ds;
    //    }
    //    catch (Exception)
    //    {
    //        con.Close();
    //        con.Dispose();
    //        throw;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();
    //    }

    //}

    public DataSet get_project_details_for_edit(project_masterBAL prdBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM  project_master left join project_images on prd_id=pi_prd_id left join category_master on cat_id = prd_cat_id where prd_id=@prd_id", con);
            cmd.Parameters.AddWithValue("@prd_id", prdBAL.prd_id);
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

        //}
        //public DataSet get_product_list(product_masterBAL pmBAL)
        //{
        //    mycon();
        //    try
        //    {
        //        cmd = new MySqlCommand("select * from get_product_details where prd_status=1 group by prd_id", con);
        //        da = new MySqlDataAdapter(cmd);
        //        DataTable dtPrddetail = new DataTable();
        //        da.Fill(dtPrddetail);
        //        //prd_detail cat wise
        //        cmd = new MySqlCommand("select * from get_product_details where cat_id=@cmid and prd_status=1 group by prd_id", con);
        //        cmd.Parameters.AddWithValue("@cmid", pmBAL.cat_id);
        //        da = new MySqlDataAdapter(cmd);
        //        DataTable dtcat = new DataTable();
        //        da.Fill(dtcat);
        //        //Populate Datasets
        //        ds = new DataSet();
        //        ds.Tables.AddRange(new DataTable[] { dtPrddetail, dtcat });
        //        con.Close();
        //        con.Dispose();
        //        return ds;
        //    }
        //    catch (Exception)
        //    {
        //        con.Close();
        //        con.Dispose();
        //        throw;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }
        //}
    }

    public DataSet get_related_project(project_masterBAL pmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM project_images  left join  project_master on pi_prd_id=prd_id where prd_id != @prd_id group by prd_id", con);
            cmd.Parameters.AddWithValue("@prd_id", pmBAL.prd_id);
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

    public DataSet get_project_by_category(project_masterBAL pmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM  project_master left join project_images on pi_prd_id = prd_id where prd_cat_id = @prd_cat_id group by prd_id", con);
            cmd.Parameters.AddWithValue("@prd_cat_id", pmBAL.prd_cat_id);
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

    public DataSet get_project_on_home_page()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM  project_master left join project_images on pi_prd_id = prd_id where prd_show_home_page = 1 group by prd_id", con);
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

    public DataSet get_project_search(project_masterBAL pmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM project_images left join project_master on pi_prd_id=prd_id where prd_status=1 and prd_name=@prd_name group by prd_id", con);
            cmd.Parameters.AddWithValue("@prd_name", pmBAL.prd_name);

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

    public DataSet get_category_by_type(project_masterBAL pmBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM project_master left join type_master on type_id = prd_type_id left join category_master on prd_cat_id=cat_id where prd_type_id = @prd_type_id group by type_id", con);
            cmd.Parameters.AddWithValue("@prd_type_id", pmBAL.prd_type_id);


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
}
public class project_imagesDAL : connection
{
    public int insert_update_project_images(project_imagesBAL pimBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_update_project_images", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_pi_id", pimBAL.pi_id);
            cmd.Parameters.AddWithValue("@_pi_prd_id", pimBAL.pi_prd_id);
            cmd.Parameters.AddWithValue("@_pi_images", pimBAL.pi_images);

            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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

    public string delete_project_image_master(project_imagesBAL pimBAL)
    {
        mycon();

        try
        {
            cmd = new MySqlCommand("delete from project_images where pi_id=@pi_id", con);
            cmd.Parameters.AddWithValue("@pi_id", pimBAL.pi_id);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return "Project Image Delete Successfully";
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

    public DataSet get_project_images(project_imagesBAL piBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("SELECT * FROM project_images where pi_prd_id=@pi_prd_id", con);
            cmd.Parameters.AddWithValue("@pi_prd_id", piBAL.pi_prd_id);
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
}
public class dealerDAL : connection
{
    public int dealer_login(dealerBAL dlrBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("dealer_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_dlr_id", dlrBAL.dlr_id);
            cmd.Parameters.AddWithValue("@_dlr_email", dlrBAL.dlr_email);
            cmd.Parameters.AddWithValue("@_dlr_password", dlrBAL.dlr_password);
            cmd.Parameters.AddWithValue("@_dlr_status", dlrBAL.dlr_status);
            cmd.Parameters.AddWithValue("@_dlr_insdt", dlrBAL.dlr_insdt);
            cmd.Parameters.AddWithValue("@_dlr_insip", dlrBAL.dlr_insip);
            cmd.Parameters.AddWithValue("@_dlr_insrid", dlrBAL.dlr_insrid);
            cmd.Parameters.AddWithValue("@_dlr_logdt", dlrBAL.dlr_logdt);
            cmd.Parameters.AddWithValue("@_dlr_logip", dlrBAL.dlr_logip);
            cmd.Parameters.AddWithValue("@_dlr_logrid", dlrBAL.dlr_logrid);


            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;

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
    public DataSet get_dealer_details(dealerBAL dlrBAL)
    {
        mycon();
        try
        {
            if (dlrBAL.dlr_status == -1)
            {
                cmd = new MySqlCommand("select * from dealer", con);
            }
            else
            {
                cmd = new MySqlCommand("select * from dealer where dlr_status=@_dlr_status", con);
                cmd.Parameters.AddWithValue("@_dlr_status", dlrBAL.dlr_status);
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
    public DataSet get_dealer_details_for_edit(dealerBAL dlrBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from dealer  where  dlr_id=@_dlr_id", con);
            cmd.Parameters.AddWithValue("@_dlr_id", dlrBAL.dlr_id);
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
    public int delete_dealer(dealerBAL dlrBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("delete from dealer where dlr_id = @dlr_id", con);
            cmd.Parameters.AddWithValue("@dlr_id", dlrBAL.dlr_id);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();

            return 1;
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
    public DataSet getdealermaninfo(dealerBAL dlrbal)
    {

        mycon();
        try
        {
            cmd = new MySqlCommand("select * from dealer where dlr_email=@_dlr_email and dlr_password=@_dlr_password", con);
            cmd.Parameters.AddWithValue("@_dlr_email", dlrbal.dlr_email);
            cmd.Parameters.AddWithValue("@_dlr_password", dlrbal.dlr_password);
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
    public DataSet get_dealer_count()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from dealer ", con);
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
}

public class salesmanDAL : connection
{
    public int salesman_login(salesmanBAL smBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("salesman_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_sm_id", smBAL.sm_id);
            cmd.Parameters.AddWithValue("@_sm_email", smBAL.sm_email);
            cmd.Parameters.AddWithValue("@_sm_password", smBAL.sm_password);
            cmd.Parameters.AddWithValue("@_sm_status", smBAL.sm_status);
            cmd.Parameters.AddWithValue("@_sm_insdt", smBAL.sm_insdt);
            cmd.Parameters.AddWithValue("@_sm_insip", smBAL.sm_insip);
            cmd.Parameters.AddWithValue("@_sm_insrid", smBAL.sm_insrid);
            cmd.Parameters.AddWithValue("@_sm_logdt", smBAL.sm_logdt);
            cmd.Parameters.AddWithValue("@_sm_logip", smBAL.sm_logip);
            cmd.Parameters.AddWithValue("@_sm_logrid", smBAL.sm_logrid);


            MySqlParameter returnval = new MySqlParameter("@_ret", SqlDbType.TinyInt);
            returnval.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnval);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            int rval = (int)returnval.Value;
            return rval;
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
    public DataSet get_salesman_details(salesmanBAL smBAL)
    {
        mycon();
        try
        {
            if (smBAL.sm_status == -1)
            {
                cmd = new MySqlCommand("select * from salesman", con);
            }
            else
            {
                cmd = new MySqlCommand("select * from salesman where sm_status=@_sm_status", con);
                cmd.Parameters.AddWithValue("@_sm_status", smBAL.sm_status);
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
    public DataSet get_salesman_details_for_edit(salesmanBAL smBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select *  from salesman where sm_id=@_sm_id", con);
            cmd.Parameters.AddWithValue("@_sm_id", smBAL.sm_id);
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
    public int delete_salesman(salesmanBAL smBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("delete from salesman where sm_id = @sm_id", con);
            cmd.Parameters.AddWithValue("@sm_id", smBAL.sm_id);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();

            return 1;
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
    public DataSet getsalesmaninfo(salesmanBAL smbal)
    {

        mycon();
        try
        {
            cmd = new MySqlCommand("select * from salesman where sm_email=@_sm_email and sm_password=@_sm_password", con);
            cmd.Parameters.AddWithValue("@_sm_email", smbal.sm_email);
            cmd.Parameters.AddWithValue("@_sm_password", smbal.sm_password);
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
    public DataSet get_salesman_count()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from  salesman", con);
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


}
public class salesman_formDAL : connection
{

    public int insert_salesman_form(salesman_formBAL slfBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert_salesman_form", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_slf_id", slfBAL.slf_id);
            cmd.Parameters.AddWithValue("@_slf_name", slfBAL.slf_name);

            cmd.Parameters.AddWithValue("@_slf_company_name", slfBAL.slf_company_name);
            cmd.Parameters.AddWithValue("@_slf_product", slfBAL.slf_product);
            cmd.Parameters.AddWithValue("@_slf_message", slfBAL.slf_message);
            cmd.Parameters.AddWithValue("@_slf_img", slfBAL.slf_img);

            cmd.Parameters.AddWithValue("@_slf_status", slfBAL.slf_status);
            cmd.Parameters.AddWithValue("@_slf_insdt", slfBAL.slf_insdt);
            cmd.Parameters.AddWithValue("@_slf_insip", slfBAL.slf_insip);
            cmd.Parameters.AddWithValue("@_slf_insrid", slfBAL.slf_insrid);
            cmd.Parameters.AddWithValue("@_slf_logdt", slfBAL.slf_logdt);
            cmd.Parameters.AddWithValue("@_slf_logip", slfBAL.slf_logip);
            cmd.Parameters.AddWithValue("@_slf_logrid", slfBAL.slf_logrid);
            cmd.Parameters.AddWithValue("@_slf_sm_id", slfBAL.slf_sm_id);
            cmd.Parameters.AddWithValue("@_slf_sm_email", slfBAL.slf_sm_email);
            cmd.Parameters.AddWithValue("@_slf_sm_date", slfBAL.slf_sm_date);
            MySqlParameter sp = new MySqlParameter("_ret", MySqlDbType.Byte);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            cmd.ExecuteNonQuery();
            Byte retval = Convert.ToByte(cmd.Parameters["_ret"].Value.ToString());
            con.Close();
            con.Dispose();
            return retval;
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
    public DataSet GetsalesmanDetails()
    {
        try
        {
            mycon();
            cmd = new MySqlCommand("SELECT * FROM salesman_form", con);
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
    public int delete_salesmanform(salesman_formBAL smBAL)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("delete from salesman_form where slf_id = @slf_id", con);
            cmd.Parameters.AddWithValue("@slf_id", smBAL.slf_id);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();

            return 1;
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
    public DataSet get_salesmanform_count()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from  salesman_form", con);
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
}
