<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

        //System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.ScriptBundle("~/scripts/js").Include("~/js/*.js"));
        //System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.StyleBundle("~/bundle/css").Include("~/css/*.css"));
        //System.Web.Optimization.BundleTable.EnableOptimizations = true;

        RegisterRoutes(System.Web.Routing.RouteTable.Routes);

    }

    void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {

        routes.RouteExistingFiles = false;

        //Main Pages
        //routes.MapPageRoute("default", "", "~/Default.aspx"); //First Route



        routes.MapPageRoute("Default", "Default", "~/Default.aspx");
        routes.MapPageRoute("signUp", "signUp", "~/signUp.aspx");

        routes.MapPageRoute("dash-assign-subject-rt", "sanjeevanAdmin/subject-master/{subjectId}", "~/sanjeevanAdmin/subject-master.aspx", false, new System.Web.Routing.RouteValueDictionary { { "subjectId", string.Empty } });
        routes.MapPageRoute("dash-assign-head-rt", "sanjeevanAdmin/add-student/{studentId}", "~/sanjeevanAdmin/add-student.aspx", false, new System.Web.Routing.RouteValueDictionary { { "studentId", string.Empty } });
        routes.MapPageRoute("dash-master-rt", "sanjeevanAdmin/dashboard", "~/sanjeevanAdmin/dashboard.aspx");
        routes.MapPageRoute("booth-master-rt", "sanjeevanAdmin/events", "~/sanjeevanAdmin/events.aspx");
        routes.MapPageRoute("ward-master-rt", "sanjeevanAdmin/notes", "~/sanjeevanAdmin/notes.aspx");
        routes.MapPageRoute("time-master-rt", "sanjeevanAdmin/time-table", "~/sanjeevanAdmin/time-table.aspx");
        routes.MapPageRoute("member-register-rt", "sanjeevanAdmin/view-notice", "~/sanjeevanAdmin/view-notice.aspx");
        //Master Login Routes
       
        routes.MapPageRoute("404", "{*url}", "~/404.aspx"); //Last Route
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        var serverError = Server.GetLastError() as HttpException;

        if (serverError != null)
        {
            if (serverError.GetHttpCode() == 404)
            {
                Server.ClearError();
                Server.Transfer("404.aspx");
            }
        }

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
