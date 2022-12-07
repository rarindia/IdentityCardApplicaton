using IDC.Base.DTO;
using System;
namespace IDC.DTO
{
    public class StudentReportSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string StudentFullName
        {
            get;
            set;
        }
        public int StudentId
        {
            get;set;
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


        public string SearchWord { get; set; }
        public int maxResult { get; set; }

        public string SearchType { get; set; }
        public int SessionID { get; set; }
    }
}
