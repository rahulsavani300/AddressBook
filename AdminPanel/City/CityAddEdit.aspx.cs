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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CountryFillDropDownList();
            
            
            if (Request.QueryString["CityID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
            else
            {

            }
        }
    }
    #endregion Page Load

    #region ButtonSave
    protected void btnSave_Click(object sender, EventArgs e)
    {

       
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPincode = SqlString.Null;

        String strErrorMessage = "";
        #region Server Side Validation
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "Select City";
        }
        if (txtCityName.Text.Trim() == "")
        {
            strErrorMessage += "Enter City Name";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        if (ddlStateID.SelectedIndex > 0)
        {
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (txtCityName.Text.Trim() != "")
        {
            strCityName = txtCityName.Text.Trim();
        }
        if (txtSTDCode.Text.Trim() != "")
        {
            strSTDCode = txtSTDCode.Text.Trim();
        }
        if (txtPincode.Text.Trim() != "")
        {
            strPincode = txtPincode.Text.Trim();
        }
        #endregion Server Side Validation

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@Pincode", strPincode);
            
            if (Request.QueryString["CityId"] != null)
            {
                #region Update City
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());

                objCmd.CommandText = "PR_City_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
                #endregion Update City

            }
            else
            {
                #region Insert City

                objCmd.CommandText = "PR_City_Insert";
                objCmd.ExecuteNonQuery();
                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPincode.Text = "";

                ddlStateID.SelectedIndex = 0;
                ddlStateID.Focus();
                lblMessage.Text = "Data Inserted Sucessfully";
                #endregion Insert City

            }
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
    #endregion ButtonSave

    private void CountryFillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            #region state select for dropdown
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
            #endregion state select for dropdown
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

    #region FillDropDownList
    private void StateFillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            #region state select for dropdown
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", ddlCountryID.SelectedValue);
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();

            }
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            #endregion state select for dropdown
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

    #region fillControls
    private void FillControls(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection("data source=RS\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            objConn.Open();
            #region city fill controls
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.CommandText = "PR_City_SelectByPK";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    StateFillDropDownList();
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (objSDR["CityName"].Equals(DBNull.Value) != true)
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (objSDR["STDCode"].Equals(DBNull.Value) != true)
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (objSDR["PinCode"].Equals(DBNull.Value) != true)
                    {
                        txtPincode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No data Available for the StateID =" + CityID.ToString();
            }
            #endregion city fill controls

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
    #endregion fillControls

    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        StateFillDropDownList();
    }
    
}
