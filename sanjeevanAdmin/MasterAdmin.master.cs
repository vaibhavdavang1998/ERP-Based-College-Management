using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sanjeevanAdmin_MasterAdmin : System.Web.UI.MasterPage
{
    public string rootPath;
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        ScriptManager1.Scripts.Add(new ScriptReference(rootPath + "js/customscripts.js"));

        if (Session["userSession"] == null)
        {
            Response.Redirect(rootPath + "Default", false);
        }
    }
}
