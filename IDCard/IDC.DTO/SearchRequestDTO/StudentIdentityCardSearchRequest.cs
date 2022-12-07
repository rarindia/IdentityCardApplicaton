using IDC.Base.DTO;
using System;
namespace IDC.DTO
{
    public class StudentIdentityCardSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
     
        public string StudentCode
        {
            get;
            set;
        }
   
        public int RollNumber
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int SectionDetailID
        {
            get;
            set;
        }
        public string AcademicYear
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
    
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
     
        public string SearchBy
        { 
            get; 
            set;
        }
        public string SortDirection
        { 
            get; 
            set;
        }
    }
}
