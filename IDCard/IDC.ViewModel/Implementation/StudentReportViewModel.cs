using IDC.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
namespace IDC.ViewModel
{
    public class StudentReportViewModel : IStudentReportViewModel
    {

        public StudentReportViewModel()
        {
            StudentReportDTO = new StudentReport();
        }
       
        public StudentReport StudentReportDTO
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                StudentReportDTO.SelectedCentreCode = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.CentreName : string.Empty;
            }
            set
            {
                StudentReportDTO.CentreName = value;
            }
        }
        public int ID
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.ID > 0) ? StudentReportDTO.ID : new int();
            }
            set
            {
                StudentReportDTO.ID = value;
            }
        }
        public int StudentId
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentId : new int();
            }
            set
            {
                StudentReportDTO.StudentId = value;
            }
        }

        [Display(Name = "Name English")]
        [Required(ErrorMessage = "Student Name in English Required")]
        public string StudentFullName
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentFullName : string.Empty;
            }
            set
            {
                StudentReportDTO.StudentFullName = value;
            }
        }
        [Display(Name = "Name Hindi")]
        [Required(ErrorMessage = "Student Name in Hindi Required")]
        public string StudentFullNameHindi
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentFullNameHindi : string.Empty;
            }
            set
            {
                StudentReportDTO.StudentFullNameHindi = value;
            }
        }

        [Display(Name = "Student Mobile Number")]
        [Required(ErrorMessage = "Mobile Number Required")]
        public string StudentMobileNumber
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.StudentMobileNumber : string.Empty;
            }
            set
            {
                StudentReportDTO.StudentMobileNumber = value;
            }
        }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Date Of Birth Required")]
        public string DateOfBirth
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.DateOfBirth : string.Empty;
            }
            set
            {
                StudentReportDTO.DateOfBirth = value;
            }
        }
        [Display(Name = "Year Of Registration")]
        [Required(ErrorMessage = "Year Of Registration Required")]
        public string YearOfReg
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.YearOfReg : string.Empty;
            }
            set
            {
                StudentReportDTO.YearOfReg = value;
            }
        }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Course Required")]
        public string Course
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.Course : string.Empty;
            }
            set
            {
                StudentReportDTO.Course = value;
            }
        }
        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Registration Number Required")]
        public string RegNo
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.RegNo : string.Empty;
            }
            set
            {
                StudentReportDTO.RegNo = value;
            }
        }
        [Display(Name = "Address Correspondence")]
        [Required(ErrorMessage = "Address Correspondence Required")]
        public string AddressCorrespondence
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.AddressCorrespondence : string.Empty;
            }
            set
            {
                StudentReportDTO.AddressCorrespondence = value;
            }
        }
        [Display(Name = "Address Permenant")]
        [Required(ErrorMessage = "Address Permenant Required")]
        public string AddressPermenant
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.AddressPermenant : string.Empty;
            }
            set
            {
                StudentReportDTO.AddressPermenant = value;
            }
        }
        [Display(Name = "Blood Group")]
        [Required(ErrorMessage = "Blood Group Required")]
        public string BloodGroup
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.BloodGroup : string.Empty;
            }
            set
            {
                StudentReportDTO.BloodGroup = value;
            }
        }
        [Display(Name = "I-Card View")]
        public string SelectedICardView
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.SelectedICardView: string.Empty;
            }
            set
            {
                StudentReportDTO.SelectedICardView = value;
            }
        }
        [Display(Name = "Barcode")]
        public string Barcode
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.Barcode : string.Empty;
            }
            set
            {
                StudentReportDTO.Barcode = value;
            }
        }
        [Display(Name = "Card Validity")]
        public string CardValidity
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.CardValidity : string.Empty;
            }
            set
            {
                StudentReportDTO.CardValidity = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.IsDeleted : false;
            }
            set
            {
                StudentReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.CreatedBy > 0) ? StudentReportDTO.CreatedBy : new int();
            }
            set
            {
                StudentReportDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentReportDTO != null) ? StudentReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentReportDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.ModifiedBy.HasValue) ? StudentReportDTO.ModifiedBy : new int();
            }
            set
            {
                StudentReportDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.ModifiedDate.HasValue) ? StudentReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.DeletedBy.HasValue) ? StudentReportDTO.DeletedBy : new int();
            }
            set
            {
                StudentReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentReportDTO != null && StudentReportDTO.DeletedDate.HasValue) ? StudentReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentReportDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public bool IsPosted { get; set; }

        public bool IsUnderValidity { get; set; }

        public bool IsShowMessage { get; set; }

        public int ExpiredInDays { get; set; }
    }
}

