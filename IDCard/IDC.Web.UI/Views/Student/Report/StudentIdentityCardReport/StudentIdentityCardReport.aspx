<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Student Identity Card</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvStudentIdentityCardReportList);
            if (!IsPostBack)
            {
                List<IDC.DTO.StudentReport> studentReport = null;
                IDC.Web.UI.Controllers.StudentIdentityCardReportController controller = new IDC.Web.UI.Controllers.StudentIdentityCardReportController();
                string IcardView = string.Empty;
                if (Request.RequestType == "POST")
                {
                    studentReport = controller.GetListStudentIdentityCardReport(out IcardView);
                }

                if (studentReport == null || studentReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    ReportParameter[] param = null;
                    string SignImageFilePath = new Uri(Server.MapPath("~/Content/UploadedFiles/Student/Signature/" + studentReport[0].SignImage)).AbsoluteUri;
                    string StudentImageFilePath = new Uri(Server.MapPath("~/Content/UploadedFiles/Student/StudentImage/" + studentReport[0].StudentImage)).AbsoluteUri;
                    string FooterImageFilePath = new Uri(Server.MapPath("~/Content/images/FooterImage_" + studentReport[0].SelectedCentreCode + ".jpg")).AbsoluteUri;


                    if (IcardView == "F")
                    {
                        param = new ReportParameter[2];
                        param[0] = new ReportParameter("SignImage", studentReport.Count > 0 ? SignImageFilePath : string.Empty, true);
                        param[1] = new ReportParameter("StudentImage", studentReport.Count > 0 ? StudentImageFilePath : string.Empty, true);

                        rvStudentIdentityCardReportList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentIdentityCardFrontReport.rdlc");
                        rvStudentIdentityCardReportList.LocalReport.ReportEmbeddedResource = "IDC.Web.UI.Report.StudentIdentityCardFrontReport.rdlc";
                    }
                    else if (IcardView == "B")
                    {
                        param = new ReportParameter[2];

                        param[0] = new ReportParameter("SignImage", studentReport.Count > 0 ? SignImageFilePath : string.Empty, true);
                        param[1] = new ReportParameter("StudentImage", studentReport.Count > 0 ? StudentImageFilePath : string.Empty, true);

                        rvStudentIdentityCardReportList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentIdentityCardBackReport.rdlc");
                        rvStudentIdentityCardReportList.LocalReport.ReportEmbeddedResource = "IDC.Web.UI.Report.StudentIdentityCardBackReport.rdlc";
                    }
                    //else if (studentReport[0].SelectedCentreCode == "MGHV")
                    //{
                    //    rvStudentIdentityCardReportList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentIdentityCardTwoSidedReport.rdlc");
                    //    rvStudentIdentityCardReportList.LocalReport.ReportEmbeddedResource = "IDC.Web.UI.Report.StudentIdentityCardTwoSidedReport.rdlc";
                    //}
                    else if (studentReport[0].SelectedCentreCode == "DIST")
                    {
                        param = new ReportParameter[2];
                        rvStudentIdentityCardReportList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentIdentityCardTwoSidedReportWithDistCentre.rdlc");
                        rvStudentIdentityCardReportList.LocalReport.ReportEmbeddedResource = "IDC.Web.UI.Report.StudentIdentityCardTwoSidedReportWithDistCentre.rdlc";
                    }
                    else
                    {
                        param = new ReportParameter[3];
                        param[0] = new ReportParameter("SignImage", studentReport.Count > 0 ? SignImageFilePath : string.Empty, true);
                        param[1] = new ReportParameter("StudentImage", studentReport.Count > 0 ? StudentImageFilePath : string.Empty, true);
                        param[2] = new ReportParameter("FooterImage", studentReport.Count > 0 ? FooterImageFilePath : string.Empty, true);

                        rvStudentIdentityCardReportList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentIdentityCardTwoSidedReportWithCentre.rdlc");
                        rvStudentIdentityCardReportList.LocalReport.ReportEmbeddedResource = "IDC.Web.UI.Report.StudentIdentityCardTwoSidedReportWithCentre.rdlc";
                    }
                    rvStudentIdentityCardReportList.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "IDCARDDataSet";
                    rdc.Value = studentReport;
                    rvStudentIdentityCardReportList.LocalReport.DataSources.Add(rdc);

                    rvStudentIdentityCardReportList.LocalReport.EnableExternalImages = true;


                    rvStudentIdentityCardReportList.LocalReport.SetParameters(param);

                    rvStudentIdentityCardReportList.LocalReport.Refresh();
                    rvStudentIdentityCardReportList.Visible = true;
                }
            }
        }


    </script>

</head>

<body>
    <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">
            <input type="button" id="printreport" value="Print" class="btn btn-small">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvStudentIdentityCardReportList" runat="server" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportEmbeddedResource="IDC.Web.UI.Report.StudentIdentityCardFrontReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="IDCARDDataSet" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <br />
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>

    </form>
</body>

</html>
<script>
    function printReport(report_ID) {
        var rv1 = $('#' + report_ID);
        var iDoc = rv1.parents('html');

        // Reading the report styles
        var styles = iDoc.find("head style[id$='ReportControl_styles']").html();
        if ((styles == undefined) || (styles == '')) {
            iDoc.find('head script').each(function () {
                var cnt = $(this).html();
                var p1 = cnt.indexOf('ReportStyles":"');
                if (p1 > 0) {
                    p1 += 15;
                    var p2 = cnt.indexOf('"', p1);
                    styles = cnt.substr(p1, p2 - p1);
                }
            });
        }
        if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }
        styles = '<style type="text/css">' + styles + "</style>";

        // Reading the report html
        var table = rv1.find("div[id$='_oReportDiv']");
        if (table == undefined) {
            alert("Report source not found.");
            return;
        }

        // Generating a copy of the report in a new window
        var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';
        var docCnt = styles + table.parent().html();
        var docHead = '<head><title>Printing ...</title><style>body{margin:0;padding:0;}</style></head>';
        var winAttr = "location=yes, statusbar=no, directories=no, menubar=no, titlebar=no, toolbar=no, dependent=no, width=720, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";;
        var newWin = window.open("", "_blank", winAttr);
        writeDoc = newWin.document;
        writeDoc.open();
        writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');
        writeDoc.close();

        // The print event will fire as soon as the window loads
        newWin.focus();
        // uncomment to autoclose the preview window when printing is confirmed or canceled.
        // newWin.close();
    };

    $('#printreport').click(function () {
        printReport('rvStudentIdentityCardReportList');
    });
</script>
