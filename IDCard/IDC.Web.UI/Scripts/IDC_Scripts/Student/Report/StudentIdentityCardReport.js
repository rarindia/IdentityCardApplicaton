//this class contain methods related to nationality functionality
var StudentIdentityCardReport = {
    //Member variables
    ActionName: null,
    map: {},
    map2: {},
    //Class intialisation method
    Initialize: function () {

        StudentIdentityCardReport.constructor();

    },
    //Attach all event of page
    constructor: function () {
        $('#btnStudentIdentityCardReportSubmit').on("click", function () {
            $("#IsPosted").val(true);
        });

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlCurrentSessionDetails = $("#SelectedAcademicYear");
            var $CurrentSessionDetailsProgress = $("#states-loading-progress");
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            $CurrentSessionDetailsProgress.show();


            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCardReport/GetUniversityByCentreCode",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University--</option>');
                        $.each(data, function (id, option) {

                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $UniversityProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $UniversityProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
                $('#btnCreate').hide();
            }
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCardReport/GetAllSessionDetails",

                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlCurrentSessionDetails.html('');
                        //   $ddlCurrentSessionDetails.append('<option value="">--Select Session--</option>');
                        $.each(data, function (id, option) {

                            $ddlCurrentSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $CurrentSessionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Session.');
                        $CurrentSessionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedAcademicYear').find('option').remove().end().append('<option value>---Select Session---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#SelectedSectionDetailID").change(function () {
            var selectedItem1 = $(this).val();
            if (selectedItem1 != "") {
                $("#divShowStudentList").fadeIn(1000);

            }
            else {
                //   $("#DivStudentListInfo").fadeOut(1000);
                $("#divShowStudentList").fadeOut(1000);
            }
        });

        $("#Course_Section").change(function () {
            var selectedItem1 = $(this).val();
            if (selectedItem1 == "C") {
                $("#DivSectionLable").fadeOut(0);
                $("#DivSectionDropDown").fadeOut(0);

                $("#DivCourseYearLable").fadeIn(0);
                $("#DivCourseYearDropDown").fadeIn(0);
                //   $("#DivReportType").fadeIn(0);


            }
            else {
                $("#DivSectionLable").fadeIn(0);
                $("#DivSectionDropDown").fadeIn(0);
                //   $("#DivReportType").fadeOut(0);
                $("#DivCourseYearLable").fadeOut(0);
                $("#DivCourseYearDropDown").fadeOut(0);
            }
        });
        // Create new record



        $("#SelectedUniversityID").change(function () {

            var selectedItem1 = $(this).val();
            var selectedItem = $("#SelectedCentreCode").val();

            var $ddlCourseYearDetails = $("#SelectedCourseYearId");
            var $CourseYearDetailsProgress = $("#states-loading-progress");
            $CourseYearDetailsProgress.show();

            var $ddlSectionDetails = $("#SelectedSectionDetailID");
            var $SectionDetailsProgress = $("#states-loading-progress");
            $SectionDetailsProgress.show();

            if ($("#SelectedUniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCardReport/GetSectionDetails",
                    data: { "CentreCode": selectedItem, "UniversityID": selectedItem1 },
                    success: function (data) {
                        $ddlSectionDetails.html('');
                        $ddlSectionDetails.append('<option value="">--Select Section--</option>');
                        $.each(data, function (id, option) {
                            $ddlSectionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $SectionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Section.');
                        $SectionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedSectionDetailID').find('option').remove().end().append('<option value>---Select Section---</option>');
                $('#btnCreate').hide();
            }



            if ($("#SelectedUniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/StudentIdentityCardReport/GetCourseYearDetails",

                    data: { "CentreCode": selectedItem, "UniversityID": selectedItem1 },
                    success: function (data) {
                        $ddlCourseYearDetails.html('');
                        $ddlCourseYearDetails.append('<option value="">--Select Course Year--</option>');
                        $.each(data, function (id, option) {

                            $ddlCourseYearDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $CourseYearDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Branch.');
                        $CourseYearDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedCourseYearId').find('option').remove().end().append('<option value>---Select Course Year---</option>');
                $('#btnCreate').hide();
            }
        });


        //$("#StudentFullName").autocomplete({
         
        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/StudentIdentityCardReport/GetStudentSearchListForIdentityCard",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, maxResults: 10, courseYearID: $("#SelectedCourseYearId :selected").val(), sectionDetailID: $("#SelectedSectionDetailID :selected").val(), SessionID: $("#SelectedAcademicYear :selected").val() }, //1 for current year student
        //                //{ term: request.term, maxResults: 10, courseYearID: $("#SelectedCourseYearId :selected").val(), sectionDetailID: $("#SelectedSectionDetailID :selected").val(), SessionID: $("#SelectedAcademicYear :selected").val() }, //1 for current year student
        //            success: function (data) {
        //                //alert(data)
        //                response($.map(data, function (item) {
        //                    return { label: item.StudentFullName, value: item.StudentFullName, id: item.id };

        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        //alert(ui.item.id);
        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $("#StudentId").val(ui.item.id);
        //    }
        //});


        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuCourseYearId = $("#SelectedCourseYearId :selected").val();
                var valuSectionDetailID = $("#SelectedSectionDetailID :selected").val();
                var valuAcademicYear = $("#SelectedAcademicYear :selected").val();
                $.ajax({
                    url: "/StudentIdentityCardReport/GetStudentSearchListForIdentityCard",
                    type: "POST",
                    //data: { term: q, maxResults: 10, centreCode: valuCentreCode, studentType: valuStudentType },
                    data: { term: q, maxResults: 10, courseYearID: valuCourseYearId, sectionDetailID: valuSectionDetailID, SessionID: valuAcademicYear }, //1 for current year student
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        $.each(data, function (i, response) {
                            //alert(response.id);
                            if (substrRegex.test(response.StudentFullName)) {
                                StudentIdentityCardReport.map[response.StudentFullName] = response;
                                matches.push(response.StudentFullName);

                            }
                        });
                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#StudentFullName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            $("#StudentId").val(StudentIdentityCardReport.map[item].id);
        });
        //end new search functionality




        $('#ShowStudentList').on("click", function () {

            var SelectedCentreCode = $("#SelectedCentreCode").val();
            var SelectedUniversityID = $("#SelectedUniversityID").val();
            var Course_Section = $("#Course_Section").val();

            if (Course_Section == "S") {
                var SelectedSectionDetailID = $("#SelectedSectionDetailID").val();
                var SelectedCourseYearId = 0;
            }
            else {
                var SelectedSectionDetailID = 0;
                var SelectedCourseYearId = $("#SelectedCourseYearId").val();
            }
            var SelectedAcademicYear = $("#SelectedAcademicYear").val();
            var AdmissionStatus = $("#AdmissionStatus").val();
            var SortOrder = $("#AdmissionStatus").val();
            var ReportType = $('input[name=ReportType]:checked').val() ? true : false;

            StudentIdentityCardReport.LoadList111(SelectedCentreCode, SelectedUniversityID, SelectedSectionDetailID, SelectedCourseYearId, SelectedAcademicYear, AdmissionStatus, SortOrder, ReportType);


        });


    },

};

