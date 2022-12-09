using IDC.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
namespace IDC.ViewModel
{
    public class StudentIdentityCardViewModel : IStudentIdentityCardViewModel
    {

        public StudentIdentityCardViewModel()
        {
            StudentIdentityCardDTO = new StudentIdentityCard();
            ListStudentIdentityCard = new List<StudentIdentityCard>();
        }

        public List<StudentIdentityCard> ListStudentIdentityCard
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListCentreMasterItems
        {
            get
            {
                return new SelectList(ListStudentIdentityCard, "SelectedCentreCode", "CentreName");
            }
        }

        [Display(Name = "Centre Name")]
        [Required(ErrorMessage = "Centre Name in Required")]
        public string SelectedCentreCode
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.SelectedCentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        [Required(ErrorMessage = "Centre Name in Required")]
        public string CentreName
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.CentreName : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.CentreName = value;
            }
        }
        public string SelectedUniversityID
        {
            get;
            set;
        }
        public string SelectedBranchID
        {
            get;
            set;
        }
        public string SelectedSectionDetailID
        {
            get;
            set;
        }
        public string SelectedAcademicYear
        {
            get;
            set;
        }
        public StudentIdentityCard StudentIdentityCardDTO
        {
            get;
            set;
        }
      
    
        public int ID
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.ID > 0) ? StudentIdentityCardDTO.ID : new int();
            }
            set
            {
                StudentIdentityCardDTO.ID = value;
            }
        }
        public int StudentId
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentId : new int();
            }
            set
            {
                StudentIdentityCardDTO.StudentId = value;
            }
        }
       
        [Display(Name = "Name English")]
        [Required(ErrorMessage ="Student Name in English Required")]
        public string StudentFullName
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentFullName : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentFullName = value;
            }
        }
        [Display(Name = "Name Hindi")]
        [Required(ErrorMessage = "Student Name in Hindi Required")]
        public string StudentFullNameHindi
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentFullNameHindi : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentFullNameHindi = value;
            }
        }

        [Display(Name = "Student Mobile Number")]
        [Required(ErrorMessage = "Mobile Number Required")]
        public string StudentMobileNumber
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentMobileNumber : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentMobileNumber = value;
            }
        }
        
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Date Of Birth Required")]
        public string DateOfBirth
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.DateOfBirth : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.DateOfBirth = value;
            }
        }
        [Display(Name = "Year Of Registration")]
        [Required(ErrorMessage = "Year Of Registration Required")]
        public string YearOfReg
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.YearOfReg : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.YearOfReg = value;
            }
        }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Course Required")]
        public string Course
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.Course : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.Course = value;
            }
        }
        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Registration Number Required")]
        public string RegNo
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.RegNo : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.RegNo = value;
            }
        }
        [Display(Name = "Address Correspondence")]
        [Required(ErrorMessage = "Address Correspondence Required")]
        public string AddressCorrespondence
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.AddressCorrespondence : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.AddressCorrespondence = value;
            }
        }
        [Display(Name = "Address Permenant")]
        [Required(ErrorMessage = "Address Permenant Required")]
        public string AddressPermenant
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.AddressPermenant : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.AddressPermenant = value;
            }
        }
        [Display(Name = "Blood Group")]
        public string Bloodgroup
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.Bloodgroup : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.Bloodgroup = value;
            }
        }
        [Display(Name = "Student Signature")]
        [Required(ErrorMessage = "student Signature Required")]
        public string SignImage
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.SignImage : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.SignImage = value;
            }
        }
        [Display(Name = "Student Image")]
        [Required(ErrorMessage = "Student Image Required")]
        public string StudentImage
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentImage : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentImage = value;
            }
        }
        [Display(Name = "Card Validity")]
        [Required(ErrorMessage = "Card Validity Required")]
        public string CardValidity
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.CardValidity : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.CardValidity = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.IsDeleted : false;
            }
            set
            {
                StudentIdentityCardDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.CreatedBy > 0) ? StudentIdentityCardDTO.CreatedBy : new int();
            }
            set
            {
                StudentIdentityCardDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentIdentityCardDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.ModifiedBy.HasValue) ? StudentIdentityCardDTO.ModifiedBy : new int();
            }
            set
            {
                StudentIdentityCardDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.ModifiedDate.HasValue) ? StudentIdentityCardDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentIdentityCardDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.DeletedBy.HasValue) ? StudentIdentityCardDTO.DeletedBy : new int();
            }
            set
            {
                StudentIdentityCardDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentIdentityCardDTO != null && StudentIdentityCardDTO.DeletedDate.HasValue) ? StudentIdentityCardDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentIdentityCardDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }


        #region File Upload

        [Display(Name = "Internet URL")]
        public string Url { get; set; }

        public bool IsUrl { get; set; }

        [Display(Name = "Flickr image")]
        public string Flickr { get; set; }

        public bool IsFlickr { get; set; }

        //[Display(Name = "Local file")]
        //[Required(ErrorMessage = "Please select the photo")]
        public HttpPostedFileBase StudentPhotoFile { get; set; }
        public HttpPostedFileBase StudentSignatureFile { get; set; }
        //  public HttpPostedFileBase StudentThumbFile { get; set; }


        public bool IsFile { get; set; }

        [Range(0, int.MaxValue)]
        public int X { get; set; }

        [Range(0, int.MaxValue)]
        public int Y { get; set; }

        [Range(0, int.MaxValue)]
        public int Width { get; set; }

        [Range(0, int.MaxValue)]
        public int Height { get; set; }

        public byte[] StudentPhoto
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhoto : new byte[1];         //review this       
            }
            set
            {
                StudentIdentityCardDTO.StudentPhoto = value;
            }
        }


        public string StudentPhotoType
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoType : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoType = value;
            }
        }


        public string StudentPhotoFilename
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoFilename : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoFilename = value;
            }
        }

        public string StudentPhotoFileWidth
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoFileWidth : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoFileWidth = value;
            }
        }


        public string StudentPhotoFileHeight
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoFileHeight : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoFileHeight = value;
            }
        }


        public string StudentPhotoFileSize
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentPhotoFileSize : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentPhotoFileSize = value;
            }
        }

        // for Signature
        public byte[] StudentSignature
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignature : new byte[1];         //review this       
            }
            set
            {
                StudentIdentityCardDTO.StudentSignature = value;
            }
        }


        public string StudentSignatureType
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureType : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureType = value;
            }
        }


        public string StudentSignatureFilename
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureFilename : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureFilename = value;
            }
        }

        public string StudentSignatureFileWidth
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureFileWidth : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureFileWidth = value;
            }
        }


        public string StudentSignatureFileHeight
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureFileHeight : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureFileHeight = value;
            }
        }


        public string StudentSignatureFileSize
        {
            get
            {
                return (StudentIdentityCardDTO != null) ? StudentIdentityCardDTO.StudentSignatureFileSize : string.Empty;
            }
            set
            {
                StudentIdentityCardDTO.StudentSignatureFileSize = value;
            }
        }



        #endregion File Upload


        #region Address

        #endregion Address

        public bool IsUnderValidity { get; set; }

        public bool IsShowMessage { get; set; }

        public int ExpiredInDays { get; set; }
    }
}

