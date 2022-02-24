using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
            else
            {

            }
        }
    }
    #endregion page load

    #region btnsave
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region variables
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;

        String strErrorMessage = "";
        #endregion variables

        #region server side validation
        if (txtCountryName.Text.Trim()=="")
        {
            strErrorMessage += "Enter Country Name<br>";
        }
        if(strErrorMessage!="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion server side validation

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        
        try
        {
            objConn.Open();
            #region Insert-Update

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            strCountryName = txtCountryName.Text.Trim();
            strCountryCode = txtCountryCode.Text.Trim();

            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);

            if (Request.QueryString["CountryID"] != null)
            {
                #region Update
                objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());

                objCmd.CommandText = "PR_Country_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
                #endregion Update
            }
            else
            {
                #region Insert
                objCmd.CommandText = "PR_Country_Insert";
                objCmd.ExecuteNonQuery();
                
                lblMessage.Text = "Data Inserted Sucessfully";
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryName.Focus();
                #endregion Insert
            }

            #endregion Insert-Update
            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }

    }
    #endregion btnsave

    #region FillControls
    private void FillControls(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection("data source=RS\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            objConn.Open();
            #region Country select
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPK";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryName"].Equals(DBNull.Value) != true)
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (objSDR["CountryCode"].Equals(DBNull.Value) != true)
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the CountryID =" + CountryID.ToString();
            }
            #endregion Country select
            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion FillControls
}