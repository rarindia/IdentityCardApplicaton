using IDC.Base.DTO;
using IDC.DataProvider;
using IDC.DTO;
using IDC.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IDC.Business.BusinessAction
{
    public class StudentReportBA : IStudentReportBA
    {
        IStudentReportDataProvider _StudentReportDataProvider;
      //  IStudentReportBR _StudentReportBR;
        private ILogger _logException;
        public StudentReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
          //  _StudentReportBR = new StudentReportBR();
            _StudentReportDataProvider = new StudentReportDataProvider();
        }

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForOrignalBranchwise(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> StudentReportCollection = new BaseEntityCollectionResponse<StudentReport>();
            try
            {
                if (_StudentReportDataProvider != null)
                    StudentReportCollection = _StudentReportDataProvider.GetBySearchForOrignalBranchwise(searchRequest);
                else
                {
                    StudentReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = "Object Null Exception",
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentReportCollection;
        }

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForStudentList(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> StudentReportCollection = new BaseEntityCollectionResponse<StudentReport>();
            try
            {
                if (_StudentReportDataProvider != null)
                    StudentReportCollection = _StudentReportDataProvider.GetBySearchForStudentList(searchRequest);
                else
                {
                    StudentReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = "Object Null Exception",
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentReportCollection;
        }

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForAddress(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> StudentReportCollection = new BaseEntityCollectionResponse<StudentReport>();
            try
            {
                if (_StudentReportDataProvider != null)
                    StudentReportCollection = _StudentReportDataProvider.GetBySearchForAddress(searchRequest);
                else
                {
                    StudentReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = "Object Null Exception",
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentReportCollection;
        }

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForRollListwise(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> StudentReportCollection = new BaseEntityCollectionResponse<StudentReport>();
            try
            {
                if (_StudentReportDataProvider != null)
                    StudentReportCollection = _StudentReportDataProvider.GetBySearchForRollListwise(searchRequest);
                else
                {
                    StudentReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = "Object Null Exception",
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentReportCollection;
        }

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForCategorywise(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> StudentReportCollection = new BaseEntityCollectionResponse<StudentReport>();
            try
            {
                if (_StudentReportDataProvider != null)
                    StudentReportCollection = _StudentReportDataProvider.GetBySearchForCategorywise(searchRequest);
                else
                {
                    StudentReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = "Object Null Exception",
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentReportCollection;
        }

        public IBaseEntityCollectionResponse<StudentReport> GetStudentSearchListForIdentityCard(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> StudentReportCollection = new BaseEntityCollectionResponse<StudentReport>();
            try
            {
                if (_StudentReportDataProvider != null)
                    StudentReportCollection = _StudentReportDataProvider.GetStudentSearchListForIdentityCard(searchRequest);
                else
                {
                    StudentReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = "Object Null Exception",
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentReportCollection;
        }









        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForStudentIdentityCard(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> StudentReportCollection = new BaseEntityCollectionResponse<StudentReport>();
            try
            {
                if (_StudentReportDataProvider != null)
                    StudentReportCollection = _StudentReportDataProvider.GetBySearchForStudentIdentityCard(searchRequest);
                else
                {
                    StudentReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = "Object Null Exception",
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentReportCollection;
        }

      
    }
}
