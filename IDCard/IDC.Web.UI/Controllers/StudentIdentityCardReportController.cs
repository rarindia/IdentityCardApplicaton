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
using IDC.DataProvider;

namespace IDC.Web.UI.Controllers
{
    public class StudentIdentityCardReportController : Controller
    {
        IStudentReportBA _StudentReportBA = null;
        private readonly ILogger _logException;

        protected static int _SectionDetailID = 0;
        protected static int _CourseYearId = 0;
        protected static int _SessionID = 0;
        protected static int _StudentID = 0;
        protected static string _ICardView = string.Empty;
        protected static string _courseOrSection = string.Empty;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentIdentityCardReportController()
        {
            _StudentReportBA = new StudentReportBA();
        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()//string CentreCode, string UniversityID, string SectionDetailID, string CourseYearId, string AcademicYear, string admissionStatus, string sortOrder, string ReportType, string actionMode)
        {
            try
            {
              
                StudentReportViewModel model = new StudentReportViewModel();
                model.IsUnderValidity = Helper.ValidateDate();
                model.IsShowMessage = Helper.ShowExpirationMessage();
                if (model.IsShowMessage)
                    model.ExpiredInDays = Helper.NumberOfDays();
                //SelectedICardView
                List<SelectListItem> SelectedICardView = new List<SelectListItem>();
                ViewBag.SelectedICardView = new SelectList(SelectedICardView, "Value", "Text");
                List<SelectListItem> li_SelectedICardView = new List<SelectListItem>();
                li_SelectedICardView.Add(new SelectListItem { Text = "Two Side", Value = "T" });
                li_SelectedICardView.Add(new SelectListItem { Text = "Front", Value = "F" });
                li_SelectedICardView.Add(new SelectListItem { Text = "Back", Value = "B" });
                ViewData["SelectedICardView"] = new SelectList(li_SelectedICardView, "Value", "Text", model.StudentReportDTO.SelectedICardView);

                return View("/Views/Student/Report/StudentIdentityCardReport/Index.cshtml", model);
            }
            catch (Exception)
            {

                throw;
            }


        }


        [HttpPost]
        public ActionResult Index(StudentReportViewModel model)//string SelectedHeadID, string SelectedCategoryID)
        {
            try
            {
                model.IsUnderValidity = Helper.ValidateDate();
                //SelectedICardView
                List<SelectListItem> SelectedICardView = new List<SelectListItem>();
                ViewBag.SelectedICardView = new SelectList(SelectedICardView, "Value", "Text");
                List<SelectListItem> li_SelectedICardView = new List<SelectListItem>();
                li_SelectedICardView.Add(new SelectListItem { Text = "Two Side", Value = "T" });
                li_SelectedICardView.Add(new SelectListItem { Text = "Front", Value = "F" });
                li_SelectedICardView.Add(new SelectListItem { Text = "Back", Value = "B" });
                ViewData["SelectedICardView"] = new SelectList(li_SelectedICardView, "Value", "Text", model.StudentReportDTO.SelectedICardView);

                if (model.IsPosted == true)
                {
                    _StudentID = model.StudentId;
                    _ICardView = model.SelectedICardView;
                    model.IsPosted = false;
                }
                else
                {
                    model.StudentId = _StudentID;
                    model.SelectedICardView = _ICardView;
                }
                return View("/Views/Student/Report/StudentIdentityCardReport/Index.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }


        protected List<StudentReport> GetStudentSearchListForIdentityCardList(string searchWord)
        {
            StudentReportSearchRequest searchRequest = new StudentReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = searchWord;
            List<StudentReport> listStudentMaster = new List<StudentReport>();
            IBaseEntityCollectionResponse<StudentReport> baseEntityCollectionResponse = _StudentReportBA.GetStudentSearchListForIdentityCard(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listStudentMaster;
        }



        #region Methods
        // Non-Action Method 



        public List<StudentReport> GetListStudentIdentityCardReport(out string IcardView)
        {
            try
            {
                StudentReportSearchRequest searchRequest = new StudentReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                searchRequest.StudentId = _StudentID;
                List<StudentReport> StudentReportFieldList = new List<StudentReport>();
                IBaseEntityCollectionResponse<StudentReport> baseEntityCollectionResponse = _StudentReportBA.GetBySearchForStudentIdentityCard(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        StudentReportFieldList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                IcardView = _ICardView;
                return StudentReportFieldList;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _SectionDetailID = 0;
                _CourseYearId = 0;
                _SessionID = 0;
                _StudentID = 0;
            }

        }
        #endregion


        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        public JsonResult GetStudentSearchListForIdentityCard(string term)//, string courseYearID, string sectionDetailID, string SessionID)  
        {
            try
            {
                if (term != "")
                {
                    var data = GetStudentSearchListForIdentityCardList(term);
                    var result = (from r in data select new { StudentFullName = r.StudentFullName, id = r.StudentId }).ToList();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion

    }
}