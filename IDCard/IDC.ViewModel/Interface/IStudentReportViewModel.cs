using IDC.DTO;
using System;

namespace IDC.ViewModel
{
    public interface IStudentReportViewModel
    {
        StudentReport StudentReportDTO { get; set; }
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


        
    }
}

