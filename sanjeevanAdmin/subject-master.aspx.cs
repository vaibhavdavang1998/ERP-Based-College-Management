using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sanjeevanAdmin_subject_master : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userSession"] == null)
            {
                Response.Redirect(Master.rootPath + "Default", false);
            }
            else
            {
                btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Saving...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
                btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");

                if (!IsPostBack)
                {
                    //FillGrid();
                    c.FillComboBox("yearName", "yrId", "Year", "", "yrId", 0, ddrYear);

                    if (Page.RouteData.Values["subjectId"] != null && Page.RouteData.Values["subjectId"].ToString() != "")
                    {
                        if (c.IsRecordExist("Select * From SubjectData Where subjectId=" + Page.RouteData.Values["subjectId"]))
                        {
                            lblId.Text = Page.RouteData.Values["subjectId"].ToString();
                            GetBoothDetails(Convert.ToInt32(lblId.Text));
                            pgTitle = "Edit Subject";
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Invalid Record Selected','Error');", true);
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/subject-master', 2000);", true);
                        }
                    }
                    else
                    {
                        lblId.Text = "[New]";
                        btnDelete.Visible = false;
                        pgTitle = "Add Subject";
                    }


                }
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(Page_Load()).','Error');", true);
            return;
        }
    }
    private void FillGrid(int crsId)
    {
        try
        {
            string strQuery = "select a.subjectId, a.subjectName, b.yearName From SubjectData a Inner Join Year b On a.yrId=b.yrId Where a.yrId=" + crsId;
            //string strQuery = "select a.subjectId, a.subjectName, b.yearName From SubjectData a Inner Join Year b On a.yrId=b.yearId Where a.yearId=" + crsId;
            using (DataTable dtBooth = c.GetDataTable(strQuery))
            {
                gvBooth.DataSource = dtBooth;
                gvBooth.DataBind();
            }
            //using (DataTable dtBooth = c.GetDataTable("select a.boothId, a.boothName, b.wardName From BoothData a Inner Join WardData b On a.wardId=b.wardId"))
            //{
            //    gvBooth.DataSource = dtBooth;
            //    gvBooth.DataBind();
            //}
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(FillGrid()).','Error');", true);
            return;
        }
    }

    protected void ddrYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddrYear.SelectedIndex > 0)
            {
                FillGrid(Convert.ToInt32(ddrYear.SelectedValue));
                pgTitle = lblId.Text == "[New]" ? "Add Subject" : "Edit Subject";
            }
            else
            {
                //FillGrid();
                pgTitle = lblId.Text == "[New]" ? "Add Subject" : "Edit Subject";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Select Year ','Error');", true);
                return;
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(ddrYear_SelectedIndexChanged()).','Error');", true);
            return;
        }
    }


    protected void gvBooth_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"" + Master.rootPath + "sanjeevanAdmin/subject-master/" + e.Row.Cells[0].Text + "\" class=\"gAnch\"></a>";
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(gvBooth_RowDataBound()).','Error');", true);
            return;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            txtName.Text = txtName.Text.Trim().Replace("'", "");
            if (ddrYear.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Select Year','Warning');", true);
                return;
            }

            if (txtName.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Enter Subject Name.','Warning');", true);
                return;
            }

            if (lblId.Text == "[New]")
            {
                if (c.IsRecordExist("Select * From SubjectData Where subjectName='" + txtName.Text + "' And yrId=" + ddrYear.SelectedValue))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Subject Name already exists under selected Year.','Warning');", true);
                    return;
                }
            }

            int maxId = lblId.Text == "[New]" ? c.NextId("SubjectData", "subjectId") : Convert.ToInt32(lblId.Text);

            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert Into SubjectData (subjectId, subjectName, yrId) Values (" + maxId + ", '" + txtName.Text + "', " + ddrYear.SelectedValue + ")");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Subject Added','Success');", true);
            }
            else
            {
                c.ExecuteQuery("Update SubjectData Set subjectName='" + txtName.Text + "', yrId=" + ddrYear.SelectedValue + " Where subjectId=" + maxId);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Subject Updated','Success');", true);
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/subject-master', 2000);", true);


        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(btnSave_Click()).','Error');", true);
            return;
        }
    }

    private void GetBoothDetails(int clsIdX)
    {
        try
        {
            using (DataTable dtClass = c.GetDataTable("Select * From SubjectData Where subjectId=" + clsIdX))
            {
                if (dtClass.Rows.Count > 0)
                {
                    DataRow row = dtClass.Rows[0];
                    ddrYear.SelectedValue = row["yrId"].ToString();
                    txtName.Text = row["subjectName"].ToString();


                    btnDelete.Visible = true;
                    btnSave.Text = "Modify Info";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Invalid Record Selected','Error');", true);
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/subject-master', 2000);", true);
                }
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(GetBoothDetails()).','Error');", true);
            return;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Delete From SubjectData Where subjectId=" + lblId.Text);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Subject Deleted','Success');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/subject-master', 2000);", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(btnDelete_Click()).','Error');", true);
            return;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(Master.rootPath + "sanjeevanAdmin/subject-master", false);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(btnReset_Click()).','Error');", true);
            return;
        }
    }
}