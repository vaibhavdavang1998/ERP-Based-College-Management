using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sanjeevanAdmin_events : System.Web.UI.Page
{
    iClass c = new iClass();
    string rootPath = "";
    public string photoMarkup;
    protected void Page_Load(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (Request.QueryString["action"] == "delete")
                    {
                        c.ExecuteQuery("Delete From Events Where evId=" + Request.QueryString["id"]);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Event Deleted','Success');", true);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/events', 2000);", true);

                    }
                }
            }
            //if (Request.QueryString["id"] != null)
            //{

            //}
            //rdbWorkshop.Checked = true;
            GetWorkshopPhotos();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            txtTitle.Text = txtTitle.Text.Trim().Replace("'", "`");

            if (txtTitle.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Enter Event Tittle','Warning');", true);
                return;
            }

            if (fuImg.HasFile)
            {
                string fExt = Path.GetExtension(fuImg.FileName).ToString().ToLower();

                if (new[] { ".jpg", ".jpeg", ".png" }.Contains(fExt))
                {
                    int maxId = c.NextId("Events", "evId");
                    string photoName = "event-photo-" + maxId.ToString() + fExt;

                    //int galFlag = rdbGallery.Checked ? 2 : 1;
                    c.ExecuteQuery("Insert Into Events (evId, evImage, evTittle, galleryFlag) Values (" + maxId + ", '" + photoName + "', '" + txtTitle.Text + "', 1)");

                    ImageUploadProcess(photoName);
                    txtTitle.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Event Uploaded Successfully','Success');", true);
                    GetWorkshopPhotos();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Only .jpg, .jpeg and .png files are allowed for photos.','Warning');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Select Event Photo to Upload','Warning');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Error occurred while processing. [btnSubmit_Click()]','Error');", true);
            return;
        }
    }
    private void ImageUploadProcess(string imgName)
    {
        string rawImgPath = "~/upload/event/raw/";
        string origImgPath = "~/upload/event/original/";
        string thumbImgPath = "~/upload/event/thumb/";
        string normalImgPath = "~/upload/event/";

        fuImg.SaveAs(Server.MapPath(origImgPath) + imgName);
        c.ImageOptimizer(imgName, origImgPath, normalImgPath, 800, false);

        c.ImageOptimizer(imgName, origImgPath, rawImgPath, 500, false);

        c.CenterCropImage(imgName, rawImgPath, thumbImgPath, 400, 300);

        File.Delete(Server.MapPath(origImgPath) + imgName);
        File.Delete(Server.MapPath(rawImgPath) + imgName);
    }

    private void GetWorkshopPhotos()
    {
        try
        {
            using (DataTable dtPhotos = c.GetDataTable("Select * From Events"))
            {

                if (dtPhotos.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    foreach (DataRow row in dtPhotos.Rows)
                    {
                        strMarkup.Append("<div class=\"imgBox\">");
                        strMarkup.Append("<div class=\"pad-5\">");
                        strMarkup.Append("<div class=\"border1\">");
                        strMarkup.Append("<div class=\"pad-5\">");
                        strMarkup.Append("<div class=\"imgContainer\">");
                        strMarkup.Append("<img src=\"" + rootPath + "upload/event/thumb/" + row["evImage"] + "\" class=\"w100\" />");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        //strMarkup.Append("<a href=\"workshop-master.aspx?id=" + row["wpId"] + "\" title=\"Delete Photo\"  class=\"closeAnch\" onClick=\"return confirm('Are you sure you want to Delete?');\" ></a>");
                        strMarkup.Append("<a href=\"events.aspx?action=delete&id=" + row["evId"] + "\" title=\"Delete Photo\"  class=\"closeAnch\" onClick=\"return confirm('Are you sure you want to Delete?');\" ></a>");
                        strMarkup.Append("</div>");
                    }
                    photoMarkup = strMarkup.ToString();
                }
                else
                {
                    photoMarkup = "No Event added ";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}