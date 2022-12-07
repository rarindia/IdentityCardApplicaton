using IDC.Base.DTO;
using System;
namespace IDC.DTO
{
    public class StudentReport : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int StudentId
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get; set;
        }
        public string CentreName
        {
            get; set;
        }
        public string StudentFullName
        {
            get;
            set;
        }
        public string StudentFullNameHindi
        {
            get; set;
        }
        public string DateOfBirth
        {
            get;
            set;
        }
        public string YearOfReg
        {
            get;
            set;
        }
        public string StudentMobileNumber
        {
            get;
            set;
        }

        public string Course
        {
            get;
            set;
        }

        public string RegNo
        {
            get;
            set;
        }
        public string AddressCorrespondence
        {
            get;
            set;
        }
        public string AddressPermenant
        {
            get;
            set;
        }
        public string BloodGroup
        {
            get;
            set;
        }

        public byte[] StudentPhoto
        {
            get;
            set;
        }
        public byte[] StudentSignature
        {
            get;
            set;
        }
        public string SignImage
        {
            get;set;
        }
        public string StudentImage
        {
            get;set;
        }
        public bool ReportType
        {
            get;
            set;
        }

        public byte[] Logo
        {
            get;
            set;
        }
        public string SelectedICardView
        {
            get;set;
        }
        public string Barcode
        {
            get;set;
        }
        public string CardValidity
        {
            get;set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }




    }
}
