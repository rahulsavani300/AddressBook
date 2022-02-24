using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
            else
            {

            }
        }
    }
    #endregion page load

    #region btnSave
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region varriable
        SqlString strContactCategoryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;

        String strErrorMessage = "";
        #endregion varriable

        #region server side validation
        if (txtContactCategory.Text.Trim() == "")
        {
            strErrorMessage += "Enter Contact Category<br>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion server side validation

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
       
        try
        {
            objConn.Open();
            #region Insert / Update
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            strContactCategoryName = txtContactCategory.Text.Trim();

            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);

            if (Request.QueryString["ContactCategoryId"] != null)
            {
                #region Update
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Request.QueryString["ContactCategoryID"].ToString().Trim());

                objCmd.CommandText = "PR_ContactCategory_UpdateByPK";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
                #endregion Update
            }
            else
            {
                #region Insert
                objCmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";
                objCmd.ExecuteNonQuery();
                objConn.Close();
                lblMessage.Text = "Data Inserted Sucessfully";
                txtContactCategory.Text = "";
                txtContactCategory.Focus();
                #endregion Insert
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
    #endregion btnSave

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        SqlConnection objConn = new SqlConnection("data source=RS\\SQLEXPRESS;initial catalog=AddressBook;Integrated Security=True;");
        try
        {
            objConn.Open();
            #region ContactCategory Select
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByPK";
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["ContactCategoryName"].Equals(DBNull.Value) != true)
                    {
                        txtContactCategory.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }
                    
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data Available for the Contact Category ID =" + ContactCategoryID.ToString();
            }
            #endregion ContactCategory Select
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
