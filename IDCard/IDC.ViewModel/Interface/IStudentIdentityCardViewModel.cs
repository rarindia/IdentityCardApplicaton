using IDC.DTO;
using System;

namespace IDC.ViewModel
{
    public interface IStudentIdentityCardViewModel
    {
        StudentIdentityCard StudentIdentityCardDTO { get; set; }
        int ID
        {
            get;
            set;
        }
        
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }


        #region File Upload
        byte[] StudentPhoto
        {
            get;
            set;
        }

        string StudentPhotoType
        {
            get;
            set;
        }
        string StudentPhotoFilename
        {
            get;

            set;

        }

        string StudentPhotoFileWidth
        {
            get;

            set;
        }


        string StudentPhotoFileHeight
        {
            get;
            set;
        }


        string StudentPhotoFileSize
        {
            get;
            set;
        }

        // for Signature
        byte[] StudentSignature
        {
            get;
            set;
        }

        string StudentSignatureType
        {
            get;
            set;
        }
        string StudentSignatureFilename
        {
            get;

            set;

        }

        string StudentSignatureFileWidth
        {
            get;

            set;
        }


        string StudentSignatureFileHeight
        {
            get;
            set;
        }


        string StudentSignatureFileSize
        {
            get;
            set;
        }


        #endregion File Upload
    }
}

