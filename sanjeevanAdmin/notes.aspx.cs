﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sanjeevanAdmin_notes : System.Web.UI.Page
{
    iClass c = new iClass();
    public string photoMarkup;
    string rootPath = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        if (!IsPostBack)
        {
            c.FillComboBox("subjectName", "subjectId", "SubjectData", "", "subjectId", 1, ddrProduct);
            if (Request.QueryString["action"] != null)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (Request.QueryString["action"] == "delete")
                    {
                        c.ExecuteQuery("Delete From NotesPhotos Where photoId=" + Request.QueryString["id"]);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('notes Deleted','Success');", true);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/notes', 2000);", true);

                    }
                    else if (Request.QueryString["action"] == "cover")
                    {
                        int prId = Convert.ToInt32(c.GetReqData("NotesPhotos", "productId", "photoId=" + Request.QueryString["id"]));
                        c.ExecuteQuery("Update NotesPhotos Set isCover=0 Where productId=" + prId);
                        c.ExecuteQuery("Update NotesPhotos Set isCover=1 Where productId=" + prId + " And photoId=" + Request.QueryString["id"]);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Notes Updated','Success');", true);
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/notes', 2000);", true);

                }
                else
                    Response.Redirect("notes.aspx", false);
            }
            //else
            //    Response.Redirect("product-photos.aspx", false);
        }
    }
    protected void ddrProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddrProduct.SelectedIndex > 0)
            {
                GetProductPhotos();
            }
            else
                photoMarkup = "";
        }
        catch (Exception)
        {

        }
    }

    private void GetProductPhotos()
    {
        try
        {
            using (DataTable dtPhotos = c.GetDataTable("Select * From NotesPhotos Where productId=" + ddrProduct.SelectedValue))
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
                        strMarkup.Append("<img src=\"" + rootPath + "upload/notes/thumb/" + row["photoName"] + "\" class=\"w100\" />");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("<a href=\"notes.aspx?action=delete&id=" + row["photoId"] + "\" title=\"Delete Photo\"  class=\"closeAnch\" onClick=\"return confirm('Are you sure you want to Delete?');\" ></a>");

                        if (row["isCover"].ToString() == "1")
                            strMarkup.Append("<span title=\"Product Thumb\"  class=\"converAnch\" ></span>");
                        //else
                        //    strMarkup.Append("<a href=\"time-table.aspx?action=cover&id=" + row["photoId"] + "\" title=\"Set As time table Thumb\"  class=\"converAnch-gray\" ></a>");
                        strMarkup.Append("</div>");
                    }
                    photoMarkup = strMarkup.ToString();
                }
                else
                {
                    photoMarkup = "No photos added for this year";
                }
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(btnSave_Click()).','Error');", true);
            return;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddrProduct.SelectedIndex <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Select Subject','Error');", true);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/notes', 2000);", true);
            }

            if (fuImg.HasFile)
            {
                string fExt = Path.GetExtension(fuImg.FileName).ToString().ToLower();
                if (new[] { ".jpg", ".jpeg", ".png" }.Contains(fExt))
                {
                    int maxId = c.NextId("NotesPhotos", "photoId");
                    string imgName = "product-" + ddrProduct.SelectedValue + "-photo-" + maxId.ToString() + fExt;
                    c.ExecuteQuery("Insert Into NotesPhotos (photoId, photoName, productId, isCover) Values (" + maxId + ", '" + imgName + "', " + ddrProduct.SelectedValue + ", 0)");
                    ImageUploadProcess(imgName);
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Notes Uploaded Successfully','Success');", true);
                    GetProductPhotos();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Only .jpg, .jpeg and .png files are allowed for photos.','Warning');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Select Notes Photo to Upload','Warning');", true);
                return;
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Error occurred while processing. [btnSubmit_Click()]','Error');", true);
            return;
        }
    }

    private void ImageUploadProcess(string imgName)
    {
        string rawImgPath = "~/upload/notes/raw/";
        string origImgPath = "~/upload/notes/original/";
        string thumbImgPath = "~/upload/notes/thumb/";
        string normalImgPath = "~/upload/notes/";

        fuImg.SaveAs(Server.MapPath(origImgPath) + imgName);
        c.ImageOptimizer(imgName, origImgPath, normalImgPath, 800, false);

        c.ImageOptimizer(imgName, origImgPath, rawImgPath, 500, false);

        c.CenterCropImage(imgName, rawImgPath, thumbImgPath, 400, 300);

        File.Delete(Server.MapPath(origImgPath) + imgName);
        File.Delete(Server.MapPath(rawImgPath) + imgName);
    }
}