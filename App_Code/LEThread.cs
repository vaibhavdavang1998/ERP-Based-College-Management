using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for LEThread
/// </summary>
public class LEThread
{
	public LEThread()
	{
		//
		// TODO: Add constructor logic here
		//


	}
    public void EmailThreadProcedure(string emailStr, int templateId)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(PromotionalEmail), emailStr + "#" + templateId);
    }

    public static void PromotionalEmail(object objMails)
    {
        iClass c = new iClass();

        string[] parametersSplit = objMails.ToString().Split('#');

        string subject = c.GetReqData("EmailTemplate", "etSubject", "etId=" + parametersSplit[1] ).ToString();
        string subjectOpt = c.GetReqData("EmailTemplate", "etSubjectOpt", "etId=" + parametersSplit[1]).ToString();
        string emailData = c.GetReqData("EmailTemplate", "etDetails", "etId=" + parametersSplit[1]).ToString();


        if (parametersSplit[0].Contains(','))
        {
            string[] emailArray = parametersSplit[0].Split(',');

            foreach (string mail in emailArray)
            {
                c.EmailHttpMarkup("no-reply@lucidedge.in", "Lucid Edge Tech Serv", mail, subject, subjectOpt, emailData, "", "", "");

                Thread.Sleep(180000);
            }
        }
        else
        {
            c.EmailHttpMarkup("no-reply@lucidedge.in", "Lucid Edge Tech Serv", parametersSplit[0], subject, subjectOpt, emailData, "", "", "");
        }
    }
}