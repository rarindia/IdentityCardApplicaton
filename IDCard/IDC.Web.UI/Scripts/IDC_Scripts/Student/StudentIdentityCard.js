//this class contain methods related to nationality functionality
var StudentIdentityCard = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentIdentityCard.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#DateOfBirth').datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
            //yearRange: '1950:document.write(currentYear.getFullYear()'

        });

        $("#ResetStudentIdentityCardRecord").click(function () {
            $('#ManageStudentInformation').html("");
        });

        $('#SaveStudentIdentityCardRecord').on("click", function () {

            StudentIdentityCard.ActionName = "Save";
            StudentIdentityCard.AjaxCallStudentIdentityCard();
        });


        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        InitAnimatedBorder();
        CloseAlert();
        //$(".ajax").colorbox();

        $("#LoadCreateForm").unbind("click").click(function () {
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "html",
                url: '/StudentIdentityCard/StudentInfo',
                success: function (data) {
                    $('#ManageStudentInformation').html(data);
                }
            });
        })

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/StudentIdentityCard/List',
             //   data: { "sectionDetailsID": selectedItem1, "centreCode": selectedItem2, "AcademicYear": selectedItem3 },
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {


        $.ajax(
        {
            cache: false,
            type: "POST",
            data: { actionMode: actionMode },
            dataType: "html",
            url: '/StudentIdentityCard/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallStudentIdentityCard: function () {
        var StudentIdentityCardData = null;
        if (StudentIdentityCard.ActionName == "Save") {
            $("#FormSaveStudentIdentityCard").validate();
            if ($("#FormSaveStudentIdentityCard").valid()) {
                StudentIdentityCardData = null;
                StudentIdentityCardData = StudentIdentityCard.GetStudentIdentityCard();
                ajaxRequest.makeRequest("/StudentIdentityCard/StudentInfoSave", "POST", StudentIdentityCardData, StudentIdentityCard.createSuccess);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetStudentIdentityCard: function () {

        var Data = {
        };
        if (StudentIdentityCard.ActionName == "Save") {
            Data.StudentId = $("#StudentId").val();
            Data.StudentImage = $("#StudentImage").val();
            Data.SignImage = $("#SignImage").val();
            Data.StudentFullName = $("#StudentFullName").val();
            Data.StudentFullNameHindi = $("#StudentFullNameHindi").val();
            Data.Course = $("#Course").val();
            Data.RegNo = $("#RegNo").val();
            Data.AddressCorrespondence = $("#AddressCorrespondence").val();
            Data.AddressPermenant = $("#AddressPermenant").val();
            Data.DateOfBirth = $("#DateOfBirth").val();
            Data.Bloodgroup = $("#Bloodgroup").val();
            Data.StudentMobileNumber = $("#StudentMobileNumber").val();
            Data.YearOfReg = $("#YearOfReg").val();
            Data.CardValidity = $("#CardValidity").val();
            Data.SelectedCentreCode = $("#SelectedCentreCode").val();
            Data.CentreName = $("#SelectedCentreCode").val();
        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    createSuccess: function (data) {
        var splitData = data.split(',');
        StudentIdentityCard.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
};

