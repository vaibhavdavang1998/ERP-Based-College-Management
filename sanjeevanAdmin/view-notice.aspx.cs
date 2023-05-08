using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sanjeevanAdmin_view_notice : System.Web.UI.Page
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
                        c.ExecuteQuery("Delete From NoticePhotos Where npId=" + Request.QueryString["id"]);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Notice Deleted','Success');", true);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/view-notice', 2000);", true);

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
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Enter Notice Tittle','Warning');", true);
                return;
            }

            if (fuImg.HasFile)
            {
                string fExt = Path.GetExtension(fuImg.FileName).ToString().ToLower();

                if (new[] { ".jpg", ".jpeg", ".png" }.Contains(fExt))
                {
                    int maxId = c.NextId("NoticePhotos", "npId");
                    string photoName = "notice-photo-" + maxId.ToString() + fExt;

                    //int galFlag = rdbGallery.Checked ? 2 : 1;
                    c.ExecuteQuery("Insert Into NoticePhotos (npId, npImage, npImageTitle, galleryFlag) Values (" + maxId + ", '" + photoName + "', '" + txtTitle.Text + "', 1)");

                    ImageUploadProcess(photoName);
                    txtTitle.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Notice Uploaded Successfully','Success');", true);
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
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Select Notice Photo to Upload','Warning');", true);
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
        string rawImgPath = "~/upload/notice/raw/";
        string origImgPath = "~/upload/notice/original/";
        string thumbImgPath = "~/upload/notice/thumb/";
        string normalImgPath = "~/upload/notice/";

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
            using (DataTable dtPhotos = c.GetDataTable("Select * From NoticePhotos"))
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
                        strMarkup.Append("<img src=\"" + rootPath + "upload/notice/thumb/" + row["npImage"] + "\" class=\"w100\" />");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        //strMarkup.Append("<a href=\"workshop-master.aspx?id=" + row["wpId"] + "\" title=\"Delete Photo\"  class=\"closeAnch\" onClick=\"return confirm('Are you sure you want to Delete?');\" ></a>");
                        strMarkup.Append("<a href=\"view-notice.aspx?action=delete&id=" + row["npId"] + "\" title=\"Delete Photo\"  class=\"closeAnch\" onClick=\"return confirm('Are you sure you want to Delete?');\" ></a>");
                        strMarkup.Append("</div>");
                    }
                    photoMarkup = strMarkup.ToString();
                }
                else
                {
                    photoMarkup = "No notice added ";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}