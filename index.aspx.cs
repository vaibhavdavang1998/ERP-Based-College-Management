using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class index : System.Web.UI.Page
{
    public string rootPath;
    iClass c = new iClass();
    //public string productStr;
    //public string testimonialStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
    }
}