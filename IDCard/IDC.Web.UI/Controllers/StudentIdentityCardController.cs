using IDC.Base.DTO;
using IDC.DTO;
using IDC.Business.BusinessAction;
using IDC.ExceptionManager;
using IDC.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using System.Web;
using System.Web.Helpers;
//using IDC.DataProvider;
namespace IDC.Web.UI.Controllers
{
    public class StudentIdentityCardController : Controller
    {

        IStudentIdentityCardBA _StudentIdentityCardBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentIdentityCardController()
        {
            _StudentIdentityCardBA = new StudentIdentityCardBA();
        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {

            //StudentIdentityCardViewModel model = new StudentIdentityCardViewModel();
            return View("/Views/Student/StudentIdentityCard/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                StudentIdentityCardViewModel model = new StudentIdentityCardViewModel();
                model.IsUnderValidity = Helper.ValidateDate();
                model.IsShowMessage = Helper.ShowExpirationMessage();
                if (model.IsShowMessage)
                    model.ExpiredInDays = Helper.NumberOfDays();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Student/StudentIdentityCard/List.cshtml", model);


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }



        public ActionResult StudentInfo(string Id)
        {
            StudentIdentityCardViewModel model = new StudentIdentityCardViewModel();

            try
            {
                model.StudentIdentityCardDTO = new StudentIdentityCard();
                model.StudentIdentityCardDTO.StudentId = !string.IsNullOrEmpty(Id) ? Convert.ToInt32(Id) : 0;
                model.StudentIdentityCardDTO.ConnectionString = _connectioString;

                if (model.StudentIdentityCardDTO.StudentId > 0)
                {
                    IBaseEntityResponse<StudentIdentityCard> response = _StudentIdentityCardBA.SelectByID(model.StudentIdentityCardDTO);
                    if (response != null && response.Entity != null)
                    {
                        model.StudentIdentityCardDTO.StudentId = response.Entity.StudentId;
                        model.StudentIdentityCardDTO.StudentImage = response.Entity.StudentImage;
                        model.StudentIdentityCardDTO.SignImage = response.Entity.SignImage;
                        model.StudentIdentityCardDTO.StudentFullName = response.Entity.StudentFullName;
                        model.StudentIdentityCardDTO.StudentFullNameHindi = response.Entity.StudentFullNameHindi;
                        model.StudentIdentityCardDTO.Course = response.Entity.Course;
                        model.StudentIdentityCardDTO.RegNo = response.Entity.RegNo;
                        model.StudentIdentityCardDTO.AddressCorrespondence = response.Entity.AddressCorrespondence;
                        model.StudentIdentityCardDTO.AddressPermenant = response.Entity.AddressPermenant;
                        model.StudentIdentityCardDTO.DateOfBirth = response.Entity.DateOfBirth;
                        model.StudentIdentityCardDTO.Bloodgroup = response.Entity.Bloodgroup;
                        model.StudentIdentityCardDTO.StudentMobileNumber = response.Entity.StudentMobileNumber;
                        model.StudentIdentityCardDTO.YearOfReg = response.Entity.YearOfReg;
                        model.StudentIdentityCardDTO.CardValidity = response.Entity.CardValidity;
                        model.StudentIdentityCardDTO.SelectedCentreCode = response.Entity.SelectedCentreCode;
                    }
                }
                //For Blood Group
                List<SelectListItem> BloodGroup = new List<SelectListItem>();
                ViewBag.BloodGroup = new SelectList(BloodGroup, "Value", "Text");
                List<SelectListItem> li_BloodGroup = new List<SelectListItem>();
                li_BloodGroup.Add(new SelectListItem { Text = "-- Select Blood Group -- ", Value = "" });
                li_BloodGroup.Add(new SelectListItem { Text = "O-", Value = "O-" });
                li_BloodGroup.Add(new SelectListItem { Text = "O+", Value = "O+" });
                li_BloodGroup.Add(new SelectListItem { Text = "A-", Value = "A-" });
                li_BloodGroup.Add(new SelectListItem { Text = "A+", Value = "A+" });
                li_BloodGroup.Add(new SelectListItem { Text = "B-", Value = "B-" });
                li_BloodGroup.Add(new SelectListItem { Text = "B+", Value = "B+" });
                li_BloodGroup.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
                li_BloodGroup.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
                ViewData["Bloodgroup"] = new SelectList(li_BloodGroup, "Value", "Text", model.StudentIdentityCardDTO.Bloodgroup);

                model.ListStudentIdentityCard = GetListOrgStudyCentreMaster();

                return PartialView("/Views/Student/StudentIdentityCard/StudentInfo.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult StudentInfoSave(StudentIdentityCardViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.StudentIdentityCardDTO != null)
                    {
                        model.StudentIdentityCardDTO.ConnectionString = _connectioString;

                        model.StudentIdentityCardDTO.StudentId = model.StudentId;
                        model.StudentIdentityCardDTO.StudentImage = model.StudentImage;
                        model.StudentIdentityCardDTO.SignImage = model.SignImage;
                        model.StudentIdentityCardDTO.StudentFullName = model.StudentFullName;
                        model.StudentIdentityCardDTO.StudentFullNameHindi = model.StudentFullNameHindi;
                        model.StudentIdentityCardDTO.Course = model.Course;
                        model.StudentIdentityCardDTO.RegNo = model.RegNo;
                        model.StudentIdentityCardDTO.AddressCorrespondence = model.AddressCorrespondence;
                        model.StudentIdentityCardDTO.AddressPermenant = model.AddressPermenant;
                        model.StudentIdentityCardDTO.DateOfBirth = model.DateOfBirth;
                        model.StudentIdentityCardDTO.Bloodgroup = model.Bloodgroup;
                        model.StudentIdentityCardDTO.StudentMobileNumber = model.StudentMobileNumber;
                        model.StudentIdentityCardDTO.YearOfReg = model.YearOfReg;
                        model.StudentIdentityCardDTO.CardValidity = model.CardValidity;
                        model.StudentIdentityCardDTO.SelectedCentreCode = model.SelectedCentreCode;

                        IBaseEntityResponse<StudentIdentityCard> response = _StudentIdentityCardBA.UpdateStudentIdentityCard(model.StudentIdentityCardDTO);
                        if (model.StudentIdentityCardDTO.StudentId > 0)
                        {
                            model.StudentIdentityCardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                        else
                        {
                            model.StudentIdentityCardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        }


                    }

                    return Json(model.StudentIdentityCardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        #region Image Upload Methods
        private const int AvatarStoredWidth = 202;  // ToDo - Change the size of the stored avatar image
        private const int AvatarStoredHeight = 202; // ToDo - Change the size of the stored avatar image
        private const int AvatarScreenWidth = 350;  // ToDo - Change the value of the width of the image on the screen

        private const int SignatureStoredWidth = 100;  // ToDo - Change the size of the stored avatar image
        private const int SignatureStoredHeight = 66; // ToDo - Change the size of the stored avatar image
        private const int SignatureScreenWidth = 350;  // ToDo - Change the value of the width of the image on the screen

        private const string TempFolder = "/Content/UploadedFiles/Temp";
        private const string MapTempFolder = "~" + TempFolder;
        private const string AvatarPath = "/Content/UploadedFiles/Student/StudentImage";
        private const string SignaturePath = "/Content/UploadedFiles/Student/Signature";

        private readonly string[] _imageFileExtensions = { ".jpg", ".png", ".gif", ".jpeg" };

        [HttpGet]
        public ActionResult StudentImageUpload()
        {
            //return PartialView();
            return PartialView("/Views/Student/StudentIdentityCard/StudentImageUpload.cshtml");
        }

        [HttpGet]
        public ActionResult SignatureUpload()
        {
            //return PartialView();
            return PartialView("/Views/Student/StudentIdentityCard/SignatureUpload.cshtml");
        }

        [ValidateAntiForgeryToken]
        public ActionResult StudentImageUpload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null || !files.Any()) return Json(new { success = false, errorMessage = "No file uploaded." });
            var file = files.FirstOrDefault();  // get ONE only
            if (file == null || !IsImage(file)) return Json(new { success = false, errorMessage = "File is of wrong format." });
            if (file.ContentLength <= 0) return Json(new { success = false, errorMessage = "File cannot be zero length." });
            var webPath = GetTempSavedFilePath(file);
            //mistertommat - 18 Nov '15 - replacing '\' to '//' results in incorrect image url on firefox and IE,
            //                            therefore replacing '\\' to '/' so that a proper web url is returned.            
            return Json(new { success = true, fileName = webPath.Replace("\\", "/") }); // success
        }
        [ValidateAntiForgeryToken]
        public ActionResult SignatureUpload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null || !files.Any()) return Json(new { success = false, errorMessage = "No file uploaded." });
            var file = files.FirstOrDefault();  // get ONE only
            if (file == null || !IsImage(file)) return Json(new { success = false, errorMessage = "File is of wrong format." });
            if (file.ContentLength <= 0) return Json(new { success = false, errorMessage = "File cannot be zero length." });
            var webPath = GetTempSavedFilePathSignature(file);
            //mistertommat - 18 Nov '15 - replacing '\' to '//' results in incorrect image url on firefox and IE,
            //                            therefore replacing '\\' to '/' so that a proper web url is returned.            
            return Json(new { success = true, fileName = webPath.Replace("\\", "/") }); // success
        }

        [HttpPost]
        public ActionResult SaveStudentImage(string t, string l, string h, string w, string fileName)
        {
            try
            {
                // Calculate dimensions
                var top = Convert.ToInt32(t.Replace("-", "").Replace("px", ""));
                var left = Convert.ToInt32(l.Replace("-", "").Replace("px", ""));
                var height = Convert.ToInt32(h.Replace("-", "").Replace("px", ""));
                var width = Convert.ToInt32(w.Replace("-", "").Replace("px", ""));

                // Get file from temporary folder
                var fn = Path.Combine(Server.MapPath(MapTempFolder), Path.GetFileName(fileName));
                // ...get image and resize it, ...
                var img = new WebImage(fn);
                img.Resize(width, height);
                // ... crop the part the user selected, ...
                img.Crop(top, left, img.Height - top - AvatarStoredHeight, img.Width - left - AvatarStoredWidth);


                // ... delete the temporary file,...
                System.IO.File.Delete(fn);
                // ... and save the new one.
                var newFileName = Path.Combine(AvatarPath, Path.GetFileName(fn));
                var newFileLocation = HttpContext.Server.MapPath(newFileName);
                if (Directory.Exists(Path.GetDirectoryName(newFileLocation)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileLocation));
                }

                img.Save(newFileLocation);

                return Json(new { success = true, avatarFileLocation = newFileName, ArticleFileName = Path.GetFileName(fileName) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = "Unable to upload file.\nERRORINFO: " + ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SaveSignature(string t, string l, string h, string w, string fileName)
        {
            try
            {
                // Calculate dimensions
                var top = Convert.ToInt32(t.Replace("-", "").Replace("px", ""));
                var left = Convert.ToInt32(l.Replace("-", "").Replace("px", ""));
                var height = Convert.ToInt32(h.Replace("-", "").Replace("px", ""));
                var width = Convert.ToInt32(w.Replace("-", "").Replace("px", ""));

                // Get file from temporary folder
                var fn = Path.Combine(Server.MapPath(MapTempFolder), Path.GetFileName(fileName));
                // ...get image and resize it, ...
                var img = new WebImage(fn);
                img.Resize(width, height);
                // ... crop the part the user selected, ...
                img.Crop(top, left, img.Height - top - SignatureStoredHeight, img.Width - left - SignatureStoredWidth);


                // ... delete the temporary file,...
                System.IO.File.Delete(fn);
                // ... and save the new one.
                var newFileName = Path.Combine(SignaturePath, Path.GetFileName(fn));
                var newFileLocation = HttpContext.Server.MapPath(newFileName);
                if (Directory.Exists(Path.GetDirectoryName(newFileLocation)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileLocation));
                }

                img.Save(newFileLocation);

                return Json(new { success = true, avatarFileLocation = newFileName, ArticleFileName = Path.GetFileName(fileName) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = "Unable to upload file.\nERRORINFO: " + ex.Message });
            }
        }

        private bool IsImage(HttpPostedFileBase file)
        {
            if (file == null) return false;
            return file.ContentType.Contains("image") ||
                _imageFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        private string GetTempSavedFilePath(HttpPostedFileBase file)
        {
            // Define destination
            var serverPath = HttpContext.Server.MapPath(TempFolder);
            if (Directory.Exists(serverPath) == false)
            {
                Directory.CreateDirectory(serverPath);
            }


            string _imgname = string.Empty;
            // Generate unique file name
            var fileName = Path.GetFileName(file.FileName);

            var _ext = Path.GetExtension(file.FileName);
            _imgname = Guid.NewGuid().ToString();

            _imgname = "Student_" + _imgname + _ext;

            fileName = SaveTemporaryAvatarFileImage(file, serverPath, _imgname);

            // Clean up old files after every save
            CleanUpTempFolder(1);
            return Path.Combine(TempFolder, fileName);
        }

        private string GetTempSavedFilePathSignature(HttpPostedFileBase file)
        {
            // Define destination
            var serverPath = HttpContext.Server.MapPath(TempFolder);
            if (Directory.Exists(serverPath) == false)
            {
                Directory.CreateDirectory(serverPath);
            }


            string _imgname = string.Empty;
            // Generate unique file name
            var fileName = Path.GetFileName(file.FileName);

            var _ext = Path.GetExtension(file.FileName);
            _imgname = Guid.NewGuid().ToString();

            _imgname = "Signature_" + _imgname + _ext;

            fileName = SaveTemporarySignatureFileImage(file, serverPath, _imgname);

            // Clean up old files after every save
            CleanUpTempFolder(1);
            return Path.Combine(TempFolder, fileName);
        }

        private static string SaveTemporaryAvatarFileImage(HttpPostedFileBase file, string serverPath, string fileName)
        {
            var img = new WebImage(file.InputStream);
            var ratio = img.Height / (double)img.Width;
            img.Resize(AvatarScreenWidth, (int)(AvatarScreenWidth * ratio));

            var fullFileName = Path.Combine(serverPath, fileName);
            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            img.Save(fullFileName);


            return Path.GetFileName(img.FileName);
        }

        private static string SaveTemporarySignatureFileImage(HttpPostedFileBase file, string serverPath, string fileName)
        {
            var img = new WebImage(file.InputStream);
            var ratio = img.Height / (double)img.Width;
            img.Resize(SignatureScreenWidth, (int)(SignatureScreenWidth * ratio));

            var fullFileName = Path.Combine(serverPath, fileName);
            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            img.Save(fullFileName);


            return Path.GetFileName(img.FileName);
        }

        private void CleanUpTempFolder(int hoursOld)
        {
            try
            {
                var currentUtcNow = DateTime.UtcNow;
                var serverPath = HttpContext.Server.MapPath("/Temp");
                if (!Directory.Exists(serverPath)) return;
                var fileEntries = Directory.GetFiles(serverPath);
                foreach (var fileEntry in fileEntries)
                {
                    var fileCreationTime = System.IO.File.GetCreationTimeUtc(fileEntry);
                    var res = currentUtcNow - fileCreationTime;
                    if (res.TotalHours > hoursOld)
                    {
                        System.IO.File.Delete(fileEntry);
                    }
                }
            }
            catch
            {
                // Deliberately empty.
            }
        }

        #endregion
        #region Methods
        // Non-Action Method 

        protected List<StudentIdentityCard> GetListOrgStudyCentreMaster()
        {

            StudentIdentityCardSearchRequest searchRequest = new StudentIdentityCardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<StudentIdentityCard> listOrganisationStudyCentreMaster = new List<StudentIdentityCard>();
            IBaseEntityCollectionResponse<StudentIdentityCard> baseEntityCollectionResponse = _StudentIdentityCardBA.GetOrganisationStudyCentreList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationStudyCentreMaster;
        }

        protected string CheckError(int errorCode, ActionModeEnum actionMode)
        {

            string errorMessage = string.Empty;
            string colorCode = string.Empty;
            string mode = string.Empty;
            if (actionMode == ActionModeEnum.Insert)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = "Record Already Exists";// "Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.LimitExceeds:
                        errorMessage = "Cannot create record as limit exceeds!";// "Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = "Record Created Successfully";// "Record created successfully";
                        colorCode = "success";
                        mode = "0";
                        break;
                    case (Int32)ErrorEnum.WorkFlowNotDefined:
                        errorMessage = "Work Flow Not Defined";// "Work Flow Not Defined ";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    default:
                        errorMessage = "Record Not Created Successfully";// "Record not created successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Update)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = "Record Already Exists"; ;//"Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = "Record Updated Successfully";// "Record updated successfully";
                        colorCode = "success";
                        mode = "1";
                        break;
                    default:
                        errorMessage = "Record Not Updated Successfully";// "Record not updated successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Delete)
            {
                mode = string.Empty;
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = "Record Deleted Successfully";// "Record deleted successfully";
                        colorCode = "success";
                        break;
                    case (Int32)ErrorEnum.DependantEntry:
                        errorMessage = "Record Dependant Entry";// "Record not deleted successfully, Because it is used in another form.";
                        colorCode = "warning";
                        break;
                    default:
                        errorMessage = "Record Not Deleted Successfully";// "Record not deleted successfully";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Sync)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = "SyncProcessDoneSuccessfully";// "Sync process completed successfully";
                        colorCode = "success";
                        break;
                    default:
                        errorMessage = "Message_SyncProcessAborted";// "Sync process aborted due to unexpected error";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.FiredJob)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = "JobFiredSuccessfully";// "Job Fired successfully";
                        colorCode = "success";
                        break;
                    default:
                        errorMessage = "UnexpectedErrorOccured";// "unexpected error Occured.";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.InActive)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = "RecordInaciveDependantEntry";// "Record not deleted successfully, Because it is used in another form.";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = "RecordInactiveSuccessfully";// "Record inactive successfully";
                        colorCode = "success";
                        mode = "1";
                        break;
                    default:
                        errorMessage = "RecordNotInactiveSuccessfully";// "Record not deleted successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            string[] arrayList = { errorMessage, colorCode, mode };
            return string.Join(",", arrayList);
        }

        public IEnumerable<StudentIdentityCardViewModel> GetStudentList(out int TotalRecords)
        {
            StudentIdentityCardSearchRequest searchRequest = new StudentIdentityCardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {

                searchRequest.SortDirection = "Desc";
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<StudentIdentityCardViewModel> listStudentIdentityCardViewModel = new List<StudentIdentityCardViewModel>();
            List<StudentIdentityCard> listStudentIdentityCard = new List<StudentIdentityCard>();
            IBaseEntityCollectionResponse<StudentIdentityCard> baseEntityCollectionResponse = _StudentIdentityCardBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentIdentityCard = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (StudentIdentityCard item in listStudentIdentityCard)
                    {
                        StudentIdentityCardViewModel StudentIdentityCardViewModel = new StudentIdentityCardViewModel();
                        StudentIdentityCardViewModel.StudentIdentityCardDTO = item;
                        listStudentIdentityCardViewModel.Add(StudentIdentityCardViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listStudentIdentityCardViewModel;
        }
        #endregion


        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        //    public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            //string centreCode = null; string sectionDetailsID = null; string AcademicYear = null;
            //if (Session["UserType"] != null)
            //{
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);

            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            if (sortDirection == null)
            {
                sortDirection = "asc";
            }

            IEnumerable<StudentIdentityCardViewModel> filteredStudentIdentityCard;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "NameEnglish";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "NameEnglish Like '%" + param.sSearch + "%'";    //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (_rowLength == 0)
            {
                _rowLength = 10;
            }

            filteredStudentIdentityCard = GetStudentList(out TotalRecords);
            var records = filteredStudentIdentityCard.Skip(0).Take(param.iDisplayLength);
            //   var result = from c in filteredStudentIdentityCard select new[] { c.StudentTitle.ToString() + " " + c.StudentFirstName.ToString() + " " + c.StudentMiddleName.ToString() + " " + c.StudentLastName.ToString(), c.StudentCode.ToString(), c.RollNumber.ToString(), Convert.ToString(c.StudentId) };
            var result = from c in records select new[] { Convert.ToString(c.StudentFullName), Convert.ToString(c.YearOfReg), Convert.ToString(c.Course), Convert.ToString(c.StudentId), Convert.ToString(c.StudentMobileNumber) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{

            //    var result = 0;
            //    return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);

            //}
        }

        #endregion

    }
}