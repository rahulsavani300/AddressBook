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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
        
            if (Request.QueryString["StateID"]!=null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            else
            {

            }
        }
    }
    #endregion page load

    #region Save Button
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region  variables
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;

        String strErrorMessage = "";
        #endregion  variables

        #region Validation
        if (ddlCountryID.SelectedIndex==0)
        {
            strErrorMessage += "Select Country";
        }
        if(txtStateName.Text.Trim()=="")
        {
            strErrorMessage += "Enter State Name";
        }
        if(strErrorMessage.Trim()!="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        if(ddlCountryID.SelectedIndex>0)
        {
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if(txtStateName.Text.Trim()!="")
        {
            strStateName = txtStateName.Text.Trim();
        }
        if(txtStateCode.Text.Trim()!="")
        {
            strStateCode = txtStateCode.Text.Trim();
        }
        #endregion Validation

        
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        
        try
        {
            objConn.Open();
            #region Insert/Update
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);

            if (Request.QueryString["StateId"] != null)
            {
                #region Update
                objCmd.Parameters.AddWithValue("@StateID",Request.QueryString["StateID"].ToString().Trim());
                
                objCmd.CommandText = "PR_State_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
                #endregion Update
            }
            else
            {
                #region Insert
                objCmd.CommandText = "PR_State_Insert";
                objCmd.ExecuteNonQuery();
                txtStateName.Text = "";
                txtStateCode.Text = "";
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();
                lblMessage.Text = "Data Inserted Sucessfully";
                #endregion Insert
            }
            objConn.Close();
        }
        #endregion Insert/Update

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
        


    }
    #endregion Save Button

    #region FillDropDownList
    private void FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection("data source=RS\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            objConn.Open();
            #region country dropdown
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();

            }
            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
            #endregion country dropdown
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
    #endregion FillDropDownList

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection("data source=RS\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            objConn.Open();
            #region state select
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByPK";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    if (objSDR["StateName"].Equals(DBNull.Value)!=true)
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    if (objSDR["StateCode"].Equals(DBNull.Value) != true)
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    }
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the StateID ="+StateID.ToString();
            }
            #endregion state select
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