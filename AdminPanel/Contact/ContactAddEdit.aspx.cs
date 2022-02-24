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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{//5452
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CountryFillDropDownList();
            StateFillDropDownList();
            CityFillDropDownList();
            ContactCategoryFillDropDownList();
            if (Request.QueryString["ContactID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
            else
            {

            }
        }
    }
    #endregion page load

    #region buttonSave
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region variables
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsappNo = SqlString.Null;
        SqlDateTime strBirthdate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebook = SqlString.Null;
        SqlString strLinkedIN = SqlString.Null;
       
        String strErrorMessage = "";
        String ContactPhotoPath ="";
        #endregion variables

        #region server side validation
        // server side validation
        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "select Country";
        }
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "select state";
        }
        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMessage += "select City";
        }
        if (ddlContactCategoryID.SelectedIndex == 0)
        {
            strErrorMessage += "select Contact Category";
        }
        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "enter city ContactName ";
        }
        if (txtContactNo.Text.Trim() == "")
        {
            strErrorMessage += "enter city Contact no ";
        }
        if (txtWhatsapp.Text.Trim() == "")
        {
            strErrorMessage += "enter city Whatsapp ";
        }
        if (txtBirthdate.Text.Trim() == "")
        {
            strErrorMessage += "enter city Birthdate ";
        }
        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "enter city Email ";
        }
        if (txtAge.Text.Trim() == "")
        {
            strErrorMessage += "enter city Age";
        }
        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "enter city Address ";
        }
        if (txtBloodGroup.Text.Trim() == "")
        {
            strErrorMessage += "enter city BloodGroup ";
        }
        if (txtFacebook.Text.Trim() == "")
        {
            strErrorMessage += "enter city Facebook";
        }
        if (txtLinkedIN.Text.Trim() == "")
        {
            strErrorMessage += "enter city LinkedIN";
        }



        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        if (ddlCountryID.SelectedIndex > 0)
        {
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (ddlStateID.SelectedIndex > 0)
        {
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (ddlCityID.SelectedIndex > 0)
        {
            strCityID = Convert.ToInt32(ddlCityID.SelectedValue);
        }
        if (ddlContactCategoryID.SelectedIndex > 0)
        {
            strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
        }

        if (txtContactName.Text.Trim() != "")
        {
            strContactName = txtContactName.Text.Trim();
        }
        if (txtContactNo.Text.Trim() != "")
        {
            strContactNo = txtContactNo.Text.Trim();
        }
        if (txtWhatsapp.Text.Trim() != "")
        {
            strWhatsappNo = txtWhatsapp.Text.Trim();
        }
        if (txtBirthdate.Text.Trim() != "")
        {
            strBirthdate = Convert.ToDateTime(txtBirthdate.Text);
        }
        if (txtEmail.Text.Trim() != "")
        {
            strEmail = txtEmail.Text.Trim();
        }
        if (txtAge.Text.Trim() != "")
        {
            strAge = txtAge.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            strAddress = txtAddress.Text.Trim();
        }
        if (txtBloodGroup.Text.Trim() != "")
        {
            strBloodGroup = txtBloodGroup.Text.Trim();
        }
        if (txtFacebook.Text.Trim() != "")
        {
            strFacebook = txtFacebook.Text.Trim();
        }
        if (txtLinkedIN.Text.Trim() != "")
        {
            strLinkedIN = txtLinkedIN.Text.Trim();
        }
        #endregion server side validation

        if (fuContactPhotoPath.HasFile)
        {
            ContactPhotoPath = "~/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();
            fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));
        }
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            #region Insert / Update 
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
            objCmd.Parameters.AddWithValue("@WhatsAppNo", strWhatsappNo);
            objCmd.Parameters.AddWithValue("@Birthdate", strBirthdate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FacebookID", strFacebook);
            objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedIN);

            if (Request.QueryString["ContactId"] != null)
            {
                #region update
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());

                objCmd.CommandText = "PR_Contact_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
                #endregion update
            }
            else
            {
                #region insert
                objCmd.CommandText = "PR_Contact_Insert";
                objCmd.ExecuteNonQuery();
                ddlStateID.SelectedIndex = 0;
                ddlStateID.Focus();
                lblMessage.Text = "Data Inserted Sucessfully";
                #endregion insert
            }
            #endregion Insert / Update 
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
    #endregion buttonSave

    #region CountryFillDropDown
    private void CountryFillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            #region Country Dropdown
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlStateID.Items.Clear();

                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }
            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
            #endregion Country Dropdown
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
    #endregion CountryFillDropDown

    #region StateFillDropDown
    private void StateFillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            #region state Dropdown
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            objCmd.Parameters.AddWithValue("@CountryID", ddlCountryID.SelectedValue);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();

            }
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            #endregion state Dropdown
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
    #endregion StateFillDropDown

    #region CityFillDropDown
    private void CityFillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            #region city Dropdown
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectForDropDownList";
            objCmd.Parameters.AddWithValue("@StateID", ddlStateID.SelectedValue);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";

                ddlCityID.DataBind();
            }
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            #endregion city Dropdown
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
    #endregion CityFillDropDown

    #region ContactCategoryFillDropDownList
    private void ContactCategoryFillDropDownList()
    {
        SqlConnection objConn = new SqlConnection("data source=RS\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            objConn.Open();
            #region ContactCategory Dropdown
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlContactCategoryID.DataSource = objSDR;
                ddlContactCategoryID.DataValueField = "ContactCategoryID";
                ddlContactCategoryID.DataTextField = "ContactCategoryName";

                ddlContactCategoryID.DataBind();
            }
            ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
            #endregion ContactCategory Dropdown
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
    #endregion ContactCategoryFillDropDownList

    #region FillControls
    private void FillControls(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection("data source=RS\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            objConn.Open();
            #region contact select
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByPK";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
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
                    CityFillDropDownList();
                    if (objSDR["CityID"].Equals(DBNull.Value) != true)
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (objSDR["ContactCategoryID"].Equals(DBNull.Value) != true)
                    {
                        ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    if (objSDR["ContactName"].Equals(DBNull.Value) != true)
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (objSDR["ContactNo"].Equals(DBNull.Value) != true)
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if(objSDR["WhatsAppNo"].Equals(DBNull.Value)!=true)
                    {
                        txtWhatsapp.Text = objSDR["WhatsAppNo"].ToString().Trim();
                    }
                    if(objSDR["Birthdate"].Equals(DBNull.Value)!=true)
                    {
                        txtBirthdate.Text = objSDR["Birthdate"].ToString().Trim();
                    }
                    if (objSDR["Email"].Equals(DBNull.Value) != true)
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (objSDR["Age"].Equals(DBNull.Value) != true)
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (objSDR["Address"].Equals(DBNull.Value) != true)
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (objSDR["Bloodgroup"].Equals(DBNull.Value) != true)
                    {
                        txtBloodGroup.Text = objSDR["Bloodgroup"].ToString().Trim();
                    }
                    if (objSDR["FacebookID"].Equals(DBNull.Value) != true)
                    {
                        txtFacebook.Text = objSDR["FacebookID"].ToString().Trim();
                    }
                    if (objSDR["LinkedINID"].Equals(DBNull.Value) != true)
                    {
                        txtLinkedIN.Text = objSDR["LinkedINID"].ToString().Trim();
                    }

                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the Contact ID =" + ContactID.ToString();
            }
            #endregion contact select
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

    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        StateFillDropDownList();
       // ddlCityID.Items.Clear();
    }

    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        CityFillDropDownList();
        
    }

    protected void ddlCityID_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}
