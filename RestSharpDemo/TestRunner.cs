using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    class TestRunner
    {
        public static string CreateHTMLReport(string strReportName, Dictionary<string, string> testResults, string testRunId)
        {
            StringBuilder objSB = new StringBuilder();
            objSB.AppendLine("<TABLE align=center border=0 cellSpacing=1 cellPadding=0 width='100%'>");
            objSB.AppendLine("<TR><TD align='center'>");
            objSB.AppendLine("<img src='http://simplot.com/cssimages/logo.jpg' alt='Simplot'  width = '125' height='125'> </TD>");
            objSB.AppendLine("</TR></TABLE>");

            objSB.AppendLine("<TABLE align=center border=0 cellSpacing=1 cellPadding=1 width='80%' font='arial'style=margin-top:20px>");
            objSB.AppendLine("<br><tr><td colspan='2' align='center'><FONT COLOR='#153E7E' FACE='Arial' SIZE=4><b>" + strReportName + "</b></td></tr></TABLE>");

            if (testResults.Count == 2)
            {
                if (testResults.Where(x => x.Key.Contains("Create PR for Auto Goods Receipt against a Purchase Order")).Count() > 1)
                {
                    objSB.AppendLine("<TABLE align=center border=0 cellSpacing=1 cellPadding=1 width='80%' font='arial'style=margin-top:20px>");
                    objSB.AppendLine("<br><tr><td colspan='2' align='center'><FONT COLOR='#153E7E' FACE='Arial' SIZE=3><b>" + "Below two test cases are prerequisite for auto goods receipt" + "</td></tr></TABLE>");
                }
            }

            objSB.AppendLine("<TABLE align=center border=1 cellSpacing=1 cellPadding=1 width='80%' font='arial'style=margin-top:10px>");
            objSB.AppendLine("</tr><tr><td width=150 align='center' bgcolor='#34495E'><FONT COLOR='#E0E0E0' FACE='Arial' SIZE=2><b>Total Tests</b></td>");
            objSB.AppendLine("<td width=150 align='center' color='#153E7E'><FONT FACE='Arial' SIZE=3><b>" + testResults.Count + "</b></td>");
            objSB.AppendLine("<tr><td width=150 align='center' bgcolor='#34495E'><FONT COLOR='#E0E0E0' FACE='Arial' SIZE=2><b>No. of Passed Tests</b></td>");
            objSB.AppendLine("<td width=150 align='center' color='#153E7E'><FONT FACE='Arial' SIZE=3><b>" + testResults.Where(x => x.Value == "Passed").Count() + "</b></td>");
            objSB.AppendLine("</tr><tr><td width=150 align='center' bgcolor='#34495E'><FONT COLOR='#E0E0E0' FACE='Arial' SIZE=2><b>No. of Failed Tests</b></td>");
            objSB.AppendLine("<td width=150 align='center' color='#153E7E'><FONT FACE='Arial' SIZE=3><b>" + testResults.Where(x => x.Value == "Failed").Count() + "</b></td>");
            //objFSO.AppendLine("</tr><tr><td width=150 align='center' bgcolor='#34495E'><FONT COLOR='#E0E0E0' FACE='Arial' SIZE=2><b>Total Execution Time</b></td>");
            //objFSO.AppendLine("<td width=150 align='center' color='#153E7E'><FONT FACE='Arial' SIZE=3><b>" + "TotalExecutionTime" + "</b></td>");
            objSB.AppendLine("</tr></table></td><td></td><br>");

            objSB.AppendLine("<TABLE align=center border=1 cellSpacing=0.5 cellPadding=1 width='80%' font='arial' >");
            objSB.AppendLine("<tr><TH colspan=2 align='center' bgColor=#153e7e><FONT COLOR='#FFFFFF' FACE='Arial' SIZE=3><b>Detailed Report</b></th></tr>");
            objSB.AppendLine("<tr><td width=80% align=center><FONT color=#153e7e FACE='Arial' SIZE=2><b>Test Case Name</b></td>");
            objSB.AppendLine("<td width=20% align=center><FONT color=#153e7e FACE='Arial' SIZE=2><b>Status</b></td></tr>");
            foreach (var result in testResults)
            {
                if (result.Value == "Passed")
                    objSB.AppendLine("<td align=center><font color=#000000 size=3 style=Arial>" + result.Key + "</B></td><td align=center bgcolor=#145A32><FONT color=white size=3 style=Arial>Passed</font></a></td></tr>");
                else if (result.Value == "Failed")
                    objSB.AppendLine("<td align=center><font color=#000000 size=3 style=Arial>" + result.Key + "</B></td><td align=center bgcolor=#800000><FONT color=white size=3 style=Arial>Failed</font></a></td></tr>");
                else
                    objSB.AppendLine("<td align=center><font color=#000000 size=3 style=Arial>" + result.Key + "</B></td><td align=center bgcolor=#800000><FONT color=white size=3 style=Arial>Failed</font></a></td></tr>");
            }
            objSB.AppendLine("</Table><p align='center'><a align='center' href='https://simplot-digital.visualstudio.com/QA_Projects/_testManagement/runs?_a=runCharts&runId=" + testRunId + "'> click here for more details</a></p>");

            return objSB.ToString();
        }
    }
}
