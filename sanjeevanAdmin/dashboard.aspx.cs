using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class sanjeevanAdmin_dashboard : System.Web.UI.Page
{
    iClass c = new iClass();
    public string[] arrCounts = new string[4];
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCounts();
    }
    private void GetCounts()
    {
        try
        {

            arrCounts[0] = c.ReturnAggregate("Select Count(studentId) From StudentsData").ToString();
            arrCounts[1] = c.ReturnAggregate("Select Count(subjectId) From SubjectData").ToString();
            arrCounts[2] = c.ReturnAggregate("Select Count(photoId) From TimeTable").ToString();
            arrCounts[3] = c.ReturnAggregate("Select count(evId) From Events").ToString();
            
        }
        catch (Exception ex)
        {

        }
    }
}