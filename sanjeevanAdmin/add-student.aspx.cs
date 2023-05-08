using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class sanjeevanAdmin_add_student : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScriptsd", "callCalendar();", true);

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
                    FillGrid();
                    c.FillComboBox("yearName", "yrId", "Year", "", "yrId", 0, ddrYear);
                    c.FillComboBox("tradeName", "tradeId", "trade", "", "tradeId", 0, ddrTrade);

                    if (Page.RouteData.Values["studentId"] != null && Page.RouteData.Values["studentId"].ToString() != "")
                    {
                        if (c.IsRecordExist("Select * From StudentsData Where studentId=" + Page.RouteData.Values["studentId"]))
                        {
                            lblId.Text = Page.RouteData.Values["studentId"].ToString();
                            GetStudentsDetails(Convert.ToInt32(lblId.Text));
                            pgTitle = "Edit Student";
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Invalid Record Selected','Error');", true);
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "boothAdmin/member-register', 2000);", true);
                        }
                    }
                    else
                    {
                        lblId.Text = "[New]";
                        btnDelete.Visible = false;
                        pgTitle = "Add Student";
                        txtRegDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                        //txtDOB.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
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
    private void FillGrid()
    {
        try
        {

            using (DataTable dtBooth = c.GetDataTable("select a.studentId, a.studentName, a.mobileNo, a.mGender, Convert(varchar(20), a.birthDate, 103) as birthDate, b.yearName, c.tradeName From StudentsData a Inner Join Year b On a.yrId=b.yrId Inner Join trade c on a.tradeId=c.tradeId"))
            {
                gvMemberReg.DataSource = dtBooth;
                gvMemberReg.DataBind();
            }
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
                c.FillComboBox("tradeName", "tradeId", "trade", "yrId=" + ddrYear.SelectedValue, "tradeName", 0, ddrTrade);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(ddrWard_SelectedIndexChanged()).','Error');", true);
            return;
        }
    }
    protected void gvMemberReg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"" + Master.rootPath + "sanjeevanAdmin/add-student/" + e.Row.Cells[0].Text + "\" class=\"gAnch\"></a>";

                Literal litGender = (Literal)e.Row.FindControl("litGender");
                if (e.Row.Cells[1].Text == "1")
                {
                    litGender.Text = "<img src=\"" + Master.rootPath + "sanjeevanAdmin/images/icons/male_icon.png\"/>";
                }
                else
                {
                    litGender.Text = "<img src=\"" + Master.rootPath + "sanjeevanAdmin/images/icons/female_icon.png\"/>";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(gvMemberReg_RowDataBound()).','Error');", true);
            return;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            txtName.Text = txtName.Text.Trim().Replace("'", "");
            txtRegDate.Text = txtRegDate.Text.Trim().Replace("'", "");
            txtAddr.Text = txtAddr.Text.Trim().Replace("'", "");
            txtMobile.Text = txtMobile.Text.Trim().Replace("'", "");
            txtWaNo.Text = txtWaNo.Text.Trim().Replace("'", "");
            txtParentName.Text = txtParentName.Text.Trim().Replace("'", "");
            txtOccupation.Text = txtOccupation.Text.Trim().Replace("'", "");
            txtCast.Text = txtCast.Text.Trim().Replace("'", "");


            if (ddrYear.SelectedIndex == 0 || ddrTrade.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Select Year & Trade Name','Warning');", true);
                return;
            }
            if (ddrBlood.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Select Blood Group','Warning');", true);
                return;
            }

            if (txtName.Text == "" || txtRegDate.Text == "" || txtAddr.Text == "" || txtMobile.Text == "" || txtWaNo.Text == "" || txtParentName.Text == "" || txtOccupation.Text == "" || txtCast.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('All * Field are Mandatory','Warning');", true);
                return;
            }


            string[] arrDate = txtRegDate.Text.Split('/');
            if (c.IsDate(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Enter valid date','Warning');", true);
                return;
            }
            DateTime regDate = Convert.ToDateTime(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]);
            string[] arrDOB = txtDOB.Text.Split('/');
            if (c.IsDate(arrDOB[1] + "/" + arrDOB[0] + "/" + arrDOB[2]) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Enter valid date','Warning');", true);
                return;
            }
            DateTime BirthDate = Convert.ToDateTime(arrDOB[1] + "/" + arrDOB[0] + "/" + arrDOB[2]);

            if (lblId.Text == "[New]")
            {
                if (c.IsRecordExist("Select studentId From StudentsData Where studentName='" + txtName.Text + "' And yrId=" + ddrYear.SelectedValue + " And tradeId=" + ddrTrade.SelectedValue))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.warning('Student already exists under selected Year And Trade','Warning');", true);
                    return;
                }
            }

            string studentName = txtName.Text;
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            //Console.WriteLine("\"{0}\" to titlecase: {1}", memberName, myTI.ToTitleCase(memberName));

            int maxId = lblId.Text == "[New]" ? c.NextId("StudentsData", "studentId") : Convert.ToInt32(lblId.Text);
            int gender = rdoMale.Checked == true ? 1 : 2;
            int president = Chkpresident.Checked == true ? 1 : 0;
            int classReprentive = ChkclassReprentive.Checked == true ? 1 : 0;
            int eventOrganizer = ChkeventOrganizer.Checked == true ? 1 : 0;
            int treasurer = Chktreasurer.Checked == true ? 1 : 0;
            int volunteer = Chkvolunteer.Checked == true ? 1 : 0;
            int otherSocial = ChkotherSocial.Checked == true ? 1 : 0;

            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert Into StudentsData (studentId, regDate, studentName, mGender, addressData, mobileNo, whatsappNo, parentsName, " +
                    " mOccupation, mCaste, bloodGroup, birthDate, mAge, emailId, state, nationality, president, classReprentive, eventOrganizer, " +
                    " treasurer, volunteer, otherSocial, yrId, tradeId, isHead) Values (" + maxId + ", '" + regDate + "', '" + myTI.ToTitleCase(studentName) + "', " + gender +
                    ", '" + txtAddr.Text + "','" + txtMobile.Text + "','" + txtWaNo.Text + "', '" + txtParentName.Text + "', '" + txtOccupation.Text +
                    "', '" + txtCast.Text + "'," + ddrBlood.SelectedIndex.ToString() + ", '" + BirthDate + "'," + txtAge.Text + ", '" + txtEmailId.Text +
                    "', '" + txtState.Text + "','" + txtNationality.Text + "'," + president + "," + classReprentive + "," + eventOrganizer + "," + treasurer +
                    "," + volunteer + "," + otherSocial + "," + ddrYear.SelectedValue + "," + ddrTrade.SelectedValue + ", 0)");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Student Added','Success');", true);
            }
            else
            {
                c.ExecuteQuery("Update StudentsData Set studentName='" + txtName.Text + "', regDate='" + regDate + "', mGender=" + gender +
                    ", addressData='" + txtAddr.Text + "', mobileNo='" + txtMobile.Text + "', whatsappNo='" + txtWaNo.Text +
                    "', parentsName='" + txtParentName.Text + "', mOccupation='" + txtOccupation.Text + "', mCaste='" + txtCast.Text +
                    "', bloodGroup=" + ddrBlood.SelectedIndex.ToString() + ", birthDate='" + BirthDate + "', mAge='" + txtAge.Text +
                    "', emailId='" + txtEmailId.Text + "', state='" + txtState.Text + "', nationality='" + txtNationality.Text +
                    "', president=" + president + ", classReprentive=" + classReprentive + ", eventOrganizer=" + eventOrganizer +
                    ", treasurer=" + treasurer + ", volunteer=" + volunteer + ", otherSocial=" + otherSocial +
                    ",  yrId=" + ddrYear.SelectedValue + ", tradeId=" + ddrTrade.SelectedValue + " Where studentId=" + maxId);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Student Updated','Success');", true);
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/add-student', 2000);", true);


        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(btnSave_Click()).','Error');", true);
            return;
        }
    }

    private void GetStudentsDetails(int clsIdX)
    {
        try
        {
            using (DataTable dtClass = c.GetDataTable("Select * From StudentsData Where studentId=" + clsIdX))
            {
                if (dtClass.Rows.Count > 0)
                {
                    DataRow row = dtClass.Rows[0];
                    ddrYear.SelectedValue = row["yrId"].ToString();
                    ddrTrade.SelectedValue = row["tradeId"].ToString();
                    ddrBlood.SelectedValue = row["bloodGroup"].ToString();
                    DateTime regDate = Convert.ToDateTime(row["regDate"]);
                    txtRegDate.Text = regDate.Day + "/" + regDate.Month + "/" + regDate.Year;
                    DateTime dobDate = Convert.ToDateTime(row["birthDate"]);
                    txtDOB.Text = dobDate.Day + "/" + dobDate.Month + "/" + dobDate.Year;

                    txtName.Text = row["studentName"].ToString();
                    txtAddr.Text = row["addressData"].ToString();
                    txtMobile.Text = row["mobileNo"].ToString();
                    txtWaNo.Text = row["whatsappNo"].ToString();
                    txtParentName.Text = row["parentsName"].ToString();
                    txtOccupation.Text = row["mOccupation"].ToString();
                    txtCast.Text = row["mCaste"].ToString();
                    txtAge.Text = row["mAge"].ToString();
                    txtEmailId.Text = row["emailId"].ToString();
                    txtState.Text = row["state"].ToString();
                    txtNationality.Text = row["nationality"].ToString();
                    if (row["mGender"].ToString() == "1")
                    {
                        rdoMale.Checked = true;
                    }
                    else
                    {
                        rdoFemale.Checked = true;
                    }
                    if (row["president"].ToString() == "1")
                    {
                        Chkpresident.Checked = true;
                    }
                    if (row["classReprentive"].ToString() == "1")
                    {
                        ChkclassReprentive.Checked = true;
                    }
                    if (row["eventOrganizer"].ToString() == "1")
                    {
                        ChkeventOrganizer.Checked = true;
                    }
                    if (row["treasurer"].ToString() == "1")
                    {
                        Chktreasurer.Checked = true;
                    }
                    if (row["volunteer"].ToString() == "1")
                    {
                        Chkvolunteer.Checked = true;
                    }
                    if (row["otherSocial"].ToString() == "1")
                    {
                        ChkotherSocial.Checked = true;
                    }
                    btnDelete.Visible = true;
                    btnSave.Text = "Modify Info";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Invalid Record Selected','Error');", true);
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/add-student', 2000);", true);
                }
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(GetStudentsDetails()).','Error');", true);
            return;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Delete From StudentsData Where studentId=" + lblId.Text);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.success('Student Deleted','Success');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('" + Master.rootPath + "sanjeevanAdmin/add-student', 2000);", true);
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
            Response.Redirect(Master.rootPath + "sanjeevanAdmin/add-student", false);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "toastr.error('Error Occurred While Processing(btnReset_Click()).','Error');", true);
            return;
        }
    }
    protected void UpdatePanel1_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "callCalendar();", true);
    }
    
}