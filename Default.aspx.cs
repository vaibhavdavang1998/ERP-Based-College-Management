using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string errMsg, rootPath;
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        cmdSign.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(cmdSign, null) + ";");
        rootPath = c.ReturnHttp();
        if (Request.QueryString["act"] == "out")
        {
            Session["userSession"] = null;
        }
        //txtUserName.Focus();
        if (!IsPostBack)
        {
            if (Session["userSession"] != null)
            {
                //Response.Redirect("");
                Response.Redirect(rootPath + "sanjeevanAdmin/dashboard.aspx");
            }
        }
    }

    protected void cmdSign_Click(object sender, EventArgs e)
    {
        txtPwd.Text = txtPwd.Text.Trim().Replace("'", "`");
        txtUserName.Text = txtUserName.Text.Trim().Replace("'", "`");
        if (txtUserName.Text == "" || txtPwd.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Enter Email Id & Password.','Warning');", true);
            return;
        }
        if (!c.IsRecordExist("Select userId From UserData Where userName='" + txtUserName.Text + "'"))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Enter valid Email Id.','Warning');", true);
            return;
        }
        else if (c.GetReqData("UserData", "userPass", "userName='" + txtUserName.Text.Trim() + "'").ToString() != txtPwd.Text)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Wrong Password Entered','Warning');", true);
            return;
        }
        else
        {
            Session["userSession"] = txtUserName.Text;
            Response.Redirect(rootPath + "sanjeevanAdmin/dashboard.aspx");
        }


    }
    protected void cmdSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect(rootPath + "signUp.aspx");
    }

}